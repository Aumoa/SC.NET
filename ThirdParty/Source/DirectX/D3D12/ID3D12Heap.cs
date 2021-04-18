// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 힙 영역에 대한 공통 메서드를 제공합니다.
    /// </summary>
    [Guid( "6B3B2502-6E51-45B3-90EE-9884265E8DF3" )]
	[ComVisible( true )]
	public interface ID3D12Heap : ID3D12Pageable
	{
		/// <summary>
		/// 힙 정보 구조체를 가져옵니다.
		/// </summary>
		/// <returns> 정보 구조체가 반환됩니다. </returns>
		D3D12HeapDesc GetDesc();
	}
}
