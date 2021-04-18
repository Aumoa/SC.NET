// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3D11DeviceChild : CComObject, ID3D11DeviceChild
	{
		::ID3D11DeviceChild* pDeviceChild;

	public:
		CD3D11DeviceChild( ::ID3D11DeviceChild* pDeviceChild );
		static void RegisterClass();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}