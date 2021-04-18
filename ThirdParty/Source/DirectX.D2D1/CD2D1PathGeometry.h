// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD2D1PathGeometry : CD2D1Geometry, ID2D1PathGeometry
	{
		::ID2D1PathGeometry* pPath;

	public:
		CD2D1PathGeometry( ::ID2D1PathGeometry* pPath );
		static void RegisterClass();

		virtual ID2D1GeometrySink^ Open();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}