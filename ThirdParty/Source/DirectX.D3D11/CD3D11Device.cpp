// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using SC::ThirdParty::DirectX::CD3D11Device;

CD3D11Device::CD3D11Device( ::ID3D11Device* pDevice ) : CComObject( pDevice )
{
	this->pDevice = pDevice;
}

void CD3D11Device::RegisterClass()
{
	RegisterCLSID( ID3D11Device::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

auto CD3D11Device::GetImmediateContext() -> ID3D11DeviceContext^
{
	ComPtr<::ID3D11DeviceContext> pImmediateContext;
	pDevice->GetImmediateContext( &pImmediateContext );
	return gcnew CD3D11DeviceContext( pImmediateContext.Detach() );
}

auto CD3D11Device::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD3D11Device( ( ::ID3D11Device* )pUnknown.ToPointer() );
}