// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// <see cref="ID3D12Resource"/> 인터페이스 개체에 대한 확장 메서드를 제공합니다.
    /// </summary>
    public static class ID3D12ResourceExtensions
	{
		/// <summary>
		/// 네이티브 데이터를 자원의 0번 서브리소스에 씁니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="dstBox"> 데이터를 제출할 위치를 전달합니다. </param>
		/// <param name="pSrcData"> 데이터 원본 네이티브 포인터를 전달합니다. </param>
		/// <param name="srcRowPitch"> 데이터의 바이트 단위 너비를 전달합니다. </param>
		/// <param name="srcDepthPitch"> 데이터의 바이트 단위 깊이를 전달합니다. </param>
		public static void WriteToSubresource( this ID3D12Resource @this, D3D12Box? dstBox, IntPtr pSrcData, uint srcRowPitch, uint srcDepthPitch = 1 )
		{
			@this.WriteToSubresource( 0, dstBox, pSrcData, srcRowPitch, srcDepthPitch );
		}

		/// <summary>
		/// 네이티브 데이터를 자원의 0번 서브리소스에 씁니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="pSrcData"> 데이터 원본 네이티브 포인터를 전달합니다. </param>
		/// <param name="srcRowPitch"> 데이터의 바이트 단위 너비를 전달합니다. </param>
		/// <param name="srcDepthPitch"> 데이터의 바이트 단위 깊이를 전달합니다. </param>
		public static void WriteToSubresource( this ID3D12Resource @this, IntPtr pSrcData, uint srcRowPitch, uint srcDepthPitch = 1 )
		{
			@this.WriteToSubresource( 0, null, pSrcData, srcRowPitch, srcDepthPitch );
		}

		/// <summary>
		/// 자원의 0번 서브리소스에서 네이티브 데이터를 가져옵니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="pDstData"> 데이터를 받을 네티이브 포인터를 전달합니다. </param>
		/// <param name="dstRowPitch"> 데이터를 받을 위치의 바이트 단위 너비를 전달합니다. </param>
		/// <param name="dstDepthPitch"> 데이터를 받을 위치의 깊이를 전달합니다. </param>
		/// <param name="srcBox"> 데이터를 가져올 서브리소스의 영역을 전달합니다. </param>
		public static void ReadFromSubresource( this ID3D12Resource @this, IntPtr pDstData, uint dstRowPitch, uint dstDepthPitch, D3D12Box? srcBox )
		{
			@this.ReadFromSubresource( pDstData, dstRowPitch, dstDepthPitch, 0, srcBox );
		}

		/// <summary>
		/// 자원의 0번 서브리소스에서 네이티브 데이터를 가져옵니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="pDstData"> 데이터를 받을 네티이브 포인터를 전달합니다. </param>
		/// <param name="dstRowPitch"> 데이터를 받을 위치의 바이트 단위 너비를 전달합니다. </param>
		/// <param name="dstDepthPitch"> 데이터를 받을 위치의 깊이를 전달합니다. </param>
		public static void ReadFromSubresource( this ID3D12Resource @this, IntPtr pDstData, uint dstRowPitch, uint dstDepthPitch )
		{
			@this.ReadFromSubresource( pDstData, dstRowPitch, dstDepthPitch, 0, null );
		}

		/// <summary>
		/// 자원의 힙 속성을 가져옵니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <returns> 힙 속성 구조체가 반환됩니다. </returns>
		public static D3D12HeapProperties GetHeapProperties( this ID3D12Resource @this )
		{
			@this.GetHeapProperties( out var heapProperties, out var _ );
			return heapProperties;
		}
	}
}
