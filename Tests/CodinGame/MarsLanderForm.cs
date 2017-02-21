﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SharpMath;
using ImageUtility;

namespace TestForm
{
	public partial class MarsLanderForm : Form {

const int	TIMER = 250;

		#region NESTED TYPES

		class Writer : StringWriter {
			public MarsLanderForm	m_owner;
			public override void WriteLine( string value ) {
System.Diagnostics.Debug.WriteLine( value );
				m_owner.React( value );
			}
		}
		class Reader : TextReader {
			public List< string >	m_lines = new List< string >();
			public override string ReadLine() {
				string	top = m_lines[0];
				m_lines.RemoveAt( 0 );
				return top;
			}
		}

		#endregion

		#region FIELDS

		Writer			m_writer = new Writer();
		Reader			m_reader = new Reader();

		float2			m_landscapeMin = float.MaxValue * float2.One;
		float2			m_landscapeMax = -float.MaxValue * float2.One;
		List< float2 >	m_landscape = new List< float2 >();

		float2			Pos;
		float2			Vel;
		int				Fuel;
		int				Rotation, Thrust;

		List< float2 >	m_pastPositions = new List< float2 >();

		#endregion

		public MarsLanderForm( string _initialLines ) {
			InitializeComponent();

			m_writer.m_owner = this;
			Console.SetIn( m_reader );
			Console.SetOut( m_writer );

			string[]	initialLines = _initialLines.Split( '\n' );
			for ( int i=0; i < initialLines.Length; i++ )
				m_reader.m_lines.Add( initialLines[i] );

			int			landscapePointsCount = int.Parse( initialLines[0] );
			for ( int i=0; i < landscapePointsCount; i++ ) {
				string[]	coords = initialLines[1+i].Split( ' ' );
				float2		P = new float2( float.Parse( coords[0] ), float.Parse( coords[1] ) );
				m_landscape.Add( P );
				m_landscapeMin.Min( P );
				m_landscapeMax.Max( P );
			}

			string[]	initialValues = initialLines[1+landscapePointsCount].Split( ' ' );
			Pos = new float2( int.Parse( initialValues[0] ), int.Parse( initialValues[1] ) );
			Vel = new float2( int.Parse( initialValues[2] ), int.Parse( initialValues[3] ) );
			Fuel = int.Parse( initialValues[4] );
			Rotation = int.Parse( initialValues[5] );
			Thrust = int.Parse( initialValues[6] );

			m_pastPositions.Add( Pos );
		}

		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );
			Application.Idle += Application_Idle;
		}

		bool	m_started = false;
		void Application_Idle( object sender, EventArgs e ) {
			if ( !m_started ) {
				//////////////////////////////////////////////////////////////////////////
				// Execute solution
				Solution.Meuh( null );
				m_started = true;
			}
		}

		void	React( string _userCommands ) {
			string[]	userCommands = _userCommands.Split( ' ' );
			int			newRotation = int.Parse( userCommands[0] );
			if ( newRotation < -90 || newRotation > 90 ) throw new Exception( "Too large rotation!" );
			if ( Math.Abs( newRotation - Rotation ) > 15 ) throw new Exception( "Too large rotation delta!" );
			int			newThrust = int.Parse( userCommands[1] );
			if ( newThrust < 0 || newThrust > 4 ) throw new Exception( "Too large thrust!" );
			if ( Math.Abs( newThrust - Thrust ) > 1 ) throw new Exception( "Too large thrust delta!" );

			Rotation = newRotation;
			Thrust = newThrust;
			Fuel--;

			float2	oldPos = Pos;

			float2	Acc = Thrust * new float2( (float) Math.Sin( Rotation * Math.PI / 180 ), (float) Math.Cos( Rotation * Math.PI / 180 ) );
			Acc.y -= 3.711f;
			Vel += Acc;
			Pos += Vel;

			m_pastPositions.Add( Pos );

			panelOutput.UpdateBitmap();
			panelOutput.Refresh();
//			Application.DoEvents();

			CheckCrash( oldPos );

			string	newLine = ((int) Pos.x) + " " + ((int) Pos.y) + " " + ((int) Vel.x) + " " + ((int) Vel.y) + " " + Fuel + " " + Rotation + " " + Thrust;
			m_reader.m_lines.Add( newLine );


			System.Threading.Thread.Sleep( TIMER );
		}

		void	CheckCrash( float2 _oldPos ) {
			for ( int i=0; i < m_landscape.Count-1; i++ ) {
				float2	P0 = m_landscape[i];
				float2	P1 = m_landscape[i+1];
				float2	D = (P1 - P0).Normalized;
				float2	N = new float2( -D.y, D.x );

				float2	Dir = Pos - _oldPos;
				float	dirLength = Dir.Length;
						Dir *= dirLength != 0.0f ? 1.0f / dirLength : 0.0f;
				float	hitDistance = (P0 - Pos).Dot( N ) / Dir.Dot( N );
				if ( hitDistance < 0.0f || hitDistance > dirLength )
					continue;	// Outside our ship's trajectory

				float2	HitPos = Pos + hitDistance * Dir;
//				float	dot = (HitPos - P0).Dot( N );	// Must be 0!
				if ( HitPos.x < P0.x || HitPos.x > P1.x )
					continue;	// Outside of landscape segment

				if ( Math.Abs( Vel.y ) >= 40.0f )
					throw new Exception( "Crash!" );
				else
					MessageBox.Show( "SUCCESS!" );
			}
		}

		private void panelOutput_OnUpdateBitmap( Graphics _G ) {
			int	W = panelOutput.Width;
			int	H = panelOutput.Height;

			_G.FillRectangle( Brushes.White, 0, 0, W, H );

			// Draw landscape
			for ( int i=0; i < m_landscape.Count-1; i++ ) {
				float2	P0 = Landscape2Client( m_landscape[i] );
				float2	P1 = Landscape2Client( m_landscape[i+1] );
				_G.DrawLine( Pens.Black, P0.x, P0.y, P1.x, P1.y );
			}

			// Draw trajectory
			for ( int i=0; i < m_pastPositions.Count-1; i++ ) {
				float2	P0 = Landscape2Client( m_pastPositions[i] );
				float2	P1 = Landscape2Client( m_pastPositions[i+1] );
				_G.DrawLine( Pens.Red, P0.x, P0.y, P1.x, P1.y );
			}

			// Draw target
			float2	targetPos = Landscape2Client( new float2( Solution.m_targetX, Solution.m_targetY ) );
			_G.DrawLine( Pens.Black, targetPos.x - 10, targetPos.y, targetPos.x + 10, targetPos.y );
			_G.DrawLine( Pens.Black, targetPos.x, targetPos.y - 10, targetPos.x, targetPos.y + 10 );

			// Draw information
			float2	Acc = Thrust * new float2( (float) Math.Sin( Rotation * Math.PI / 180 ), (float) Math.Cos( Rotation * Math.PI / 180 ) );
					Acc.y -= 3.711f;

			_G.DrawString( "A = (" + Acc.x.ToString( "G4" ) + ", " + Acc.y.ToString( "G4" ) + ")", Font, Brushes.Black, 0, 0 );
			_G.DrawString( "V = (" + Vel.x.ToString( "G4" ) + ", " + Vel.y.ToString( "G4" ) + ")", Font, Brushes.Black, 0, 16 );
			_G.DrawString( "Fuel = " + Fuel + " Thrust = " + Thrust, Font, Brushes.Black, 0, 32 );
		}

		float2	Landscape2Client( float2 P ) {
			float	maxY = 2.0f * m_landscapeMax.y;
			return new float2(	panelOutput.Width  * (P.x - m_landscapeMin.x) / (m_landscapeMax.x - m_landscapeMin.x),
								panelOutput.Height * (P.y - maxY) / (m_landscapeMin.x - maxY) );
		}
	}
}
