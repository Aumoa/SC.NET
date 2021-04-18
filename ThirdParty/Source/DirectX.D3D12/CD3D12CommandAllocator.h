// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3D12CommandAllocator : CD3D12Pageable, ID3D12CommandAllocator
	{
		::ID3D12CommandAllocator* pCommandAllocator;

	public:
		CD3D12CommandAllocator( ::ID3D12CommandAllocator* pCommandAllocator );
		static void RegisterClass();

		virtual void Reset();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}