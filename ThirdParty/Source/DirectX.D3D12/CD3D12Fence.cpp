// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::ThirdParty::DirectX;
using namespace SC::ThirdParty::WinAPI;

using namespace System;

CD3D12Fence::CD3D12Fence( ::ID3D12Fence* pFence ) : CD3D12Pageable( pFence )
{
	this->pFence = pFence;
}

void CD3D12Fence::RegisterClass()
{
	RegisterCLSID( ID3D12Fence::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

unsigned long long CD3D12Fence::GetCompletedValue()
{
	return pFence->GetCompletedValue();
}

void CD3D12Fence::SetEventOnCompletion( unsigned long long value, IPlatformHandle^ hEvent )
{
	HR( pFence->SetEventOnCompletion( value, hEvent->GetHandle().ToPointer() ) );
}

void CD3D12Fence::Signal( unsigned long long value )
{
	HR( pFence->Signal( value ) );
}

auto CD3D12Fence::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD3D12Fence( ( ::ID3D12Fence* )pUnknown.ToPointer() );
}