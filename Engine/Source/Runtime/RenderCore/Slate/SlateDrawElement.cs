// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.RenderCore.Slate.Layout;

namespace SC.Engine.Runtime.RenderCore.Slate
{
    /// <summary>
    /// 슬레이트 렌더링 요소를 표현합니다.
    /// </summary>
    public class SlateDrawElement
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SlateDrawElement()
        {
        }

        /// <summary>
        /// 요소가 사용하는 브러시 정보를 나타냅니다.
        /// </summary>
        public SlateBrush Brush;

        /// <summary>
        /// 요소의 트랜스폼을 나타냅니다.
        /// </summary>
        public Geometry Transform;
    }
}
