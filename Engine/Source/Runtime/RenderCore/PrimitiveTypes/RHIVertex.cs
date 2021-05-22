// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System.Runtime.InteropServices;

using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.RenderCore.PrimitiveTypes
{
    /// <summary>
    /// 단일 정점을 정의합니다.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 32)]
    public struct RHIVertex
    {
        /// <summary>
        /// 정점의 위치를 나타냅니다.
        /// </summary>
        [FieldOffset(0)]
        public Vector3 Position;

        /// <summary>
        /// 정점의 텍스처 좌표를 나타냅니다.
        /// </summary>
        [FieldOffset(12)]
        public Vector2 TexCoord;
        
        /// <summary>
        /// 정점의 법선 좌표를 나타냅니다.
        /// </summary>
        [FieldOffset(20)]
        public Vector3 Normal;
    }
}
