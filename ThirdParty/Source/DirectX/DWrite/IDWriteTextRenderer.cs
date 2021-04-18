// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite 사용자가 정의하는 텍스트 렌더러에 대한 공통 Callback 메서드를 제공합니다.
    /// </summary>
    [Guid( "ef8a8135-5cc6-45fe-8825-c5a0724eb819" )]
	[ComVisible( true )]
	public interface IDWriteTextRenderer : IDWritePixelSnapping
	{
		/// <summary>
		/// <see cref="IDWriteTextLayout.Draw"/> calls this function to instruct the client to render a run of glyphs.
		/// </summary>
		/// <param name="clientDrawingContext"> The context passed to <see cref="IDWriteTextLayout.Draw"/>. </param>
		/// <param name="baselineOriginX"> X-coordinate of the baseline. </param>
		/// <param name="baselineOriginY"> Y-coordinate of the baseline. </param>
		/// <param name="measuringMode"> Specifies measuring mode for glyphs in the run. </param>
		/// <param name="glyphRun"> The glyph run to draw. </param>
		/// <param name="glyphRunDescription"> Properties of the characters associated with this run. </param>
		/// <param name="clientDrawingEffect"> The drawing effect set in <see cref="IDWriteTextLayout.SetDrawingEffect"/>. </param>
		void DrawGlyphRun(
			object clientDrawingContext,
			float baselineOriginX,
			float baselineOriginY,
			DWriteMeasuringMode measuringMode,
			DWriteGlyphRun glyphRun,
			DWriteGlyphRunDescription glyphRunDescription,
			IUnknown clientDrawingEffect
			);

		/// <summary>
		/// <see cref="IDWriteTextLayout.Draw"/> calls this function to instruct the client to draw an underline.
		/// </summary>
		/// <param name="clientDrawingContext"> The context passed to <see cref="IDWriteTextLayout.Draw"/>. </param>
		/// <param name="baselineOriginX"> X-coordinate of the baseline. </param>
		/// <param name="baselineOriginY"> Y-coordinate of the baseline. </param>
		/// <param name="underline"> Underline logical information. </param>
		/// <param name="clientDrawingEffect"> The drawing effect set in <see cref="IDWriteTextLayout.SetDrawingEffect"/>. </param>
		/// <remarks>
		/// <para> A single underline can be broken into multiple calls, depending on how the formatting changes attributes. </para>
		/// <para> If font sizes/styles change within an underline, the thickness and offset will be averaged weighted according to characters. </para>
		/// <para> To get the correct top coordinate of the underline rect, add <see cref="DWriteUnderline.Offset"/> to the baseline's Y. Otherwise the underline will be immediately under the text. </para>
		/// <para> The x coordinate will always be passed as the left side, regardless of text directionality. </para>
		/// <para> This simplifies drawing and reduces the problem of round-off that could potentially cause gaps or a double stamped alpha blend. </para>
		/// <para> To avoid alpha overlap, round the end points to the nearest device pixel. </para>
		/// </remarks>
		void DrawUnderline(
			object clientDrawingContext,
			float baselineOriginX,
			float baselineOriginY,
			DWriteUnderline underline,
			IUnknown clientDrawingEffect
			);

		/// <summary>
		/// <see cref="IDWriteTextLayout.Draw"/> calls this function to instruct the client to draw an strikethrough.
		/// </summary>
		/// <param name="clientDrawingContext"> The context passed to <see cref="IDWriteTextLayout.Draw"/>. </param>
		/// <param name="baselineOriginX"> X-coordinate of the baseline. </param>
		/// <param name="baselineOriginY"> Y-coordinate of the baseline. </param>
		/// <param name="strikethrough"> Strikethrough logical information. </param>
		/// <param name="clientDrawingEffect"> The drawing effect set in <see cref="IDWriteTextLayout.SetDrawingEffect"/>. </param>
		/// <remarks>
		/// <para> A single strikethrough can be broken into multiple calls, depending on how the formatting changes attributes. </para>
		/// <para> If font sizes/styles change within an strikethrough, the thickness and offset will be averaged weighted according to characters. </para>
		/// <para> To get the correct top coordinate of the strikethrough rect, add <see cref="DWriteStrikethrough.Offset"/> to the baseline's Y. Otherwise the strikethrough will be immediately under the text. </para>
		/// <para> The x coordinate will always be passed as the left side, regardless of text directionality. </para>
		/// <para> This simplifies drawing and reduces the problem of round-off that could potentially cause gaps or a double stamped alpha blend. </para>
		/// <para> To avoid alpha overlap, round the end points to the nearest device pixel. </para>
		/// </remarks>
		void DrawStrikethrough(
			object clientDrawingContext,
			float baselineOriginX,
			float baselineOriginY,
			DWriteStrikethrough strikethrough,
			IUnknown clientDrawingEffect
			);

		/// <summary>
		/// <see cref="IDWriteTextLayout.Draw"/> calls this application callback when it needs to draw in inline object.
		/// </summary>
		/// <param name="clientDrawingContext"> The context passed to <see cref="IDWriteTextLayout.Draw"/>. </param>
		/// <param name="originX"> X-coordinate at the top-left corner of the inline object. </param>
		/// <param name="originY"> Y-coordinate at the top-left corner of the inline object. </param>
		/// <param name="inlineObject"> The object set using <see cref="IDWriteTextLayout.SetInlineObject"/>. </param>
		/// <param name="isSideways"> The object shoud be drawn on its side. </param>
		/// <param name="isRightToLeft"> The object is in an right-to-left context and should be drawn flipped. </param>
		/// <param name="clientDrawingEffect"> The drawing effect set in <see cref="IDWriteTextLayout.SetDrawingEffect"/>. </param>
		void DrawInlineObject(
			object clientDrawingContext,
			float originX,
			float originY,
			IDWriteInlineObject inlineObject,
			bool isSideways,
			bool isRightToLeft,
			IUnknown clientDrawingEffect
			);
	}
}
