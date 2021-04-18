// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3D12QueryHeap : CD3D12Pageable, ID3D12QueryHeap
	{
		::ID3D12QueryHeap* pQueryHeap;

	public:
		CD3D12QueryHeap( ::ID3D12QueryHeap* pQueryHeap );
		static void RegisterClass();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}