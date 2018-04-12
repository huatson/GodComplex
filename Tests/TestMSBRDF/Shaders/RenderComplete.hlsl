#include "Global.hlsl"
#include "Scene.hlsl"

static const float3	LIGHT_COLOR = 1.0;
static const float3	ALBEDO_SPHERE = float3( 0.9, 0.5, 0.1 );	// Nicely saturated yellow
static const float3	ALBEDO_PLANE = float3( 0.9, 0.5, 0.1 );		// Nicely saturated yellow
static const float3	F0 = 1.0;
static const float3	AMBIENT = 0* 0.02 * float3( 0.5, 0.8, 0.9 );

cbuffer CB_Render : register(b2) {
	float	_roughness;
	float	_albedo;
	float	_lightElevation;
};

TextureCube< float3 >	_tex_CubeMap : register( t0 );
Texture2D< float >		_tex_BlueNoise : register( t1 );

Texture2D< float >		_tex_IrradianceComplement : register( t2 );
Texture2D< float >		_tex_IrradianceAverage : register( t3 );

//////////////////////////////////////////////////////////////////////////////
// New multiple-scattering term computed from energy compensation

float3	ComputeLightingSS( float3 _albedo, float _roughness, float3 _F0, float3 _wsNormal, float3 _wsView, float3 _wsLight, float3 _lightColor ) {

	float3	rho = _albedo / PI;

	float3	specular = BRDF_GGX( _wsNormal, _wsView, _wsLight, _roughness, _F0 );
//return specular;
return _lightColor * specular;

	float	LdotN = saturate( dot( _wsLight, _wsNormal ) );
	return (_albedo / PI) * saturate( LdotN ) * _lightColor;
}

float3	ComputeLightingMS( float3 _albedo, float _roughness, float3 _F0, float3 _wsNormal, float3 _wsView, float3 _wsLight, float3 _lightColor ) {

	float3	rho = _albedo / PI;

	float	a = _roughness;

	float	mu_o = saturate( dot( _wsView, _wsNormal ) );
	float	mu_i = saturate( dot( _wsLight, _wsNormal ) );

	float	E_o = 1.0 - _tex_IrradianceComplement.SampleLevel( LinearClamp, float2( mu_o, a ), 0.0 );	// 1 - E_o
	float	E_i = 1.0 - _tex_IrradianceComplement.SampleLevel( LinearClamp, float2( mu_i, a ), 0.0 );	// 1 - E_i
	float	E_avg = _tex_IrradianceAverage.SampleLevel( LinearClamp, float2( a, 0.5 ), 0.0 );			// E_avg

	float3	BRDF_GGX_ms = E_o * E_i / (PI - E_avg);

//return 0.5 * E_i;
//return 0.5 * (PI - E_avg) / PI;
return BRDF_GGX_ms;

	float3	specular = BRDF_GGX_ms;
return 0*_lightColor * specular;

//	float	LdotN = saturate( dot( _wsLight, _wsNormal ) );
//	return (_albedo / PI) * saturate( LdotN ) * _lightColor;
	return 0.0;
}


float3	SampleSky( float3 _wsDirection, float _mipLevel ) {

	float2	scRot;
	sincos( _lightElevation, scRot.x, scRot.y );
	_wsDirection.xz = float2( _wsDirection.x * scRot.y + _wsDirection.y * scRot.x,
							-_wsDirection.x * scRot.x + _wsDirection.y * scRot.y );

return 50;
	return 50.0 * _tex_CubeMap.SampleLevel( LinearWrap, _wsDirection, _mipLevel );
}

float3	PS( VS_IN _In ) : SV_TARGET0 {

	float2	UV = float2( _ScreenSize.x / _ScreenSize.y * (2.0 * _In.__Position.x / _ScreenSize.x - 1.0), 1.0 - 2.0 * _In.__Position.y / _ScreenSize.y );
	float	noise = _tex_BlueNoise[uint2(_In.__Position.xy) & 0x3F];

	float3	csView = normalize( float3( UV, 1 ) );
//	float3	wsAt = normalize( CAMERA_TARGET - CAMERA_POS );
//	float3	wsRight = normalize( cross( wsAt, float3( 0, 0, 1 ) ) );
//	float3	wsUp = cross( wsRight, wsAt );
	float3	wsRight = _Camera2World[0].xyz;
	float3	wsUp = _Camera2World[1].xyz;
	float3	wsAt = _Camera2World[2].xyz;
	float3	wsView = csView.x * wsRight + csView.y * wsUp + csView.z * wsAt;
	float3	wsPosition = _Camera2World[3].xyz;

//return 1-_tex_IrradianceComplement.SampleLevel( LinearClamp, _In.__Position.xy / _ScreenSize.xy, 0.0 );
//return _tex_IrradianceAverage.SampleLevel( LinearClamp, _In.__Position.xy / _ScreenSize.xy, 0.0 ) / PI;

	float3	wsClosestPosition;
	float3	wsNormal;
	float2	hit = RayTraceScene( wsPosition, wsView, wsNormal, wsClosestPosition );

	if ( hit.x > 1e4 )
		return 0.0;	// No hit

	wsPosition += hit.x * wsView;

#if 1
	wsPosition += 1e-2 * wsNormal;	// Offset from surface

	float3	wsTangent, wsBiTangent;
	BuildOrthonormalBasis( wsNormal, wsTangent, wsBiTangent );

	const float	roughness = max( 0.01, _roughness );

	float3	Lo = 0.0;

	const uint	SAMPLES_COUNT = 64;
	[loop]
	for ( uint i=0; i < SAMPLES_COUNT; i++ ) {
		float	X0 = float(i) / SAMPLES_COUNT;
		float	X1 = ReverseBits( i );

		float	phiH = TWOPI * (noise+X0);
		float	sinPhiH, cosPhiH;
		sincos( phiH, sinPhiH, cosPhiH );

//		float	thetaH = atan( -roughness * roughness * log( 1.0 - X1 ) );		// Ward importance sampling
		float	thetaH = atan( -roughness * sqrt( X1 ) / sqrt( 1.0 - X1 ) );	// GGX importance sampling
		float	sinThetaH, cosThetaH;
		sincos( thetaH, sinThetaH, cosThetaH );

		float3	lsHalf = float3(	sinThetaH * sinPhiH,
									cosThetaH,
									sinThetaH * cosPhiH
								);
		float3	wsHalf = lsHalf.x * wsTangent + lsHalf.y * wsBiTangent + lsHalf.z * wsNormal;

 		float3	wsLight = 2.0 * dot( wsView, wsHalf ) * wsHalf - wsView;	// Light is on the other size of the half vector...
		float	LdotN = dot( wsLight, wsNormal );
		if ( LdotN <= 0.0 )
			continue;	// Goes below the surface...

		// Sample lighting
		float3	wsClosestPositionLight;
		float3	wsNormalLight;
		float2	hit2 = RayTraceScene( wsPosition, wsLight, wsNormalLight, wsClosestPositionLight );
		float3	Li = 0.0;
		if ( hit2.x > 1e4 ) {
			// Sample sky
			Li = SampleSky( wsLight, 0.0 );
		} else {
			// Sample scene
			if ( hit2.y == 0 ) {
				// Sphere was hit, assume 0
				Li = 0.0;
			} else {
				// Plane was hit, sample diffuse 
				Li = SampleSky( wsNormalLight, 8 );			// Incoming "diffuse" lighting
//				Li *= ComputeShadow( wsPosition + hit2.x * wsLight, wsLight );			// * plane shadowing <== CAN'T! No clear direction! Should be coming from indirect samples instead of 1 unique diffuse sample. Or use AO but we don't have it...
//				Li *= ComputeSphereAO( wsPosition + hit2.x * wsLight, wsNormalLight );	// * Sphere AO
				Li *= saturate( -dot( wsNormalLight, wsLight ) );						// * cos( theta )
				Li *= ALBEDO_PLANE / PI;												// * diffuse reflectance
			}
		}

		// Apply BRDF
		Lo += Li * BRDF_GGX( wsNormal, wsView, wsLight, roughness, F0 ) * LdotN;
	}

	Lo /= SAMPLES_COUNT;

	float3	color = Lo;

//color = 10;

#else
	// Compute simple lighting
	const float		theta = _lightElevation;
	const float3	wsLight = float3( sin(theta), cos(theta), 0 );

	const float3	albedo = _albedo * ALBEDO;
	const float		roughness = max( 0.01, _roughness );

	float	LdotN = dot( wsLight, wsNormal );
	float	shadow = hit.y != 0 ? ComputeShadow( wsPosition, wsLight ) : 1;

	float3	color = ComputeLightingSS( ALBEDO, roughness, F0, wsNormal, -wsView, wsLight, shadow * LIGHT_COLOR );

	// Add magic?
	if ( roughness > 0 ) {
		float	shadow2 = lerp( 1.0, shadow, saturate( 10.0 * (LdotN-0.2) ) );	// This removes shadowing on back faces
				shadow2 = 1.0 - pow( saturate( 1.0 - shadow2 ), 16.0 );
//				shadow2 *= saturate( 0.2 + 0.8 * dot( light, _normal ) );	// Larger L.N, eating into the backfaces
				shadow2 *= LdotN;

//shadow2 = shadow;

//color *= 0;

		color += ComputeLightingMS( ALBEDO, roughness, F0, wsNormal, -wsView, wsLight, shadow * LIGHT_COLOR );

//diffuseTerm = shadow * LdotN;
	}
#endif

	return AMBIENT + color;
}
