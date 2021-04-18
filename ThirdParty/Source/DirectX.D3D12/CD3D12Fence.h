// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3D12Fence : CD3D12Pageable, ID3D12Fence
	{
		::ID3D12Fence* pFence;

	public:
		CD3D12Fence( ::ID3D12Fence* pFence );
		static void RegisterClass();

		virtual unsigned long long GetCompletedValue();
		virtual void SetEventOnCompletion( unsigned long long value, WinAPI::IPlatformHandle^ hEvent );
		virtual void Signal( unsigned long long value );

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}