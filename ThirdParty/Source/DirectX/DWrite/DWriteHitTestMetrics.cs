// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite Geometry enclosing of text positions.
    /// </summary>
    public struct DWriteHitTestMetrics
	{
		/// <summary>
		/// First text position within the geometry.
		/// </summary>
		public uint TextPosition;

		/// <summary>
		/// Number of text positions within the geometry.
		/// </summary>
		public uint Length;

		/// <summary>
		/// Left position of the top-left coordinate of the geometry.
		/// </summary>
		public float Left;

		/// <summary>
		/// Top position of the top-left coordinate of the geometry.
		/// </summary>
		public float Top;

		/// <summary>
		/// Geometry's width.
		/// </summary>
		public float Width;

		/// <summary>
		/// Geometry's height.
		/// </summary>
		public float Height;

		/// <summary>
		/// Bidi level of text positions enclosed within the geometry.
		/// </summary>
		public uint BidiLevel;

		/// <summary>
		/// Geometry encloses text?
		/// </summary>
		public bool IsText;

		/// <summary>
		/// Range is trimmed.
		/// </summary>
		public bool IsTrimmed;
	}
}
