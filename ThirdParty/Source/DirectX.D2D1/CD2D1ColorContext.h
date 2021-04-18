// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD2D1ColorContext : CD2D1Resource, ID2D1ColorContext
	{
		::ID2D1ColorContext* pColorContext;

	public:
		CD2D1ColorContext( ::ID2D1ColorContext* pColorContext );
		static void RegisterClass();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}