// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::ThirdParty::DirectX;

using namespace System;

CD3D12Resource::CD3D12Resource( ::ID3D12Resource* pResource ) : CD3D12Pageable( pResource )
{
	this->pResource = pResource;
}

void CD3D12Resource::RegisterClass()
{
	RegisterCLSID( ID3D12Resource::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

IntPtr CD3D12Resource::Map( unsigned int subresource, Nullable<D3D12Range> readRange )
{
	D3D12_RANGE range;
	if ( readRange.HasValue ) Assign( range, readRange.Value );

	void* pBlock = nullptr;
	HR( pResource->Map( subresource, readRange.HasValue ? &range : nullptr, &pBlock ) );

	return IntPtr( pBlock );
}

void CD3D12Resource::Unmap( unsigned int subresource, Nullable<D3D12Range> writtenRange )
{
	D3D12_RANGE range;
	if ( writtenRange.HasValue ) Assign( range, writtenRange.Value );

	pResource->Unmap( subresource, writtenRange.HasValue ? &range : nullptr );
}

D3D12ResourceDesc CD3D12Resource::GetDesc()
{
	D3D12_RESOURCE_DESC desc = pResource->GetDesc();
	D3D12ResourceDesc desc_;
	Assign( desc_, desc );
	return desc_;
}

unsigned long long CD3D12Resource::GetGPUVirtualAddress()
{
	return pResource->GetGPUVirtualAddress();
}

void CD3D12Resource::WriteToSubresource( unsigned int dstSubresource, Nullable<D3D12Box> dstBox, IntPtr pSrcData, unsigned int srcRowPitch, unsigned int srcDepthPitch )
{
	D3D12_BOX dst;
	if ( dstBox.HasValue ) Assign( dst, dstBox.Value );
	HR( pResource->WriteToSubresource( dstSubresource, dstBox.HasValue ? &dst : nullptr, pSrcData.ToPointer(), srcRowPitch, srcDepthPitch ) );
}

void CD3D12Resource::ReadFromSubresource( IntPtr pDstData, unsigned int dstRowPitch, unsigned int dstDepthPitch, unsigned int srcSubresource, Nullable<D3D12Box> srcBox )
{
	D3D12_BOX dst;
	if ( srcBox.HasValue ) Assign( dst, srcBox.Value );
	HR( pResource->ReadFromSubresource( pDstData.ToPointer(), dstRowPitch, dstDepthPitch, srcSubresource, srcBox.HasValue ? &dst : nullptr ) );
}

void CD3D12Resource::GetHeapProperties( D3D12HeapProperties% heapProperties, D3D12HeapFlags% heapFlags )
{
	D3D12_HEAP_PROPERTIES heapProp;
	D3D12_HEAP_FLAGS flags;

	HR( pResource->GetHeapProperties( &heapProp, &flags ) );

	Assign( heapProperties, heapProp );
	heapFlags = ( D3D12HeapFlags )flags;
}

auto CD3D12Resource::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD3D12Resource( ( ::ID3D12Resource* )pUnknown.ToPointer() );
}