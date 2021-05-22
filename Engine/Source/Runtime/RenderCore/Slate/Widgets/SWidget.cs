// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Container;
using SC.Engine.Runtime.Core.Mathematics;
using SC.Engine.Runtime.Core.Numerics;
using SC.Engine.Runtime.RenderCore.Slate.Layout;
using SC.Engine.Runtime.RenderCore.Slate.WidgetEvents;

namespace SC.Engine.Runtime.RenderCore.Slate.Widgets
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
        public virtual void Tick(Geometry allottedGeometry, double inCurrentTime, double inDeltaTime)
        {
        }

        /// <summary>
        /// 위젯을 렌더링합니다.
        /// </summary>
        /// <param name="paintArgs"> 슬레이트 렌더링 매개변수를 전달합니다. </param>
        /// <param name="allottedGeometry"> 이 위젯에 할당된 트랜스폼을 전달합니다. </param>
        /// <param name="myCullingRect"> 컬링 영역을 전달합니다. </param>
        /// <param name="drawElements"> 렌더링 요소 목록 개체를 전달합니다. </param>
        /// <param name="layer"> 레이어 위치를 전달합니다. </param>
        /// <param name="parentEnabled"> 상위 요소의 활성화 여부를 전달합니다. </param>
        public int Paint(SlatePaintArgs paintArgs, Geometry allottedGeometry, Rectangle myCullingRect, SlateWindowElementList drawElements, int layer, bool parentEnabled)
        {
            return OnPaint(paintArgs, allottedGeometry, myCullingRect, drawElements, layer, parentEnabled);
        }

        /// <summary>
        /// 위젯을 렌더링합니다.
        /// </summary>
        /// <param name="paintArgs"> 슬레이트 렌더링 매개변수가 전달됩니다. </param>
        /// <param name="allottedGeometry"> 이 위젯에 할당된 트랜스폼이 전달됩니다. </param>
        /// <param name="myCullingRect"> 컬링 영역이 전달됩니다. </param>
        /// <param name="drawElements"> 렌더링 요소 목록 개체가 전달됩니다. </param>
        /// <param name="layer"> 레이어 위치가 전달됩니다. </param>
        /// <param name="parentEnabled"> 상위 요소의 활성화 여부가 전달됩니다. </param>
        protected abstract int OnPaint(SlatePaintArgs paintArgs, Geometry allottedGeometry, Rectangle myCullingRect, SlateWindowElementList drawElements, int layer, bool parentEnabled);

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
        public virtual SlateVisibility Visibility
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

        /// <summary>
        /// 위젯의 방향에 따른 렌더 트랜스폼 기준점을 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public Vector2 GetRenderTransformPivotWithRespectToFlowDirection()
        {
            return RenderTransformPivot;
        }

        /// <summary>
        /// 위젯의 방향에 따른 렌더 트랜스폼을 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public SlateRenderTransform? GetRenderTransformWithRespectToFlowDirection()
        {
            return RenderTransform;
        }

        /// <summary>
        /// 렌더링 트랜스폼을 가져옵니다.
        /// </summary>
        public SlateRenderTransform? RenderTransform { get; set; }

        /// <summary>
        /// 렌더링 트랜스폼 기준점을 가져옵니다.
        /// </summary>
        public Vector2 RenderTransformPivot { get; set; }

        /// <summary>
        /// 레이아웃 위젯을 재배치합니다.
        /// </summary>
        /// <param name="arrangedChildren"> 재배치 위젯 목록 개체를 전달합니다. </param>
        /// <param name="allottedGeometry"> 이 위젯에 할당된 트랜스폼이 전달됩니다. </param>
        public void ArrangeChildren(ArrangedChildren arrangedChildren, Geometry allottedGeometry)
        {
            OnArrangeChildren(arrangedChildren, allottedGeometry);
        }

        /// <summary>
        /// 레이아웃 위젯을 재배치합니다.
        /// </summary>
        /// <param name="arrangedChildren"> 재배치 위젯 목록 개체를 전달합니다. </param>
        /// <param name="allottedGeometry"> 이 위젯에 할당된 트랜스폼이 전달됩니다. </param>
        protected abstract void OnArrangeChildren(ArrangedChildren arrangedChildren, Geometry allottedGeometry);

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{GetType().Name}: [{GetDesiredSize()}] ({Visibility})";
        }

        /// <summary>
        /// 자식 위젯 요소가 컬링 영역에 의해 컬링되었는지 검사합니다.
        /// </summary>
        /// <param name="myCullingRect"> 컬링 영역을 전달합니다. </param>
        /// <param name="arrangedChild"> 재배치된 자식 요소를 전달합니다. </param>
        /// <returns> 상태가 반환됩니다. </returns>
        protected bool IsChildWidgetCulled(Rectangle myCullingRect, ArrangedWidget arrangedChild)
        {
            // 1) We check if the rendered bounding box overlaps with the culling rect.  Which is so that
            //    a render transformed element is never culled if it would have been visible to the user.
            if (myCullingRect.IsIntersect(arrangedChild.Geometry.GetRenderBoundingRect()) is not null)
            {
                return false;
            }

            // 2) We also check the layout bounding box to see if it overlaps with the culling rect.  The
            //    reason for this is a bit more nuanced.  Suppose you dock a widget on the screen on the side
            //    and you want have it animate in and out of the screen.  Even though the layout transform 
            //    keeps the widget on the screen, the render transform alone would have caused it to be culled
            //    and therefore not ticked or painted.  The best way around this for now seems to be to simply
            //    check both rects to see if either one is overlapping the culling volume.
            if (myCullingRect.IsIntersect(arrangedChild.Geometry.GetLayoutBoundingRect()) is not null)
            {
                return false;
            }

            // There's a special condition if the widget's clipping state is set does not intersect with clipping bounds, they in effect
            // will be setting a new culling rect, so let them pass being culling from this step.
            if (arrangedChild.Widget.Clipping == WidgetClipping.ClipToBoundsWithoutIntersection)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 위젯의 클리핑 규칙을 가져오거나 설정합니다.
        /// </summary>
        public WidgetClipping Clipping { get; set; }

        /// <summary>
        /// 부모 위젯의 상태와 교차하여 이 위젯이 활성화 될 수 있는지 검사합니다.
        /// </summary>
        /// <param name="inParentEnabled"> 부모 위젯의 상태를 전달합니다. </param>
        /// <returns> 상태가 반환됩니다. </returns>
        public bool ShouldBeEnabled(bool inParentEnabled)
        {
            return inParentEnabled && IsEnabled;
        }

        /// <summary>
        /// 위젯의 활성화 상태를 가져오거나 설정합니다.
        /// </summary>
        public bool IsEnabled { get; set; }

        WidgetEventReply InvokeArrangedMouseEvent(Geometry myGeometry, WidgetPointerEventArgs eventArgs, Func<ArrangedWidget, WidgetPointerEventArgs, WidgetEventReply> body)
        {
            if (!eventArgs.Parent.Visibility.AreChildrenHitTestVisible())
            {
                return null;
            }

            ArrangedChildren arrangedChildren = new(SlateVisibility.Visible);
            ArrangeChildren(arrangedChildren, myGeometry);

            eventArgs = eventArgs with
            {
                Parent = this
            };

            TArray<ArrangedWidget> widgets = arrangedChildren.GetWidgets();
            foreach (ArrangedWidget curWidget in widgets[^0..0])
            {
                // Mouse event can only receive that geometry is under the location.
                if (curWidget.Geometry.IsUnderLocation(eventArgs.CursorLocation))
                {
                    WidgetEventReply myReply = body(curWidget, eventArgs);
                    // If child widget consume this input event, we will return immediately.
                    if (myReply.Consume)
                    {
                        return myReply;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 마우스 버튼이 눌러졌을 때에 대한 이벤트를 처리합니다.
        /// </summary>
        /// <param name="myGeometry"> 위젯의 기하 모형을 전달합니다. </param>
        /// <param name="eventArgs"> 이벤트 매개 변수를 전달합니다. </param>
        /// <returns> 이벤트 응답이 반환됩니다. </returns>
        public WidgetEventReply MouseDown(Geometry myGeometry, WidgetPointerEventArgs eventArgs)
        {
            if (eventArgs.Parent.Visibility.AreChildrenHitTestVisible())
            {
                WidgetEventReply reply = InvokeArrangedMouseEvent(myGeometry, eventArgs, (widget, eventArgs) => widget.Widget.MouseDown(widget.Geometry, eventArgs));
                // If child widget return reply with consume flag, return immediately with current reply.
                if (reply?.Consume == true)
                {
                    return reply;
                }
            }

            if (Visibility.IsHitTestVisible())
            {
                return OnMouseDown(myGeometry, eventArgs);
            }

            return new WidgetEventReply()
            {
                IsProcessed = false
            };
        }

        /// <summary>
        /// 마우스 버튼이 놓였을 때에 대한 이벤트를 처리합니다.
        /// </summary>
        /// <param name="myGeometry"> 위젯의 기하 모형을 전달합니다. </param>
        /// <param name="eventArgs"> 이벤트 매개 변수를 전달합니다. </param>
        /// <returns> 이벤트 응답이 반환됩니다. </returns>
        public WidgetEventReply MouseUp(Geometry myGeometry, WidgetPointerEventArgs eventArgs)
        {
            if (eventArgs.Parent.Visibility.AreChildrenHitTestVisible())
            {
                WidgetEventReply reply = InvokeArrangedMouseEvent(myGeometry, eventArgs, (widget, eventArgs) => widget.Widget.MouseUp(widget.Geometry, eventArgs));
                // If child widget return reply with consume flag, return immediately with current reply.
                if (reply?.Consume == true)
                {
                    return reply;
                }
            }

            if (Visibility.IsHitTestVisible())
            {
                return OnMouseUp(myGeometry, eventArgs);
            }

            return new WidgetEventReply()
            {
                IsProcessed = false
            };
        }

        /// <summary>
        /// 마우스 위치가 이동되었을 때에 대한 이벤트를 처리합니다.
        /// </summary>
        /// <param name="myGeometry"> 위젯의 기하 모형을 전달합니다. </param>
        /// <param name="eventArgs"> 이벤트 매개 변수를 전달합니다. </param>
        /// <returns> 이벤트 응답이 반환됩니다. </returns>
        public WidgetEventReply MouseMove(Geometry myGeometry, WidgetPointerEventArgs eventArgs)
        {
            if (eventArgs.Parent.Visibility.AreChildrenHitTestVisible())
            {
                WidgetEventReply reply = InvokeArrangedMouseEvent(myGeometry, eventArgs, (widget, eventArgs) => widget.Widget.MouseMove(widget.Geometry, eventArgs));
                // If child widget return reply with consume flag, return immediately with current reply.
                if (reply?.Consume == true)
                {
                    return reply;
                }
            }

            if (Visibility.IsHitTestVisible())
            {
                return OnMouseMove(myGeometry, eventArgs);
            }

            return new WidgetEventReply()
            {
                IsProcessed = false
            };
        }

        /// <summary>
        /// 마우스 버튼이 눌러졌을 때 호출되는 처리기입니다.
        /// </summary>
        /// <param name="myGeometry"> 위젯의 기하 모형이 전달됩니다. </param>
        /// <param name="eventArgs"> 이벤트 매개 변수가 전달됩니다. </param>
        /// <returns> 이벤트 응답을 반환합니다. </returns>
        protected virtual WidgetEventReply OnMouseDown(Geometry myGeometry, WidgetPointerEventArgs eventArgs)
        {
            RenderTransform ??= SlateRenderTransform.Identity;
            RenderTransform = RenderTransform.Value.Concatenate(new SlateRenderTransform(Matrix2x2.Rotation(1.0f.ToRadians())));
            RenderTransformPivot = new Vector2(0.5f);
            return new WidgetEventReply()
            {
                Consume = true
            };
        }

        /// <summary>
        /// 마우스 버튼이 놓였을 때 호출되는 처리기입니다.
        /// </summary>
        /// <param name="myGeometry"> 위젯의 기하 모형이 전달됩니다. </param>
        /// <param name="eventArgs"> 이벤트 매개 변수가 전달됩니다. </param>
        /// <returns> 이벤트 응답을 반환합니다. </returns>
        protected virtual WidgetEventReply OnMouseUp(Geometry myGeometry, WidgetPointerEventArgs eventArgs) => new WidgetEventReply();

        /// <summary>
        /// 마우스 위치가 이동되었을 때 호출되는 처리기입니다.
        /// </summary>
        /// <param name="myGeometry"> 위젯의 기하 모형이 전달됩니다. </param>
        /// <param name="eventArgs"> 이벤트 매개 변수가 전달됩니다. </param>
        /// <returns> 이벤트 응답을 반환합니다. </returns>
        protected virtual WidgetEventReply OnMouseMove(Geometry myGeometry, WidgetPointerEventArgs eventArgs) => new WidgetEventReply();
    }
}
