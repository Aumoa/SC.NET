// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using SC::ThirdParty::DirectX::CD2D1Device;

CD2D1Device::CD2D1Device( ::ID2D1Device* pDevice ) : CD2D1Resource( pDevice )
{
	this->pDevice = pDevice;
}

void CD2D1Device::RegisterClass()
{
	RegisterCLSID<ID2D1Device^>( gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

auto CD2D1Device::CreateDeviceContext( D2D1DeviceContextOptions options ) -> ID2D1DeviceContext^
{
	ComPtr<::ID2D1DeviceContext> pDeviceContext;
	HR( pDevice->CreateDeviceContext( ( D2D1_DEVICE_CONTEXT_OPTIONS )options, &pDeviceContext ) );
	return gcnew CD2D1DeviceContext( pDeviceContext.Detach() );
}

auto CD2D1Device::GetFactory() -> ID2D1Factory^
{
	ComPtr<::ID2D1Factory> pFactory;
	pDevice->GetFactory( &pFactory );
	return gcnew CD2D1Factory( pFactory.Detach() );
}

auto CD2D1Device::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD2D1Device( ( ::ID2D1Device* )pUnknown.ToPointer() );
}