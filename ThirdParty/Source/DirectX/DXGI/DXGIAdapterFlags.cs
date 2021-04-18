// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// 어댑터의 속성을 표현합니다.
    /// </summary>
    public enum DXGIAdapterFlags
	{
		/// <summary>
		/// 아무 속성도 나타내지 않습니다.
		/// </summary>
		None = 0,

		/// <summary>
		/// 원격 어댑터를 표현합니다. 이 속성은 현재 예약된 속성이므로 사용되지 않습니다.
		/// </summary>
		Remote = 1,

		/// <summary>
		/// 소프트웨어 구현 어댑터를 표현합니다.
		/// </summary>
		Software = 2
	}
}
