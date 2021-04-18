// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

using SC.ThirdParty.WinAPI;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// 화면에 내용을 출력하는 스왑 체인에 대한 공통 함수를 제공합니다.
    /// </summary>
    [Guid( "790A45F7-0D42-4876-983A-0A55CFE6F4AA" )]
	[ComVisible( true )]
	public interface IDXGISwapChain1 : IDXGISwapChain
	{
		/// <summary>
		/// 현재 스왑 체인의 정보 서술 구조체를 가져옵니다.
		/// </summary>
		/// <returns> 서술 구조체가 반환됩니다. </returns>
		DXGISwapChainDesc1 GetDesc1();

		/// <summary>
		/// 현재 스왑 체인의 전체 화면 서술 구조체를 가져옵니다.
		/// </summary>
		/// <returns> 서술 구조체가 반환됩니다. </returns>
		DXGISwapChainFullscreenDesc GetFullscreenDesc();

		/// <summary>
		/// 출력 대상 창의 핸들을 가져옵니다.
		/// </summary>
		/// <returns> 창 핸들이 반환됩니다. </returns>
		IPlatformHandle GetHwnd();

		/// <summary>
		/// 출력 대상 CoreWindow 개체를 가져옵니다.
		/// </summary>
		/// <param name="riid"> CoreWindow 개체의 GUID를 전달합니다. </param>
		/// <param name="ppUnknown"> 개체를 받을 변수의 참조를 전달합니다. </param>
		void GetCoreWindow( Guid riid, out IUnknown ppUnknown );

		/// <summary>
		/// 후면 버퍼를 디스플레이 화면에 출력합니다.
		/// </summary>
		/// <param name="syncInterval"> 수직 동기 인터벌을 전달합니다. </param>
		/// <param name="presentFlags"> 출력 속성을 전달합니다. </param>
		/// <param name="presentParams"> 출력 매개변수를 전달합니다. </param>
		void Present1( uint syncInterval, DXGIPresent presentFlags, DXGIPresentParameters presentParams );

		/// <summary>
		/// 스왑 체인 개체가 임시 모노 상태를 지원하는지 나타냅니다.
		/// </summary>
		public bool IsTemporaryMonoSupported { get; }

		/// <summary>
		/// 현재 설정된 출력 내용 제한 디스플레이 장치를 가져옵니다.
		/// </summary>
		/// <returns> 디스플레이 장치를 나타내는 인터페이스 개체를 가져옵니다. </returns>
		IDXGIOutput GetRestrictToOutput();

		/// <summary>
		/// 백그라운드 색상을 설정합니다.
		/// </summary>
		/// <param name="color"> 색상을 전달합니다. </param>
		void SetBackgroundColor( DXGIRGBA color );

		/// <summary>
		/// 백그라운드 색상을 가져옵니다.
		/// </summary>
		/// <returns> 색상 구조체를 가져옵니다. </returns>
		DXGIRGBA GetBackgroundColor();

		/// <summary>
		/// 회전 상태를 설정합니다.
		/// </summary>
		/// <param name="rotation"> 회전 상태를 나타내는 열거형을 전달합니다. </param>
		void SetRotation( DXGIModeRotation rotation );

		/// <summary>
		/// 회전 상태를 가져옵니다.
		/// </summary>
		/// <returns> 회전 상태를 나타내는 열거형을 가져옵니다. </returns>
		DXGIModeRotation GetRotation();
	}
}
