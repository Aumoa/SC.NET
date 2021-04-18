// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite Contains information about a glyph cluster.
    /// </summary>
    public struct DWriteClusterMetrics
	{
		/// <summary>
		/// The total advance width of all glyphs in the cluster.
		/// </summary>
		public float Width;

		/// <summary>
		/// The number of text positions in the cluster.
		/// </summary>
		public ushort Length;

		/// <summary>
		/// Indicate whether line can be broken right after the cluster.
		/// </summary>
		public bool CanWrapLineAfter;

		/// <summary>
		/// Indicate whether the cluster corresponds to whitespace character.
		/// </summary>
		public bool IsWhitespace;

		/// <summary>
		/// Indicate whether the cluster corresponds to a newline character.
		/// </summary>
		public bool IsNewline;

		/// <summary>
		/// Indicate whether the cluster corresponds to soft hyphen character.
		/// </summary>
		public bool IsSoftHyphen;

		/// <summary>
		/// Indicate whether the cluster is read from right to left.
		/// </summary>
		public bool IsRightToLeft;
	}
}
