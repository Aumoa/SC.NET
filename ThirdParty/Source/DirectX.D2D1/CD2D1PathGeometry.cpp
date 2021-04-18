// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using SC::ThirdParty::DirectX::CD2D1PathGeometry;

CD2D1PathGeometry::CD2D1PathGeometry( ::ID2D1PathGeometry* pPath ) : CD2D1Geometry( pPath )
{
	this->pPath = pPath;
}

void CD2D1PathGeometry::RegisterClass()
{
	RegisterCLSID<ID2D1PathGeometry^>( gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

auto CD2D1PathGeometry::Open() -> ID2D1GeometrySink^
{
	ComPtr<::ID2D1GeometrySink> pSink;
	HR( pPath->Open( &pSink ) );
	return gcnew CD2D1GeometrySink( pSink.Detach() );
}

auto CD2D1PathGeometry::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD2D1PathGeometry( ( ::ID2D1PathGeometry* )pUnknown.ToPointer() );
}