// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CDXGISwapChain1 : CDXGISwapChain, IDXGISwapChain1
	{
		::IDXGISwapChain1* pSwapChain;

	public:
		CDXGISwapChain1( ::IDXGISwapChain1* pSwapChain );
		static void RegisterClass();

		virtual DXGISwapChainDesc1 GetDesc1();
		virtual DXGISwapChainFullscreenDesc GetFullscreenDesc();
		virtual WinAPI::IPlatformHandle^ GetHwnd();
		virtual void GetCoreWindow( System::Guid riid, IUnknown^% ppUnknown );
		virtual void Present1( unsigned int syncInterval, DXGIPresent presentFlags, DXGIPresentParameters presentParams );
		virtual IDXGIOutput^ GetRestrictToOutput();
		virtual void SetBackgroundColor( DXGIRGBA color );
		virtual DXGIRGBA GetBackgroundColor();
		virtual void SetRotation( DXGIModeRotation rotation );
		virtual DXGIModeRotation GetRotation();

		property bool IsTemporaryMonoSupported
		{
			virtual bool get();
		}

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}