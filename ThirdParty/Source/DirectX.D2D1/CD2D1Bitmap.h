// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD2D1Bitmap : CD2D1Image, ID2D1Bitmap
	{
		::ID2D1Bitmap* pBitmap;

	public:
		CD2D1Bitmap( ::ID2D1Bitmap* pBitmap );
		static void RegisterClass();

		virtual Engine::Runtime::Core::Numerics::Vector2 GetSize();
		virtual Engine::Runtime::Core::Numerics::Vector2 GetPixelSize();
		virtual D2D1PixelFormat GetPixelFormat();
		virtual void GetDpi( [System::Runtime::InteropServices::Out] float% dpiX, [System::Runtime::InteropServices::Out] float% dpiY );

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}