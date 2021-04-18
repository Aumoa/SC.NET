// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CDXGISurface : CDXGIDeviceSubObject, IDXGISurface
	{
		::IDXGISurface* pSur;

	public:
		CDXGISurface( ::IDXGISurface* pSur );
		static void RegisterClass();

		virtual DXGISurfaceDesc GetDesc();
		virtual DXGIMappedRect Map( DXGIMapFlags flags );
		virtual void Unmap();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}