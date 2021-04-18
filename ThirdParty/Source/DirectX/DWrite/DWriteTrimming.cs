// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite Specifies the trimming option for text overflowing the layout box.
    /// </summary>
    public struct DWriteTrimming
	{
		/// <summary>
		/// Text granularity of which trimming applies.
		/// </summary>
		public DWriteTrimmingGranularity Granularity;

		/// <summary>
		/// <para> Character code used as the delimiter signaling the beginning of the portion of text to be preserved, most useful for path ellipsis, where the delimiter would be a slash. </para>
		/// <para> Leave this zero if there is no delimiter. </para>
		/// </summary>
		public uint Delimiter;

		/// <summary>
		/// <para> How many occurrences of the delimiter to step back. </para>
		/// <para> Leave this zero if there is no delimiter. </para>
		/// </summary>
		public uint DelimiterCount;
	}
}
