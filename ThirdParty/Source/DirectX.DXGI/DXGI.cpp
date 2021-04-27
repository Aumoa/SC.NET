// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::ThirdParty::DirectX;

using namespace System;

void DXGI::CoInitialize()
{
	CDXGIDevice::RegisterClass();
	CDXGIDeviceSubObject::RegisterClass();
	CDXGIFactory::RegisterClass();
	CDXGIFactory1::RegisterClass();
	CDXGISurface::RegisterClass();
	CDXGISwapChain::RegisterClass();
	CDXGISwapChain1::RegisterClass();
	CDXGISwapChain2::RegisterClass();
	CDXGISwapChain3::RegisterClass();
	CDXGIAdapter::RegisterClass();
	CDXGIAdapter1::RegisterClass();
	CDXGIObject::RegisterClass();
	CDXGIOutput::RegisterClass();
	CD3DBlob::RegisterClass();
}

void DXGI::CoUninitialize()
{
	ComObject::UnregisterCLSID( IDXGIDevice::typeid->GUID );
	ComObject::UnregisterCLSID( IDXGIDeviceSubObject::typeid->GUID );
	ComObject::UnregisterCLSID( IDXGIFactory::typeid->GUID );
	ComObject::UnregisterCLSID( IDXGIFactory1::typeid->GUID );
	ComObject::UnregisterCLSID( IDXGISurface::typeid->GUID );
	ComObject::UnregisterCLSID( IDXGISwapChain::typeid->GUID );
	ComObject::UnregisterCLSID( IDXGISwapChain1::typeid->GUID );
	ComObject::UnregisterCLSID( IDXGISwapChain2::typeid->GUID );
	ComObject::UnregisterCLSID( IDXGISwapChain3::typeid->GUID );
	ComObject::UnregisterCLSID( IDXGIAdapter::typeid->GUID );
	ComObject::UnregisterCLSID( IDXGIAdapter1::typeid->GUID );
	ComObject::UnregisterCLSID( IDXGIObject::typeid->GUID );
	ComObject::UnregisterCLSID( IDXGIOutput::typeid->GUID );
}