// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::ThirdParty::DirectX;

using namespace System;

CD3D12CommandAllocator::CD3D12CommandAllocator( ::ID3D12CommandAllocator* pCommandAllocator ) : CD3D12Pageable( pCommandAllocator )
{
	this->pCommandAllocator = pCommandAllocator;
}

void CD3D12CommandAllocator::RegisterClass()
{
	RegisterCLSID( ID3D12CommandAllocator::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

void CD3D12CommandAllocator::Reset()
{
	HR( pCommandAllocator->Reset() );
}

auto CD3D12CommandAllocator::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD3D12CommandAllocator( ( ::ID3D12CommandAllocator* )pUnknown.ToPointer() );
}