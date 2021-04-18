// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 렌더 타겟 서술자에 대한 정보를 서술합니다.
    /// </summary>
    public struct D3D12RenderTargetViewDesc
	{
		ValueType valueType;

		/// <summary>
		/// 자원의 형식을 나타냅니다.
		/// </summary>
		public DXGIFormat Format;

		/// <summary>
		/// 자원의 차원을 나타냅니다.
		/// </summary>
		public D3D12RTVDimension ViewDimension;

		/// <summary>
		/// 버퍼 렌더 타겟에 대한 정보를 설정하거나 가져옵니다.
		/// </summary>
		public D3D12BufferRTV Buffer
		{
			get => ( D3D12BufferRTV )( valueType ??= new D3D12BufferRTV() );
			set => valueType = value;
		}

		/// <summary>
		/// 1차원 텍스처 렌더 타겟에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex1DRTV Texture1D
		{
			get => ( D3D12Tex1DRTV )( valueType ??= new D3D12Tex1DRTV() );
			set => valueType = value;
		}

		/// <summary>
		/// 1차원 텍스처 배열 렌더 타겟에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex1DArrayRTV Texture1DArray
		{
			get => ( D3D12Tex1DArrayRTV )( valueType ??= new D3D12Tex1DArrayRTV() );
			set => valueType = value;
		}

		/// <summary>
		/// 2차원 텍스처 렌더 타겟에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex2DRTV Texture2D
		{
			get => ( D3D12Tex2DRTV )( valueType ??= new D3D12Tex2DRTV() );
			set => valueType = value;
		}

		/// <summary>
		/// 2차원 텍스처 배열 렌더 타겟에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex2DArrayRTV Texture2DArray
		{
			get => ( D3D12Tex2DArrayRTV )( valueType ??= new D3D12Tex2DArrayRTV() );
			set => valueType = value;
		}

		/// <summary>
		/// 2차원 멀티샘플 텍스처 렌더 타겟에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex2DMSRTV Texture2DMS
		{
			get => ( D3D12Tex2DMSRTV )( valueType ??= new D3D12Tex2DMSRTV() );
			set => valueType = value;
		}

		/// <summary>
		/// 2차원 멀티샘플 텍스처 배열 렌더 타겟에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex2DMSArrayRTV Texture2DMSArray
		{
			get => ( D3D12Tex2DMSArrayRTV )( valueType ??= new D3D12Tex2DMSArrayRTV() );
			set => valueType = value;
		}

		/// <summary>
		/// 3차원 텍스처 렌더 타겟에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex3DRTV Texture3D
		{
			get => ( D3D12Tex3DRTV )( valueType ??= new D3D12Tex3DRTV() );
			set => valueType = value;
		}
	}
}
