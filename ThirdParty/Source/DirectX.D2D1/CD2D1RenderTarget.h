// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD2D1RenderTarget : CD2D1Resource, ID2D1RenderTarget
	{
		::ID2D1RenderTarget* pRenderTarget;

	public:
		CD2D1RenderTarget( ::ID2D1RenderTarget* pRenderTarget );
		static void RegisterClass();

		virtual void Clear( System::Nullable<Engine::Runtime::Core::Numerics::Color> clearColor );
		virtual void BeginDraw();
		virtual void EndDraw();
		virtual void DrawLine( Engine::Runtime::Core::Numerics::Vector2 point0, Engine::Runtime::Core::Numerics::Vector2 point1, ID2D1Brush^ brush, float strokeWidth, ID2D1StrokeStyle^ strokeStyle );
		virtual void DrawRectangle( Engine::Runtime::Core::Numerics::Rectangle rect, ID2D1Brush^ brush, float strokeWidth, ID2D1StrokeStyle^ strokeStyle );
		virtual void FillRectangle( Engine::Runtime::Core::Numerics::Rectangle rect, ID2D1Brush^ brush );
		virtual void DrawRoundedRectangle( D2D1RoundedRect roundedRect, ID2D1Brush^ brush, float strokeWidth, ID2D1StrokeStyle^ strokeStyle );
		virtual void FillRoundedRectangle( D2D1RoundedRect roundedRect, ID2D1Brush^ brush );
		virtual void DrawEllipse( D2D1Ellipse ellipse, ID2D1Brush^ brush, float strokeWidth, ID2D1StrokeStyle^ strokeStyle );
		virtual void FillEllipse( D2D1Ellipse ellipse, ID2D1Brush^ brush );
		virtual void DrawGeometry( ID2D1Geometry^ geometry, ID2D1Brush^ brush, float strokeWidth, ID2D1StrokeStyle^ strokeStyle );
		virtual void FillGeometry( ID2D1Geometry^ geometry, ID2D1Brush^ brush, ID2D1Brush^ opacityBrush );
		virtual void DrawText( System::String^ string, IDWriteTextFormat^ textFormat, Engine::Runtime::Core::Numerics::Rectangle layoutRect, ID2D1Brush^ defaultFillBrush, D2D1DrawTextOptions options, DWriteMeasuringMode measuringMode );
		virtual void DrawTextLayout( Engine::Runtime::Core::Numerics::Vector2 origin, IDWriteTextLayout^ textLayout, ID2D1Brush^ defaultFillBrush, D2D1DrawTextOptions options );
		virtual void DrawGlyphRun( Engine::Runtime::Core::Numerics::Vector2 baselineOrigin, DWriteGlyphRun glyphRun, ID2D1Brush^ foregroundBrush, DWriteMeasuringMode measuringMode );
		virtual void SetTransform( Engine::Runtime::Core::Numerics::Matrix3x2 transform );
		virtual Engine::Runtime::Core::Numerics::Matrix3x2 GetTransform();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}