// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD2D1GeometrySink : CD2D1SimplifiedGeometrySink, ID2D1GeometrySink
	{
		::ID2D1GeometrySink* pSink;

	public:
		CD2D1GeometrySink( ::ID2D1GeometrySink* pSink );
		static void RegisterClass();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}