// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CDXGIFactory1 : CDXGIFactory, IDXGIFactory1
	{
		::IDXGIFactory1* pFactory;

	public:
		CDXGIFactory1( ::IDXGIFactory1* pFactory );
		static void RegisterClass();

		property bool IsCurrent
		{
			virtual bool get();
		}

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
		static ::IDXGIFactory1* CreateDXGIFactory();
	};
}