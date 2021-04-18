// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 출력 디스플레이 모드를 열거하는데 사용되는 속성들입니다.
    /// </summary>
    [Flags]
	public enum DXGIEnumModeFlags
	{
		/// <summary>
		/// 아무 속성을 지정하지 않습니다.
		/// </summary>
		None = 0,

		/// <summary>
		/// 인터레이스 모드를 나타냅니다.
		/// </summary>
		Interlaced = 1,

		/// <summary>
		/// 늘림 비례 모드를 나타냅니다.
		/// </summary>
		Scaling = 2,

		/// <summary>
		/// 스테레오 모드를 나타냅니다.
		/// </summary>
		Stereo = 4,

		/// <summary>
		/// 사용자에 의해 스테레오가 비활성화된 모드를 포함합니다.
		/// </summary>
		DisabledStereo = 8
	}
}
