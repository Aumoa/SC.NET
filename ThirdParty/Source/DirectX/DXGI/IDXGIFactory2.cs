// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 개체를 통합 관리하는 개체에 대한 공통 함수를 제공합니다.
    /// </summary>
    [Guid( "50C83A1C-E072-4C48-87B0-3630FA36A6D0" )]
	[ComVisible( true )]
	public interface IDXGIFactory2 : IDXGIFactory1
	{
		/// <summary>
		/// 스테레오 모드 사용 여부를 가져옵니다.
		/// </summary>
		bool IsWindowedStereoEnabled
		{
			get;
		}

		/// <summary>
		/// 창 핸들을 대상으로 하는 스왑 체인 개체를 생성합니다.
		/// </summary>
		/// <param name="device"> 스왑 체인의 출력 명령을 수행할 수 있는 디바이스 개체를 전달합니다. 예를 들어, D3D11에서는 <see cref="ID3D11Device"/> 개체를, D3D12에서는 <see cref="ID3D12CommandQueue"/> 개체를 전달합니다. </param>
		/// <param name="hWnd"> 창 핸들을 전달합니다. </param>
		/// <param name="desc"> 스왑 체인의 정보 서술 구조체를 전달합니다. </param>
		/// <param name="fullscreenDesc"> 전체 화면 정보 서술 구조체를 전달합니다. </param>
		/// <param name="restrictToOutput"> 출력을 제한할 대상 모니터 개체를 전달합니다. </param>
		/// <returns> 생성된 스왑 체인 개체가 반환됩니다. </returns>
		IDXGISwapChain1 CreateSwapChainForHwnd(
			IUnknown device,
			IntPtr hWnd,
			DXGISwapChainDesc1 desc,
			DXGISwapChainFullscreenDesc? fullscreenDesc = null,
			IDXGIOutput restrictToOutput = null
			);

		/// <summary>
		/// 창 개체를 대상으로 하는 스왑 체인 개체를 생성합니다.
		/// </summary>
		/// <param name="device"> 스왑 체인의 출력 명령을 수행할 수 있는 디바이스 개체를 전달합니다. 예를 들어, D3D11에서는 <see cref="ID3D11Device"/> 개체를, D3D12에서는 <see cref="ID3D12CommandQueue"/> 개체를 전달합니다. </param>
		/// <param name="hWnd"> 창 핸들을 전달합니다. </param>
		/// <param name="desc"> 스왑 체인의 정보 서술 구조체를 전달합니다. </param>
		/// <param name="restrictToOutput"> 출력을 제한할 대상 모니터 개체를 전달합니다. </param>
		/// <returns> 생성된 스왑 체인 개체가 반환됩니다. </returns>
		IDXGISwapChain1 CreateSwapChainForCoreWindow(
			IUnknown device,
			IUnknown hWnd,
			DXGISwapChainDesc1 desc,
			IDXGIOutput restrictToOutput = null
			);

		/// <summary>
		/// DirectComposition API 또는 Windows.UI.Xaml 프레임워크를 대상으로 하는 스왑 체인을 생성합니다.
		/// </summary>
		/// <param name="device"> 스왑 체인의 출력 명령을 수행할 수 있는 디바이스 개체를 전달합니다. 예를 들어, D3D11에서는 <see cref="ID3D11Device"/> 개체를, D3D12에서는 <see cref="ID3D12CommandQueue"/> 개체를 전달합니다. </param>
		/// <param name="desc"> 스왑 체인의 정보 서술 구조체를 전달합니다. </param>
		/// <param name="restrictToOutput"> 출력을 제한할 대상 모니터 개체를 전달합니다. </param>
		/// <returns> 생성된 스왑 체인 개체가 반환됩니다. </returns>
		IDXGISwapChain1 CreateSwapChainForComposition(
			IUnknown device,
			DXGISwapChainDesc1 desc,
			IDXGIOutput restrictToOutput = null
			);

		/// <summary>
		/// 공유된 자원에 대한 어댑터 LUID를 가져옵니다.
		/// </summary>
		/// <param name="hResource"> 공유 자원의 핸들을 전달합니다. </param>
		/// <returns> LUID 값을 가져옵니다. </returns>
		Luid GetSharedResourceAdapterLuid( IntPtr hResource );

		/// <summary>
		/// 스테레오 상태 변경에 대한 알림 메시지를 받도록 응용 프로그램 창을 등록합니다.
		/// </summary>
		/// <param name="windowHandle"> 알림을 받을 창 핸들을 전달합니다. </param>
		/// <param name="wMsg"> 창에 전달될 메시지의 ID를 전달합니다. </param>
		/// <returns> <see cref="UnregisterStereoStatus"/> 메서드에 전달할 수 있도록 이 등록을 식별하는 값을 반환합니다. </returns>
		uint RegisterStereoStatusWindow( IntPtr windowHandle, uint wMsg );

		/// <summary>
		/// 스테레오 상태 변경에 대한 알림을 받을 이벤트를 등록합니다.
		/// </summary>
		/// <param name="hEvent"> 알림을 받을 이벤트의 핸들을 전달합니다. </param>
		/// <returns> <see cref="UnregisterStereoStatus"/> 메서드에 전달할 수 있도록 이 등록을 식별하는 값을 반환합니다. </returns>
		uint RegisterStereoStatusEvent( IntPtr hEvent );

		/// <summary>
		/// 스트레오 상태 변경에 대한 알림을 해제합니다.
		/// </summary>
		/// <param name="cookie"> 등록 시 발급되었던 등록 식별 값을 전달합니다. </param>
		void UnregisterStereoStatus( uint cookie );

		/// <summary>
		/// 오클루전 상태 변경에 대한 알림 메시지를 받도록 응용 프로그램 창을 등록합니다.
		/// </summary>
		/// <param name="windowHandle"> 알림을 받을 창 핸들을 전달합니다. </param>
		/// <param name="wMsg"> 창에 전달될 메시지의 ID를 전달합니다. </param>
		/// <returns> <see cref="UnregisterOcclusionStatus"/> 메서드에 전달할 수 있도록 이 등록을 식별하는 값을 반환합니다. </returns>
		uint RegisterOcclusionStatusWindow( IntPtr windowHandle, uint wMsg );

		/// <summary>
		/// 오클루전 상태 변경에 대한 알림을 받을 이벤트를 등록합니다.
		/// </summary>
		/// <param name="hEvent"> 알림을 받을 이벤트의 핸들을 전달합니다. </param>
		/// <returns> <see cref="UnregisterOcclusionStatus"/> 메서드에 전달할 수 있도록 이 등록을 식별하는 값을 반환합니다. </returns>
		uint RegisterOcclusionStatusEvent( IntPtr hEvent );

		/// <summary>
		/// 오클루전 상태 변경에 대한 알림을 해제합니다.
		/// </summary>
		/// <param name="cookie"> 등록 시 발급되었던 등록 식별 값을 전달합니다. </param>
		void UnregisterOcclusionStatus( uint cookie );
	}
}
