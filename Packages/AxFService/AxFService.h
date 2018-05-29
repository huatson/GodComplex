// AxFService.h
#pragma once

using namespace System;

namespace AxFService {

	public ref class AxFFile {
	public:

		ref class	Material {
		public:

			enum class	TYPE {
				SVBRDF,
				BTF,		// Factorized Bidirectional Texture Function
				CARPAINT,
			};

			enum class	SVBRDF_DIFFUSE_TYPE {
				LAMBERT,
				OREN_NAYAR,
//				DISNEY,
			};

			enum class	SVBRDF_SPECULAR_TYPE {
				WARD,
				BLINN_PHONG,
				COOK_TORRANCE,
				GGX,
				PHONG,
			};

		private:

			AxFFile^	m_owner;
			::axf::decoding::AXF_MATERIAL_HANDLE		m_hMaterial;
			::axf::decoding::AXF_REPRESENTATION_HANDLE	m_hMaterialRepresentation;
			String^		m_name;

			TYPE					m_type;
			SVBRDF_DIFFUSE_TYPE		m_diffuseType;
			SVBRDF_SPECULAR_TYPE	m_specularType;

		public:

			property String^				Name { String^ get() { return m_name; } }
			property TYPE					Type { TYPE get() { return m_type; } }
			property SVBRDF_DIFFUSE_TYPE	DiffuseType { SVBRDF_DIFFUSE_TYPE get() { return m_diffuseType; } }
			property SVBRDF_SPECULAR_TYPE	SpecularType { SVBRDF_SPECULAR_TYPE get() { return m_specularType; } }

		public:
			Material( AxFFile^ _owner, UInt32 _materialIndex );
		};
		
	private:

		::axf::decoding::AXF_FILE_HANDLE	m_hFile;	// Opened file handle

	public:

		property UInt32		MaterialsCount { UInt32	get(); }
		property Material^	default[UInt32] { Material^ get( UInt32 ); }

	public:

		AxFFile( System::IO::FileInfo^ _fileName );
		~AxFFile();

	};
}
