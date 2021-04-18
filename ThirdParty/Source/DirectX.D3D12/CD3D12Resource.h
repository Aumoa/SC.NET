// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3D12Resource : CD3D12Pageable, ID3D12Resource
	{
		::ID3D12Resource* pResource;

	public:
		CD3D12Resource( ::ID3D12Resource* pResource );
		static void RegisterClass();

		virtual System::IntPtr Map( unsigned int subresource, System::Nullable<D3D12Range> readRange );
		virtual void Unmap( unsigned int subresource, System::Nullable<D3D12Range> writtenRange );
		virtual D3D12ResourceDesc GetDesc();
		virtual unsigned long long GetGPUVirtualAddress();
		virtual void WriteToSubresource( unsigned int dstSubresource, System::Nullable<D3D12Box> dstBox, System::IntPtr pSrcData, unsigned int srcRowPitch, unsigned int srcDepthPitch );
		virtual void ReadFromSubresource( System::IntPtr pDstData, unsigned int dstRowPitch, unsigned int dstDepthPitch, unsigned int srcSubresource, System::Nullable<D3D12Box> srcBox );
		virtual void GetHeapProperties( D3D12HeapProperties% heapProperties, D3D12HeapFlags% heapFlags );

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}