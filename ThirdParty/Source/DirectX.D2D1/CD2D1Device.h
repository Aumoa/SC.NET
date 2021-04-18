// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD2D1Device : CD2D1Resource, ID2D1Device
	{
		::ID2D1Device* pDevice;

	public:
		CD2D1Device( ::ID2D1Device* pDevice );
		static void RegisterClass();

		virtual ID2D1DeviceContext^ CreateDeviceContext( D2D1DeviceContextOptions options );
		virtual ID2D1Factory^ GetFactory();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}