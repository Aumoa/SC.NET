// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::ThirdParty::DirectX;

using namespace System;

CDXGIAdapter1::CDXGIAdapter1( ::IDXGIAdapter1* pAdapter ) : CDXGIAdapter( pAdapter )
{
	this->pAdapter = pAdapter;
}

void CDXGIAdapter1::RegisterClass()
{
	RegisterCLSID( IDXGIAdapter1::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

DXGIAdapterDesc1 CDXGIAdapter1::GetDesc1()
{
	DXGI_ADAPTER_DESC1 desc;
	DXGIAdapterDesc1 desc_;

	HR( pAdapter->GetDesc1( &desc ) );
	Assign( desc_, desc );

	return desc_;
}