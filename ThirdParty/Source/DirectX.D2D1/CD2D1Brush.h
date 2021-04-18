// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD2D1Brush : CD2D1Resource, ID2D1Brush
	{
		::ID2D1Brush* pBrush;

	public:
		CD2D1Brush( ::ID2D1Brush* pBrush );
		static void RegisterClass();

		virtual void SetOpacity( float opacity );
		virtual void SetTransform( Engine::Runtime::Core::Numerics::Matrix3x2 transform);
		virtual float GetOpacity();
		virtual Engine::Runtime::Core::Numerics::Matrix3x2 GetTransform();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}