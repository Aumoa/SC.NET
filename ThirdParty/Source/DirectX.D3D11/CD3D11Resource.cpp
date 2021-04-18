// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using SC::ThirdParty::DirectX::CD3D11Resource;

CD3D11Resource::CD3D11Resource( ::ID3D11Resource* pResource ) : CD3D11DeviceChild( pResource )
{
	this->pResource = pResource;
}

void CD3D11Resource::RegisterClass()
{
	RegisterCLSID( ID3D11Resource::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

auto CD3D11Resource::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD3D11Resource( ( ::ID3D11Resource* )pUnknown.ToPointer() );
}