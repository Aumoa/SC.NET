// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using SC::ThirdParty::DirectX::D3D12;

void D3D12::CoInitialize()
{
	CD3D12Object::RegisterClass();
	CD3D12DeviceChild::RegisterClass();
	CD3D12Pageable::RegisterClass();
	CD3D12PipelineState::RegisterClass();
	CD3D12Heap::RegisterClass();
	CD3D12Resource::RegisterClass();
	CD3D12RootSignature::RegisterClass();
	CD3D12QueryHeap::RegisterClass();
	CD3D12Fence::RegisterClass();
	CD3D12CommandAllocator::RegisterClass();
	CD3D12CommandList::RegisterClass();
	CD3D12CommandQueue::RegisterClass();
	CD3D12CommandSignature::RegisterClass();
	CD3D12GraphicsCommandList::RegisterClass();
	CD3D12DescriptorHeap::RegisterClass();
	CD3D12Device::RegisterClass();
	CD3D12Debug::RegisterClass();
}

void D3D12::CoUninitialize()
{
	ComObject::UnregisterCLSID( ID3D12Object::typeid->GUID );
	ComObject::UnregisterCLSID( ID3D12DeviceChild::typeid->GUID );
	ComObject::UnregisterCLSID( ID3D12Pageable::typeid->GUID );
	ComObject::UnregisterCLSID( ID3D12PipelineState::typeid->GUID );
	ComObject::UnregisterCLSID( ID3D12Heap::typeid->GUID );
	ComObject::UnregisterCLSID( ID3D12Resource::typeid->GUID );
	ComObject::UnregisterCLSID( ID3D12RootSignature::typeid->GUID );
	ComObject::UnregisterCLSID( ID3D12QueryHeap::typeid->GUID );
	ComObject::UnregisterCLSID( ID3D12Fence::typeid->GUID );
	ComObject::UnregisterCLSID( ID3D12CommandAllocator::typeid->GUID );
	ComObject::UnregisterCLSID( ID3D12CommandList::typeid->GUID );
	ComObject::UnregisterCLSID( ID3D12CommandQueue::typeid->GUID );
	ComObject::UnregisterCLSID( ID3D12CommandSignature::typeid->GUID );
	ComObject::UnregisterCLSID( ID3D12GraphicsCommandList::typeid->GUID );
	ComObject::UnregisterCLSID( ID3D12DescriptorHeap::typeid->GUID );
	ComObject::UnregisterCLSID( ID3D12Device::typeid->GUID );
	ComObject::UnregisterCLSID( ID3D12Debug::typeid->GUID );
}

auto D3D12::D3D12CreateDevice( IUnknown^ pAdapter, D3DFeatureLevel minimumFeatureLevel ) -> ID3D12Device^
{
	auto p = Take<::IUnknown>( pAdapter );
	ComPtr<::ID3D12Device> pDevice;
	ComObject::HR( ::D3D12CreateDevice( p, ( D3D_FEATURE_LEVEL )minimumFeatureLevel, IID_PPV_ARGS( &pDevice ) ) );
	return gcnew CD3D12Device( pDevice.Detach() );
}

auto D3D12::D3D12SerializeRootSignature( D3D12RootSignatureDesc rootSignature ) -> ID3DBlob^
{
	D3D12_ROOT_SIGNATURE_DESC left;
	Assign( left, rootSignature );

	ComPtr<::ID3DBlob> pBlob;
	ComPtr<::ID3DBlob> pError;
	HRESULT hr = ::D3D12SerializeRootSignature( &left, D3D_ROOT_SIGNATURE_VERSION_1_0, &pBlob, &pError );
	if ( FAILED( hr ) )
	{
		if ( pError )
		{
			OutputDebugStringA( ( const char* )pError->GetBufferPointer() );
		}
		ComObject::HR( hr );
	}

	Cleanup( left );
	return ( ID3DBlob^ )ComObject::CoCreateInstance( ID3DBlob::typeid->GUID, IntPtr( pBlob.Detach() ) );
}