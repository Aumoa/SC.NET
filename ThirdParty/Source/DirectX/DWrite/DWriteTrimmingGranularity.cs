// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite Text granularity used to trim text overflowing the layout box.
    /// </summary>
    public enum DWriteTrimmingGranularity
	{
		/// <summary>
		/// No trimming occurs. Text flows beyond the layout width.
		/// </summary>
		None,

		/// <summary>
		/// Trimming occurs at character cluster boundary.
		/// </summary>
		Character,

		/// <summary>
		/// Trimming occurs at word boundary.
		/// </summary>
		Word,
	}
}
