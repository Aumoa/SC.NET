// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using SC::ThirdParty::DirectX::D2D1;

void D2D1::CoInitialize()
{
	CD2D1Resource::RegisterClass();
	CD2D1Image::RegisterClass();
	CD2D1Bitmap::RegisterClass();
	CD2D1Bitmap1::RegisterClass();
	CD2D1ColorContext::RegisterClass();
	CD2D1RenderTarget::RegisterClass();
	CD2D1DeviceContext::RegisterClass();
	CD2D1Device::RegisterClass();
	CD2D1Factory::RegisterClass();
	CD2D1Brush::RegisterClass();
	CD2D1SolidColorBrush::RegisterClass();
	CD2D1SimplifiedGeometrySink::RegisterClass();
	CD2D1GeometrySink::RegisterClass();
	CD2D1Geometry::RegisterClass();
	CD2D1PathGeometry::RegisterClass();
}

void D2D1::CoUninitialize()
{
	CComObject::UnregisterCLSID<ID2D1Resource^>();
	CComObject::UnregisterCLSID<ID2D1Image^>();
	CComObject::UnregisterCLSID<ID2D1Bitmap^>();
	CComObject::UnregisterCLSID<ID2D1Bitmap1^>();
	CComObject::UnregisterCLSID<ID2D1ColorContext^>();
	CComObject::UnregisterCLSID<ID2D1RenderTarget^>();
	CComObject::UnregisterCLSID<ID2D1DeviceContext^>();
	CComObject::UnregisterCLSID<ID2D1Device^>();
	CComObject::UnregisterCLSID<ID2D1Factory^>();
	CComObject::UnregisterCLSID<ID2D1Brush^>();
	CComObject::UnregisterCLSID<ID2D1SolidColorBrush^>();
	CComObject::UnregisterCLSID<ID2D1SimplifiedGeometrySink^>();
	CComObject::UnregisterCLSID<ID2D1GeometrySink^>();
	CComObject::UnregisterCLSID<ID2D1Geometry^>();
	CComObject::UnregisterCLSID<ID2D1PathGeometry^>();
}

auto D2D1::D2D1CreateDevice( IDXGIDevice^ dxgiDevice, D2D1CreationProperties creationProperties ) -> ID2D1Device^
{
	D2D1_CREATION_PROPERTIES creationProperties_;
	Assign( creationProperties_, creationProperties );

	ComPtr<::ID2D1Device> pDevice;
	CComObject::HR( ::D2D1CreateDevice( Take<::IDXGIDevice>( dxgiDevice ), creationProperties_, &pDevice ) );
	
	return gcnew CD2D1Device( pDevice.Detach() );
}