// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CDXGIAdapter1 : CDXGIAdapter, IDXGIAdapter1
	{
		::IDXGIAdapter1* pAdapter;

	public:
		CDXGIAdapter1( ::IDXGIAdapter1* pAdapter );
		static void RegisterClass();

		virtual DXGIAdapterDesc1 GetDesc1();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown )
		{
			return gcnew CDXGIAdapter1( ( ::IDXGIAdapter1* )pUnknown.ToPointer() );
		}
	};
}