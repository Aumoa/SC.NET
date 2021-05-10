// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System.Runtime.InteropServices;

using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.RenderCore.Slate
{
    /// <summary>
    /// 슬레이트 트랜스폼을 표현합니다.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct SlateTransform
    {
        /// <summary>
        /// 슬레이트 위치를 표현합니다.
        /// </summary>
        [FieldOffset(0)]
        public Vector2 Location;

        /// <summary>
        /// 슬레이트 크기를 표현합니다.
        /// </summary>
        [FieldOffset(8)]
        public Vector2 Size;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="location"> 위치 벡터를 전달합니다. </param>
        /// <param name="size"> 크기 벡터를 전달합니다. </param>
        public SlateTransform(Vector2 location, Vector2 size)
        {
            Location = location;
            Size = size;
        }
    }
}
