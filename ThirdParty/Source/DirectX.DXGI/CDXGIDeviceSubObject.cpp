// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using SC::ThirdParty::DirectX::CDXGIDeviceSubObject;

CDXGIDeviceSubObject::CDXGIDeviceSubObject( ::IDXGIDeviceSubObject* pObj ) : CDXGIObject( pObj )
{
	this->pObj = pObj;
}

void CDXGIDeviceSubObject::RegisterClass()
{
	RegisterCLSID( IDXGIDeviceSubObject::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

void CDXGIDeviceSubObject::GetDevice( Guid riid, IUnknown^% ppUnknown )
{
	ComPtr<::IUnknown> pRef;
	HR( pObj->GetDevice( ToGUID( riid ), &pRef ) );

	if ( riid == IUnknown::typeid->GUID )
	{
		ppUnknown = gcnew CComObject( pRef.Detach() );
	}
	else
	{
		ppUnknown = CoCreateInstance( riid, IntPtr( pRef.Detach() ) );
	}
}