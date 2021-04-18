// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3D11DeviceContext : CD3D11DeviceChild, ID3D11DeviceContext
	{
		::ID3D11DeviceContext* pDeviceContext;

	public:
		CD3D11DeviceContext( ::ID3D11DeviceContext* pDeviceContext );
		static void RegisterClass();

		virtual void ClearState();
		virtual void Flush();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}