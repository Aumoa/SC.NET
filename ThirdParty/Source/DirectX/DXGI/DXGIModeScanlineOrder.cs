// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 화면의 스캔라인 방식을 표현합니다.
    /// </summary>
    public enum DXGIModeScanlineOrder
	{
		/// <summary>
		/// 방식을 지정하지 않습니다.
		/// </summary>
		Unspecified = 0,

		/// <summary>
		/// 건너뛰지 않고 순차적 스캔을 수행하도록 합니다.
		/// </summary>
		Progressive = 1,

		/// <summary>
		/// 위쪽 영역 스캔을 우선하도록 합니다.
		/// </summary>
		UpperFieldFirst = 2,

		/// <summary>
		/// 아래쪽 영역 스캔을 우선하도록 합니다.
		/// </summary>
		LowerFieldFirst = 3
	}
}
