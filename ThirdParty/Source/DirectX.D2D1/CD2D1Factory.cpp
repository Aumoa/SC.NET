// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using SC::ThirdParty::DirectX::CD2D1Factory;

CD2D1Factory::CD2D1Factory( ::ID2D1Factory* pFactory ) : CComObject( pFactory )
{
	this->pFactory = pFactory;
}

void CD2D1Factory::RegisterClass()
{
	RegisterCLSID<ID2D1Factory^>( gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

auto CD2D1Factory::CreatePathGeometry() -> ID2D1PathGeometry^
{
	ComPtr<::ID2D1PathGeometry> pGeo;
	HR( pFactory->CreatePathGeometry( &pGeo ) );
	return gcnew CD2D1PathGeometry( pGeo.Detach() );
}

auto CD2D1Factory::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD2D1Factory( ( ::ID2D1Factory* )pUnknown.ToPointer() );
}