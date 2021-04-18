// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 스왑 체인의 전체화면 정보를 서술합니다.
    /// </summary>
    public struct DXGISwapChainFullscreenDesc
	{
		/// <summary>
		/// 화면의 재생 빈도를 표현합니다.
		/// </summary>
		public DXGIRational RefreshRate;

		/// <summary>
		/// 스캔라인 방식을 표현합니다.
		/// </summary>
		public DXGIModeScanlineOrder ScanlineOrdering;

		/// <summary>
		/// 비례 방식을 표현합니다.
		/// </summary>
		public DXGIModeScaling Scaling;

		/// <summary>
		/// 창 모드 상태를 표현합니다.
		/// </summary>
		public bool Windowed;

		/// <summary>
		/// <see cref="DXGISwapChainFullscreenDesc"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="refreshRate"> 화면의 재생 빈도를 전달합니다. </param>
		/// <param name="scanlineOrder"> 화면의 스캔라인 방식을 전달합니다. </param>
		/// <param name="scaling"> 화면의 비례 방식을 전달합니다. </param>
		public DXGISwapChainFullscreenDesc( DXGIRational refreshRate, DXGIModeScanlineOrder scanlineOrder, DXGIModeScaling scaling )
		{
			this.RefreshRate = refreshRate;
			this.ScanlineOrdering = scanlineOrder;
			this.Scaling = scaling;
			this.Windowed = false;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format( "{0}: {{{1}}}, Windowed = {2}", base.ToString(), RefreshRate, Windowed );
		}
	}
}
