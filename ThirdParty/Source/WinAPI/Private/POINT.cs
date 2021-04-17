// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System.Runtime.InteropServices;

namespace SC.ThirdParty.WinAPI
{
    /// <summary>
    /// The POINT structure defines the x- and y- coordinates of a point.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    struct POINT
    {
        /// <summary>
        /// The x-coordinate of the point.
        /// </summary>
        [FieldOffset(0)]
        public int x;

        /// <summary>
        /// The y-coordinate of the point.
        /// </summary>
        [FieldOffset(4)]
        public int y;
    }
}
