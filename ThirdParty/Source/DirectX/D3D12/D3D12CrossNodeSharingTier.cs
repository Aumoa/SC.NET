// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 크로스 장치 노드의 공유 티어를 표현합니다.
    /// </summary>
    public enum D3D12CrossNodeSharingTier
	{
		/// <summary>
		/// 지원하지 않습니다.
		/// </summary>
		NotSupported = 0,

		/// <summary>
		/// 에뮬레이트 된 1티어를 나타냅니다.
		/// </summary>
		Tier1Emulated = 1,

		/// <summary>
		/// 1티어를 나타냅니다.
		/// </summary>
		Tier1 = 2,

		/// <summary>
		/// 2티어를 나타냅니다.
		/// </summary>
		Tier2 = 3,

		/// <summary>
		/// 3티어를 나타냅니다.
		/// </summary>
		Tier3 = 4
	}
}
