// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 서술자 범위 유형을 표현합니다.
    /// </summary>
    public enum D3D12DescriptorRangeType
	{
		/// <summary>
		/// 셰이더 자원 서술자에 대한 범위를 나타냅니다.
		/// </summary>
		SRV = 0,

		/// <summary>
		/// 순서없는 접근 서술자에 대한 범위를 나타냅니다.
		/// </summary>
		UAV,

		/// <summary>
		/// 상수 버퍼 서술자에 대한 범위를 나타냅니다.
		/// </summary>
		CBV,

		/// <summary>
		/// 샘플러 서술자에 대한 범위를 나타냅니다.
		/// </summary>
		SAMPLER
	}
}
