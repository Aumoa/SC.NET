// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::Engine::Runtime::Core::Numerics;

using namespace System;

using SC::ThirdParty::DirectX::CD2D1DeviceContext;

CD2D1DeviceContext::CD2D1DeviceContext( ::ID2D1DeviceContext* pDeviceContext ) : CD2D1RenderTarget( pDeviceContext )
{
	this->pDeviceContext = pDeviceContext;
}

void CD2D1DeviceContext::RegisterClass()
{
	RegisterCLSID<ID2D1DeviceContext^>( gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

auto CD2D1DeviceContext::CreateSolidColorBrush( Color color ) -> ID2D1SolidColorBrush^
{
	D2D1_COLOR_F color_;
	Assign( color_, color );
	ComPtr<::ID2D1SolidColorBrush> pSolidColorBrush;
	HR( pDeviceContext->CreateSolidColorBrush( color_, &pSolidColorBrush ) );
	return gcnew CD2D1SolidColorBrush( pSolidColorBrush.Detach() );
}

auto CD2D1DeviceContext::CreateBitmapFromDxgiSurface( IDXGISurface^ surface, Nullable<D2D1BitmapProperties1> bitmapProperties ) -> ID2D1Bitmap1^
{
	D2D1_BITMAP_PROPERTIES1 bitmapProperties_;
	if ( bitmapProperties.HasValue ) Assign( bitmapProperties_, bitmapProperties.Value );

	ComPtr<::ID2D1Bitmap1> pBitmap;
	HR( pDeviceContext->CreateBitmapFromDxgiSurface( Take<::IDXGISurface>( surface ), bitmapProperties.HasValue ? &bitmapProperties_ : nullptr, &pBitmap ) );

	return gcnew CD2D1Bitmap1( pBitmap.Detach() );
}

auto CD2D1DeviceContext::GetDevice() -> ID2D1Device^
{
	ComPtr<::ID2D1Device> pDevice;
	pDeviceContext->GetDevice( &pDevice );
	return gcnew CD2D1Device( pDevice.Detach() );
}

void CD2D1DeviceContext::SetTarget( ID2D1Image^ image )
{
	pDeviceContext->SetTarget( Take<::ID2D1Image>( image ) );
}

auto CD2D1DeviceContext::GetTarget() -> ID2D1Image^
{
	ComPtr<::ID2D1Image> pImage;
	pDeviceContext->GetTarget( &pImage );
	return gcnew CD2D1Image( pImage.Detach() );
}

void CD2D1DeviceContext::SetPrimitiveBlend( D2D1PrimitiveBlend primitiveBlend )
{
	pDeviceContext->SetPrimitiveBlend( ( D2D1_PRIMITIVE_BLEND )primitiveBlend );
}

auto CD2D1DeviceContext::GetPrimitiveBlend() -> D2D1PrimitiveBlend
{
	return ( D2D1PrimitiveBlend )pDeviceContext->GetPrimitiveBlend();
}

auto CD2D1DeviceContext::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD2D1DeviceContext( ( ::ID2D1DeviceContext* )pUnknown.ToPointer() );
}