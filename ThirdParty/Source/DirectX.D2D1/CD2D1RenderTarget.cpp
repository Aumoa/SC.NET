// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::Engine::Runtime::Core::Numerics;

using namespace System;

using namespace std;

using SC::ThirdParty::DirectX::CD2D1RenderTarget;

CD2D1RenderTarget::CD2D1RenderTarget( ::ID2D1RenderTarget* pRenderTarget ) : CD2D1Resource( pRenderTarget )
{
	this->pRenderTarget = pRenderTarget;
}

void CD2D1RenderTarget::RegisterClass()
{
	RegisterCLSID<ID2D1RenderTarget^>( gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

void CD2D1RenderTarget::Clear( Nullable<Color> clearColor )
{
	D2D1_COLOR_F clearColor_;
	if ( clearColor.HasValue ) Assign( clearColor_, clearColor.Value );
	pRenderTarget->Clear( clearColor.HasValue ? &clearColor_ : nullptr );
}

void CD2D1RenderTarget::BeginDraw()
{
	pRenderTarget->BeginDraw();
}

void CD2D1RenderTarget::EndDraw()
{
	HR( pRenderTarget->EndDraw() );
}

void CD2D1RenderTarget::DrawLine( Vector2 point0, Vector2 point1, ID2D1Brush^ brush, float strokeWidth, ID2D1StrokeStyle^ strokeStyle )
{
	D2D1_POINT_2F point0_, point1_;
	Assign( point0_, point0 );
	Assign( point1_, point1 );
	pRenderTarget->DrawLine( point0_, point1_, Take<::ID2D1Brush>( brush ), strokeWidth, Take<::ID2D1StrokeStyle>( strokeStyle ) );
}

void CD2D1RenderTarget::DrawRectangle( Engine::Runtime::Core::Numerics::Rectangle rect, ID2D1Brush^ brush, float strokeWidth, ID2D1StrokeStyle^ strokeStyle )
{
	D2D1_RECT_F rect_;
	Assign( rect_, rect );
	pRenderTarget->DrawRectangle( rect_, Take<::ID2D1Brush>( brush ), strokeWidth, Take<::ID2D1StrokeStyle>( strokeStyle ) );
}

void CD2D1RenderTarget::FillRectangle( Engine::Runtime::Core::Numerics::Rectangle rect, ID2D1Brush^ brush )
{
	D2D1_RECT_F rect_;
	Assign( rect_, rect );
	pRenderTarget->FillRectangle( rect_, Take<::ID2D1Brush>( brush ) );
}

void CD2D1RenderTarget::DrawRoundedRectangle( D2D1RoundedRect roundedRect, ID2D1Brush^ brush, float strokeWidth, ID2D1StrokeStyle^ strokeStyle )
{
	D2D1_ROUNDED_RECT roundedRect_;
	Assign( roundedRect_, roundedRect );
	pRenderTarget->DrawRoundedRectangle( roundedRect_, Take<::ID2D1Brush>( brush ), strokeWidth, Take<::ID2D1StrokeStyle>( strokeStyle ) );
}

void CD2D1RenderTarget::FillRoundedRectangle( D2D1RoundedRect roundedRect, ID2D1Brush^ brush )
{
	D2D1_ROUNDED_RECT roundedRect_;
	Assign( roundedRect_, roundedRect );
	pRenderTarget->FillRoundedRectangle( roundedRect_, Take<::ID2D1Brush>( brush ) );
}

void CD2D1RenderTarget::DrawEllipse( D2D1Ellipse ellipse, ID2D1Brush^ brush, float strokeWidth, ID2D1StrokeStyle^ strokeStyle )
{
	D2D1_ELLIPSE ellipse_;
	Assign( ellipse_, ellipse );
	pRenderTarget->DrawEllipse( ellipse_, Take<::ID2D1Brush>( brush ), strokeWidth, Take<::ID2D1StrokeStyle>( strokeStyle ) );
}

void CD2D1RenderTarget::FillEllipse( D2D1Ellipse ellipse, ID2D1Brush^ brush )
{
	D2D1_ELLIPSE ellipse_;
	Assign( ellipse_, ellipse );
	pRenderTarget->FillEllipse( ellipse_, Take<::ID2D1Brush>( brush ) );
}

void CD2D1RenderTarget::DrawGeometry( ID2D1Geometry^ geometry, ID2D1Brush^ brush, float strokeWidth, ID2D1StrokeStyle^ strokeStyle )
{
	pRenderTarget->DrawGeometry( Take<::ID2D1Geometry>( geometry ), Take<::ID2D1Brush>( brush ), strokeWidth, Take<::ID2D1StrokeStyle>( strokeStyle ) );
}

void CD2D1RenderTarget::FillGeometry( ID2D1Geometry^ geometry, ID2D1Brush^ brush, ID2D1Brush^ opacityBrush )
{
	pRenderTarget->FillGeometry( Take<::ID2D1Geometry>( geometry ), Take<::ID2D1Brush>( brush ), Take<::ID2D1Brush>( opacityBrush ) );
}

void CD2D1RenderTarget::DrawText( String^ string, IDWriteTextFormat^ textFormat, Engine::Runtime::Core::Numerics::Rectangle layoutRect, ID2D1Brush^ defaultFillBrush, D2D1DrawTextOptions options, DWriteMeasuringMode measuringMode )
{
	wstring string_;
	Assign( string_, string );

	D2D1_RECT_F layoutRect_;
	Assign( layoutRect_, layoutRect );

	auto textFormat_ = Take<::IDWriteTextFormat>( textFormat );
	auto defaultFillBrush_ = Take<::ID2D1Brush>( defaultFillBrush );

	pRenderTarget->DrawText( string_.c_str(), ( UINT )string_.length(), textFormat_, layoutRect_, defaultFillBrush_, ( D2D1_DRAW_TEXT_OPTIONS )options, ( DWRITE_MEASURING_MODE )measuringMode );
}

void CD2D1RenderTarget::DrawTextLayout( Vector2 origin, IDWriteTextLayout^ textLayout, ID2D1Brush^ defaultFillBrush, D2D1DrawTextOptions options )
{
	D2D1_POINT_2F origin_;
	Assign( origin_, origin );

	auto textLayout_ = Take<::IDWriteTextLayout>( textLayout );
	auto defaultFillBrush_ = Take<::ID2D1Brush>( defaultFillBrush );

	pRenderTarget->DrawTextLayout( origin_, textLayout_, defaultFillBrush_, ( D2D1_DRAW_TEXT_OPTIONS )options );
}

void CD2D1RenderTarget::DrawGlyphRun( Vector2 baselineOrigin, DWriteGlyphRun glyphRun, ID2D1Brush^ foregroundBrush, DWriteMeasuringMode measuringMode )
{
	D2D1_POINT_2F baselineOrigin_;
	Assign( baselineOrigin_, baselineOrigin );

	DWRITE_GLYPH_RUN glyphRun_;
	Assign( glyphRun_, glyphRun );

	auto foregroundBrush_ = Take<::ID2D1Brush>( foregroundBrush );

	pRenderTarget->DrawGlyphRun( baselineOrigin_, &glyphRun_, foregroundBrush_, ( DWRITE_MEASURING_MODE )measuringMode );

	Cleanup( glyphRun_ );
}

void CD2D1RenderTarget::SetTransform( Matrix3x2 transform )
{
	D2D1_MATRIX_3X2_F transform_;
	Assign( transform_, transform );
	pRenderTarget->SetTransform( transform_ );
}

Matrix3x2 CD2D1RenderTarget::GetTransform()
{
	D2D1_MATRIX_3X2_F transform;
	pRenderTarget->GetTransform( &transform );
	Matrix3x2 transform_;
	Assign( transform_, transform );
	return transform_;
}

auto CD2D1RenderTarget::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD2D1RenderTarget( ( ::ID2D1RenderTarget* )pUnknown.ToPointer() );
}