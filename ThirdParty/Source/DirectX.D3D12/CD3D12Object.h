// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3D12Object : CComObject, ID3D12Object
	{
		::ID3D12Object* pObject;

	public:
		CD3D12Object( ::ID3D12Object* pObject );
		static void RegisterClass();

		virtual void SetPrivateData( System::Guid riid, System::Object^ data );
		virtual System::Object^ GetPrivateData( System::Guid riid );
		virtual void SetName( System::String^ name );

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}