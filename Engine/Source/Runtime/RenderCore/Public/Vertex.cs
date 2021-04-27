// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System.Runtime.InteropServices;

using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.RenderCore
{
    /// <summary>
    /// 단일 정점을 표현합니다.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct Vertex
    {
        /// <summary>
        /// 위치를 지정합니다.
        /// </summary>
        [FieldOffset(0)]
        public Vector3 Position;

        /// <summary>
        /// 텍스처 좌표를 지정합니다.
        /// </summary>
        [FieldOffset(12)]
        public Vector2 TexCoord;

        /// <summary>
        /// 노말을 지정합니다.
        /// </summary>
        [FieldOffset(20)]
        public Vector3 Normal;

        /// <summary>
        /// 탄젠트를 지정합니다.
        /// </summary>
        [FieldOffset(32)]
        public Vector4 Tangent;
    }
}
