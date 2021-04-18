// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;
using namespace SC::ThirdParty::WinAPI;

using SC::ThirdParty::DirectX::CDXGISwapChain1;

CDXGISwapChain1::CDXGISwapChain1( ::IDXGISwapChain1* pSwapChain ) : CDXGISwapChain( pSwapChain )
{
	this->pSwapChain = pSwapChain;
}

void CDXGISwapChain1::RegisterClass()
{
	RegisterCLSID( IDXGISwapChain1::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

auto CDXGISwapChain1::GetDesc1() -> DXGISwapChainDesc1
{
	DXGI_SWAP_CHAIN_DESC1 desc;
	HR( pSwapChain->GetDesc1( &desc ) );

	DXGISwapChainDesc1 desc_;
	Assign( desc_, desc );
	return desc_;
}

auto CDXGISwapChain1::GetFullscreenDesc() -> DXGISwapChainFullscreenDesc
{
	DXGI_SWAP_CHAIN_FULLSCREEN_DESC desc;
	HR( pSwapChain->GetFullscreenDesc( &desc ) );

	DXGISwapChainFullscreenDesc desc_;
	Assign( desc_, desc );

	return desc_;
}

auto CDXGISwapChain1::GetHwnd() -> IPlatformHandle^
{
	HWND hwnd;
	HR( pSwapChain->GetHwnd( &hwnd ) );

	return gcnew GeneralHandle( IntPtr( hwnd ) );
}

void CDXGISwapChain1::GetCoreWindow( Guid riid, IUnknown^% ppUnknown )
{
	ComPtr<::IUnknown> pUnknown;
	HR( pSwapChain->GetCoreWindow( ToGUID( riid ), &pUnknown ) );

	if ( riid == IUnknown::typeid->GUID )
	{
		ppUnknown = gcnew CComObject( pUnknown.Detach() );
	}
	else
	{
		ppUnknown = CoCreateInstance( riid, IntPtr( pUnknown.Detach() ) );
	}
}

void CDXGISwapChain1::Present1( unsigned int syncInterval, DXGIPresent presentFlags, DXGIPresentParameters presentParams )
{
	DXGI_PRESENT_PARAMETERS param;
	Assign( param, presentParams );
	HR( pSwapChain->Present1( syncInterval, ( UINT )presentFlags, &param ) );

	SafeDeleteArray( param.pDirtyRects );
	SafeDelete( param.pScrollRect );
	SafeDelete( param.pScrollOffset );
}

auto CDXGISwapChain1::GetRestrictToOutput() -> IDXGIOutput^
{
	ComPtr<::IDXGIOutput> pOutput;
	HR( pSwapChain->GetRestrictToOutput( &pOutput ) );
	return gcnew CDXGIOutput( pOutput.Detach() );
}

void CDXGISwapChain1::SetBackgroundColor( DXGIRGBA color )
{
	DXGI_RGBA color_;
	Assign( color_, color );
	HR( pSwapChain->SetBackgroundColor( &color_ ) );
}

auto CDXGISwapChain1::GetBackgroundColor() -> DXGIRGBA
{
	DXGI_RGBA color;
	HR( pSwapChain->GetBackgroundColor( &color ) );

	DXGIRGBA color_;
	Assign( color_, color );

	return color_;
}

void CDXGISwapChain1::SetRotation( DXGIModeRotation rotation )
{
	HR( pSwapChain->SetRotation( ( DXGI_MODE_ROTATION )rotation ) );
}

auto CDXGISwapChain1::GetRotation() -> DXGIModeRotation
{
	DXGI_MODE_ROTATION rotation;
	HR( pSwapChain->GetRotation( &rotation ) );
	return ( DXGIModeRotation )rotation;
}

bool CDXGISwapChain1::IsTemporaryMonoSupported::get()
{
	return pSwapChain->IsTemporaryMonoSupported();
}

auto CDXGISwapChain1::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CDXGISwapChain1( ( ::IDXGISwapChain1* )pUnknown.ToPointer() );
}