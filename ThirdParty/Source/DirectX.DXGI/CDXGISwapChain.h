// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CDXGISwapChain : CDXGIDeviceSubObject, IDXGISwapChain
	{
	private:
		::IDXGISwapChain* pChain;

	public:
		CDXGISwapChain( ::IDXGISwapChain* pChain );
		static void RegisterClass();

		virtual void Present( unsigned int syncInterval, DXGIPresent flags );
		virtual void GetBuffer( int index, System::Guid riid, IUnknown^% ppUnknown );
		virtual void SetFullscreenState( bool fullscreen, IDXGIOutput^ target );
		virtual bool GetFullscreenState( IDXGIOutput^% target );
		virtual DXGISwapChainDesc GetDesc();
		virtual void ResizeBuffers( System::Nullable<unsigned int> bufferCount, int width, int height, System::Nullable<DXGIFormat> newFormat, System::Nullable<DXGISwapChainFlag> swapChainFlags );
		virtual void ResizeTarget( DXGIModeDesc newTargetMode );
		virtual IDXGIOutput^ GetContainingOutput();
		virtual DXGIFrameStatistics GetFrameStatistics();
		virtual long long GetLastPresentCount();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}