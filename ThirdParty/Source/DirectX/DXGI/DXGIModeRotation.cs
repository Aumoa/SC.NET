// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 화면 회전을 표현합니다.
    /// </summary>
    public enum DXGIModeRotation
	{
		/// <summary>
		/// 지정되지 않은 회전 방식을 표현합니다.
		/// </summary>
		Unspecified = 0,

		/// <summary>
		/// 회전 없음을 나타냅니다.
		/// </summary>
		Identity = 1,

		/// <summary>
		/// 90도 회전을 나타냅니다.
		/// </summary>
		Rotate90 = 2,

		/// <summary>
		/// 180도 회전을 나타냅니다.
		/// </summary>
		Rotate180 = 3,

		/// <summary>
		/// 270도 회전을 나타냅니다.
		/// </summary>
		Rotate270 = 4,
	}
}
