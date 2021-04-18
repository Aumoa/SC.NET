// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD2D1SimplifiedGeometrySink : CComObject, ID2D1SimplifiedGeometrySink
	{
		::ID2D1SimplifiedGeometrySink* pSink;

	public:
		CD2D1SimplifiedGeometrySink( ::ID2D1SimplifiedGeometrySink* pSink );
		static void RegisterClass();

		virtual void SetFillMode( D2D1FillMode fillMode );
		virtual void Close();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}