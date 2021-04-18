// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;
using namespace System::Collections::Generic;

using SC::ThirdParty::DirectX::CDXGIDevice;
using SC::ThirdParty::DirectX::DXGIResidency;

CDXGIDevice::CDXGIDevice( ::IDXGIDevice* pDevice ) : CDXGIObject( pDevice )
{
	this->pDevice = pDevice;
}

void CDXGIDevice::RegisterClass()
{
	RegisterCLSID( IDXGIDevice::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

auto CDXGIDevice::GetAdapter() -> IDXGIAdapter^
{
	ComPtr<::IDXGIAdapter> pAdapter;
	HR( pDevice->GetAdapter( &pAdapter ) );
	return gcnew CDXGIAdapter( pAdapter.Detach() );
}

cli::array<DXGIResidency>^ CDXGIDevice::QueryResourceResidency( IList<IUnknown^>^ unknowns )
{
	std::vector<::IUnknown*> ppUnknowns( unknowns->Count );

	for ( int i = 0; i < unknowns->Count; ++i )
	{
		ppUnknowns[i] = Take<::IUnknown>( unknowns[i] );
	}

	std::vector<DXGI_RESIDENCY> residency( unknowns->Count );
	HR( pDevice->QueryResourceResidency( ppUnknowns.data(), residency.data(), ( UINT )residency.size() ) );

	auto residency_ = gcnew cli::array<DXGIResidency>( unknowns->Count );
	for ( int i = 0; i < unknowns->Count; ++i )
	{
		residency_[i] = ( DXGIResidency )residency[i];
	}

	return residency_;
}

void CDXGIDevice::SetGPUThreadPriority( int priority )
{
	HR( pDevice->SetGPUThreadPriority( priority ) );
}

int CDXGIDevice::GetGPUThreadPriority()
{
	INT priority;
	HR( pDevice->GetGPUThreadPriority( &priority ) );
	return priority;
}