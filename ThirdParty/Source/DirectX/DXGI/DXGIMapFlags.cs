// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 표면 데이터 매핑 속성을 나타냅니다.
    /// </summary>
    [Flags]
	public enum DXGIMapFlags
	{
		/// <summary>
		/// 데이터를 읽기 상태로 매핑합니다.
		/// </summary>
		Read = 1,

		/// <summary>
		/// 데이터를 쓰기 상태로 매핑합니다.
		/// </summary>
		Write = 2,

		/// <summary>
		/// 데이터를 쓰기 상태로 매핑하며, 이전 데이터는 버려집니다.
		/// </summary>
		Discard = 4
	}
}
