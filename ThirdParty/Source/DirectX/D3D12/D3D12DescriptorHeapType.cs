// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 서술자 힙 유형을 표현합니다.
    /// </summary>
    public enum D3D12DescriptorHeapType
	{
		/// <summary>
		/// 상수 버퍼 서술자, 셰이더 자원 서술자, 순서없는 접근 서술자에 대한 힙을 나타냅니다.
		/// </summary>
		CBV_SRV_UAV,

		/// <summary>
		/// 샘플러에 대한 힙을 나타냅니다.
		/// </summary>
		SAPMLER,

		/// <summary>
		/// 렌더 타겟 서술자에 대한 힙을 나타냅니다.
		/// </summary>
		RTV,

		/// <summary>
		/// 깊이 스텐실 서술자에 대한 힙을 나타냅니다.
		/// </summary>
		DSV,
	}
}
