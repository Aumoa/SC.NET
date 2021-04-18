// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using SC::ThirdParty::DirectX::CD3D12DeviceChild;

CD3D12DeviceChild::CD3D12DeviceChild( ::ID3D12DeviceChild* pDeviceChild ) : CD3D12Object( pDeviceChild )
{
	this->pDeviceChild = pDeviceChild;
}

void CD3D12DeviceChild::RegisterClass()
{
	RegisterCLSID( ID3D12DeviceChild::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

void CD3D12DeviceChild::GetDevice( Guid riid, IUnknown^% device )
{
	ComPtr<::IUnknown> pRef;
	HR( pDeviceChild->GetDevice( ToGUID( riid ), &pRef ) );

	if ( riid == IUnknown::typeid->GUID )
	{
		device = gcnew CComObject( pRef.Detach() );
	}
	else
	{
		device = CoCreateInstance( riid, IntPtr( pRef.Detach() ) );
	}
}

auto CD3D12DeviceChild::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD3D12DeviceChild( ( ::ID3D12DeviceChild* )pUnknown.ToPointer() );
}