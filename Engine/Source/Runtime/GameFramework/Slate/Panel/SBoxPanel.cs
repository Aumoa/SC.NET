// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Collections.Generic;

using SC.Engine.Runtime.Core.Container;
using SC.Engine.Runtime.Core.Numerics;
using SC.Engine.Runtime.RenderCore.Slate;
using SC.Engine.Runtime.RenderCore.Slate.Layout;
using SC.Engine.Runtime.RenderCore.Slate.Widgets;

namespace SC.Engine.Runtime.GameFramework.Slate.Panel
{
    /// <summary>
    /// 여러 개의 위젯을 규칙에 맞게 배열하는 컨테이너의 기초 클래스입니다.
    /// </summary>
    public abstract class SBoxPanel : SPanelWidget
    {
        int GetChildIndex(Index index)
        {
            if (index.IsFromEnd)
            {
                return _childrens.Count - index.Value;
            }
            else
            {
                return index.Value;
            }
        }

        /// <summary>
        /// <see cref="SBoxPanel"/> 위젯의 슬롯을 표현합니다.
        /// </summary>
        public class SSlot : SSlotBase, IAlignmentSlot
        {
            /// <summary>
            /// 수평 정렬 위치를 가져오거나 설정합니다.
            /// </summary>
            public HorizontalAlignment HAlignment { get; set; } = HorizontalAlignment.Fill;

            /// <summary>
            /// 수직 정렬 위치를 가져오거나 설정합니다.
            /// </summary>
            public VerticalAlignment VAlignment { get; set; } = VerticalAlignment.Fill;

            /// <summary>
            /// 크기 매개변수를 가져오거나 설정합니다.
            /// </summary>
            public SizeParam SizeParam { get; set; } = new SizeParam(SizeRule.Stretch, 1.0f);

            /// <summary>
            /// 슬롯의 각 위치로부터 여백을 가져오거나 설정합니다.
            /// </summary>
            public Margin SlotPadding { get; set; }

            /// <summary>
            /// 슬롯의 최대 크기를 가져오거나 설정합니다. 0일 경우 최댓값이 없습니다.
            /// </summary>
            public float MaxSize { get; set; }

            /// <summary>
            /// 개체를 초기화합니다.
            /// </summary>
            /// <param name="owner"> 이 슬롯의 소유자를 전달합니다. </param>
            public SSlot(SBoxPanel owner) : base(owner)
            {
            }

            /// <summary>
            /// 특성을 초기화합니다.
            /// </summary>
            /// <param name="HAlignment"> 수평 정렬 위치를 가져오거나 설정합니다. </param>
            /// <param name="VAlignment"> 수직 정렬 위치를 가져오거나 설정합니다. </param>
            /// <param name="SizeParam"> 크기 매개변수를 가져오거나 설정합니다. </param>
            /// <param name="SlotPadding"> 슬롯의 각 위치로부터 여백을 가져오거나 설정합니다. </param>
            /// <param name="MaxSize"> 슬롯의 최대 크기를 가져오거나 설정합니다. 0일 경우 최댓값이 없습니다. </param>
            /// <returns> 작업 체인이 반환됩니다. </returns>
            public SBoxPanel Init(HorizontalAlignment? HAlignment = null, VerticalAlignment? VAlignment = null, SizeParam SizeParam = null, Margin? SlotPadding = null, float? MaxSize = null)
            {
                this.HAlignment = HAlignment ?? this.HAlignment;
                this.VAlignment = VAlignment ?? this.VAlignment;
                this.SizeParam = SizeParam ?? this.SizeParam;
                this.SlotPadding = SlotPadding ?? this.SlotPadding;
                this.MaxSize = MaxSize ?? this.MaxSize;
                return SourcePanel as SBoxPanel;
            }
        }

        /// <summary>
        /// 새 슬롯을 추가합니다.
        /// </summary>
        /// <returns> 생성된 슬롯이 반환됩니다. </returns>
        public virtual SSlot AddSlot()
        {
            var slot = new SSlot(this);
            _childrens.Add(slot);
            return slot;
        }

        /// <summary>
        /// 슬롯을 제거합니다.
        /// </summary>
        /// <param name="index"> 제거할 슬롯의 인덱스를 전달합니다. </param>
        /// <returns> 슬롯이 올바르게 제거되었는지 나타내는 값을 반환합니다. </returns>
        public bool RemoveSlot(int index)
        {
            if (_childrens.IsValidIndex(index))
            {
                _childrens.RemoveAt(index);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 슬롯을 제거합니다.
        /// </summary>
        /// <param name="index"> 제거할 슬롯의 인덱스를 전달합니다. </param>
        public void RemoveSlot(Index index) => RemoveSlot(GetChildIndex(index));

        /// <summary>
        /// 슬롯 목록에 해당 위젯을 사용하는 슬롯이 포함되어 있을 경우 대상 슬롯을 제거합니다.
        /// </summary>
        /// <param name="slotWidget"> 위젯 개체를 전달합니다. </param>
        /// <returns> 제거된 슬롯의 인덱스가 반환됩니다. 제거되지 않았을 경우 -1이 반환됩니다. </returns>
        public int RemoveSlot(SWidget slotWidget)
        {
            for (int i = 0; i < _childrens.Count; ++i)
            {
                if (_childrens[i].Content.Equals(slotWidget))
                {
                    _childrens.RemoveAt(i);
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 모든 슬롯을 제거합니다.
        /// </summary>
        public void ClearChildren()
        {
            _childrens.Clear();
        }

        /// <inheritdoc/>
        protected override void OnArrangeChildren(ArrangedChildren arrangedChildren, Geometry allottedGeometry)
        {
            ArrangeChildrenAlong(Orientation, FlowDirection.LeftToRight, allottedGeometry, arrangedChildren);
        }

        /// <inheritdoc/>
        public override Vector2 GetDesiredSize()
        {
            return base.GetDesiredSize();
        }

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="orientation"> 패널의 방향을 전달합니다. </param>
        public SBoxPanel(Orientation orientation)
        {
            Orientation = orientation;
        }

        /// <summary>
        /// 위젯의 방향을 가져오거나 설정합니다.
        /// </summary>
        public Orientation Orientation { get; init; }

        void ArrangeChildrenAlong(Orientation orientation, FlowDirection inLayoutFlow, Geometry allottedGeometry, ArrangedChildren arrangedChildren)
        {
	        // Allotted space will be given to fixed-size children first.
	        // Remaining space will be proportionately divided between stretch children (SizeRule_Stretch)
	        // based on their stretch coefficient

	        if (_childrens.Count > 0)
	        {
		        float stretchCoefficientTotal = 0;
		        float fixedTotal = 0;

		        bool anyChildVisible = false;
                // Compute the sum of stretch coefficients (SizeRule_Stretch) and space required by fixed-size widgets
                // (SizeRule_Auto).
                foreach (SSlot curChild in _childrens)
                {
                    if (curChild.Content.Visibility != SlateVisibility.Collapsed)
                    {
                        anyChildVisible = true;
                        // All widgets contribute their margin to the fixed space requirement
                        fixedTotal += curChild.SlotPadding.GetTotalSpaceAlong(orientation);

                        if (curChild.SizeParam.SizeRule == SizeRule.Stretch)
                        {
                            // for stretch children we save sum up the stretch coefficients
                            stretchCoefficientTotal += curChild.SizeParam.Value;
                        }
                        else
                        {
                            Vector2 childDesiredSize = curChild.Content.GetDesiredSize();

                            // Auto-sized children contribute their desired size to the fixed space requirement
                            float childSize = (orientation == Orientation.Vertical)
                                ? childDesiredSize.Y
                                : childDesiredSize.X;

                            // Clamp to the max size if it was specified
                            float maxSize = curChild.MaxSize;
                            fixedTotal += maxSize > 0 ? Math.Min(maxSize, childSize) : childSize;
                        }
                    }
                }

		        if (!anyChildVisible)
		        {
			        return;
		        }

                // The space available for SizeRule_Stretch widgets is any space that wasn't taken up by fixed-sized widgets.
                float nonFixedSpace = Math.Max(0.0f, (orientation == Orientation.Vertical)
                    ? allottedGeometry.Size.Y - fixedTotal
                    : allottedGeometry.Size.X - fixedTotal);

                float positionSoFar = 0;

                Func<IEnumerable<SSlot>> GetChildrenIterator = () =>
                {
                    FlowDirection layoutFlow = orientation == Orientation.Vertical ? FlowDirection.LeftToRight : inLayoutFlow;
                    return layoutFlow switch
                    {
                        FlowDirection.LeftToRight => _childrens[0..^0],
                        FlowDirection.RightToLeft => _childrens[^0..0],
                        _ => throw new InvalidOperationException()
                    };
                };

                // Now that we have the total fixed-space requirement and the total stretch coefficients we can
                // arrange widgets top-to-bottom or left-to-right (depending on the orientation).
                foreach (SSlot curChild in GetChildrenIterator())
		        {
                    SlateVisibility childVisibility = curChild.Content.Visibility;

			        // Figure out the area allocated to the child in the direction of BoxPanel
			        // The area allocated to the slot is ChildSize + the associated margin.
			        float childSize = 0;
			        if (childVisibility != SlateVisibility.Collapsed)
			        {
				        // The size of the widget depends on its size type
				        if (curChild.SizeParam.SizeRule == SizeRule.Stretch)
				        {
					        if (stretchCoefficientTotal > 0)
					        {
						        // Stretch widgets get a fraction of the space remaining after all the fixed-space requirements are met
						        childSize = nonFixedSpace * curChild.SizeParam.Value / stretchCoefficientTotal;
					        }
				        }
				        else
				        {
					        Vector2 childDesiredSize = curChild.Content.GetDesiredSize();

					        // Auto-sized widgets get their desired-size value
					        childSize = (orientation == Orientation.Vertical)
						        ? childDesiredSize.Y
						        : childDesiredSize.X;
				        }

				        // Clamp to the max size if it was specified
				        float maxSize = curChild.MaxSize;
				        if (maxSize > 0)
				        {
					        childSize = Math.Min(maxSize, childSize);
				        }
			        }

                    Margin slotPadding = curChild.SlotPadding.LayoutPaddingWithFlow(inLayoutFlow);

			        Vector2 slotSize = (orientation == Orientation.Vertical)
				        ? new Vector2(allottedGeometry.Size.X, childSize + slotPadding.GetTotalSpaceAlong(Orientation.Vertical))
				        : new Vector2(childSize + slotPadding.GetTotalSpaceAlong(Orientation.Horizontal), allottedGeometry.Size.Y);

			        // Figure out the size and local position of the child within the slot			
			        var xAlignmentResult = AlignmentArrangeResult.AlignChild(Orientation.Horizontal, inLayoutFlow, slotSize.X, curChild, slotPadding);
			        var yAlignmentResult = AlignmentArrangeResult.AlignChild(Orientation.Vertical, inLayoutFlow, slotSize.Y, curChild, slotPadding);

			        Vector2 localPosition = (orientation == Orientation.Vertical)
				        ? new Vector2(xAlignmentResult.Offset, positionSoFar + yAlignmentResult.Offset)
				        : new Vector2(positionSoFar + xAlignmentResult.Offset, yAlignmentResult.Offset);

			        Vector2 localSize = new(xAlignmentResult.Size, yAlignmentResult.Size);

			        // Add the information about this child to the output list (ArrangedChildren)
			        arrangedChildren.AddWidget(childVisibility, allottedGeometry.MakeChild(
				        // The child widget being arranged
				        curChild.Content,
				        // Child's local position (i.e. position within parent)
				        localPosition,
				        // Child's size
				        localSize
			        ));

			        if (childVisibility != SlateVisibility.Collapsed)
			        {
				        // Offset the next child by the size of the current child and any post-child (bottom/right) margin
				        positionSoFar += (orientation == Orientation.Vertical) ? slotSize.Y : slotSize.X;
			        }
		        }
	        }
        }

        TArray<SSlot> _childrens = new();

        /// <summary>
        /// 자식 슬롯 목록을 가져옵니다.
        /// </summary>
        protected IList<SSlot> Childrens => _childrens;
    }
}
