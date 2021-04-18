// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 서술자 데이터가 저장되는 서술자 힙에 대한 공통 메서드를 제공합니다.
    /// </summary>
    [Guid( "8EFB471D-616C-4F49-90F7-127BB763FA51" )]
	[ComVisible( true )]
	public interface ID3D12DescriptorHeap : ID3D12Pageable
	{
		/// <summary>
		/// 서술자 힙을 서술하는 구조체를 가져옵니다.
		/// </summary>
		/// <returns> 서술 구조체를 가져옵니다. </returns>
		D3D12DescriptorHeapDesc GetDesc();

		/// <summary>
		/// CPU 서술자 힙의 시작 지점 핸들을 가져옵니다.
		/// </summary>
		/// <returns> CPU 서술자 힙 구조체가 반환됩니다. </returns>
		D3D12CPUDescriptorHandle GetCPUDescriptorHandleForHeapStart();

		/// <summary>
		/// GPU 서술자 힙의 시작 지점 핸들을 가져옵니다.
		/// </summary>
		/// <returns> GPU 서술자 힙 구조체가 반환됩니다. </returns>
		D3D12GPUDescriptorHandle GetGPUDescriptorHandleForHeapStart();
	}
}
