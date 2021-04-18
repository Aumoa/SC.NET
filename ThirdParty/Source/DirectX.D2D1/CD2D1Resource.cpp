// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using SC::ThirdParty::DirectX::CD2D1Resource;

CD2D1Resource::CD2D1Resource( ::ID2D1Resource* pResource ) : CComObject( pResource )
{
	this->pResource = pResource;
}

void CD2D1Resource::RegisterClass()
{
	RegisterCLSID<ID2D1Resource^>( gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

auto CD2D1Resource::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD2D1Resource( ( ::ID2D1Resource* )pUnknown.ToPointer() );
}