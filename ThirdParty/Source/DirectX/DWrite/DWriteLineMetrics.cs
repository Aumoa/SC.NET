// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite Contains information about a formatted line of text.
    /// </summary>
    public struct DWriteLineMetrics
	{
		/// <summary>
		/// <para> The number of total text positions in the line. </para>
		/// <para> This includes any trailing whitespace and newline characters. </para>
		/// </summary>
		public uint Length;

		/// <summary>
		/// The number of whitespace positions at the end of the line. Newline sequences are considered whitespace.
		/// </summary>
		public uint TrailingWhitespaceLength;

		/// <summary>
		/// <para> The number of characters in the newline sequence at the end of the line. </para>
		/// <para> If the count is zero, then the line was either wrapped or it is the end of the text. </para>
		/// </summary>
		public uint NewlineLength;

		/// <summary>
		/// Height of the line as measured from top to bottom.
		/// </summary>
		public float Height;

		/// <summary>
		/// Distance from the top of the line to its baseline.
		/// </summary>
		public float Baseline;

		/// <summary>
		/// The line is trimmed.
		/// </summary>
		public bool IsTrimmed;
	}
}
