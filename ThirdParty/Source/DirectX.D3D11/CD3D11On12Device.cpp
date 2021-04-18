// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;
using namespace System::Collections::Generic;

using namespace std;

using SC::ThirdParty::DirectX::CD3D11On12Device;

CD3D11On12Device::CD3D11On12Device( ::ID3D11On12Device* pDevice11On12 ) : CComObject( pDevice11On12 )
{
	this->pDevice11On12 = pDevice11On12;
}

void CD3D11On12Device::RegisterClass()
{
	RegisterCLSID( ID3D11On12Device::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

void CD3D11On12Device::CreateWrappedResource( IUnknown^ pResource12, D3D11ResourceFlags resourceFlags, D3D12ResourceStates inState, D3D12ResourceStates outState, Guid riid, IUnknown^% ppResource11 )
{
	D3D11_RESOURCE_FLAGS flags{ };
	Assign( flags, resourceFlags );


	ComPtr<::IUnknown> pUnknown;
	HR( pDevice11On12->CreateWrappedResource( Take<::IUnknown>( pResource12 ), &flags, ( D3D12_RESOURCE_STATES )inState, ( D3D12_RESOURCE_STATES )outState, ToGUID( riid ), &pUnknown ) );

	ppResource11 = CoCreateInstance( riid, IntPtr( pUnknown.Detach() ) );
}

void CD3D11On12Device::AcquireWrappedResources( IList<ID3D11Resource^>^ ppResources )
{
	vector<::ID3D11Resource*> ppResources_( ppResources->Count );
	for ( int i = 0; i < ppResources->Count; ++i )
	{
		ppResources_[i] = Take<::ID3D11Resource>( ppResources[i] );
	}
	pDevice11On12->AcquireWrappedResources( ppResources_.data(), ( UINT )ppResources->Count );
}

void CD3D11On12Device::ReleaseWrappedResources( IList<ID3D11Resource^>^ ppResources )
{
	vector<::ID3D11Resource*> ppResources_( ppResources->Count );
	for ( int i = 0; i < ppResources->Count; ++i )
	{
		ppResources_[i] = Take<::ID3D11Resource>( ppResources[i] );
	}
	pDevice11On12->ReleaseWrappedResources( ppResources_.data(), ( UINT )ppResources->Count );
}

auto CD3D11On12Device::CoCreateInstance(IntPtr pUnknown) -> IUnknown^
{
	return gcnew CD3D11On12Device((::ID3D11On12Device*)pUnknown.ToPointer());
}