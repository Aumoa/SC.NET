// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite Holds how much any visible pixels(in DIPs) overshoot each side of the layout or inline objects.
    /// </summary>
    public struct DWriteOverhangMetrics
	{
		/// <summary>
		/// The distance from the left-most visible DIP to its left alignment edge.
		/// </summary>
		public float Left;

		/// <summary>
		/// The distance from the top-most visible DIP to its top alignment edge.
		/// </summary>
		public float Top;

		/// <summary>
		/// The distance from the right-most visible DIP to its right alignment edge.
		/// </summary>
		public float Right;

		/// <summary>
		/// The distance from the bottom-most visible DIP to its bottom alignment edge.
		/// </summary>
		public float Bottom;
	}
}
