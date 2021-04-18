// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 명령을 할당할 수 있는 개체에 대한 공통 메서드를 제공합니다.
    /// </summary>
    [Guid( "6102DEE4-AF59-4B09-B999-B44D73F09B24" )]
	[ComVisible( true )]
	public interface ID3D12CommandAllocator : ID3D12Pageable
	{
		/// <summary>
		/// 할당된 모든 명령을 제거합니다.
		/// </summary>
		void Reset();
	}
}
