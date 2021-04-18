// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 추가 기능에 대한 기능 단계를 점검합니다.
    /// </summary>
    public struct D3D12FeatureDataD3D12Options
	{
		/// <summary>
		/// 셰이더에서 배정밀도 부동 소수점 값을 사용할 수 있습니다.
		/// </summary>
		public bool DoublePrecisionFloatShaderOps;

		/// <summary>
		/// 출력 병합기에서 논리 연산을 사용할 수 있습니다.
		/// </summary>
		public bool OutputMergerLogicOp;

		/// <summary>
		/// 
		/// </summary>
		public D3D12ShaderMinPrecisionSupport MinPrecisionSupport;

		/// <summary>
		/// 지원되는 타일 리소스 티어 정보를 나타냅니다.
		/// </summary>
		public D3D12TiledResourceTier TiledResourceTier;

		/// <summary>
		/// 리소스 바인딩 티어 정보를 나타냅니다.
		/// </summary>
		public D3D12ResourceBindingTier ResourceBindingTier;

		/// <summary>
		/// 
		/// </summary>
		public bool PSSpecifiedStencilRefSupported;

		/// <summary>
		/// 
		/// </summary>
		public bool TypedUAVLoadAdditionalFormats;
		
		/// <summary>
		/// 
		/// </summary>
		public bool ROVsSupported;

		/// <summary>
		/// 
		/// </summary>
		public D3D12ConservativeRasterizationTier ConservativeRasterizationTier;

		/// <summary>
		/// 리소스당 GPU 가상 주소의 최대 비트 수를 나타냅니다.
		/// </summary>
		public uint MaxGPUVirtualAddressBitsPerResource;

		/// <summary>
		/// 
		/// </summary>
		public bool StandardSwizzle64KBSupported;

		/// <summary>
		/// 크로스 장치 노드 공유 티어를 나타냅니다.
		/// </summary>
		public D3D12CrossNodeSharingTier CrossNodeSharingTier;

		/// <summary>
		/// 크로스 어댑터에서 열 우선 텍스처를 지원하는지 여부를 나타냅니다.
		/// </summary>
		public bool CrossAdapterRowMajorTextureSupported;

		/// <summary>
		/// 
		/// </summary>
		public bool VPAndRTArrayIndexFromAnyShaderFeedingRasterizerSupportedWithoutGSEmulation;

		/// <summary>
		/// 리소스 힙의 티어를 나타냅니다.
		/// </summary>
		public D3D12ResourceHeapTier ResourceHeapTier;
	}
}
