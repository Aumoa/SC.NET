// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD2D1Bitmap1 : CD2D1Bitmap, ID2D1Bitmap1
	{
		::ID2D1Bitmap1* pBitmap;

	public:
		CD2D1Bitmap1( ::ID2D1Bitmap1* pBitmap );
		static void RegisterClass();

		virtual IDXGISurface^ GetSurface();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}