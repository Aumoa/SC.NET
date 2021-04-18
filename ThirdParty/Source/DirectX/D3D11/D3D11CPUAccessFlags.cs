// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D11 CPU 엑세스 속성을 표현합니다.
    /// </summary>
    [Flags]
	public enum D3D11CPUAccessFlags
	{
		/// <summary>
		/// CPU 엑세스를 허용하지 않습니다.
		/// </summary>
		None = 0,

		/// <summary>
		/// 쓰기 엑세스를 허용합니다.
		/// </summary>
		Write = 0x10000,

		/// <summary>
		/// 읽기 엑세스를 허용합니다.
		/// </summary>
		Read = 0x20000
	}
}
