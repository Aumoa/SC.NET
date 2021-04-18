// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 셰이더 자원 서술자에 대한 정보를 서술합니다.
    /// </summary>
    public struct D3D12ShaderResourceViewDesc
	{
		ValueType valueType;

		/// <summary>
		/// 셰이더 자원의 형식을 나타냅니다.
		/// </summary>
		public DXGIFormat Format;

		/// <summary>
		/// 셰이더 자원의 서술 차원을 나타냅니다.
		/// </summary>
		public D3D12SRVDimension ViewDimension;

		/// <summary>
		/// 셰이더 컴포넌트 매핑 방식을 나타냅니다.
		/// </summary>
		public D3D12ShaderComponentMapping Shader4ComponentMapping;

		/// <summary>
		/// 버퍼 셰이더 자원에 대한 정보를 설정하거나 가져옵니다.
		/// </summary>
		public D3D12BufferSRV Buffer
		{
			get => ( D3D12BufferSRV )( valueType ??= new D3D12BufferSRV() );
			set => valueType = value;
		}

		/// <summary>
		/// 1차원 텍스처 셰이더 자원에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex1DSRV Texture1D
		{
			get => ( D3D12Tex1DSRV )( valueType ??= new D3D12Tex1DSRV() );
			set => valueType = value;
		}

		/// <summary>
		/// 1차원 텍스처 배열 셰이더 자원에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex1DArraySRV Texture1DArray
		{
			get => ( D3D12Tex1DArraySRV )( valueType ??= new D3D12Tex1DArraySRV() );
			set => valueType = value;
		}

		/// <summary>
		/// 2차원 텍스처 셰이더 자원에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex2DSRV Texture2D
		{
			get => ( D3D12Tex2DSRV )( valueType ??= new D3D12Tex2DSRV() );
			set => valueType = value;
		}

		/// <summary>
		/// 2차원 텍스처 배열 셰이더 자원에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex2DArraySRV Texture2DArray
		{
			get => ( D3D12Tex2DArraySRV )( valueType ??= new D3D12Tex2DArraySRV() );
			set => valueType = value;
		}

		/// <summary>
		/// 2차원 멀티샘플 텍스처 셰이더 자원에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex2DMSSRV Texture2DMS
		{
			get => ( D3D12Tex2DMSSRV )( valueType ??= new D3D12Tex2DMSSRV() );
			set => valueType = value;
		}

		/// <summary>
		/// 2차원 멀티샘플 텍스처 배열 셰이더 자원에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex2DMSArraySRV Texture2DMSArray
		{
			get => ( D3D12Tex2DMSArraySRV )( valueType ??= new D3D12Tex2DMSArraySRV() );
			set => valueType = value;
		}

		/// <summary>
		/// 3차원 텍스처 셰이더 자원에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12Tex3DSRV Texture3D
		{
			get => ( D3D12Tex3DSRV )( valueType ??= new D3D12Tex3DSRV() );
			set => valueType = value;
		}

		/// <summary>
		/// 텍스처 큐브 셰이더 자원에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12TexCubeSRV TextureCube
		{
			get => ( D3D12TexCubeSRV )( valueType ??= new D3D12TexCubeSRV() );
			set => valueType = value;
		}

		/// <summary>
		/// 텍스처 큐브 배열 셰이더 자원에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12TexCubeArraySRV TextureCubeArray
		{
			get => ( D3D12TexCubeArraySRV )( valueType ??= new D3D12TexCubeArraySRV() );
			set => valueType = value;
		}

		/// <summary>
		/// 레이트레이싱 가속화 구조체 셰이더 자원에 대한 정보를 가져옵니다.
		/// </summary>
		public D3D12RaytracingAccelerationStructureSRV RaytracingAccelerationStructure
		{
			get => ( D3D12RaytracingAccelerationStructureSRV )( valueType ??= new D3D12RaytracingAccelerationStructureSRV() );
			set => valueType = value;
		}
	}
}
