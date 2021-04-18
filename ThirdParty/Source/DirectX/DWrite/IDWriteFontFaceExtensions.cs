// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// <see cref="IDWriteFontFace"/> 인터페이스 개체에 대한 확장 메서드를 제공합니다.
    /// </summary>
    public static class IDWriteFontFaceExtensions
	{
		/// <summary>
		/// 글리프 런 정보의 외각선 정보를 D2D1 기하 모형 형태로 가져옵니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="glyphRun"> 글리프 런 정보를 전달합니다. </param>
		/// <param name="geometrySink"> 기하 정보를 받을 개체를 전달합니다. </param>
		/// <param name="isSideways"> <c>true</c>일 경우, 글리프가 반시계방향으로 90도 회전하고 수직 정보가 사용됩니다. </param>
		public static void GetGlyphRunOutline( this IDWriteFontFace @this, DWriteGlyphRun glyphRun, ID2D1SimplifiedGeometrySink geometrySink, bool isSideways = false )
			=> @this.GetGlyphRunOutline(
				glyphRun.FontEmSize,
				glyphRun.GlyphIndices,
				glyphRun.GlyphAdvances,
				glyphRun.GlyphOffsets,
				glyphRun.IsSideways,
				isSideways,
				geometrySink
				);
	}
}
