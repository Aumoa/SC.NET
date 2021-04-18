// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CDXGIFactory : CDXGIObject, IDXGIFactory
	{
		::IDXGIFactory* pFactory;

		virtual System::Collections::IEnumerator^ GetEnumerator1() sealed = System::Collections::IEnumerable::GetEnumerator;

	public:
		CDXGIFactory( ::IDXGIFactory* pFactory );
		static void RegisterClass();

		virtual System::Collections::Generic::IEnumerator<IDXGIAdapter^>^ GetEnumerator();

		virtual void MakeWindowAssociation( WinAPI::IPlatformHandle^ windowHandle, DXGIWindowAssociation flags );
		virtual WinAPI::IPlatformHandle^ GetWindowAssociation();
		virtual IDXGISwapChain^ CreateSwapChain( IUnknown^ device, DXGISwapChainDesc desc );
		virtual IDXGIAdapter^ CreateSoftwareAdapter( WinAPI::IPlatformHandle^ hModule );

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
		static ::IDXGIFactory* CreateDXGIFactory();
	};
}