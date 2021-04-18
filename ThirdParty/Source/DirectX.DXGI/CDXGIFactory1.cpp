// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using SC::ThirdParty::DirectX::CDXGIFactory1;

CDXGIFactory1::CDXGIFactory1( ::IDXGIFactory1* pFactory ) : CDXGIFactory( pFactory )
{
	this->pFactory = pFactory;
}

void CDXGIFactory1::RegisterClass()
{
	RegisterCLSID( IDXGIFactory1::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

bool CDXGIFactory1::IsCurrent::get()
{
	return pFactory->IsCurrent();
}

auto CDXGIFactory1::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	if ( pUnknown == IntPtr::Zero )
	{
		return gcnew CDXGIFactory1( CreateDXGIFactory() );
	}
	else
	{
		return gcnew CDXGIFactory1( ( ::IDXGIFactory1* )pUnknown.ToPointer() );
	}
}

::IDXGIFactory1* CDXGIFactory1::CreateDXGIFactory()
{
	ComPtr<::IDXGIFactory1> pFactory;
	HR( ::CreateDXGIFactory( IID_PPV_ARGS( &pFactory ) ) );
	return pFactory.Detach();
}