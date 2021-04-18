// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 순서없는 접근 서술자에 대한 정보를 서술합니다.
    /// </summary>
    public struct D3D12UnorderedAccessViewDesc
	{
		ValueType valueType;

		/// <summary>
		/// 순서없는 접근의 형식을 나타냅니다.
		/// </summary>
		public DXGIFormat Format;

		/// <summary>
		/// 순서없는 접근 서술 차원을 나타냅니다.
		/// </summary>
		public D3D12UAVDimension ViewDimension;

		/// <summary>
		/// 버퍼 순서없는 접근에 대한 정보를 설정하거나 가져옵니다.
		/// </summary>
		public D3D12BufferUAV Buffer
		{
			get => ( D3D12BufferUAV )( valueType ??= new D3D12BufferUAV() );
			set => valueType = value;
		}

		/// <summary>
		/// 1차원 텍스처 순서없는 접근에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex1DUAV Texture1D
		{
			get => ( D3D12Tex1DUAV )( valueType ??= new D3D12Tex1DUAV() );
			set => valueType = value;
		}

		/// <summary>
		/// 1차원 텍스처 배열 순서없는 접근에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex1DArrayUAV Texture1DArray
		{
			get => ( D3D12Tex1DArrayUAV )( valueType ??= new D3D12Tex1DArrayUAV() );
			set => valueType = value;
		}

		/// <summary>
		/// 2차원 텍스처 순서없는 접근에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex2DUAV Texture2D
		{
			get => ( D3D12Tex2DUAV )( valueType ??= new D3D12Tex2DUAV() );
			set => valueType = value;
		}

		/// <summary>
		/// 2차원 텍스처 배열 순서없는 접근에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex2DArrayUAV Texture2DArray
		{
			get => ( D3D12Tex2DArrayUAV )( valueType ??= new D3D12Tex2DArrayUAV() );
			set => valueType = value;
		}

		/// <summary>
		/// 3차원 텍스처 순서없는 접근에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex3DUAV Texture3D
		{
			get => ( D3D12Tex3DUAV )( valueType ??= new D3D12Tex3DUAV() );
			set => valueType = value;
		}
	}
}
