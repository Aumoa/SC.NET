// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using SC::ThirdParty::DirectX::CD2D1SimplifiedGeometrySink;

CD2D1SimplifiedGeometrySink::CD2D1SimplifiedGeometrySink( ::ID2D1SimplifiedGeometrySink* pSink ) : CComObject( pSink )
{
	this->pSink = pSink;
}

void CD2D1SimplifiedGeometrySink::RegisterClass()
{
	RegisterCLSID<ID2D1SimplifiedGeometrySink^>( gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

void CD2D1SimplifiedGeometrySink::SetFillMode( D2D1FillMode fillMode )
{
	pSink->SetFillMode( ( D2D1_FILL_MODE )fillMode );
}

void CD2D1SimplifiedGeometrySink::Close()
{
	HR( pSink->Close() );
}

auto CD2D1SimplifiedGeometrySink::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD2D1SimplifiedGeometrySink( ( ::ID2D1SimplifiedGeometrySink* )pUnknown.ToPointer() );
}