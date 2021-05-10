// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System.Runtime.InteropServices;

using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.RenderCore.Slate
{
    [StructLayout(LayoutKind.Explicit)]
    struct SlateShaderElement
    {
        [FieldOffset(0)]
        public Vector2 Location;
        [FieldOffset(8)]
        public Vector2 Size;
        [FieldOffset(16)]
        public float Depth;
    }
}
