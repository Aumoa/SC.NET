// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3D11Resource : CD3D11DeviceChild, ID3D11Resource
	{
		::ID3D11Resource* pResource;

	public:
		CD3D11Resource( ::ID3D11Resource* pResource );
		static void RegisterClass();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}