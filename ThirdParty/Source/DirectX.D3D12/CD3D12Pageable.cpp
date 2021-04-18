// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::ThirdParty::DirectX;

using namespace System;

CD3D12Pageable::CD3D12Pageable( ::ID3D12Pageable* pPageable ) : CD3D12DeviceChild( pPageable )
{
	this->pPageable = pPageable;
}

void CD3D12Pageable::RegisterClass()
{
	RegisterCLSID( ID3D12Pageable::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

auto CD3D12Pageable::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD3D12Pageable( ( ::ID3D12Pageable* )pUnknown.ToPointer() );
}