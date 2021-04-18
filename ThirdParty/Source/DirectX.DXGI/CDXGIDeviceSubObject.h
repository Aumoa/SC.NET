// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CDXGIDeviceSubObject : CDXGIObject, IDXGIDeviceSubObject
	{
		::IDXGIDeviceSubObject* pObj;

	public:
		CDXGIDeviceSubObject( ::IDXGIDeviceSubObject* pObj );
		static void RegisterClass();

		virtual void GetDevice( System::Guid riid, IUnknown^% ppUnknown );

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown )
		{
			return gcnew CDXGIDeviceSubObject( ( ::IDXGIDeviceSubObject* )pUnknown.ToPointer() );
		}
	};
}