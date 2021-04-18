// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::ThirdParty::WinAPI;

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;

using namespace std;

using SC::ThirdParty::DirectX::D3D11;

void D3D11::CoInitialize()
{
	CD3D11Device::RegisterClass();
	CD3D11DeviceChild::RegisterClass();
	CD3D11DeviceContext::RegisterClass();
	CD3D11On12Device::RegisterClass();
	CD3D11Resource::RegisterClass();
}

void D3D11::CoUninitialize()
{
	ComObject::UnregisterCLSID( ID3D11Device::typeid->GUID );
	ComObject::UnregisterCLSID( ID3D11DeviceChild::typeid->GUID );
	ComObject::UnregisterCLSID( ID3D11DeviceContext::typeid->GUID );
	ComObject::UnregisterCLSID( ID3D11On12Device::typeid->GUID );
	ComObject::UnregisterCLSID( ID3D11Resource::typeid->GUID );
}

auto D3D11::D3D11CreateDevice(
	IDXGIAdapter^ pAdapter,
	D3DDriverType driverType,
	IPlatformHandle^ hSoftware,
	D3D11CreateDeviceFlags flags,
	IList<D3DFeatureLevel>^ featureLevels,
	[Out] D3DFeatureLevel% featureLevel,
	[Out] ID3D11DeviceContext^% ppImmediateContext
) -> ID3D11Device^
{
	vector<D3D_FEATURE_LEVEL> featureLevels_;
	if ( featureLevels != nullptr )
	{
		featureLevels_.resize( featureLevels->Count );
		for ( int i = 0; i < featureLevels->Count; ++i )
		{
			featureLevels_[i] = ( D3D_FEATURE_LEVEL )featureLevels[i];
		}
	}

	D3D_FEATURE_LEVEL choosed;

	ComPtr<::ID3D11Device> pDevice;
	ComPtr<::ID3D11DeviceContext> pImmediateContext;

	ComObject::HR( ::D3D11CreateDevice(
		Take<::IDXGIAdapter>( pAdapter ),
		( D3D_DRIVER_TYPE )driverType,
		hSoftware != nullptr ? ( HMODULE )hSoftware->GetHandle().ToPointer() : nullptr,
		( UINT )flags,
		featureLevels != nullptr ? featureLevels_.data() : nullptr,
		( UINT )featureLevels->Count,
		D3D11_SDK_VERSION,
		&pDevice,
		&choosed,
		&pImmediateContext
	) );

	featureLevel = ( D3DFeatureLevel )choosed;
	ppImmediateContext = gcnew CD3D11DeviceContext( pImmediateContext.Detach() );

	return gcnew CD3D11Device( pDevice.Detach() );
}

auto D3D11::D3D11On12CreateDevice(
	IUnknown^ pDevice12,
	D3D11CreateDeviceFlags flags,
	IList<D3DFeatureLevel>^ featureLevels,
	IList<IUnknown^>^ ppCommandQueues,
	uint_ nodeMask,
	[Out] D3DFeatureLevel% featureLevel,
	[Out] ID3D11DeviceContext^% ppImmediateContext
) -> ID3D11Device^
{
	vector<D3D_FEATURE_LEVEL> featureLevels_;
	if ( featureLevels != nullptr )
	{
		featureLevels_.resize( featureLevels->Count );
		for ( int i = 0; i < featureLevels->Count; ++i )
		{
			featureLevels_[i] = ( D3D_FEATURE_LEVEL )featureLevels[i];
		}
	}
	
	vector<::IUnknown*> ppCommandQueues_( ppCommandQueues->Count );
	for ( int i = 0; i < ppCommandQueues->Count; ++i )
	{
		ppCommandQueues_[i] = Take<::IUnknown>( ppCommandQueues[i] );
	}

	D3D_FEATURE_LEVEL choosed;

	ComPtr<::ID3D11Device> pDevice;
	ComPtr<::ID3D11DeviceContext> pImmediateContext;

	ComObject::HR( ::D3D11On12CreateDevice(
		Take<::IUnknown>( pDevice12 ),
		( UINT )flags,
		featureLevels != nullptr ? featureLevels_.data() : nullptr,
		( UINT )featureLevels_.size(),
		ppCommandQueues_.data(),
		( UINT )ppCommandQueues->Count,
		nodeMask,
		&pDevice,
		&pImmediateContext,
		&choosed
	) );

	featureLevel = ( D3DFeatureLevel )choosed;
	ppImmediateContext = gcnew CD3D11DeviceContext( pImmediateContext.Detach() );

	return gcnew CD3D11Device( pDevice.Detach() );
}