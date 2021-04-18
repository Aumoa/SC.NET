// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3D12Heap : CD3D12Pageable, ID3D12Heap
	{
		::ID3D12Heap* pHeap;
		
	public:
		CD3D12Heap( ::ID3D12Heap* pHeap );
		static void RegisterClass();

		virtual D3D12HeapDesc GetDesc();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}