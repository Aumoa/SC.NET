// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System.Runtime.InteropServices;

using SC.Engine.Runtime.Core.Mathematics;
using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.RenderCore.Slate
{
    /// <summary>
    /// 슬레이트 트랜스폼을 표현합니다.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct Geometry
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
        /// 슬레이트 크기를 종료 위치로 설정하거나 가져옵니다.
        /// </summary>
        public Vector2 EndLocation
        {
            get => Location + Size;
            set => Size = EndLocation - Location;
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="location"> 위치 벡터를 전달합니다. </param>
        /// <param name="size"> 크기 벡터를 전달합니다. </param>
        public Geometry(Vector2 location, Vector2 size)
        {
            Location = location;
            Size = size;
        }

        /// <inheritdoc/>
        public override string ToString() => $"Location: {Location}, Size: {Size}";

        /// <summary>
        /// 재배열된 자식 위젯을 생성합니다.
        /// </summary>
        /// <param name="childWidget"> 위젯을 전달합니다. </param>
        /// <param name="childOffset"> 위치 오프셋을 전달합니다. </param>
        /// <param name="inLocalSize"> 크기를 전달합니다. </param>
        /// <returns> 재배열된 위젯 개체가 반환됩니다. </returns>
        public ArrangedWidget MakeChild(SWidget childWidget, Vector2 childOffset, Vector2 inLocalSize)
        {
            return new ArrangedWidget(childWidget, new Geometry(Location + childOffset, inLocalSize));
        }

        /// <summary>
        /// 자식 트랜스폼을 생성합니다.
        /// </summary>
        /// <param name="childOffset"> 위치 오프셋을 전달합니다. </param>
        /// <param name="inLocalSize"> 크기를 전달합니다. </param>
        /// <returns> 재배열된 위젯 개체가 반환됩니다. </returns>
        public Geometry MakeChild(Vector2 childOffset, Vector2 inLocalSize)
        {
            Geometry v = new();
            v.Location = Location + childOffset;
            v.Size = inLocalSize;
            v.EndLocation = MathEx.Min(EndLocation, v.EndLocation);
            return v;
        }
    }
}
