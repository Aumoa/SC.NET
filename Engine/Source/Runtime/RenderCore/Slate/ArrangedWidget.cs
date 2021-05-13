// Copyright 2020-2021 Aumoa.lib. All right reserved.

namespace SC.Engine.Runtime.RenderCore.Slate
{
    /// <summary>
    /// 배열된 위젯 정보를 표현합니다.
    /// </summary>
    public struct ArrangedWidget
    {
        /// <summary>
        /// 위젯 인스턴스를 나타냅니다.
        /// </summary>
        public SWidget Widget;

        /// <summary>
        /// 위젯의 기하 모형을 나타냅니다.
        /// </summary>
        public Geometry Geometry;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="widget"> 위젯 인스턴스를 전달합니다. </param>
        /// <param name="geometry"> 기하 모형을 전달합니다. </param>
        public ArrangedWidget(SWidget widget, Geometry geometry)
        {
            Widget = widget;
            Geometry = geometry;
        }
    }
}
