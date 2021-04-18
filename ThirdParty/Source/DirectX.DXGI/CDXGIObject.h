// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CDXGIObject : CComObject, IDXGIObject
	{
		::IDXGIObject* pDXGIObject;

	public:
		CDXGIObject( ::IDXGIObject* pObject );
		static void RegisterClass();

		virtual void SetPrivateData( System::Guid iid, System::Object^ data );
		virtual System::Object^ GetPrivateData( System::Guid iid );
		virtual void GetParent( System::Guid iid, IUnknown^% ppUnknown );

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}