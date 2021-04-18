// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD2D1SolidColorBrush : CD2D1Brush, ID2D1SolidColorBrush
	{
		::ID2D1SolidColorBrush* pSolidBrush;

	public:
		CD2D1SolidColorBrush( ::ID2D1SolidColorBrush* pSolidBrush );
		static void RegisterClass();

		virtual void SetColor( Engine::Runtime::Core::Numerics::Color color );
		virtual Engine::Runtime::Core::Numerics::Color GetColor();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}