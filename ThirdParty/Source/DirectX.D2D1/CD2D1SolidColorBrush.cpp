// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::Engine::Runtime::Core::Numerics;

using namespace System;

using SC::ThirdParty::DirectX::CD2D1SolidColorBrush;

CD2D1SolidColorBrush::CD2D1SolidColorBrush( ::ID2D1SolidColorBrush* pSolidBrush ) : CD2D1Brush( pSolidBrush )
{
	this->pSolidBrush = pSolidBrush;
}

void CD2D1SolidColorBrush::RegisterClass()
{
	RegisterCLSID<ID2D1SolidColorBrush^>( gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

void CD2D1SolidColorBrush::SetColor( Color color )
{
	D2D1_COLOR_F color_;
	Assign( color_, color );
	pSolidBrush->SetColor( color_ );
}

Color CD2D1SolidColorBrush::GetColor()
{
	Color color_;
	auto color = pSolidBrush->GetColor();
	Assign( color_, color );

	return color_;
}

auto CD2D1SolidColorBrush::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD2D1SolidColorBrush( ( ::ID2D1SolidColorBrush* )pUnknown.ToPointer() );
}