// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// 화면에 내용을 출력하는 스왑 체인에 대한 공통 함수를 제공합니다.
    /// </summary>
    [Guid( "310D36A0-D2E7-4C0A-AA04-6A9D23B8886A" )]
	[ComVisible( true )]
	public interface IDXGISwapChain : IDXGIDeviceSubObject
	{
		/// <summary>
		/// 후면 버퍼를 디스플레이 화면에 출력합니다.
		/// </summary>
		/// <param name="syncInterval"> 수직 동기 인터벌을 전달합니다. </param>
		/// <param name="flags"> 출력 속성을 전달합니다. </param>
		void Present( uint syncInterval = 0, DXGIPresent flags = DXGIPresent.None );

		/// <summary>
		/// 후면 버퍼를 가져옵니다.
		/// </summary>
		/// <param name="index"> 후면 버퍼 인덱스를 전달합니다. </param>
		/// <param name="riid"> 후면 버퍼의 인터페이스 GUID를 전달합니다.  </param>
		/// <param name="ppUnknown"> 후면 버퍼를 받을 변수의 참조를 전달합니다. </param>
		void GetBuffer( int index, Guid riid, out IUnknown ppUnknown );

		/// <summary>
		/// 전체 화면 모드를 설정합니다.
		/// </summary>
		/// <param name="fullscreen"> 전체 화면 상태를 전달합니다. </param>
		/// <param name="target"> 대상 디스플레이 인터페이스를 전달합니다. </param>
		void SetFullscreenState( bool fullscreen, IDXGIOutput target );

		/// <summary>
		/// 현재 스왑 체인에 지정된 전체 화면 설정 정보를 가져옵니다.
		/// </summary>
		/// <param name="target"> 대상 디스플레이 인터페이스를 받을 변수의 참조를 전달합니다. </param>
		/// <returns> 전체 화면 상태가 반환됩니다. </returns>
		bool GetFullscreenState( out IDXGIOutput target );

		/// <summary>
		/// 현재 스왑 체인의 정보 서술 구조체를 가져옵니다.
		/// </summary>
		/// <returns> 서술 구조체가 반환됩니다. </returns>
		DXGISwapChainDesc GetDesc();

		/// <summary>
		/// 후면 버퍼의 크기를 변경합니다.
		/// </summary>
		/// <param name="bufferCount"> 변경할 버퍼의 개수를 전달합니다. null을 전달할 경우 버퍼의 개수를 변경하지 않습니다. </param>
		/// <param name="width"> 변경할 버퍼의 너비를 전달합니다. </param>
		/// <param name="height"> 변경할 버퍼의 높이를 전달합니다. </param>
		/// <param name="newFormat"> 변경할 버퍼의 픽셀 형식을 전달합니다. null을 전달할 경우 형식을 변경하지 않습니다. </param>
		/// <param name="swapChainFlag"> 변경할 스왑 체인의 속성을 전달합니다. null을 전달할 경우 속성을 변경하지 않습니다. </param>
		/// <remarks> 이 메서드를 호출하기 전, 반드시 모든 후면 버퍼의 참조가 제거되어야 합니다. <see cref="IUnknown.Release"/> 메서드를 참조하십시오. </remarks>
		void ResizeBuffers( uint? bufferCount, int width, int height, DXGIFormat? newFormat, DXGISwapChainFlag? swapChainFlag );

		/// <summary>
		/// 스왑 체인의 대상 창의 모드를 변경합니다.
		/// </summary>
		/// <param name="newTargetMode"> 새로운 디스플레이 모드를 전달합니다. </param>
		void ResizeTarget( DXGIModeDesc newTargetMode );

		/// <summary>
		/// 현재 스왑 체인의 대부분의 영역을 포함하는 디스플레이 인터페이스를 가져옵니다.
		/// </summary>
		/// <returns> 디스플레이 인터페이스 개체를 반환합니다. </returns>
		IDXGIOutput GetContainingOutput();

		/// <summary>
		/// 현재 스왑 체인의 프레임 통계를 가져옵니다.
		/// </summary>
		/// <returns> 프레임 통계 값이 반환됩니다. </returns>
		DXGIFrameStatistics GetFrameStatistics();

		/// <summary>
		/// 마지막 출력의 출력 횟수를 가져옵니다.
		/// </summary>
		/// <returns> 출력 횟수가 반환됩니다. </returns>
		long GetLastPresentCount();
	}
}
