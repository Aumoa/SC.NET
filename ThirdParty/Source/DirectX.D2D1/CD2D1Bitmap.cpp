// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::Engine::Runtime::Core::Numerics;

using namespace System;

using SC::ThirdParty::DirectX::CD2D1Bitmap;

CD2D1Bitmap::CD2D1Bitmap( ::ID2D1Bitmap* pBitmap ) : CD2D1Image( pBitmap )
{
	this->pBitmap = pBitmap;
}

void CD2D1Bitmap::RegisterClass()
{
	RegisterCLSID<ID2D1Bitmap^>( gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

auto CD2D1Bitmap::GetSize() -> Vector2
{
	auto size = pBitmap->GetSize();
	return Vector2( size.width, size.height );
}

auto CD2D1Bitmap::GetPixelSize() -> Vector2
{
	auto size = pBitmap->GetPixelSize();
	return Vector2( (float)size.width, (float)size.height );
}

auto CD2D1Bitmap::GetPixelFormat() -> D2D1PixelFormat
{
	auto pixelFormat = pBitmap->GetPixelFormat();
	D2D1PixelFormat pixelFormat_;
	Assign( pixelFormat_, pixelFormat );
	return pixelFormat_;
}

void CD2D1Bitmap::GetDpi( float% dpiX, float% dpiY )
{
	float dpiX_, dpiY_;
	pBitmap->GetDpi( &dpiX_, &dpiY_ );
	dpiX = dpiX_;
	dpiY = dpiY_;
}

auto CD2D1Bitmap::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD2D1Bitmap( ( ::ID2D1Bitmap* )pUnknown.ToPointer() );
}