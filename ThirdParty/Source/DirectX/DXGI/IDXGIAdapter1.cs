// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// 시스템에 설치된 물리 또는 소프트웨어 어댑터를 제어하기 위한 공통 함수를 제공합니다.
    /// </summary>
    [Guid( "29038F61-3839-4626-91FD-086879011A05" )]
	[ComVisible( true )]
	public interface IDXGIAdapter1 : IDXGIAdapter
	{
		/// <summary>
		/// GPU 어댑터의 정보를 가져옵니다.
		/// </summary>
		/// <returns> 정보를 표현하는 구조체를 반환합니다. </returns>
		DXGIAdapterDesc1 GetDesc1();
	}
}
