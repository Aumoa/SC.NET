// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 개체를 통합 관리하는 개체에 대한 공통 함수를 제공합니다.
    /// </summary>
    [Guid( "770AAE78-F26F-4DBA-A829-253C83D1B387" )]
	[ComVisible( true )]
	public interface IDXGIFactory1 : IDXGIFactory
	{
		/// <summary>
		/// 시스템에서 조회 가능한 어댑터 장치가 추가 또는 제거되었을 경우 false가 반환됩니다. 이 경우 응용 프로그램은 어댑터 장치를 다시 열거해야 합니다.
		/// </summary>
		bool IsCurrent
		{
			get;
		}
	}
}
