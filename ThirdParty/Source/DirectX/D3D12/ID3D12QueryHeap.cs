// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 GPU에 요청한 정보를 받을 힙에 대한 공통 메서드를 제공합니다.
    /// </summary>
    [Guid( "0D9658AE-ED45-469E-A61D-970EC583CAB4" )]
	[ComVisible( true )]
	public interface ID3D12QueryHeap : ID3D12Pageable
	{
	}
}
