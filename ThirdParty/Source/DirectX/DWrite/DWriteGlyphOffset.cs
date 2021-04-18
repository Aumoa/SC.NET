// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite Optional adjustment to a glyph's position.
    /// </summary>
    public struct DWriteGlyphOffset
	{
		/// <summary>
		///  Offset in the advance direction of the run.
		/// </summary>
		public float AdvanceOffset;

		/// <summary>
		/// Offset in the ascent direction, i.e., the direction ascenders point.
		/// </summary>
		public float AscenderOffset;
	}
}
