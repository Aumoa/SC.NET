// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD2D1Geometry : CD2D1Resource, ID2D1Geometry
	{
		::ID2D1Geometry* pGeo;

	public:
		CD2D1Geometry( ::ID2D1Geometry* pGeo );
		static void RegisterClass();

		virtual Engine::Runtime::Core::Numerics::Rectangle GetBounds( System::Nullable<Engine::Runtime::Core::Numerics::Matrix3x2> worldTransform );
		virtual Engine::Runtime::Core::Numerics::Rectangle GetWidenedBounds( float strokeWidth, ID2D1StrokeStyle^ strokeStyle, System::Nullable<Engine::Runtime::Core::Numerics::Matrix3x2> worldTransform, float flatteningTolerance );

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}