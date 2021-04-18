// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 비례 방식을 지정합니다.
    /// </summary>
    public enum DXGIScaling
	{
		/// <summary>
		/// 화면의 크기에 맞춰 늘어나도록 지정합니다.
		/// </summary>
		Stretch = 0,

		/// <summary>
		/// 크기 비례 방식을 지정하지 않습니다.
		/// </summary>
		None = 1,

		/// <summary>
		/// 화면의 종횡비에 맞춰 늘어나도록 지정합니다.
		/// </summary>
		AspectRatioStretch = 2
	}
}
