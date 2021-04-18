// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3D12DeviceChild : CD3D12Object, ID3D12DeviceChild
	{
		::ID3D12DeviceChild* pDeviceChild;

	public:
		CD3D12DeviceChild( ::ID3D12DeviceChild* pDeviceChild );
		static void RegisterClass();

		virtual void GetDevice( System::Guid riid, IUnknown^% device );

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}