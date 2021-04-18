// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD2D1Image : CD2D1Resource, ID2D1Image
	{
		::ID2D1Image* pImage;

	public:
		CD2D1Image( ::ID2D1Image* pImage );
		static void RegisterClass();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}