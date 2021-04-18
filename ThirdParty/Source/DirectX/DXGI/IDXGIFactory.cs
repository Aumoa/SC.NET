// Copyright 2020 Aumoa.lib. All right reserved.

using SC.ThirdParty.WinAPI;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 개체를 통합 관리하는 개체에 대한 공통 함수를 제공합니다.
    /// </summary>
    [Guid( "7B7166EC-21C7-44AE-B21A-C9AE321AE369" )]
	[ComVisible( true )]
	public interface IDXGIFactory : IDXGIObject, IEnumerable<IDXGIAdapter>
	{
		/// <summary>
		/// DXGI 개체의 창 연결 속성을 설정합니다.
		/// </summary>
		/// <param name="windowHandle"> 대상 창 핸들을 전달합니다. </param>
		/// <param name="flags"> 창 연결 속성을 전달합니다. </param>
		void MakeWindowAssociation( IPlatformHandle windowHandle, DXGIWindowAssociation flags );

		/// <summary>
		/// DXGI 개체의 연결된 창 핸들을 가져옵니다.
		/// </summary>
		/// <returns> 연결된 창이 있을 경우 핸들을, 그렇지 않을 경우 null이 반환됩니다. </returns>
		IPlatformHandle GetWindowAssociation();

		/// <summary>
		/// 스왑 체인 개체를 생성합니다.
		/// </summary>
		/// <param name="device"> 스왑 체인의 출력 명령을 수행할 수 있는 디바이스 개체를 전달합니다. 예를 들어, D3D11에서는 <see cref="ID3D11Device"/> 개체를, D3D12에서는 <see cref="ID3D12CommandQueue"/> 개체를 전달합니다. </param>
		/// <param name="desc"> 스왑 체인을 서술하는 구조체를 전달합니다. </param>
		/// <returns> 생성된 스왑 체인 개체가 반환됩니다. </returns>
		IDXGISwapChain CreateSwapChain( IUnknown device, DXGISwapChainDesc desc );

		/// <summary>
		/// 소프트웨어 기능으로 구현된 어댑터를 생성합니다.
		/// </summary>
		/// <param name="hModule"> 소프트웨어 구현체의 핸들을 전달합니다. </param>
		/// <returns> 생성된 어댑터 개체가 반환됩니다. </returns>
		IDXGIAdapter CreateSoftwareAdapter( IPlatformHandle hModule );
	}
}
