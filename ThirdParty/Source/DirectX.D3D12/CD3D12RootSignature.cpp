// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::ThirdParty::DirectX;

using namespace System;

CD3D12RootSignature::CD3D12RootSignature( ::ID3D12RootSignature* pRootSignature ) : CD3D12DeviceChild( pRootSignature )
{
	this->pRootSignature = pRootSignature;
}

void CD3D12RootSignature::RegisterClass()
{
	RegisterCLSID( ID3D12RootSignature::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

auto CD3D12RootSignature::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD3D12RootSignature( ( ::ID3D12RootSignature* )pUnknown.ToPointer() );
}