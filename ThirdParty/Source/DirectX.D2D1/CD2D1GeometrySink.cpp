// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using SC::ThirdParty::DirectX::CD2D1GeometrySink;

CD2D1GeometrySink::CD2D1GeometrySink( ::ID2D1GeometrySink* pSink ) : CD2D1SimplifiedGeometrySink( pSink )
{
	this->pSink = pSink;
}

void CD2D1GeometrySink::RegisterClass()
{
	RegisterCLSID<ID2D1GeometrySink^>( gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

auto CD2D1GeometrySink::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD2D1GeometrySink( ( ::ID2D1GeometrySink* )pUnknown.ToPointer() );
}