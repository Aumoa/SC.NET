// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using SC::ThirdParty::DirectX::CD3D11DeviceChild;

CD3D11DeviceChild::CD3D11DeviceChild( ::ID3D11DeviceChild* pDeviceChild ) : CComObject( pDeviceChild )
{
	this->pDeviceChild = pDeviceChild;
}

void CD3D11DeviceChild::RegisterClass()
{
	RegisterCLSID( ID3D11DeviceChild::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

auto CD3D11DeviceChild::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD3D11DeviceChild( ( ::ID3D11DeviceChild* )pUnknown.ToPointer() );
}