// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.RenderCore.Slate
{
    /// <summary>
    /// UI 위젯을 표현합니다.
    /// </summary>
    public abstract class SWidget : IDisposable
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SWidget()
        {
        }

        /// <summary>
        /// 이 위젯의 틱 함수를 실행합니다.
        /// </summary>
        /// <param name="allottedGeometry"> 이 위젯에 할당된 트랜스폼이 전달됩니다. </param>
        /// <param name="inCurrentTime"> 현재를 나타내는 절대 시간값이 전달됩니다. </param>
        /// <param name="inDeltaTime"> 이전 프레임에서 이동한 시간이 전달됩니다. </param>
        public virtual void Tick(Geometry allottedGeometry, double inCurrentTime, float inDeltaTime)
        {
        }

        /// <summary>
        /// 위젯을 렌더링합니다.
        /// </summary>
        /// <param name="paintArgs"> 슬레이트 렌더링 매개변수가 전달됩니다. </param>
        /// <param name="allottedGeometry"> 이 위젯에 할당된 트랜스폼이 전달됩니다. </param>
        public void Paint(SlatePaintArgs paintArgs, Geometry allottedGeometry)
        {
            OnPaint(paintArgs, allottedGeometry);
        }

        /// <summary>
        /// 위젯을 렌더링합니다.
        /// </summary>
        /// <param name="paintArgs"> 슬레이트 렌더링 매개변수가 전달됩니다. </param>
        /// <param name="allottedGeometry"> 이 위젯에 할당된 트랜스폼이 전달됩니다. </param>
        protected abstract void OnPaint(SlatePaintArgs paintArgs, Geometry allottedGeometry);

        /// <inheritdoc/>
        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 이 위젯의 요청 크기를 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public virtual Vector2 GetDesiredSize()
        {
            return Vector2.Zero;
        }

        SlateVisibility _visibility;

        /// <summary>
        /// 위젯의 가시 상태를 설정하거나 가져옵니다.
        /// </summary>
        public SlateVisibility Visibility
        {
            get
            {
                return _visibility;
            }
            set
            {
                _visibility = value;
            }
        }
    }
}
