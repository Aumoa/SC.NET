// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 개체를 통합 관리하는 개체에 대한 공통 함수를 제공합니다.
    /// </summary>
    [Guid( "25483823-CD46-4C7D-86CA-47AA95B837BD" )]
	[ComVisible( true )]
	public interface IDXGIFactory3 : IDXGIFactory2
	{
		/// <summary>
		/// 이 개체가 생성될 때 전달되었던 플래그 집합을 가져옵니다.
		/// </summary>
		DXGICreateFlags CreationFlags
		{
			get;
		}
	}
}
