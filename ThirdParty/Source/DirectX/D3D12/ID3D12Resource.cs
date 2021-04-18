// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 GPU에서 사용되는 자원에 대한 공통 메서드를 제공합니다.
    /// </summary>
    [Guid( "696442BE-A72E-4059-BC79-5B5C98040FAD" )]
	[ComVisible( true )]
	public interface ID3D12Resource : ID3D12Pageable
	{
		/// <summary>
		/// CPU에서 접근 가능한 메모리 주소를 매핑합니다.
		/// </summary>
		/// <param name="subresource"> 자원의 서브리소스 인덱스를 전달합니다. </param>
		/// <param name="readRange"> 자원의 매핑 범위를 전달합니다. </param>
		/// <returns> 자원의 매핑 주소가 반환됩니다. </returns>
		IntPtr Map( uint subresource = 0, D3D12Range? readRange = null );

		/// <summary>
		/// 메모리 주소 매핑을 해제합니다.
		/// </summary>
		/// <param name="subresource"> 자원의 서브리소스 인덱스를 전달합니다. </param>
		/// <param name="writtenRange"> 자원의 쓰기 범위를 전달합니다. </param>
		void Unmap( uint subresource = 0, D3D12Range? writtenRange = null );

		/// <summary>
		/// 자원의 생성 서술 구조체를 가져옵니다.
		/// </summary>
		/// <returns> 서술 구조체가 반환됩니다. </returns>
		D3D12ResourceDesc GetDesc();

		/// <summary>
		/// GPU 가상 주소 값을 가져옵니다.
		/// </summary>
		/// <returns> 가상 주소 값이 반환됩니다. </returns>
		ulong GetGPUVirtualAddress();

		/// <summary>
		/// 네이티브 데이터를 자원의 서브리소스에 씁니다.
		/// </summary>
		/// <param name="dstSubresource"> 데이터를 제출할 서브리소스 인덱스를 전달합니다. </param>
		/// <param name="dstBox"> 데이터를 제출할 위치를 전달합니다. </param>
		/// <param name="pSrcData"> 데이터 원본 네이티브 포인터를 전달합니다. </param>
		/// <param name="srcRowPitch"> 데이터의 바이트 단위 너비를 전달합니다. </param>
		/// <param name="srcDepthPitch"> 데이터의 깊이를 전달합니다. </param>
		void WriteToSubresource( uint dstSubresource, D3D12Box? dstBox, IntPtr pSrcData, uint srcRowPitch, uint srcDepthPitch = 1 );

		/// <summary>
		/// 자원의 서브리소스에서 네이티브 데이터를 가져옵니다.
		/// </summary>
		/// <param name="pDstData"> 데이터를 받을 네티이브 포인터를 전달합니다. </param>
		/// <param name="dstRowPitch"> 데이터를 받을 위치의 바이트 단위 너비를 전달합니다. </param>
		/// <param name="dstDepthPitch"> 데이터를 받을 위치의 깊이를 전달합니다. </param>
		/// <param name="srcSubresource"> 데이터를 가져올 서브리소스 인덱스를 전달합니다. </param>
		/// <param name="srcBox"> 데이터를 가져올 서브리소스의 영역을 전달합니다. </param>
		void ReadFromSubresource( IntPtr pDstData, uint dstRowPitch, uint dstDepthPitch, uint srcSubresource, D3D12Box? srcBox );

		/// <summary>
		/// 자원의 힙 속성을 가져옵니다.
		/// </summary>
		/// <param name="heapProperties"> 힙 속성 서술 구조체를 받을 변수의 참조를 전달합니다. </param>
		/// <param name="heapFlags"> 힙 속성을 받을 변수의 참조를 전달합니다. </param>
		void GetHeapProperties( out D3D12HeapProperties heapProperties, out D3D12HeapFlags heapFlags );
	}
}
