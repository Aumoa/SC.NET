// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using SC::ThirdParty::DirectX::CD2D1Bitmap1;

CD2D1Bitmap1::CD2D1Bitmap1( ::ID2D1Bitmap1* pBitmap ) : CD2D1Bitmap( pBitmap )
{
	this->pBitmap = pBitmap;
}

void CD2D1Bitmap1::RegisterClass()
{
	RegisterCLSID<ID2D1Bitmap1^>( gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

auto CD2D1Bitmap1::GetSurface() -> IDXGISurface^
{
	ComPtr<::IDXGISurface> pSurface;
	HR( pBitmap->GetSurface( &pSurface ) );
	return CComObject::CoCreateInstance<IDXGISurface^>( IntPtr( pSurface.Detach() ) );
}

auto CD2D1Bitmap1::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD2D1Bitmap1( ( ::ID2D1Bitmap1* )pUnknown.ToPointer() );
}