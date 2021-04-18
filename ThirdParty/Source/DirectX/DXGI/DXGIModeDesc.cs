// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 화면 모드에 대한 정보를 서술합니다.
    /// </summary>
    public struct DXGIModeDesc
	{
		/// <summary>
		/// 화면 넓이를 표현합니다.
		/// </summary>
		public int Width;

		/// <summary>
		/// 화면 높이를 표현합니다.
		/// </summary>
		public int Height;

		/// <summary>
		/// 화면 모드의 재생 빈도를 표현합니다.
		/// </summary>
		public DXGIRational RefreshRate;

		/// <summary>
		/// 화면 모드의 출력 포맷을 표현합니다.
		/// </summary>
		public DXGIFormat Format;

		/// <summary>
		/// 화면 모드의 스캔라인 방식을 표현합니다.
		/// </summary>
		public DXGIModeScanlineOrder ScanlineOrdering;

		/// <summary>
		/// 화면 모드의 비례 방식을 표현합니다.
		/// </summary>
		public DXGIModeScaling Scaling;

		/// <summary>
		/// <see cref="DXGIModeDesc"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="width"> 화면의 넓이를 전달합니다. </param>
		/// <param name="height"> 화면의 높이를 전달합니다. </param>
		/// <param name="format"> 화면의 출력 형식을 전달합니다. </param>
		public DXGIModeDesc( int width, int height, DXGIFormat format )
		{
			this.Width = width;
			this.Height = height;
			this.RefreshRate = new DXGIRational( 0, 1 );
			this.Format = format;
			this.ScanlineOrdering = DXGIModeScanlineOrder.Unspecified;
			this.Scaling = DXGIModeScaling.Unspecified;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format( "{0}: Width = {1}, Height = {2}, Format = {3}", base.ToString(), Width, Height, Format );
		}
	}
}
