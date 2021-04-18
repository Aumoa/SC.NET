// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3D12Pageable : CD3D12DeviceChild, ID3D12Pageable
	{
		::ID3D12Pageable* pPageable;

	public:
		CD3D12Pageable( ::ID3D12Pageable* pPageable );
		static void RegisterClass();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}