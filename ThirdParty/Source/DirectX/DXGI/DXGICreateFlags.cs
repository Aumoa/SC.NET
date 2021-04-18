// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 팩토리 개체 생성 플래그를 표현합니다.
    /// </summary>
    [Flags]
	public enum DXGICreateFlags
	{
		/// <summary>
		/// 아무 플래그를 설정하지 않습니다.
		/// </summary>
		None = 0,

		/// <summary>
		/// 팩토리 개체를 디버그 모드로 생성합니다.
		/// </summary>
		Debug = 0x01
	}
}
