// Copyright 2020 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
	/// <summary>
	/// D2D1 비트맵 개체에 대한 공통 메서드를 제공합니다.
	/// </summary>
	[Guid( "a2296057-ea42-4099-983b-539fb6505426" )]
	[ComVisible( true )]
	public interface ID2D1Bitmap : ID2D1Image
	{
		/// <summary>
		/// 비트맵의 해상도 독립적 단위를 가져옵니다.
		/// </summary>
		/// <returns> 크기가 반환됩니다. </returns>
		Vector2 GetSize();

		/// <summary>
		/// 비트맵의 픽셀 단위 해상도를 가져옵니다.
		/// </summary>
		/// <returns> 해상도가 반환됩니다. </returns>
		Vector2 GetPixelSize();

		/// <summary>
		/// 비트맵의 픽셀 형식을 가져옵니다.
		/// </summary>
		/// <returns> 픽셀 형식이 반환됩니다. </returns>
		D2D1PixelFormat GetPixelFormat();

		/// <summary>
		/// 비트맵의 DPI를 가져옵니다.
		/// </summary>
		/// <param name="dpiX"> X축 DPI 값을 받을 변수의 참조를 전달합니다. </param>
		/// <param name="dpiY"> Y축 DPI 값을 받을 변수의 참조를 전달합니다. </param>
		void GetDpi( out float dpiX, out float dpiY );
	}
}
