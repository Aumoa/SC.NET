// Copyright 2020 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
	/// <summary>
	/// D2D1 그리기 명령을 받을 수 있는 개체에 대한 공통 메서드를 제공합니다.
	/// </summary>
	[Guid( "2cd90694-12e2-11dc-9fed-001143a055f9" )]
	[ComVisible( true )]
	public interface ID2D1RenderTarget : ID2D1Resource
	{
		/// <summary>
		/// 대상으로 지정된 렌더 타겟 비트맵을 단색으로 초기화합니다.
		/// </summary>
		/// <param name="clearColor"> 초기화 색을 전달합니다. </param>
		void Clear( Color? clearColor = null );

		/// <summary>
		/// 렌더 타겟의 렌더링을 시작합니다.
		/// </summary>
		void BeginDraw();

		/// <summary>
		/// 렌더 타겟의 렌더링을 종료합니다.
		/// </summary>
		void EndDraw();

		/// <summary>
		/// 선분을 그립니다.
		/// </summary>
		/// <param name="point0"> 선분의 시작 위치를 전달합니다. </param>
		/// <param name="point1"> 선분의 종료 위치를 전달합니다. </param>
		/// <param name="brush"> 선분 내부를 채울 방식을 전달합니다. </param>
		/// <param name="strokeWidth"> 선분 굵기를 전달합니다. </param>
		/// <param name="strokeStyle"> 선분 스타일을 전달합니다. </param>
		void DrawLine( Vector2 point0, Vector2 point1, ID2D1Brush brush, float strokeWidth = 1.0f, ID2D1StrokeStyle strokeStyle = null );

		/// <summary>
		/// 사각형 테두리를 그립니다.
		/// </summary>
		/// <param name="rect"> 사각 영역을 전달합니다. </param>
		/// <param name="brush"> 선분 내부를 채울 방식을 전달합니다. </param>
		/// <param name="strokeWidth"> 선분 굵기를 전달합니다. </param>
		/// <param name="strokeStyle"> 선분 스타일을 전달합니다. </param>
		void DrawRectangle( Rectangle rect, ID2D1Brush brush, float strokeWidth = 1.0f, ID2D1StrokeStyle strokeStyle = null );

		/// <summary>
		/// 사각형 내부를 채웁니다.
		/// </summary>
		/// <param name="rect"> 사각 영역을 전달합니다. </param>
		/// <param name="brush"> 내부 영역을 채울 방식을 전달합니다. </param>
		void FillRectangle( Rectangle rect, ID2D1Brush brush );

		/// <summary>
		/// 둥근 사각형 테두리를 그립니다.
		/// </summary>
		/// <param name="roundedRect"> 둥근 사각 영역을 전달합니다. </param>
		/// <param name="brush"> 선분 내부를 채울 방식을 전달합니다. </param>
		/// <param name="strokeWidth"> 선분 굵기를 전달합니다. </param>
		/// <param name="strokeStyle"> 선분 스타일을 전달합니다. </param>
		void DrawRoundedRectangle( D2D1RoundedRect roundedRect, ID2D1Brush brush, float strokeWidth = 1.0f, ID2D1StrokeStyle strokeStyle = null );

		/// <summary>
		/// 둥근 사각형 내부를 채웁니다.
		/// </summary>
		/// <param name="roundedRect"> 둥근 사각 영역을 전달합니다. </param>
		/// <param name="brush"> 내부 영역을 채울 방식을 전달합니다. </param>
		void FillRoundedRectangle( D2D1RoundedRect roundedRect, ID2D1Brush brush );

		/// <summary>
		/// 타원 테두리를 그립니다.
		/// </summary>
		/// <param name="ellipse"> 타원 영역을 전달합니다. </param>
		/// <param name="brush"> 선분 내부를 채울 방식을 전달합니다. </param>
		/// <param name="strokeWidth"> 선분 굵기를 전달합니다. </param>
		/// <param name="strokeStyle"> 선분 스타일을 전달합니다. </param>
		void DrawEllipse( D2D1Ellipse ellipse, ID2D1Brush brush, float strokeWidth = 1.0f, ID2D1StrokeStyle strokeStyle = null );

		/// <summary>
		/// 타원 내부를 채웁니다.
		/// </summary>
		/// <param name="ellipse"> 타원 영역을 전달합니다. </param>
		/// <param name="brush"> 내부 영역을 채울 방식을 전달합니다. </param>
		void FillEllipse( D2D1Ellipse ellipse, ID2D1Brush brush );

		/// <summary>
		/// 기하 모형의 외각선을 그립니다.
		/// </summary>
		/// <param name="geometry"> 기하 모형을 전달합니다. </param>
		/// <param name="brush"> 선분 내부를 채울 방식을 전달합니다. </param>
		/// <param name="strokeWidth"> 선분 굵기를 전달합니다. </param>
		/// <param name="strokeStyle"> 선분 스타일을 전달합니다. </param>
		void DrawGeometry( ID2D1Geometry geometry, ID2D1Brush brush, float strokeWidth = 1.0f, ID2D1StrokeStyle strokeStyle = null );

		/// <summary>
		/// 기하 모형의 내부를 채웁니다.
		/// </summary>
		/// <param name="geometry"> 기하 모형을 전달합니다. </param>
		/// <param name="brush"> 내부 영역을 채울 방식을 전달합니다. </param>
		/// <param name="opacityBrush"> 선택적 알파 브러시를 전달합니다. </param>
		void FillGeometry( ID2D1Geometry geometry, ID2D1Brush brush, ID2D1Brush opacityBrush = null );

		/// <summary>
		/// 텍스트를 렌더링합니다.
		/// </summary>
		/// <param name="string"> 렌더링할 텍스트를 전달합니다. </param>
		/// <param name="textFormat"> 텍스트 포맷을 전달합니다. </param>
		/// <param name="layoutRect"> 텍스트 배치 레이아웃을 전달합니다. </param>
		/// <param name="defaultFillBrush"> 기본 채우기 브러시를 전달합니다. </param>
		/// <param name="options"> 텍스트 렌더링 옵션을 전달합니다. </param>
		/// <param name="measuringMode"> 측정 모드를 전달합니다. </param>
		void DrawText( string @string, IDWriteTextFormat textFormat, Rectangle layoutRect, ID2D1Brush defaultFillBrush, D2D1DrawTextOptions options = D2D1DrawTextOptions.None, DWriteMeasuringMode measuringMode = DWriteMeasuringMode.Natural );

		/// <summary>
		/// 텍스트 레이아웃 개체를 렌더링합니다.
		/// </summary>
		/// <param name="origin"> 렌더링 위치를 전달합니다. </param>
		/// <param name="textLayout"> 텍스트 레이아웃 개체를 전달합니다. </param>
		/// <param name="defaultFillBrush"> 기본 채우기 브러시를 전달합니다. </param>
		/// <param name="options"> 텍스트 렌더링 옵션을 전달합니다. </param>
		void DrawTextLayout( Vector2 origin, IDWriteTextLayout textLayout, ID2D1Brush defaultFillBrush, D2D1DrawTextOptions options );

		/// <summary>
		/// GlyphRun을 렌더링합니다.
		/// </summary>
		/// <param name="baselineOrigin"> 텍스트의 베이스라인 위치를 전달합니다. </param>
		/// <param name="glyphRun"> GlyphRun 정보를 전달합니다. </param>
		/// <param name="foregroundBrush"> 전경 채우기 브러시를 전달합니다. </param>
		/// <param name="measuringMode"> 측정 모드를 전달합니다. </param>
		void DrawGlyphRun( Vector2 baselineOrigin, DWriteGlyphRun glyphRun, ID2D1Brush foregroundBrush, DWriteMeasuringMode measuringMode = DWriteMeasuringMode.Natural );

		/// <summary>
		/// 현재 설정된 트랜스폼을 교체합니다.
		/// </summary>
		/// <param name="transform"> 새로 설정할 트랜스폼을 전달합니다. </param>
		void SetTransform( Matrix3x2 transform );

		/// <summary>
		/// 현재 설정된 트랜스폼을 가져옵니다.
		/// </summary>
		/// <returns> 트랜스폼이 반환됩니다. </returns>
		Matrix3x2 GetTransform();
	}
}
