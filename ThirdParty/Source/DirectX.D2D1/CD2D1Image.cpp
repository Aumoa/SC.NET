// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using SC::ThirdParty::DirectX::CD2D1Image;

CD2D1Image::CD2D1Image( ::ID2D1Image* pImage ) : CD2D1Resource( pImage )
{
	this->pImage = pImage;
}

void CD2D1Image::RegisterClass()
{
	RegisterCLSID<ID2D1Image^>( gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

auto CD2D1Image::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD2D1Image( ( ::ID2D1Image* )pUnknown.ToPointer() );
}