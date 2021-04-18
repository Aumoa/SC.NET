// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CDXGISwapChain2 : CDXGISwapChain1, IDXGISwapChain2
	{
		::IDXGISwapChain2* pSwapChain;

	public:
		CDXGISwapChain2( ::IDXGISwapChain2* pSwapChain );
		static void RegisterClass();

		virtual void SetSourceSize( Engine::Runtime::Core::Numerics::Vector2 size );
		virtual Engine::Runtime::Core::Numerics::Vector2 GetSourceSize();
		virtual void SetMaximumFrameLatency( unsigned int maxLatency );
		virtual unsigned int GetMaximumFrameLatency();
		virtual WinAPI::IPlatformHandle^ GetFrameLatencyWaitableObject();
		virtual void SetMatrixTransform( Engine::Runtime::Core::Numerics::Matrix3x2 matrix );
		virtual Engine::Runtime::Core::Numerics::Matrix3x2 GetMatrixTransform();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}