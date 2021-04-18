// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 자원 장벽 유형을 나타냅니다.
    /// </summary>
    public enum D3D12ResourceBarrierType
	{
		/// <summary>
		/// 자원 상태 전이 장벽 유형을 나타냅니다.
		/// </summary>
		Transition = 0,

		/// <summary>
		/// 자원 앨리어싱 장벽 유형을 나타냅니다.
		/// </summary>
		Aliasing = 1,

		/// <summary>
		/// 순서없는 접근 장벽 유형을 나타냅니다.
		/// </summary>
		UAV = 2
	}
}
