// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD2D1DeviceContext : CD2D1RenderTarget, ID2D1DeviceContext
	{
		::ID2D1DeviceContext* pDeviceContext;

	public:
		CD2D1DeviceContext( ::ID2D1DeviceContext* pDeviceContext );
		static void RegisterClass();

		virtual ID2D1SolidColorBrush^ CreateSolidColorBrush( Engine::Runtime::Core::Numerics::Color color );
		virtual ID2D1Bitmap1^ CreateBitmapFromDxgiSurface( IDXGISurface^ surface, System::Nullable<D2D1BitmapProperties1> bitmapProperties );
		virtual ID2D1Device^ GetDevice();
		virtual void SetTarget( ID2D1Image^ image );
		virtual ID2D1Image^ GetTarget();
		virtual void SetPrimitiveBlend( D2D1PrimitiveBlend primitiveBlend );
		virtual D2D1PrimitiveBlend GetPrimitiveBlend();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}