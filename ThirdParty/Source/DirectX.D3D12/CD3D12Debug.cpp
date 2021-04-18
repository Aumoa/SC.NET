// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using SC::ThirdParty::DirectX::CD3D12Debug;

CD3D12Debug::CD3D12Debug( ::ID3D12Debug* pDebug ) : CComObject( pDebug )
{
	this->pDebug = pDebug;
}

void CD3D12Debug::RegisterClass()
{
	RegisterCLSID( ID3D12Debug::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

void CD3D12Debug::EnableDebugLayer()
{
	pDebug->EnableDebugLayer();
}

auto CD3D12Debug::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	if ( pUnknown == IntPtr::Zero )
	{
		ComPtr<::ID3D12Debug> pDebug;
		HR( ::D3D12GetDebugInterface( IID_PPV_ARGS( &pDebug ) ) );
		return gcnew CD3D12Debug( pDebug.Detach() );
	}
	else
	{
		return gcnew CD3D12Debug( ( ::ID3D12Debug* )pUnknown.ToPointer() );
	}
}