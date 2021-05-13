// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.RenderCore.Slate
{
    /// <summary>
    /// 고정점 계산이 필요한 영역을 표현합니다.
    /// </summary>
    public struct Anchors
    {
        /// <summary>
        /// 영역의 최소 위치를 표현합니다.
        /// </summary>
        public Vector2 Minimum;

        /// <summary>
        /// 영역의 최대 위치를 표현합니다.
        /// </summary>
        public Vector2 Maximum;

        /// <summary>
        /// 개체를 단일 값으로 초기화합니다.
        /// </summary>
        /// <param name="uniformAnchors"> 값을 전달합니다. </param>
        public Anchors(float uniformAnchors)
        {
            Minimum = new Vector2(uniformAnchors);
            Maximum = new Vector2(uniformAnchors);
        }

        /// <summary>
        /// 개체를 수평 및 수직 값으로 초기화합니다.
        /// </summary>
        /// <param name="horizontal"> 수평 값을 전달합니다. </param>
        /// <param name="vertical"> 수직 값을 전달합니다. </param>
        public Anchors(float horizontal, float vertical)
        {
            Minimum = new Vector2(horizontal, vertical);
            Maximum = new Vector2(horizontal, vertical);
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="minX"> 최소 위치를 전달합니다. </param>
        /// <param name="minY"> 최소 위치를 전달합니다. </param>
        /// <param name="maxX"> 최대 위치를 전달합니다. </param>
        /// <param name="maxY"> 최대 위치를 전달합니다. </param>
        public Anchors(float minX, float minY, float maxX, float maxY)
        {
            Minimum = new Vector2(minX, minY);
            Maximum = new Vector2(maxX, maxY);
        }
        
        /// <summary>
        /// 이 고정점 영역이 수직으로 무한한지 나타내는 값을 가져옵니다.
        /// </summary>
        public bool IsStretchedVertical => Minimum.Y != Maximum.Y;

        /// <summary>
        /// 이 고정점 영역이 수평으로 무한한지 나타내는 값을 가져옵니다.
        /// </summary>
        /// <returns></returns>
	    public bool IsStretchedHorizontal => Minimum.X != Maximum.X;
    }
}
