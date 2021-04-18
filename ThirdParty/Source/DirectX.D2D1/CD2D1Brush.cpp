// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::Engine::Runtime::Core::Numerics;

using namespace System;

using SC::ThirdParty::DirectX::CD2D1Brush;

CD2D1Brush::CD2D1Brush( ::ID2D1Brush* pBrush ) : CD2D1Resource( pBrush )
{
	this->pBrush = pBrush;
}

void CD2D1Brush::RegisterClass()
{
	RegisterCLSID<ID2D1Brush^>( gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

void CD2D1Brush::SetOpacity( float opacity )
{
	pBrush->SetOpacity( opacity );
}

void CD2D1Brush::SetTransform( Matrix3x2 transform )
{
	D2D1_MATRIX_3X2_F transform_;
	Assign( transform_, transform );
	pBrush->SetTransform( transform_ );
}

float CD2D1Brush::GetOpacity()
{
	return pBrush->GetOpacity();
}

Matrix3x2 CD2D1Brush::GetTransform()
{
	D2D1_MATRIX_3X2_F transform;
	pBrush->GetTransform( &transform );

	Matrix3x2 transform_;
	Assign( transform_, transform );

	return transform_;
}

auto CD2D1Brush::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD2D1Brush( ( ::ID2D1Brush* )pUnknown.ToPointer() );
}