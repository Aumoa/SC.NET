// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite The method used for line spacing in layout.
    /// </summary>
    public enum DWriteLineSpacingMethod
	{
		/// <summary>
		/// Line spacing depends solely on the content, growing to accommodate the size of fonts and inline objects.
		/// </summary>
		Default,

		/// <summary>
		/// <para> Lines are explicitly set to uniform spacing, regardless of contained font sizes. </para>
		/// <para> This can be useful to avoid the uneven appearance that can occur from font fallback. </para>
		/// </summary>
		Uniform,

		/// <summary>
		/// Line spacing and baseline distances are proportional to the computed values based on the content, the size of the fonts and inline objects.
		/// </summary>
		Proportional
	}
}
