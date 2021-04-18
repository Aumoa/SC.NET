// Copyright 2020 Aumoa.lib. All right reserved.

using System.Collections.Generic;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite Contains the information needed by renderers to draw glyph runs. All coordinates are in device independent pixels (DIPs).
    /// </summary>
    public struct DWriteGlyphRun
	{
		/// <summary>
		/// The physical font face to draw with.
		/// </summary>
		public IDWriteFontFace FontFace;

		/// <summary>
		/// Logical size of the font in DIPs, not points (equals 1/96 inch).
		/// </summary>
		public float FontEmSize;

		/// <summary>
		/// The number of glyphs.
		/// </summary>
		public uint GlyphCount;

		/// <summary>
		/// The indices to render.
		/// </summary>    
		public IList<ushort> GlyphIndices;

		/// <summary>
		/// Glyph advance widths.
		/// </summary>
		public IList<float> GlyphAdvances;

		/// <summary>
		/// Glyph offsets.
		/// </summary>
		public IList<DWriteGlyphOffset> GlyphOffsets;

		/// <summary>
		/// <para> If true, specifies that glyphs are rotated 90 degrees to the left and vertical metrics are used. </para>
		/// <para> Vertical writing is achieved by specifying IsSideways = true and rotating the entire run 90 degrees to the right via a rotate transform. </para>
		/// </summary>
		public bool IsSideways;

		/// <summary>
		/// <para> The implicit resolved bidi level of the run. </para>
		/// <para> Odd levels indicate right-to-left languages like Hebrew and Arabic, while even levels indicate left-to-right languages like English and Japanese (when written horizontally). </para>
		/// <para> For right-to-left languages, the text origin is on the right, and text should be drawn to the left. </para>
		/// </summary>
		public uint BidiLevel;
	}
}
