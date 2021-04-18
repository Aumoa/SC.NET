// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::ThirdParty::DirectX;

using namespace System;

CD3D12CommandSignature::CD3D12CommandSignature( ::ID3D12CommandSignature* pCommandSignature ) : CD3D12Pageable( pCommandSignature )
{
	this->pCommandSignature = pCommandSignature;
}

void CD3D12CommandSignature::RegisterClass()
{
	RegisterCLSID( ID3D12CommandSignature::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

auto CD3D12CommandSignature::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD3D12CommandSignature( ( ::ID3D12CommandSignature* )pUnknown.ToPointer() );
}