// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3D12RootSignature : CD3D12DeviceChild, ID3D12RootSignature
	{
		::ID3D12RootSignature* pRootSignature;

	public:
		CD3D12RootSignature( ::ID3D12RootSignature* pRootSignature );
		static void RegisterClass();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}