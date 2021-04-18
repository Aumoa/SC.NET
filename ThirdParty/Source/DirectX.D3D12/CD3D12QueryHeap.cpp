// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::ThirdParty::DirectX;

using namespace System;

CD3D12QueryHeap::CD3D12QueryHeap( ::ID3D12QueryHeap* pQueryHeap ) : CD3D12Pageable( pQueryHeap )
{
	this->pQueryHeap = pQueryHeap;
}

void CD3D12QueryHeap::RegisterClass()
{
	RegisterCLSID( ID3D12QueryHeap::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

auto CD3D12QueryHeap::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD3D12QueryHeap( ( ::ID3D12QueryHeap* )pUnknown.ToPointer() );
}