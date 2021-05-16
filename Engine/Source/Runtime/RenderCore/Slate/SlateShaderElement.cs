// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System.Runtime.InteropServices;

using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.RenderCore.Slate
{
    [StructLayout(LayoutKind.Explicit)]
    struct SlateShaderElement
    {
        [FieldOffset(0)]
        public Matrix2x2 M;
        [FieldOffset(16)]
        public Vector2 AbsolutePosition;
        [FieldOffset(24)]
        public Vector2 AbsoluteSize;
        [FieldOffset(32)]
        public float Depth;
    }
}
