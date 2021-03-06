﻿// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Container;
using SC.Engine.Runtime.Core.Numerics;
using SC.Engine.Runtime.RenderCore.Slate.Widgets;

namespace SC.Engine.Runtime.RenderCore.Slate
{
    /// <summary>
    /// 슬레이트 렌더링 매개변수를 표현합니다.
    /// </summary>
    public class SlatePaintArgs
    {
        /// <summary>
        /// 슬레이트 애플리케이션이 시작된 후 흐른 시간을 나타냅니다.
        /// </summary>
        public double CurrentTime;

        /// <summary>
        /// 이전 프레임에서 경과한 시간을 나타냅니다.
        /// </summary>
        public float DeltaTime;

        /// <summary>
        /// 부모 슬레이트를 나타냅니다.
        /// </summary>
        public SWidget SlateParent;

        /// <summary>
        /// 렌더링 디바이스 컨텍스트를 나타냅니다.
        /// </summary>
        public RHIDeviceContext Context;

        internal TMap<int, TArray<SlateDrawElement>> Elements = new();
        int _elementsCount;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SlatePaintArgs()
        {
        }

        /// <summary>
        /// 전체 화면의 크기를 나타냅니다.
        /// </summary>
        public Vector2 ScreenSize;

        /// <summary>
        /// 새 요소를 추가합니다.
        /// </summary>
        /// <param name="element"> 요소를 전달합니다. </param>
        /// <param name="layer"> 레이어를 전달합니다. </param>
        public void AddElement(SlateDrawElement element, int layer)
        {
            TArray<SlateDrawElement> elementArray;

            if (!Elements.TryGetValue(layer, out elementArray))
            {
                elementArray = new TArray<SlateDrawElement>();
                Elements.Add(layer, elementArray);
            }

            elementArray.Add(element);
            _elementsCount += 1;
        }

        /// <summary>
        /// 모든 요소의 개수를 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public int GetElementsCount()
        {
            return _elementsCount;
        }
    }
}
