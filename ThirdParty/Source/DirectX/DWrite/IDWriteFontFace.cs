// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite Exposes various font data such as metrics, names, and glyph outlines.
    /// </summary>
    [Guid( "5f49804d-7024-4d43-bfa9-d25984f53849" )]
	[ComVisible( true )]
	public interface IDWriteFontFace : IUnknown
	{
		/// <summary>
		/// 글리프 런 정보의 외각선 정보를 D2D1 기하 모형 형태로 가져옵니다.
		/// </summary>
		/// <param name="emSize"> 폰트 크기를 전달합니다. </param>
		/// <param name="glyphIndices"> 글리프 인덱스 목록을 전달합니다. </param>
		/// <param name="glyphAdvances"> 글리프 진행 간격 목록을 전달합니다. </param>
		/// <param name="glyphOffsets"> 글리프 오프셋 목록을 전달합니다. </param>
		/// <param name="isSideways"> <c>true</c>일 경우, 글리프가 반시계방향으로 90도 회전하고 수직 정보가 사용됩니다. </param>
		/// <param name="isRightToLeft"> <c>true</c>일 경우, 진행 방향이 왼쪽으로 향하도록 지시합니다. 기본적으로, 진행 방향은 오른쪽입니다. </param>
		/// <param name="geometrySink"> 기하 정보를 받을 개체를 전달합니다. </param>
		void GetGlyphRunOutline(
			float emSize,
			IList<ushort> glyphIndices,
			IList<float> glyphAdvances,
			IList<DWriteGlyphOffset> glyphOffsets,
			bool isSideways,
			bool isRightToLeft,
			ID2D1SimplifiedGeometrySink geometrySink
			);
	}
}
