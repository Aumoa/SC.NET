// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::Engine::Runtime::Core::Numerics;

using namespace System;

using SC::ThirdParty::DirectX::CD2D1Geometry;

CD2D1Geometry::CD2D1Geometry( ::ID2D1Geometry* pGeo ) : CD2D1Resource( pGeo )
{
	this->pGeo = pGeo;
}

void CD2D1Geometry::RegisterClass()
{
	RegisterCLSID<ID2D1Geometry^>( gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

SC::Engine::Runtime::Core::Numerics::Rectangle CD2D1Geometry::GetBounds( Nullable<Matrix3x2> worldTransform )
{
	throw gcnew NotImplementedException();
}

SC::Engine::Runtime::Core::Numerics::Rectangle CD2D1Geometry::GetWidenedBounds( float strokeWidth, ID2D1StrokeStyle^ strokeStyle, Nullable<Matrix3x2> worldTransform, float flatteningTolerance )
{
	throw gcnew NotImplementedException();
}

auto CD2D1Geometry::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD2D1Geometry( ( ::ID2D1Geometry* )pUnknown.ToPointer() );
}