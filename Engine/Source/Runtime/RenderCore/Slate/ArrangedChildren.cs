// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System.Collections.Generic;

using SC.Engine.Runtime.Core.Container;

namespace SC.Engine.Runtime.RenderCore.Slate
{
    /// <summary>
    /// 배열된 레이아웃을 표현합니다.
    /// </summary>
    public class ArrangedChildren
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
            /// 개체를 초기화합니다.
            /// </summary>
            /// <param name="widget"> 위젯 인스턴스를 전달합니다. </param>
            public ArrangedWidget(SWidget widget)
            {
                Widget = widget;
            }
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public ArrangedChildren()
        {
        }

        /// <summary>
        /// 배열된 위젯을 추가합니다.
        /// </summary>
        /// <param name="widget"> 개체를 전달합니다. </param>
        public void AddWidget(SWidget widget)
        {
            _arrangedChildrens.Add(new ArrangedWidget(widget));
        }

        /// <summary>
        /// 배열된 위젯 목록을 가져옵니다.
        /// </summary>
        /// <returns> 위젯 목록을 가져옵니다. </returns>
        public IEnumerable<ArrangedWidget> GetWidgets()
        {
            return _arrangedChildrens;
        }

        TArray<ArrangedWidget> _arrangedChildrens = new();
    }
}
