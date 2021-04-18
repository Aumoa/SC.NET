// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 정적 샘플러 정보를 서술합니다.
    /// </summary>
    public struct D3D12StaticSamplerDesc
	{
		/// <summary>
		/// 필터 형식을 나타냅니다.
		/// </summary>
		public D3D12Filter Filter;

		/// <summary>
		/// 텍스처 주소 매핑 형식을 나타냅니다.
		/// </summary>
		public D3D12TextureAddressMode AddressU;

		/// <summary>
		/// 텍스처 주소 매핑 형식을 나타냅니다.
		/// </summary>
		public D3D12TextureAddressMode AddressV;

		/// <summary>
		/// 텍스처 주소 매핑 형식을 나타냅니다.
		/// </summary>
		public D3D12TextureAddressMode AddressW;

		/// <summary>
		/// MIP LOD 바이어스 값을 나타냅니다.
		/// </summary>
		public float MipLODBias;

		/// <summary>
		/// 최대 비등방성 필터링 퀄리티를 나타냅니다.
		/// </summary>
		public uint MaxAnisotropy;

		/// <summary>
		/// 필터 형식이 비교 필터일 경우, 비교 함수를 나타냅니다.
		/// </summary>
		public D3D12ComparisonFunc ComparisonFunc;

		/// <summary>
		/// 경계선 색을 나타냅니다.
		/// </summary>
		public D3D12StaticBorderColor BorderColor;

		/// <summary>
		/// 최소 LOD 값을 나타냅니다.
		/// </summary>
		public float MinLOD;

		/// <summary>
		/// 최대 LOD 값을 나타냅니다.
		/// </summary>
		public float MaxLOD;

		/// <summary>
		/// 셰이더 레지스터 번호를 나타냅니다.
		/// </summary>
		public uint ShaderRegister;

		/// <summary>
		/// 레지스터 공간을 나타냅니다.
		/// </summary>
		public uint RegisterSpace;

		/// <summary>
		/// 셰이더 관측 가능성을 나타냅니다.
		/// </summary>
		public D3D12ShaderVisibility ShaderVisibility;

		/// <summary>
		/// <see cref="D3D12SamplerDesc"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="filter"> 필터 형식을 전달합니다. </param>
		/// <param name="addressMode"> 텍스처 주소 매핑 형식을 전달합니다. </param>
		/// <param name="shaderRegister"> 셰이더 레지스터 번호를 전달합니다. </param>
		/// <param name="shaderVisibility"> 셰이더 관측 가능성을 전달합니다. </param>
		public D3D12StaticSamplerDesc( D3D12Filter filter, D3D12TextureAddressMode addressMode, uint shaderRegister, D3D12ShaderVisibility shaderVisibility = D3D12ShaderVisibility.All )
		{
			this.Filter = filter;
			this.AddressU = addressMode;
			this.AddressV = addressMode;
			this.AddressW = addressMode;
			this.MipLODBias = 0.0f;
			this.MaxAnisotropy = 0;
			this.ComparisonFunc = D3D12ComparisonFunc.Always;
			this.BorderColor = D3D12StaticBorderColor.TransparentBlack;
			this.MinLOD = 0;
			this.MaxLOD = float.MaxValue;
			this.ShaderRegister = shaderRegister;
			this.RegisterSpace = 0;
			this.ShaderVisibility = shaderVisibility;
		}
	}
}
