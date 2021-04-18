// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 스왑 체인의 컬러 스페이스 지원 플래그 목록을 나열합니다.
    /// </summary>
    [Flags]
	public enum DXGISwapChainColorSpaceSupportFlags
	{
		/// <summary>
		/// 컬러 스페이스 변환이 디스플레이 출력에서 지원됨을 나타냅니다.
		/// </summary>
		Present = 0x01,

		/// <summary>
		/// 컬러 스페이스 변환이 오버레이 디스플레이 출력에서 지원됨을 나타냅니다.
		/// </summary>
		OverlayPresent = 0x02
	}
}
