// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::ThirdParty::DirectX;

using namespace System;

CDXGISurface::CDXGISurface( ::IDXGISurface* pSur ) : CDXGIDeviceSubObject( pSur )
{
	this->pSur = pSur;
}

void CDXGISurface::RegisterClass()
{
	RegisterCLSID( IDXGISurface::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

DXGISurfaceDesc CDXGISurface::GetDesc()
{
	DXGI_SURFACE_DESC desc;
	HR( pSur->GetDesc( &desc ) );

	DXGISurfaceDesc desc_;
	Assign( desc_, desc );

	return desc_;
}

DXGIMappedRect CDXGISurface::Map( DXGIMapFlags flags )
{
	DXGI_MAPPED_RECT mapped;
	pSur->Map( &mapped, ( UINT )flags );

	DXGIMappedRect mapped_;
	mapped_.Pitch = mapped.Pitch;
	mapped_.pBits = IntPtr( mapped.pBits );
	return mapped_;
}

void CDXGISurface::Unmap()
{
	HR( pSur->Unmap() );
}

auto CDXGISurface::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CDXGISurface( ( ::IDXGISurface* )pUnknown.ToPointer() );
}