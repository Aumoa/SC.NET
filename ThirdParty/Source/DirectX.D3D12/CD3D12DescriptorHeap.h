// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3D12DescriptorHeap : CD3D12Pageable, ID3D12DescriptorHeap
	{
		::ID3D12DescriptorHeap* pDescriptorHeap;

	public:
		CD3D12DescriptorHeap( ::ID3D12DescriptorHeap* pDescriptorHeap );
		static void RegisterClass();

		virtual D3D12DescriptorHeapDesc GetDesc();
		virtual D3D12CPUDescriptorHandle GetCPUDescriptorHandleForHeapStart();
		virtual D3D12GPUDescriptorHandle GetGPUDescriptorHandleForHeapStart();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}