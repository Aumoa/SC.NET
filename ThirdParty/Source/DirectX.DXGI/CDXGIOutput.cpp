// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;
using namespace SC::ThirdParty::WinAPI;

using SC::ThirdParty::DirectX::CDXGIOutput;

CDXGIOutput::CDXGIOutput( ::IDXGIOutput* pOutput ) : CDXGIObject( pOutput )
{
	this->pOutput = pOutput;
}

void CDXGIOutput::RegisterClass()
{
	RegisterCLSID( IDXGIOutput::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

void CDXGIOutput::GetParent( Guid iid, IUnknown^% ppUnknown )
{
	ComPtr<::IUnknown> pRef;
	HR( pOutput->QueryInterface( ToGUID( iid ), &pRef ) );

	if ( iid == IUnknown::typeid->GUID )
	{
		ppUnknown = gcnew CComObject( pRef.Detach() );
	}
	else
	{
		ppUnknown = CoCreateInstance( iid, IntPtr( pRef.Detach() ) );
	}
}

auto CDXGIOutput::GetDesc() -> DXGIOutputDesc
{
	DXGI_OUTPUT_DESC left;
	DXGIOutputDesc right;

	HR( pOutput->GetDesc( &left ) );

	right.DeviceName = gcnew String( left.DeviceName );
	right.DesktopCoordinates = ToRectangle( left.DesktopCoordinates );
	right.AttachedToDesktop = left.AttachedToDesktop;
	right.Rotation = ( DXGIModeRotation )left.Rotation;
	right.Monitor = gcnew GeneralHandle( IntPtr(left.Monitor) );

	return right;
}

auto CDXGIOutput::GetDisplayModeList( DXGIFormat enumFormat, DXGIEnumModeFlags flags ) -> cli::array<DXGIModeDesc>^
{
	UINT numModes = 0;
	HR( pOutput->GetDisplayModeList( ( DXGI_FORMAT )enumFormat, ( UINT )flags, &numModes, nullptr ) );

	std::vector<DXGI_MODE_DESC> modeDescs( numModes );
	HR( pOutput->GetDisplayModeList( ( DXGI_FORMAT )enumFormat, ( UINT )flags, &numModes, modeDescs.data() ) );

	auto modeArray = gcnew cli::array<DXGIModeDesc>( numModes );
	for ( int i = 0; i < modeArray->Length; ++i )
	{
		modeArray[i].Width = modeDescs[i].Width;
		modeArray[i].Height = modeDescs[i].Height;
		modeArray[i].RefreshRate.Numerator = modeDescs[i].RefreshRate.Numerator;
		modeArray[i].RefreshRate.Denominator = modeDescs[i].RefreshRate.Denominator;
		modeArray[i].Format = ( DXGIFormat )modeDescs[i].Format;
		modeArray[i].ScanlineOrdering = ( DXGIModeScanlineOrder )modeDescs[i].ScanlineOrdering;
		modeArray[i].Scaling = ( DXGIModeScaling )modeDescs[i].Scaling;
	}

	return modeArray;
}

auto CDXGIOutput::FindClosestMatchingMode( DXGIModeDesc modeToMatch, IUnknown^ concernedDevice ) -> DXGIModeDesc
{
	DXGI_MODE_DESC modeToMatch_;
	Assign( modeToMatch_, modeToMatch );
	
	DXGI_MODE_DESC closest;
	HR( pOutput->FindClosestMatchingMode( &modeToMatch_, &closest, ( ::IUnknown* )( ( CComObject^ )concernedDevice )->Handle.ToPointer() ) );

	DXGIModeDesc closest_;
	Assign( closest_, closest );

	return closest_;
}

void CDXGIOutput::WaitForVBlank()
{
	HR( pOutput->WaitForVBlank() );
}

void CDXGIOutput::TakeOwnership( IUnknown^ device, bool exclusive )
{
	HR( pOutput->TakeOwnership( Take<::IUnknown>( device ), exclusive ) );
}

void CDXGIOutput::ReleaseOwnership()
{
	pOutput->ReleaseOwnership();
}

auto CDXGIOutput::GetGammaControlCapabilities() -> DXGIGammaControlCapabilities
{
	DXGI_GAMMA_CONTROL_CAPABILITIES caps;
	HR( pOutput->GetGammaControlCapabilities( &caps ) );

	DXGIGammaControlCapabilities caps_;
	Assign( caps_, caps );
	return caps_;
}

void CDXGIOutput::SetGammaControl( DXGIGammaControl gammaControl )
{
	DXGI_GAMMA_CONTROL gammaControl_;
	Assign( gammaControl_, gammaControl );
	HR( pOutput->SetGammaControl( &gammaControl_ ) );
}

auto CDXGIOutput::GetGammaControl() -> DXGIGammaControl
{
	DXGI_GAMMA_CONTROL gammaControl;
	HR( pOutput->GetGammaControl( &gammaControl ) );
	DXGIGammaControl gammaControl_;
	Assign( gammaControl_, gammaControl );
	return gammaControl_;
}

void CDXGIOutput::SetDisplaySurface( IDXGISurface^ scanoutSurface )
{
	HR( pOutput->SetDisplaySurface( Take<::IDXGISurface>( scanoutSurface ) ) );
}

void CDXGIOutput::GetDisplaySurfaceData( IDXGISurface^ destination )
{
	HR( pOutput->GetDisplaySurfaceData( Take<::IDXGISurface>( destination ) ) );
}

auto CDXGIOutput::GetFrameStatistics() -> DXGIFrameStatistics
{
	DXGI_FRAME_STATISTICS left;
	DXGIFrameStatistics right;
	HR( pOutput->GetFrameStatistics( &left ) );
	Assign( right, left );
	return right;
}