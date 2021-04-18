// Copyright 2020 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
	/// <summary>
	/// D2D1 장치에 대한 상태를 설정하거나 비트맵을 대상으로 하는 명령 버퍼를 작성하는 디바이스 컨텍스트 개체에 대한 공통 메서드를 제공합니다.
	/// </summary>
	[Guid( "e8f7fe7a-191c-466d-ad95-975678bda998" )]
	[ComVisible( true )]
	public interface ID2D1DeviceContext : ID2D1RenderTarget
	{
		/// <summary>
		/// 단색 브러시 개체를 생성합니다.
		/// </summary>
		/// <param name="color"> 색상 값을 전달합니다. </param>
		/// <returns> 생성된 브러시 개체가 반환됩니다. </returns>
		ID2D1SolidColorBrush CreateSolidColorBrush( Color color );

		/// <summary>
		/// DXGI 표면 개체로부터 비트맵 개체를 생성합니다.
		/// </summary>
		/// <param name="surface"> DXGI 표면 개체를 전달합니다. </param>
		/// <param name="bitmapProperties"> 비트맵 정보를 전달합니다. </param>
		/// <returns> 비트맵 개체가 반환됩니다. </returns>
		ID2D1Bitmap1 CreateBitmapFromDxgiSurface( IDXGISurface surface, D2D1BitmapProperties1? bitmapProperties );

		/// <summary>
		/// 이 비트맵을 생성한 디바이스 개체를 가져옵니다.
		/// </summary>
		/// <returns> 디바이스 개체가 반환됩니다. </returns>
		ID2D1Device GetDevice();

		/// <summary>
		/// 이미지 개체를 렌더 타겟으로 설정합니다. 대상 이미지는 반드시 <see cref="D2D1BitmapOptions.Target"/> 속성이 지정되어야 합니다.
		/// </summary>
		/// <param name="image"> 이미지 개체를 전달합니다. </param>
		void SetTarget( ID2D1Image image );

		/// <summary>
		/// 렌더 타겟으로 설정된 이미지 개체를 가져옵니다.
		/// </summary>
		/// <returns> 이미지 개체가 반환됩니다. </returns>
		ID2D1Image GetTarget();

		/// <summary>
		/// 단위 블렌딩 형식을 설정합니다.
		/// </summary>
		/// <param name="primitiveBlend"> 블렌딩 형식을 전달합니다. </param>
		void SetPrimitiveBlend( D2D1PrimitiveBlend primitiveBlend );

		/// <summary>
		/// 단위 블렌딩 형식을 가져옵니다.
		/// </summary>
		/// <returns> 블렌딩 형식이 반환됩니다. </returns>
		D2D1PrimitiveBlend GetPrimitiveBlend();
	}
}
