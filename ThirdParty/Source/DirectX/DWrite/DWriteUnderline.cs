// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite Contains information about the size and placement of underlines.
    /// </summary>
    public struct DWriteUnderline
	{
		/// <summary>
		/// Width of the underline, measured parallel to the baseline.
		/// </summary>
		public float Width;

		/// <summary>
		/// Thickness of the underline, measured perpendicular to the baseline.
		/// </summary>
		public float Thickness;

		/// <summary>
		/// <para> Offset of the underline from the baseline. </para>
		/// <para> A positive offset represents a position below the baseline and a negative offset is above. </para>
		/// </summary>
		public float Offset;

		/// <summary>
		/// Height of the tallest run where the underline applies.
		/// </summary>
		public float RunHeight;

		/// <summary>
		/// <para> Reading direction of the text associated with the underline. </para>
		/// <para> This value is used to interpret whether the width value runs horizontally or vertically. </para>
		/// </summary>
		public DWriteReadingDirection ReadingDirection;

		/// <summary>
		/// <para> Flow direction of the text associated with the underline. </para>
		/// <para> This value is used to interpret whether the thickness value advances top to bottom, left to right, or right to left. </para>
		/// </summary>
		public DWriteFlowDirection FlowDirection;

		/// <summary>
		/// Locale of the text the underline is begin drawn under.
		/// </summary>
		public string LocaleName;

		/// <summary>
		/// The measuring mode can be useful to the renderer to determine how underlines are rendered, e.g. rounding the thickness to a whole pixel in GDI_compatible modes.
		/// </summary>
		public DWriteMeasuringMode MeasuringMode;
	}
}
