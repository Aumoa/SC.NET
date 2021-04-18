// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 장치 인터페이스 개체에 대한 공통 함수를 표현합니다.
    /// </summary>
    [Guid( "54EC77FA-1377-44E6-8C32-88FD5F44C84C" )]
	[ComVisible( true )]
	public interface IDXGIDevice : IDXGIObject
	{
		/// <summary>
		/// 이 장치 인터페이스가 참조하는 어댑터 개체를 가져옵니다.
		/// </summary>
		/// <returns> 어댑터 인터페이스 개체를 가져옵니다. </returns>
		IDXGIAdapter GetAdapter();

		/// <summary>
		/// 리소스의 메모리 위치를 조회합니다.
		/// </summary>
		/// <param name="unknowns"> 리소스 목록을 전달합니다. </param>
		/// <returns> 리소스의 위치를 나타내는 열거형 목록을 반환합니다. </returns>
		DXGIResidency[] QueryResourceResidency( IList<IUnknown> unknowns );

		/// <summary>
		/// GPU 스레드의 우선 순위를 설정합니다. 
		/// </summary>
		/// <param name="priority"> 우선 순위 값을 전달합니다. 값은 -7에서 7사이이며, 0은 보통 우선 순위를 나타냅니다. </param>
		void SetGPUThreadPriority( int priority );

		/// <summary>
		/// GPU 스레드의 우선 순위를 가져옵니다.
		/// </summary>
		/// <returns> 우선 순위 값이 반환됩니다. </returns>
		int GetGPUThreadPriority();
	}
}
