// Defines the fat pixel format and some helpers
//
#pragma once

// A pixel is a color + a height + a roughness + a material ID
// From a bunch of pixels we can thus deduce the diffuse, specular, ambient occlusion, height and normal maps
struct	Pixel
{
 	NjFloat4	RGBA;
	float		Height;
	float		Roughness;
	int			MatID;

	Pixel()
	{
		RGBA = NjFloat4::Zero;
		Height = 0.0f;
		Roughness = 0.0f;
		MatID = 0;
	}

	Pixel( const NjFloat4& _RGBA, float _Height=0.0f, float _Roughness=0.0f, int _MatID=0 )
	{
		RGBA = _RGBA;
		Height = _Height;
		Roughness = _Roughness;
		MatID = _MatID;
	}

	// Blends source with current value using provided interpolant
	//	this = this * (1-t) + _Target * t
	void		Blend( const Pixel& _Target, float t )
	{
		float	r = 1.0f - t;

		RGBA = RGBA * r + _Target.RGBA * t;
		Height = Height * r + _Target.Height * t;
		Roughness = Roughness * r + _Target.Roughness * t;
		if ( t > 0.5f )
			MatID = _Target.MatID;
	}
};