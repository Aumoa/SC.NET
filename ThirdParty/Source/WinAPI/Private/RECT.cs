// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System.Runtime.InteropServices;

namespace SC.ThirdParty.WinAPI
{
    /// <summary>
    /// The RECT structure defines a rectangle by the coordinates of its upper-left and lower-right corners.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    struct RECT
    {
        /// <summary>
        /// Specifies the x-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        [FieldOffset(0)]
        public int left;

        /// <summary>
        /// Specifies the y-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        [FieldOffset(4)]
        public int top;

        /// <summary>
        /// Specifies the x-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        [FieldOffset(8)]
        public int right;

        /// <summary>
        /// Specifies the y-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        [FieldOffset(12)]
        public int bottom;
    }
}
