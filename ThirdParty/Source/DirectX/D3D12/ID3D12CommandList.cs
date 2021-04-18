// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 명령 목록 제어에 대한 공통 함수를 제공합니다.
    /// </summary>
    [Guid( "7116D91C-E7E4-47CE-B8C6-EC8168F437E5" )]
	[ComVisible( true )]
	public interface ID3D12CommandList : ID3D12DeviceChild
	{
		/// <summary>
		/// 명령 목록이 실행 가능한 명령 유형을 가져옵니다.
		/// </summary>
		/// <returns> 명령 목록 유형이 반환됩니다. </returns>
		D3D12CommandListType GetType();
	}
}
