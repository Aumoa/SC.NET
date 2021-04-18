// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 모드의 크기 비례 방식을 표현합니다.
    /// </summary>
    public enum DXGIModeScaling
	{
		/// <summary>
		/// 크기 비례 방식을 지정하지 않습니다.
		/// </summary>
		Unspecified = 0,

		/// <summary>
		/// 화면의 중앙에 위치하도록 지정합니다.
		/// </summary>
		Centered = 1,

		/// <summary>
		/// 화면의 크기에 맞춰 늘어나도록 지정합니다.
		/// </summary>
		Stretched = 2
	}
}
