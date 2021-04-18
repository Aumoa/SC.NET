// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using SC::ThirdParty::DirectX::CDXGISwapChain;

CDXGISwapChain::CDXGISwapChain( ::IDXGISwapChain* pChain ) : CDXGIDeviceSubObject( pChain )
{
	this->pChain = pChain;
}

void CDXGISwapChain::RegisterClass()
{
	RegisterCLSID( IDXGISwapChain::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

void CDXGISwapChain::Present( unsigned int syncInterval, DXGIPresent flags )
{
	HR( pChain->Present( syncInterval, ( UINT )flags ) );
}

void CDXGISwapChain::GetBuffer( int index, Guid riid, IUnknown^% ppUnknown )
{
	ComPtr<::IUnknown> pRef;
	HR( pChain->GetBuffer( ( UINT )index, ToGUID( riid ), &pRef ) );

	if ( riid == IUnknown::typeid->GUID )
	{
		ppUnknown = gcnew CComObject( pRef.Detach() );
	}
	else
	{
		ppUnknown = CoCreateInstance( riid, IntPtr( pRef.Detach() ) );
	}
}

void CDXGISwapChain::SetFullscreenState( bool fullscreen, IDXGIOutput^ target )
{
	HR( pChain->SetFullscreenState( fullscreen, Take<::IDXGIOutput>( target ) ) );
}

bool CDXGISwapChain::GetFullscreenState( IDXGIOutput^% target )
{
	BOOL fullscreen;
	ComPtr<::IDXGIOutput> output;
	HR( pChain->GetFullscreenState( &fullscreen, &output ) );
	target = gcnew CDXGIOutput( output.Detach() );
	return fullscreen;
}

auto CDXGISwapChain::GetDesc() -> DXGISwapChainDesc
{
	DXGI_SWAP_CHAIN_DESC desc;
	HR( pChain->GetDesc( &desc ) );

	DXGISwapChainDesc desc_;
	Assign( desc_, desc );
	
	return desc_;
}

void CDXGISwapChain::ResizeBuffers( Nullable<unsigned int> bufferCount, int width, int height, Nullable<DXGIFormat> newFormat, Nullable<DXGISwapChainFlag> swapChainFlags )
{
	HR( pChain->ResizeBuffers(
		bufferCount.HasValue ? ( UINT )bufferCount.Value : 0,
		( UINT )width,
		( UINT )height,
		( DXGI_FORMAT )( newFormat.HasValue ? newFormat.Value : DXGIFormat::Unknown ),
		swapChainFlags.HasValue ? ( UINT )swapChainFlags.Value : 0
	) );
}

void CDXGISwapChain::ResizeTarget( DXGIModeDesc newTargetMode )
{
	DXGI_MODE_DESC desc;
	Assign( desc, newTargetMode );
	HR( pChain->ResizeTarget( &desc ) );
}

auto CDXGISwapChain::GetContainingOutput() -> IDXGIOutput^
{
	ComPtr<::IDXGIOutput> output;
	HR( pChain->GetContainingOutput( &output ) );
	return gcnew CDXGIOutput( output.Detach() );
}

auto CDXGISwapChain::GetFrameStatistics() -> DXGIFrameStatistics
{
	DXGI_FRAME_STATISTICS stats;
	HR( pChain->GetFrameStatistics( &stats ) );

	DXGIFrameStatistics stats_;
	Assign( stats_, stats );

	return stats_;
}

long long CDXGISwapChain::GetLastPresentCount()
{
	UINT last;
	HR( pChain->GetLastPresentCount( &last ) );
	return ( long long )last;
}

auto CDXGISwapChain::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CDXGISwapChain( ( ::IDXGISwapChain* )pUnknown.ToPointer() );
}