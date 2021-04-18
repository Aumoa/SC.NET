// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D2D1 픽셀 형식을 표현합니다.
    /// </summary>
    public struct D2D1PixelFormat
	{
		/// <summary>
		/// 픽셀 형식을 전달합니다.
		/// </summary>
		public DXGIFormat Format;

		/// <summary>
		/// 알파 처리 형식을 전달합니다.
		/// </summary>
		public D2D1AlphaMode AlphaMode;
	}
}
