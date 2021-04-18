// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 자원 장벽 속성을 나타냅니다.
    /// </summary>
    public enum D3D12ResourceBarrierFlags
	{
		/// <summary>
		/// 아무 속성도 나타내지 않습니다.
		/// </summary>
		None = 0,

		/// <summary>
		/// 장벽 시작만을 나타냅니다.
		/// </summary>
		BeginOnly = 0x1,

		/// <summary>
		/// 장벽 종료만을 나타냅니다.
		/// </summary>
		EndOnly = 0x2
	}
}
