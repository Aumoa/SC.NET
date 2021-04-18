// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::ThirdParty::DirectX;

using namespace System;

CD3D12CommandList::CD3D12CommandList( ::ID3D12CommandList* pCommandList ) : CD3D12DeviceChild( pCommandList )
{
	this->pCommandList = pCommandList;
}

void CD3D12CommandList::RegisterClass()
{
	RegisterCLSID( ID3D12CommandList::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

D3D12CommandListType CD3D12CommandList::GetType()
{
	return ( D3D12CommandListType )pCommandList->GetType();
}

auto CD3D12CommandList::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD3D12CommandList( ( ::ID3D12CommandList* )pUnknown.ToPointer() );
}