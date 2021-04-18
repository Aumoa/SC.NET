// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CDXGISwapChain3 : CDXGISwapChain2, IDXGISwapChain3
	{
		::IDXGISwapChain3* pSwapChain;

	public:
		CDXGISwapChain3( ::IDXGISwapChain3* pSwapChain );
		static void RegisterClass();

		virtual unsigned int GetCurrentBackBufferIndex();
		virtual DXGISwapChainColorSpaceSupportFlags CheckColorSpaceSupport( DXGIColorSpaceType colorSpace );
		virtual void SetColorSpace1( DXGIColorSpaceType colorSpace );
		virtual void ResizeBuffers1( System::Nullable<unsigned int> bufferCount, int width, int height, System::Nullable<DXGIFormat> newFormat, System::Nullable<DXGISwapChainFlag> swapChainFlag, System::Collections::Generic::IList<unsigned int>^ creationNodeMask, System::Collections::Generic::IList<IUnknown^>^ presentQueues );

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}