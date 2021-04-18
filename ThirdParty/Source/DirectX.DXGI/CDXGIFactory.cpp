// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;
using namespace System::Collections::Generic;

using namespace SC::ThirdParty::WinAPI;

using SC::ThirdParty::DirectX::CDXGIFactory;

System::Collections::IEnumerator^ CDXGIFactory::GetEnumerator1()
{
	return GetEnumerator();
}

CDXGIFactory::CDXGIFactory( ::IDXGIFactory* pFactory ) : CDXGIObject( pFactory )
{
	this->pFactory = pFactory;
}

void CDXGIFactory::RegisterClass()
{
	RegisterCLSID( IDXGIFactory::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

auto CDXGIFactory::GetEnumerator() -> IEnumerator<IDXGIAdapter^>^
{
	return gcnew AdapterEnumerator( pFactory );
}

void CDXGIFactory::MakeWindowAssociation( IPlatformHandle^ windowHandle, DXGIWindowAssociation flags )
{
	HR( pFactory->MakeWindowAssociation( ( HWND )windowHandle->GetHandle().ToPointer(), ( UINT )flags ) );
}

IPlatformHandle^ CDXGIFactory::GetWindowAssociation()
{
	HWND hwnd;
	HR( pFactory->GetWindowAssociation( &hwnd ) );

	return gcnew GeneralHandle( IntPtr( hwnd ) );
}

auto CDXGIFactory::CreateSwapChain( IUnknown^ device, DXGISwapChainDesc desc ) -> IDXGISwapChain^
{
	DXGI_SWAP_CHAIN_DESC desc_;
	Assign( desc_, desc );

	ComPtr<::IDXGISwapChain> pSwapChain;
	HR( pFactory->CreateSwapChain( Take<::IUnknown>( device ), &desc_, &pSwapChain ) );

	return gcnew CDXGISwapChain( pSwapChain.Detach() );
}

auto CDXGIFactory::CreateSoftwareAdapter( IPlatformHandle^ hModule ) -> IDXGIAdapter^
{
	ComPtr<::IDXGIAdapter> pAdapter;
	HR( pFactory->CreateSoftwareAdapter( ( HMODULE )hModule->GetHandle().ToPointer(), &pAdapter ) );
	return gcnew CDXGIAdapter( pAdapter.Detach() );
}

auto CDXGIFactory::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	if ( pUnknown == IntPtr::Zero )
	{
		return gcnew CDXGIFactory( CreateDXGIFactory() );
	}
	else
	{
		return gcnew CDXGIFactory( ( ::IDXGIFactory* )pUnknown.ToPointer() );
	}
}

::IDXGIFactory* CDXGIFactory::CreateDXGIFactory()
{
	ComPtr<::IDXGIFactory> pFactory;
	HR( ::CreateDXGIFactory( IID_PPV_ARGS( &pFactory ) ) );
	return pFactory.Detach();
}