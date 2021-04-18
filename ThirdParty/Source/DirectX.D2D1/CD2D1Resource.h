// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD2D1Resource : CComObject, ID2D1Resource
	{
		::ID2D1Resource* pResource;

	public:
		CD2D1Resource( ::ID2D1Resource* pResource );
		static void RegisterClass();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}