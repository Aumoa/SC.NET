// Copyright 2020 Aumoa.lib. All right reserved.

using System.Collections.Generic;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite Contains additional properties related to those in <see cref="DWriteGlyphRun"/>.
    /// </summary>
    public struct DWriteGlyphRunDescription
	{
		/// <summary>
		/// The locale name associated with this run.
		/// </summary>
		public string LocaleName;

		/// <summary>
		/// <para> The text associated with the glyphs. </para>
		/// <para> Note that count of this string may be different than the number of glyphs. </para>
		/// </summary>
		public string String;

		/// <summary>
		/// An array of indices to the glyph indices array, of the first glyphs of all the glyph clusters of the glyphs to render.
		/// </summary>
		public IList<ushort> ClusterMap;

		/// <summary>
		/// Corresponding text position in the original string this glyph run came from.
		/// </summary>
		public uint TextPosition;
	}
}
