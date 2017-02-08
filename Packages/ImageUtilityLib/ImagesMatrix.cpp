#include "stdafx.h"
#include "ImagesMatrix.h"

using namespace ImageUtilityLib;
using namespace BaseLib;

ImagesMatrix::ImagesMatrix()
	: m_type( TYPE::GENERIC )
	, m_format( ImageFile::PIXEL_FORMAT::UNKNOWN ) {
}
ImagesMatrix::~ImagesMatrix() {
	ReleasePointers();
}

void	ImagesMatrix::InitTexture2DArray( U32 _width, U32 _height, U32 _arraySize, U32 _mipLevelsCount ) {
	RELEASE_ASSERT( _width > 0 && _height > 0, "Invalid texture size!" );
	RELEASE_ASSERT( _arraySize > 0, "Invalid texture array size!" );
	if ( _mipLevelsCount == 0 )
		_mipLevelsCount = ComputeMipsCount( MAX( _width, _height ) );

	ReleasePointers();

	m_type = ImagesMatrix::TYPE::TEXTURE2D;
	m_mipsArray.SetCount( _arraySize );
	for ( U32 arraySliceIndex=0; arraySliceIndex < _arraySize; arraySliceIndex++ ) {
		Mips&	sliceMips = m_mipsArray[arraySliceIndex];
		sliceMips.Init( _mipLevelsCount );

		U32	W = _width;
		U32	H = _height;
		for ( U32 mipLevelIndex=0; mipLevelIndex < _mipLevelsCount; mipLevelIndex++ ) {
			Mips::Mip&	mip = sliceMips[mipLevelIndex];
			mip.Init( W, H, 1 );	// Each mip in a texture 2D array has only 1 slice
			NextMipSize( W, H );
		}
	}
}
void	ImagesMatrix::InitCubeTextureArray( U32 _cubeMapSize, U32 _cubeMapsCount, U32 _mipLevelsCount ) {
	RELEASE_ASSERT( _cubeMapSize > 0, "Invalid texture size!" );
	RELEASE_ASSERT( _cubeMapsCount > 0, "Invalid amount of cube maps!" );
	if ( _mipLevelsCount == 0 )
		_mipLevelsCount = ComputeMipsCount( _cubeMapSize );

	ReleasePointers();

	U32	cubeFacesCount = 6 * _cubeMapsCount;
	m_type = ImagesMatrix::TYPE::TEXTURECUBE;
	m_mipsArray.SetCount( cubeFacesCount );
	for ( U32 arraySliceIndex=0; arraySliceIndex < cubeFacesCount; arraySliceIndex++ ) {
		Mips&	sliceMips = m_mipsArray[arraySliceIndex];
		sliceMips.Init( _mipLevelsCount );

		U32	S = _cubeMapSize;
		for ( U32 mipLevelIndex=0; mipLevelIndex < _mipLevelsCount; mipLevelIndex++ ) {
			Mips::Mip&	mip = sliceMips[mipLevelIndex];
			mip.Init( S, S, 1 );	// Each mip in a texture 2D array has only 1 slice
			NextMipSize( S );
		}
	}
}

void	ImagesMatrix::InitTexture3D( U32 _width, U32 _height, U32 _depth, U32 _mipLevelsCount ) {
	RELEASE_ASSERT( _width > 0 && _height > 0 && _depth > 0, "Invalid texture size!" );
	if ( _mipLevelsCount == 0 )
		_mipLevelsCount = ComputeMipsCount( MAX( MAX( _width, _height ), _depth ) );

	ReleasePointers();

	m_type = ImagesMatrix::TYPE::TEXTURE3D;
	m_mipsArray.SetCount( 1 );
	Mips&	mips = m_mipsArray[0];
	mips.Init( _mipLevelsCount );

	U32	W = _width;
	U32	H = _height;
	U32	D = _depth;
	for ( U32 mipLevelIndex=0; mipLevelIndex < _mipLevelsCount; mipLevelIndex++ ) {
		Mips::Mip&	mip = mips[mipLevelIndex];
		mip.Init( W, H, D );	// Each mip in a texture 3D has many slices to cover the size of the reduced 3D texture
		NextMipSize( W, H, D );
	}
}

void	ImagesMatrix::InitTextureGeneric( U32 _width, U32 _height, U32 _depth, U32 _arraySize, U32 _mipLevelsCount ) {
	m_type = ImagesMatrix::TYPE::GENERIC;
	m_mipsArray.SetCount( _arraySize );
	for ( U32 arraySliceIndex=0; arraySliceIndex < _arraySize; arraySliceIndex++ ) {
		Mips&	sliceMips = m_mipsArray[arraySliceIndex];
		sliceMips.Init( _mipLevelsCount );

		U32	W = _width;
		U32	H = _height;
		U32	D = _depth;
		for ( U32 mipLevelIndex=0; mipLevelIndex < _mipLevelsCount; mipLevelIndex++ ) {
			Mips::Mip&	mip = sliceMips[mipLevelIndex];
			mip.Init( W, H, D );
			NextMipSize( W, H, D );
		}
	}
}

void	ImagesMatrix::AllocateImageFiles( ImageFile::PIXEL_FORMAT _format, const ColorProfile& _colorProfile ) {
//	ReleasePointers();	// Release first <= NOPE! The user may have already filled some components of the matrix!

	m_format = _format;
	m_colorProfile = _colorProfile;

	for ( U32 i=0; i < m_mipsArray.Count(); i++ ) {
		m_mipsArray[i].AllocateImageFiles( _format, _colorProfile );
	}
}

void	ImagesMatrix::AllocateRawBuffers( const GetRawBufferSizeFunctor& _getRawBufferSizeDelegate ) {
	m_format = ImageFile::PIXEL_FORMAT::UNKNOWN;

	U32	rowPitch, depthPitch;
	for ( U32 sliceIndex=0; sliceIndex < m_mipsArray.Count(); sliceIndex++ ) {
		Mips&	mips = m_mipsArray[sliceIndex];
		for ( U32 mipLevelIndex=0; mipLevelIndex < mips.GetMipLevelsCount(); mipLevelIndex++ ) {
			Mips::Mip&	mip = mips[mipLevelIndex];

			// Ask the raw buffer info for that mip
			const U8*	sourceBuffer = _getRawBufferSizeDelegate( sliceIndex, mipLevelIndex, rowPitch, depthPitch );

			// Actual allocation
			mip.AllocateRawBuffer( rowPitch, depthPitch, sourceBuffer );
		}
	}
}

void	ImagesMatrix::ReleasePointers() {
	for ( U32 i=0; i < m_mipsArray.Count(); i++ ) {
		m_mipsArray[i].ReleasePointers();
	}

	m_format = ImageFile::PIXEL_FORMAT::UNKNOWN;
}
void	ImagesMatrix::ClearPointers() {
	for ( U32 i=0; i < m_mipsArray.Count(); i++ ) {
		m_mipsArray[i].ClearPointers();
	}

	m_format = ImageFile::PIXEL_FORMAT::UNKNOWN;
}


void	ImagesMatrix::Mips::Init( U32 _mipLevelsCount ) {
	m_mips.SetCount( _mipLevelsCount );
}

void	ImagesMatrix::Mips::AllocateImageFiles( ImageFile::PIXEL_FORMAT _format, const ColorProfile& _colorProfile ) {
//	ReleasePointers();	// Release first
	for ( U32 i=0; i < m_mips.Count(); i++ ) {
		m_mips[i].AllocateImageFiles( _format, _colorProfile );
	}
}

void	ImagesMatrix::Mips::ReleasePointers() {
	for ( U32 i=0; i < m_mips.Count(); i++ ) {
		m_mips[i].ReleasePointers();
	}
}
void	ImagesMatrix::Mips::ClearPointers() {
	for ( U32 i=0; i < m_mips.Count(); i++ ) {
		m_mips[i].ClearPointers();
	}
}

void	ImagesMatrix::Mips::Mip::Init( U32 _width, U32 _height, U32 _depth ) {
	m_width = _width;
	m_height = _height;
	m_images.SetCount( _depth );
	memset( m_images.Ptr(), 0, _depth*sizeof(ImageFile*) );
}

void	ImagesMatrix::Mips::Mip::AllocateImageFiles( ImageFile::PIXEL_FORMAT _format, const ColorProfile& _colorProfile ) {
//	ReleasePointers();	// Release first
	for ( U32 i=0; i < m_images.Count(); i++ ) {
		if ( m_images[i] == NULL ) {
			ImageFile*	imageSlice = new ImageFile( m_width, m_height, _format, _colorProfile );
			m_images[i] = imageSlice;
		}
	}
}
void	ImagesMatrix::Mips::Mip::AllocateRawBuffer( U32 _rowPitch, U32 _slicePitch, const U8* _sourceBuffer ) {
	m_rowPitch = _rowPitch;
	m_slicePitch = _slicePitch;

	U32	bufferSize = Depth() * m_slicePitch;
	if ( m_rawBuffer == NULL ) {
		m_rawBuffer = new U8[bufferSize];
	}

	if ( _sourceBuffer != NULL ) {
		memcpy_s( m_rawBuffer, bufferSize, _sourceBuffer, bufferSize );
	}
}

void	ImagesMatrix::Mips::Mip::ReleasePointers() {
	for ( U32 i=0; i < m_images.Count(); i++ ) {
		SAFE_DELETE( m_images[i] );
	}
	SAFE_DELETE_ARRAY( m_rawBuffer );
}
void	ImagesMatrix::Mips::Mip::ClearPointers() {
	for ( U32 i=0; i < m_images.Count(); i++ ) {
		m_images[i] = NULL;
	}
	m_rawBuffer = NULL;
}

void	ImagesMatrix::NextMipSize( U32& _size ) {
//	_size = (1+_size) >> 1;
	_size = MAX( 1U, _size >> 1 );
}
void	ImagesMatrix::NextMipSize( U32& _width, U32& _height ) {
	NextMipSize( _width );
	NextMipSize( _height );
}
void	ImagesMatrix::NextMipSize( U32& _width, U32& _height, U32& _depth ) {
	NextMipSize( _width, _height );
	_depth = (1+_depth) >> 1;
}

// Examples:
//	15 gives us 4 mips at respective sizes 15, 7, 3, 1
//	16 gives us 5 mips at respective sizes 16, 8, 4, 2, 1
U32		ImagesMatrix::ComputeMipsCount( U32 _size ) {
	U32	sizeLog2 = U32( floorf( log2f( _size ) ) );	// Worst case scenario: we want a 2^N-1 size to give us N-1
	return 1 + sizeLog2;							// And we need 1 more mip level to reach level 2^0
}