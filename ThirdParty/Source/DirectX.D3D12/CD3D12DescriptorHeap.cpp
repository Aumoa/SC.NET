// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::ThirdParty::DirectX;

using namespace System;

CD3D12DescriptorHeap::CD3D12DescriptorHeap( ::ID3D12DescriptorHeap* pDescriptorHeap ) : CD3D12Pageable( pDescriptorHeap )
{
	this->pDescriptorHeap = pDescriptorHeap;
}

void CD3D12DescriptorHeap::RegisterClass()
{
	RegisterCLSID( ID3D12DescriptorHeap::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

D3D12DescriptorHeapDesc CD3D12DescriptorHeap::GetDesc()
{
	D3D12_DESCRIPTOR_HEAP_DESC desc = pDescriptorHeap->GetDesc();
	D3D12DescriptorHeapDesc desc_;
	Assign( desc_, desc );

	return desc_;
}

D3D12CPUDescriptorHandle CD3D12DescriptorHeap::GetCPUDescriptorHandleForHeapStart()
{
	return D3D12CPUDescriptorHandle( IntPtr( ( void* )pDescriptorHeap->GetCPUDescriptorHandleForHeapStart().ptr ) );
}

D3D12GPUDescriptorHandle CD3D12DescriptorHeap::GetGPUDescriptorHandleForHeapStart()
{
	return D3D12GPUDescriptorHandle( pDescriptorHeap->GetGPUDescriptorHandleForHeapStart().ptr );
}

auto CD3D12DescriptorHeap::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD3D12DescriptorHeap( ( ::ID3D12DescriptorHeap* )pUnknown.ToPointer() );
}