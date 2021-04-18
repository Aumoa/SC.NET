// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::ThirdParty::DirectX;

using namespace System;

CD3D12Heap::CD3D12Heap( ::ID3D12Heap* pHeap ) : CD3D12Pageable( pHeap )
{
	this->pHeap = pHeap;
}

void CD3D12Heap::RegisterClass()
{
	RegisterCLSID( ID3D12Heap::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

D3D12HeapDesc CD3D12Heap::GetDesc()
{
	D3D12_HEAP_DESC desc = pHeap->GetDesc();
	D3D12HeapDesc desc_;

	Assign( desc_, desc );
	return desc_;
}

auto CD3D12Heap::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD3D12Heap( ( ::ID3D12Heap* )pUnknown.ToPointer() );
}