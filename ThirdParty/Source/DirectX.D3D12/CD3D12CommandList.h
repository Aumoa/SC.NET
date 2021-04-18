// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3D12CommandList : CD3D12DeviceChild, ID3D12CommandList
	{
		::ID3D12CommandList* pCommandList;

	public:
		CD3D12CommandList( ::ID3D12CommandList* pCommandList );
		static void RegisterClass();

		virtual D3D12CommandListType GetType();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}