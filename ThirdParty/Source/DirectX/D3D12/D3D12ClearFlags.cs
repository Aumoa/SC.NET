// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 초기화 플래그를 표현합니다.
    /// </summary>
    [Flags]
	public enum D3D12ClearFlags
	{
		/// <summary>
		/// 깊이 값을 초기화합니다.
		/// </summary>
		Depth = 0x01,

		/// <summary>
		/// 스텐실 값을 초기화합니다.
		/// </summary>
		Stencil = 0x02
	}
}
