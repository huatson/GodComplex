﻿namespace AreaLightTest
{
	partial class AreaLightForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if ( disposing && (components != null) )
			{
				components.Dispose();
				m_Device.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.floatTrackbarControlProjectionDiffusion = new Nuaj.Cirrus.Utility.FloatTrackbarControl();
			this.buttonReload = new System.Windows.Forms.Button();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.floatTrackbarControlProjectionTheta = new Nuaj.Cirrus.Utility.FloatTrackbarControl();
			this.label2 = new System.Windows.Forms.Label();
			this.floatTrackbarControlProjectionPhi = new Nuaj.Cirrus.Utility.FloatTrackbarControl();
			this.label3 = new System.Windows.Forms.Label();
			this.floatTrackbarControlGloss = new Nuaj.Cirrus.Utility.FloatTrackbarControl();
			this.label4 = new System.Windows.Forms.Label();
			this.floatTrackbarControlLightIntensity = new Nuaj.Cirrus.Utility.FloatTrackbarControl();
			this.label5 = new System.Windows.Forms.Label();
			this.floatTrackbarControlMetal = new Nuaj.Cirrus.Utility.FloatTrackbarControl();
			this.label6 = new System.Windows.Forms.Label();
			this.floatTrackbarControlLightPosX = new Nuaj.Cirrus.Utility.FloatTrackbarControl();
			this.label7 = new System.Windows.Forms.Label();
			this.floatTrackbarControlLightPosY = new Nuaj.Cirrus.Utility.FloatTrackbarControl();
			this.label8 = new System.Windows.Forms.Label();
			this.floatTrackbarControlLightPosZ = new Nuaj.Cirrus.Utility.FloatTrackbarControl();
			this.label9 = new System.Windows.Forms.Label();
			this.floatTrackbarControlLightTargetX = new Nuaj.Cirrus.Utility.FloatTrackbarControl();
			this.label10 = new System.Windows.Forms.Label();
			this.floatTrackbarControlLightTargetY = new Nuaj.Cirrus.Utility.FloatTrackbarControl();
			this.label11 = new System.Windows.Forms.Label();
			this.floatTrackbarControlLightTargetZ = new Nuaj.Cirrus.Utility.FloatTrackbarControl();
			this.label12 = new System.Windows.Forms.Label();
			this.panelOutput = new AreaLightTest.PanelOutput(this.components);
			this.floatTrackbarControlLightRoll = new Nuaj.Cirrus.Utility.FloatTrackbarControl();
			this.label13 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// floatTrackbarControlProjectionDiffusion
			// 
			this.floatTrackbarControlProjectionDiffusion.Location = new System.Drawing.Point(1180, 12);
			this.floatTrackbarControlProjectionDiffusion.MaximumSize = new System.Drawing.Size(10000, 20);
			this.floatTrackbarControlProjectionDiffusion.MinimumSize = new System.Drawing.Size(70, 20);
			this.floatTrackbarControlProjectionDiffusion.Name = "floatTrackbarControlProjectionDiffusion";
			this.floatTrackbarControlProjectionDiffusion.RangeMax = 1F;
			this.floatTrackbarControlProjectionDiffusion.RangeMin = 0F;
			this.floatTrackbarControlProjectionDiffusion.Size = new System.Drawing.Size(200, 20);
			this.floatTrackbarControlProjectionDiffusion.TabIndex = 1;
			this.floatTrackbarControlProjectionDiffusion.Value = 0F;
			this.floatTrackbarControlProjectionDiffusion.VisibleRangeMax = 1F;
			// 
			// buttonReload
			// 
			this.buttonReload.Location = new System.Drawing.Point(1305, 629);
			this.buttonReload.Name = "buttonReload";
			this.buttonReload.Size = new System.Drawing.Size(75, 23);
			this.buttonReload.TabIndex = 2;
			this.buttonReload.Text = "Reload";
			this.buttonReload.UseVisualStyleBackColor = true;
			this.buttonReload.Click += new System.EventHandler(this.buttonReload_Click);
			// 
			// timer
			// 
			this.timer.Enabled = true;
			this.timer.Interval = 10;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(1059, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Projection Diffusion";
			// 
			// floatTrackbarControlProjectionTheta
			// 
			this.floatTrackbarControlProjectionTheta.Location = new System.Drawing.Point(1180, 38);
			this.floatTrackbarControlProjectionTheta.MaximumSize = new System.Drawing.Size(10000, 20);
			this.floatTrackbarControlProjectionTheta.MinimumSize = new System.Drawing.Size(70, 20);
			this.floatTrackbarControlProjectionTheta.Name = "floatTrackbarControlProjectionTheta";
			this.floatTrackbarControlProjectionTheta.RangeMax = 90F;
			this.floatTrackbarControlProjectionTheta.RangeMin = -90F;
			this.floatTrackbarControlProjectionTheta.Size = new System.Drawing.Size(200, 20);
			this.floatTrackbarControlProjectionTheta.TabIndex = 1;
			this.floatTrackbarControlProjectionTheta.Value = -20F;
			this.floatTrackbarControlProjectionTheta.VisibleRangeMax = 90F;
			this.floatTrackbarControlProjectionTheta.VisibleRangeMin = -90F;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(1059, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Projection Theta";
			// 
			// floatTrackbarControlProjectionPhi
			// 
			this.floatTrackbarControlProjectionPhi.Location = new System.Drawing.Point(1180, 64);
			this.floatTrackbarControlProjectionPhi.MaximumSize = new System.Drawing.Size(10000, 20);
			this.floatTrackbarControlProjectionPhi.MinimumSize = new System.Drawing.Size(70, 20);
			this.floatTrackbarControlProjectionPhi.Name = "floatTrackbarControlProjectionPhi";
			this.floatTrackbarControlProjectionPhi.RangeMax = 180F;
			this.floatTrackbarControlProjectionPhi.RangeMin = -180F;
			this.floatTrackbarControlProjectionPhi.Size = new System.Drawing.Size(200, 20);
			this.floatTrackbarControlProjectionPhi.TabIndex = 1;
			this.floatTrackbarControlProjectionPhi.Value = 0F;
			this.floatTrackbarControlProjectionPhi.VisibleRangeMax = 180F;
			this.floatTrackbarControlProjectionPhi.VisibleRangeMin = -180F;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(1059, 69);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Projection Phi";
			// 
			// floatTrackbarControlGloss
			// 
			this.floatTrackbarControlGloss.Location = new System.Drawing.Point(1180, 147);
			this.floatTrackbarControlGloss.MaximumSize = new System.Drawing.Size(10000, 20);
			this.floatTrackbarControlGloss.MinimumSize = new System.Drawing.Size(70, 20);
			this.floatTrackbarControlGloss.Name = "floatTrackbarControlGloss";
			this.floatTrackbarControlGloss.RangeMax = 1F;
			this.floatTrackbarControlGloss.RangeMin = 0F;
			this.floatTrackbarControlGloss.Size = new System.Drawing.Size(200, 20);
			this.floatTrackbarControlGloss.TabIndex = 1;
			this.floatTrackbarControlGloss.Value = 0F;
			this.floatTrackbarControlGloss.VisibleRangeMax = 1F;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(1059, 154);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(33, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Gloss";
			// 
			// floatTrackbarControlLightIntensity
			// 
			this.floatTrackbarControlLightIntensity.Location = new System.Drawing.Point(1180, 90);
			this.floatTrackbarControlLightIntensity.MaximumSize = new System.Drawing.Size(10000, 20);
			this.floatTrackbarControlLightIntensity.MinimumSize = new System.Drawing.Size(70, 20);
			this.floatTrackbarControlLightIntensity.Name = "floatTrackbarControlLightIntensity";
			this.floatTrackbarControlLightIntensity.RangeMax = 1000F;
			this.floatTrackbarControlLightIntensity.RangeMin = 0F;
			this.floatTrackbarControlLightIntensity.Size = new System.Drawing.Size(200, 20);
			this.floatTrackbarControlLightIntensity.TabIndex = 1;
			this.floatTrackbarControlLightIntensity.Value = 10F;
			this.floatTrackbarControlLightIntensity.VisibleRangeMax = 100F;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(1059, 95);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 13);
			this.label5.TabIndex = 3;
			this.label5.Text = "Light Intensity";
			// 
			// floatTrackbarControlMetal
			// 
			this.floatTrackbarControlMetal.Location = new System.Drawing.Point(1180, 173);
			this.floatTrackbarControlMetal.MaximumSize = new System.Drawing.Size(10000, 20);
			this.floatTrackbarControlMetal.MinimumSize = new System.Drawing.Size(70, 20);
			this.floatTrackbarControlMetal.Name = "floatTrackbarControlMetal";
			this.floatTrackbarControlMetal.RangeMax = 1F;
			this.floatTrackbarControlMetal.RangeMin = 0F;
			this.floatTrackbarControlMetal.Size = new System.Drawing.Size(200, 20);
			this.floatTrackbarControlMetal.TabIndex = 1;
			this.floatTrackbarControlMetal.Value = 0F;
			this.floatTrackbarControlMetal.VisibleRangeMax = 1F;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(1059, 180);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(33, 13);
			this.label6.TabIndex = 3;
			this.label6.Text = "Metal";
			// 
			// floatTrackbarControlLightPosX
			// 
			this.floatTrackbarControlLightPosX.Location = new System.Drawing.Point(1180, 244);
			this.floatTrackbarControlLightPosX.MaximumSize = new System.Drawing.Size(10000, 20);
			this.floatTrackbarControlLightPosX.MinimumSize = new System.Drawing.Size(70, 20);
			this.floatTrackbarControlLightPosX.Name = "floatTrackbarControlLightPosX";
			this.floatTrackbarControlLightPosX.RangeMax = 100F;
			this.floatTrackbarControlLightPosX.RangeMin = -100F;
			this.floatTrackbarControlLightPosX.Size = new System.Drawing.Size(200, 20);
			this.floatTrackbarControlLightPosX.TabIndex = 1;
			this.floatTrackbarControlLightPosX.Value = 0F;
			this.floatTrackbarControlLightPosX.VisibleRangeMax = 2F;
			this.floatTrackbarControlLightPosX.VisibleRangeMin = -2F;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(1059, 251);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(61, 13);
			this.label7.TabIndex = 3;
			this.label7.Text = "Light Pos X";
			// 
			// floatTrackbarControlLightPosY
			// 
			this.floatTrackbarControlLightPosY.Location = new System.Drawing.Point(1180, 270);
			this.floatTrackbarControlLightPosY.MaximumSize = new System.Drawing.Size(10000, 20);
			this.floatTrackbarControlLightPosY.MinimumSize = new System.Drawing.Size(70, 20);
			this.floatTrackbarControlLightPosY.Name = "floatTrackbarControlLightPosY";
			this.floatTrackbarControlLightPosY.RangeMax = 100F;
			this.floatTrackbarControlLightPosY.RangeMin = -100F;
			this.floatTrackbarControlLightPosY.Size = new System.Drawing.Size(200, 20);
			this.floatTrackbarControlLightPosY.TabIndex = 1;
			this.floatTrackbarControlLightPosY.Value = 0F;
			this.floatTrackbarControlLightPosY.VisibleRangeMax = 2F;
			this.floatTrackbarControlLightPosY.VisibleRangeMin = -2F;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(1059, 277);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(61, 13);
			this.label8.TabIndex = 3;
			this.label8.Text = "Light Pos Y";
			// 
			// floatTrackbarControlLightPosZ
			// 
			this.floatTrackbarControlLightPosZ.Location = new System.Drawing.Point(1180, 296);
			this.floatTrackbarControlLightPosZ.MaximumSize = new System.Drawing.Size(10000, 20);
			this.floatTrackbarControlLightPosZ.MinimumSize = new System.Drawing.Size(70, 20);
			this.floatTrackbarControlLightPosZ.Name = "floatTrackbarControlLightPosZ";
			this.floatTrackbarControlLightPosZ.RangeMax = 100F;
			this.floatTrackbarControlLightPosZ.RangeMin = -100F;
			this.floatTrackbarControlLightPosZ.Size = new System.Drawing.Size(200, 20);
			this.floatTrackbarControlLightPosZ.TabIndex = 1;
			this.floatTrackbarControlLightPosZ.Value = 0F;
			this.floatTrackbarControlLightPosZ.VisibleRangeMax = 2F;
			this.floatTrackbarControlLightPosZ.VisibleRangeMin = -2F;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(1059, 303);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(61, 13);
			this.label9.TabIndex = 3;
			this.label9.Text = "Light Pos Z";
			// 
			// floatTrackbarControlLightTargetX
			// 
			this.floatTrackbarControlLightTargetX.Location = new System.Drawing.Point(1180, 346);
			this.floatTrackbarControlLightTargetX.MaximumSize = new System.Drawing.Size(10000, 20);
			this.floatTrackbarControlLightTargetX.MinimumSize = new System.Drawing.Size(70, 20);
			this.floatTrackbarControlLightTargetX.Name = "floatTrackbarControlLightTargetX";
			this.floatTrackbarControlLightTargetX.RangeMax = 100F;
			this.floatTrackbarControlLightTargetX.RangeMin = -100F;
			this.floatTrackbarControlLightTargetX.Size = new System.Drawing.Size(200, 20);
			this.floatTrackbarControlLightTargetX.TabIndex = 1;
			this.floatTrackbarControlLightTargetX.Value = 0F;
			this.floatTrackbarControlLightTargetX.VisibleRangeMin = -10F;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(1059, 353);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(74, 13);
			this.label10.TabIndex = 3;
			this.label10.Text = "Light Target X";
			// 
			// floatTrackbarControlLightTargetY
			// 
			this.floatTrackbarControlLightTargetY.Location = new System.Drawing.Point(1180, 372);
			this.floatTrackbarControlLightTargetY.MaximumSize = new System.Drawing.Size(10000, 20);
			this.floatTrackbarControlLightTargetY.MinimumSize = new System.Drawing.Size(70, 20);
			this.floatTrackbarControlLightTargetY.Name = "floatTrackbarControlLightTargetY";
			this.floatTrackbarControlLightTargetY.RangeMax = 100F;
			this.floatTrackbarControlLightTargetY.RangeMin = -100F;
			this.floatTrackbarControlLightTargetY.Size = new System.Drawing.Size(200, 20);
			this.floatTrackbarControlLightTargetY.TabIndex = 1;
			this.floatTrackbarControlLightTargetY.Value = 0F;
			this.floatTrackbarControlLightTargetY.VisibleRangeMin = -10F;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(1059, 379);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(74, 13);
			this.label11.TabIndex = 3;
			this.label11.Text = "Light Target Y";
			// 
			// floatTrackbarControlLightTargetZ
			// 
			this.floatTrackbarControlLightTargetZ.Location = new System.Drawing.Point(1180, 398);
			this.floatTrackbarControlLightTargetZ.MaximumSize = new System.Drawing.Size(10000, 20);
			this.floatTrackbarControlLightTargetZ.MinimumSize = new System.Drawing.Size(70, 20);
			this.floatTrackbarControlLightTargetZ.Name = "floatTrackbarControlLightTargetZ";
			this.floatTrackbarControlLightTargetZ.RangeMax = 100F;
			this.floatTrackbarControlLightTargetZ.RangeMin = -100F;
			this.floatTrackbarControlLightTargetZ.Size = new System.Drawing.Size(200, 20);
			this.floatTrackbarControlLightTargetZ.TabIndex = 1;
			this.floatTrackbarControlLightTargetZ.Value = 0F;
			this.floatTrackbarControlLightTargetZ.VisibleRangeMin = -10F;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(1059, 405);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(74, 13);
			this.label12.TabIndex = 3;
			this.label12.Text = "Light Target Z";
			// 
			// panelOutput
			// 
			this.panelOutput.Location = new System.Drawing.Point(12, 12);
			this.panelOutput.Name = "panelOutput";
			this.panelOutput.Size = new System.Drawing.Size(1024, 640);
			this.panelOutput.TabIndex = 0;
			// 
			// floatTrackbarControlLightRoll
			// 
			this.floatTrackbarControlLightRoll.Location = new System.Drawing.Point(1180, 435);
			this.floatTrackbarControlLightRoll.MaximumSize = new System.Drawing.Size(10000, 20);
			this.floatTrackbarControlLightRoll.MinimumSize = new System.Drawing.Size(70, 20);
			this.floatTrackbarControlLightRoll.Name = "floatTrackbarControlLightRoll";
			this.floatTrackbarControlLightRoll.RangeMax = 180F;
			this.floatTrackbarControlLightRoll.RangeMin = -180F;
			this.floatTrackbarControlLightRoll.Size = new System.Drawing.Size(200, 20);
			this.floatTrackbarControlLightRoll.TabIndex = 1;
			this.floatTrackbarControlLightRoll.Value = 0F;
			this.floatTrackbarControlLightRoll.VisibleRangeMax = 180F;
			this.floatTrackbarControlLightRoll.VisibleRangeMin = -180F;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(1059, 442);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(51, 13);
			this.label13.TabIndex = 3;
			this.label13.Text = "Light Roll";
			// 
			// AreaLightForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1392, 665);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonReload);
			this.Controls.Add(this.floatTrackbarControlMetal);
			this.Controls.Add(this.floatTrackbarControlLightPosZ);
			this.Controls.Add(this.floatTrackbarControlLightPosY);
			this.Controls.Add(this.floatTrackbarControlLightRoll);
			this.Controls.Add(this.floatTrackbarControlLightTargetZ);
			this.Controls.Add(this.floatTrackbarControlLightTargetY);
			this.Controls.Add(this.floatTrackbarControlLightTargetX);
			this.Controls.Add(this.floatTrackbarControlLightPosX);
			this.Controls.Add(this.floatTrackbarControlGloss);
			this.Controls.Add(this.floatTrackbarControlLightIntensity);
			this.Controls.Add(this.floatTrackbarControlProjectionPhi);
			this.Controls.Add(this.floatTrackbarControlProjectionTheta);
			this.Controls.Add(this.floatTrackbarControlProjectionDiffusion);
			this.Controls.Add(this.panelOutput);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "AreaLightForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Area Light Test";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private PanelOutput panelOutput;
		private Nuaj.Cirrus.Utility.FloatTrackbarControl floatTrackbarControlProjectionDiffusion;
		private System.Windows.Forms.Button buttonReload;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.Label label1;
		private Nuaj.Cirrus.Utility.FloatTrackbarControl floatTrackbarControlProjectionTheta;
		private System.Windows.Forms.Label label2;
		private Nuaj.Cirrus.Utility.FloatTrackbarControl floatTrackbarControlProjectionPhi;
		private System.Windows.Forms.Label label3;
		private Nuaj.Cirrus.Utility.FloatTrackbarControl floatTrackbarControlGloss;
		private System.Windows.Forms.Label label4;
		private Nuaj.Cirrus.Utility.FloatTrackbarControl floatTrackbarControlLightIntensity;
		private System.Windows.Forms.Label label5;
		private Nuaj.Cirrus.Utility.FloatTrackbarControl floatTrackbarControlMetal;
		private System.Windows.Forms.Label label6;
		private Nuaj.Cirrus.Utility.FloatTrackbarControl floatTrackbarControlLightPosX;
		private System.Windows.Forms.Label label7;
		private Nuaj.Cirrus.Utility.FloatTrackbarControl floatTrackbarControlLightPosY;
		private System.Windows.Forms.Label label8;
		private Nuaj.Cirrus.Utility.FloatTrackbarControl floatTrackbarControlLightPosZ;
		private System.Windows.Forms.Label label9;
		private Nuaj.Cirrus.Utility.FloatTrackbarControl floatTrackbarControlLightTargetX;
		private System.Windows.Forms.Label label10;
		private Nuaj.Cirrus.Utility.FloatTrackbarControl floatTrackbarControlLightTargetY;
		private System.Windows.Forms.Label label11;
		private Nuaj.Cirrus.Utility.FloatTrackbarControl floatTrackbarControlLightTargetZ;
		private System.Windows.Forms.Label label12;
		private Nuaj.Cirrus.Utility.FloatTrackbarControl floatTrackbarControlLightRoll;
		private System.Windows.Forms.Label label13;
	}
}
