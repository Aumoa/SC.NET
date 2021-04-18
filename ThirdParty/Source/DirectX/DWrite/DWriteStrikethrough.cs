// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite Contains information about the size and placement of strikethroughs.
    /// </summary>
    public struct DWriteStrikethrough
	{
		/// <summary>
		/// Width of the strikethrough, measured parallel to the baseline.
		/// </summary>
		public float Width;

		/// <summary>
		/// Thickness of the strikethrough, measured perpendicular to the baseline.
		/// </summary>
		public float Thickness;

		/// <summary>
		/// <para> Offset of the strikethrough from the baseline. </para>
		/// <para> A positive offset represents a position below the baseline and a negative offset is above. </para>
		/// </summary>
		public float Offset;

		/// <summary>
		/// <para> Reading direction of the text associated with the strikethrough. </para>
		/// <para> This value is used to interpret whether the width value runs horizontally or vertically. </para>
		/// </summary>
		public DWriteReadingDirection ReadingDirection;

		/// <summary>
		/// <para> Flow direction of the text associated with the strikethrough. </para>
		/// <para> This value is used to interpret whether the thickness value advances top to bottom, left to right, or right to left. </para>
		/// </summary>
		public DWriteFlowDirection FlowDirection;

		/// <summary>
		/// Locale of the range.
		/// </summary>
		public string LocaleName;

		/// <summary>
		/// The measuring mode can be useful to the renderer to determine how strikethroughs are rendered, e.g. rounding the thickness to a whole pixel in GDI_compatible modes.
		/// </summary>
		public DWriteMeasuringMode MeasuringMode;
	}
}
