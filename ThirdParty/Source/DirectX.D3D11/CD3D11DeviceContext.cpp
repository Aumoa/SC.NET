// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using SC::ThirdParty::DirectX::CD3D11DeviceContext;

CD3D11DeviceContext::CD3D11DeviceContext( ::ID3D11DeviceContext* pDeviceContext ) : CD3D11DeviceChild( pDeviceContext )
{
	this->pDeviceContext = pDeviceContext;
}

void CD3D11DeviceContext::RegisterClass()
{
	RegisterCLSID( ID3D11DeviceContext::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

void CD3D11DeviceContext::ClearState()
{
	pDeviceContext->ClearState();
}

void CD3D11DeviceContext::Flush()
{
	pDeviceContext->Flush();
}

auto CD3D11DeviceContext::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD3D11DeviceContext( ( ::ID3D11DeviceContext* )pUnknown.ToPointer() );
}