// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3D11Device : CComObject, ID3D11Device
	{
		::ID3D11Device* pDevice;

	public:
		CD3D11Device( ::ID3D11Device* pDevice );
		static void RegisterClass();

		virtual ID3D11DeviceContext^ GetImmediateContext();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}