// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite Properties describing the geometric measurement of an application-defined inline object.
    /// </summary>
    public struct DWriteInlineObjectMetrics
	{
		/// <summary>
		/// Width of the inline object.
		/// </summary>
		public float Width;

		/// <summary>
		/// Height of the inline object as measured from top to bottom.
		/// </summary>
		public float Height;

		/// <summary>
		/// <para> Distance from the top of the object to the baseline where it is lined up with the adjacent text. </para>
		/// <para> If the baseline is at the bottom, baseline simply equals height. </para>
		/// </summary>
		public float Baseline;

		/// <summary>
		/// Flag indicating whether the object is to be placed upright or alongside the text baseline for vertical text.
		/// </summary>
		public bool SupportsSideways;
	}
}
