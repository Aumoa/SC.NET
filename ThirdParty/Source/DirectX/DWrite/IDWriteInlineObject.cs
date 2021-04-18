// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite 텍스트 내부에 표현되는 그래픽 개체에 대한 공통 메서드를 제공합니다.
    /// </summary>
    [Guid( "8339FDE3-106F-47ab-8373-1C6295EB10B3" )]
	[ComVisible( true )]
	public interface IDWriteInlineObject : IUnknown
	{
		/// <summary>
		/// <para> The application implement rendering callback <see cref="IDWriteTextRenderer.DrawInlineObject"/> can use this to draw the inline object without needing to cast or query the object type. </para>
		/// <para> The text layout does not call this method directly. </para>
		/// </summary>
		/// <param name="clientDrawingContext"> The context passed to <see cref="IDWriteTextLayout.Draw"/>. </param>
		/// <param name="renderer"> The renderer passed to <see cref="IDWriteTextLayout.Draw"/> as the object's containing parent. </param>
		/// <param name="originX"> X-coordinate at the top-left corner of the inline object. </param>
		/// <param name="originY"> Y-coordinate at the top-left corner of the inline object. </param>
		/// <param name="isSideways"> The object should be drawn on its side. </param>
		/// <param name="isRightToLeft"> The object is in an right-to-left context and should be drawn flipped. </param>
		/// <param name="clientDrawingEffect"> The drawing effect set in <see cref="IDWriteTextLayout.SetDrawingEffect"/>. </param>
		void Draw(
			object clientDrawingContext,
			IDWriteTextRenderer renderer,
			float originX,
			float originY,
			bool isSideways,
			bool isRightToLeft,
			IUnknown clientDrawingEffect
			);

		/// <summary>
		/// <see cref="IDWriteTextLayout"/> calls this callback function to get the measurement of the inline object.
		/// </summary>
		/// <returns> Return metrics. </returns>
		DWriteInlineObjectMetrics GetMetrics();

		/// <summary>
		/// <para> <see cref="IDWriteTextLayout"/> calls this callback function to get the visible extents (in DIPs) of the inline object. </para>
		/// <para> In the case of a single bitmap, with no padding and no overhang, all the overhangs will simply be zeroes. </para>
		/// </summary>
		/// <returns> Return overshoot of visible extents (in DIPs) outside the object. </returns>
		DWriteOverhangMetrics GetOverhangMetrics();

		/// <summary>
		/// Layout used this to determine the line breaking behaviour of the inline object amidst the text.
		/// </summary>
		/// <param name="breakConditionBefore"> Line-breaking condition between the object and the content immediately preceding it. </param>
		/// <param name="breakConditionAfter"> Line-breaking condition between the object and the content immediately following it. </param>
		void GetBreakConditions( out DWriteBreakCondition breakConditionBefore, out DWriteBreakCondition breakConditionAfter );
	}
}
