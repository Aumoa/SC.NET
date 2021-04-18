// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 출력 디스플레이에 대한 요약 인스턴스의 공통 함수를 제공합니다.
    /// </summary>
    [Guid( "AE02EEDB-C735-4690-8D52-5A8DC20213AA" )]
	[ComVisible( true )]
	public interface IDXGIOutput : IDXGIObject
	{
		/// <summary>
		/// 출력 디스플레이의 정보를 가져옵니다.
		/// </summary>
		/// <returns> 정보 서술 구조체를 반환합니다. </returns>
		DXGIOutputDesc GetDesc();

		/// <summary>
		/// 디스플레이 호환 모드 정보 목록을 가져옵니다.
		/// </summary>
		/// <param name="enumFormat"> 검색할 디스플레이 포맷을 전달합니다. </param>
		/// <param name="flags"> </param>
		/// <returns> 호환 가능한 모드 목록이 반환됩니다. </returns>
		DXGIModeDesc[] GetDisplayModeList( DXGIFormat enumFormat, DXGIEnumModeFlags flags = DXGIEnumModeFlags.None );

		/// <summary>
		/// 지정된 모드와 가장 근접한 호환 모드를 가져옵니다.
		/// </summary>
		/// <param name="modeToMatch"> 모드를 지정합니다. </param>
		/// <param name="concernedDevice"> 장치 인터페이스를 전달합니다. 해당 장치와 호환되는 모드를 </param>
		/// <returns> 호환 가능한 가장 근접한 모드가 반환됩니다. </returns>
		DXGIModeDesc FindClosestMatchingMode( DXGIModeDesc modeToMatch, IUnknown concernedDevice = null );

		/// <summary>
		/// 대상 출력 디스플레이의 수직 동기 시점까지 대기합니다.
		/// </summary>
		void WaitForVBlank();

		/// <summary>
		/// 출력 디스플레이의 소유권을 가져옵니다.
		/// </summary>
		/// <param name="device"> 소유권을 소유할 장치 개체를 전달합니다. </param>
		/// <param name="exclusive"> 이 디스플레이 장치를 베타적으로 소유할지 여부를 전달합니다. </param>
		void TakeOwnership( IUnknown device, bool exclusive );

		/// <summary>
		/// 출력 디스플레이의 소유권을 포기합니다.
		/// </summary>
		void ReleaseOwnership();

		/// <summary>
		/// 감마 컨트롤 호환 값을 가져옵니다.
		/// </summary>
		/// <returns> 감마 컨트롤 호환 값이 반환됩니다. </returns>
		DXGIGammaControlCapabilities GetGammaControlCapabilities();

		/// <summary>
		/// 감마 컨트롤 값을 설정합니다.
		/// </summary>
		/// <param name="gammaControl"> 감마 컨트롤 값을 전달합니다. </param>
		void SetGammaControl( DXGIGammaControl gammaControl );

		/// <summary>
		/// 감마 컨트롤 값을 가져옵니다.
		/// </summary>
		/// <returns> 감마 컨트롤 값이 반환됩니다. </returns>
		DXGIGammaControl GetGammaControl();

		/// <summary>
		/// 디스플레이 모드를 변경합니다.
		/// </summary>
		/// <param name="scanoutSurface"> 이미지를 화면에 렌더링하는 데 사용되는 표면에 대한 인터페이스 개체를 전달됩니다. 표면 개체는 <see cref="DXGIUsage.BackBuffer"/>로 생성되어야 합니다. </param>
		/// <remarks> 이 메서드를 응용 프로그램에서 직접 호출하면 결과를 예측할 수 없습니다. 전체 화면 전환 중 DXGI에 의해 암시적으로 호출되므로 스왑 체인 메서드 대신 사용할 수 없습니다. </remarks>
		void SetDisplaySurface( IDXGISurface scanoutSurface );

		/// <summary>
		/// 현재 표시 화면의 복사본을 가져옵니다.
		/// </summary>
		/// <param name="destination"> 복사 대상 표면 개체를 전달합니다. </param>
		/// <remarks> 이 메서드는 출력이 전체 화면 모드인 경우에만 호출할 수 있습니다. </remarks>
		void GetDisplaySurfaceData( IDXGISurface destination );

		/// <summary>
		/// 프레임 통계를 가져옵니다.
		/// </summary>
		/// <returns> 프레임 통계 값이 반환됩니다. </returns>
		DXGIFrameStatistics GetFrameStatistics();
	}
}
