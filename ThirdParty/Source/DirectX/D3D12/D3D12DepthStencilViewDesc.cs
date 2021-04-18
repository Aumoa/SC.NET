// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 깊이 스텐실 서술자에 대한 정보를 서술합니다.
    /// </summary>
    public struct D3D12DepthStencilViewDesc
	{
		ValueType valueType;

		/// <summary>
		/// 자원의 형식을 나타냅니다.
		/// </summary>
		public DXGIFormat Format;

		/// <summary>
		/// 자원의 차원을 나타냅니다.
		/// </summary>
		public D3D12DSVDimension ViewDimension;

		/// <summary>
		/// 깊이 스텐실 속성을 나타냅니다.
		/// </summary>
		public D3D12DSVFlags Flags;

		/// <summary>
		/// 1차원 텍스처 깊이 스텐실 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex1DDSV Texture1D
		{
			get => ( D3D12Tex1DDSV )( valueType ??= new D3D12Tex1DDSV() );
			set => valueType = value;
		}

		/// <summary>
		/// 1차원 텍스처 배열 깊이 스텐실에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex1DArrayDSV Texture1DArray
		{
			get => ( D3D12Tex1DArrayDSV )( valueType ??= new D3D12Tex1DArrayDSV() );
			set => valueType = value;
		}

		/// <summary>
		/// 2차원 텍스처 깊이 스텐실에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex2DDSV Texture2D
		{
			get => ( D3D12Tex2DDSV )( valueType ??= new D3D12Tex2DDSV() );
			set => valueType = value;
		}

		/// <summary>
		/// 2차원 텍스처 배열 깊이 스텐실에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex2DArrayDSV Texture2DArray
		{
			get => ( D3D12Tex2DArrayDSV )( valueType ??= new D3D12Tex2DArrayDSV() );
			set => valueType = value;
		}

		/// <summary>
		/// 2차원 멀티샘플 텍스처 깊이 스텐실에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex2DMSDSV Texture2DMS
		{
			get => ( D3D12Tex2DMSDSV )( valueType ??= new D3D12Tex2DMSDSV() );
			set => valueType = value;
		}

		/// <summary>
		/// 2차원 멀티샘플 텍스처 배열 깊이 스텐실에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex2DMSArrayDSV Texture2DMSArray
		{
			get => ( D3D12Tex2DMSArrayDSV )( valueType ??= new D3D12Tex2DMSArrayDSV() );
			set => valueType = value;
		}
	}
}
