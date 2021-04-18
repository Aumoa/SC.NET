// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using SC::ThirdParty::DirectX::CD2D1ColorContext;

CD2D1ColorContext::CD2D1ColorContext( ::ID2D1ColorContext* pColorContext ) : CD2D1Resource( pColorContext )
{
	this->pColorContext = pColorContext;
}

void CD2D1ColorContext::RegisterClass()
{
	RegisterCLSID<ID2D1ColorContext^>( gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

auto CD2D1ColorContext::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD2D1ColorContext( ( ::ID2D1ColorContext* )pUnknown.ToPointer() );
}