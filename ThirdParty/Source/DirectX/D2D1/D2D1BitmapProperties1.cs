// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D2D1 비트맵 정보를 표현합니다.
    /// </summary>
    public struct D2D1BitmapProperties1
	{
		/// <summary>
		/// 픽셀 형식을 나타냅니다.
		/// </summary>
		public D2D1PixelFormat PixelFormat;

		/// <summary>
		/// X축 DPI 계수를 나타냅니다.
		/// </summary>
		public float DpiX;

		/// <summary>
		/// Y축 DPI 계수를 나타냅니다.
		/// </summary>
		public float DpiY;

		/// <summary>
		/// 비트맵의 사용 형식을 나타냅니다.
		/// </summary>
		public D2D1BitmapOptions BitmapOptions;

		/// <summary>
		/// 비트맵의 컬러 컨텍스트 개체를 지정합니다.
		/// </summary>
		public ID2D1ColorContext ColorContext;

		/// <summary>
		/// <see cref="D2D1BitmapProperties1"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="format"> 비트맵 픽셀 형식을 전달합니다. </param>
		/// <param name="alphaMode"> 비트맵 알파 처리 방식을 전달합니다. </param>
		/// <param name="options"> 비트맵 옵션을 전달합니다. </param>
		public D2D1BitmapProperties1( DXGIFormat format, D2D1AlphaMode alphaMode, D2D1BitmapOptions options )
		{
			this.PixelFormat.Format = format;
			this.PixelFormat.AlphaMode = alphaMode;
			this.DpiX = 96.0f;
			this.DpiY = 96.0f;
			this.BitmapOptions = options;
			this.ColorContext = null;
		}
	}
}
