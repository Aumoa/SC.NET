﻿// Copyright 2020-2021 Aumoa.lib. All right reserved.

namespace SC.Engine.Runtime.RenderCore.Slate
{
    /// <summary>
    /// UI 위젯을 표현합니다.
    /// </summary>
    public abstract class SWidget
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SWidget()
        {
        }

        /// <summary>
        /// 위젯을 렌더링합니다.
        /// </summary>
        /// <param name="paintArgs"> 슬레이트 렌더링 매개변수가 전달됩니다. </param>
        /// <param name="allottedTransform"> 이 위젯에 할당된 트랜스폼이 전달됩니다. </param>
        public void Paint(SlatePaintArgs paintArgs, SlateTransform allottedTransform)
        {
            OnPaint(paintArgs, allottedTransform);
        }

        /// <summary>
        /// 위젯을 렌더링합니다.
        /// </summary>
        /// <param name="paintArgs"> 슬레이트 렌더링 매개변수가 전달됩니다. </param>
        /// <param name="allottedTransform"> 이 위젯에 할당된 트랜스폼이 전달됩니다. </param>
        protected abstract void OnPaint(SlatePaintArgs paintArgs, SlateTransform allottedTransform);
    }
}
