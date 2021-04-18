// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD2D1Factory : CComObject, ID2D1Factory
	{
		::ID2D1Factory* pFactory;

	public:
		CD2D1Factory( ::ID2D1Factory* pFactory );
		static void RegisterClass();

		virtual ID2D1PathGeometry^ CreatePathGeometry();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}