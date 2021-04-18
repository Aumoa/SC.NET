// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite Overall metrics associated with text after layout. All coordinates are in device independent pixels (DIPs).
    /// </summary>
    public struct DWriteTextMetrics
	{
		/// <summary>
		/// Left-most point of formatted text relative to layout box(excluding any glyph overhang).
		/// </summary>
		public float Left;

		/// <summary>
		/// Top-most point of formatted text relative to layout box(excluding any glyph overhang).
		/// </summary>
		public float Top;

		/// <summary>
		/// The width of the formatted text ignoring trailing whitespace at the end of each line.
		/// </summary>
		public float Width;

		/// <summary>
		/// The width of the formatted text taking into account the trailing whitespace at the end of each line.
		/// </summary>
		public float WidthIncludingTrailingWhitespace;

		/// <summary>
		/// The height of the formatted text. The height of an empty string is determined by the size of the default font's line height.
		/// </summary>
		public float Height;

		/// <summary>
		/// Initial width given to the layout. Depending on whether the text was wrapped or not, it can be either larger or smaller than the text content width.
		/// </summary>
		public float LayoutWidth;

		/// <summary>
		/// Initial height given to the layout. Depending on the length of the text, it may be larger or smaller than the text content height.
		/// </summary>
		public float LayoutHeight;

		/// <summary>
		/// <para> The maximum reordering count of any line of text, used to calculate the most number of hit-testing boxes needed. </para>
		/// <para> If the layout has no bidirectional text or no text at all, the minimum level is 1. </para>
		/// </summary>
		public uint MaxBidiReorderingDepth;

		/// <summary>
		/// Total number of lines.
		/// </summary>
		public uint LineCount;
	}
}
