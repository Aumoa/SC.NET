// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Container;
using SC.Engine.Runtime.Core.Numerics;
using SC.Engine.Runtime.RenderCore.Slate;
using SC.Engine.Runtime.RenderCore.Slate.Layout;
using SC.Engine.Runtime.RenderCore.Slate.Widgets;

namespace SC.Engine.Runtime.GameFramework.Slate.Panel
{
    /// <summary>
    /// 위치를 지정하여 위젯 목록을 렌더링하는 패널을 표현합니다.
    /// </summary>
    public class SCanvasPanel : SPanelWidget
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SCanvasPanel() : base()
        {
        }

        /// <inheritdoc/>
        protected override SSlot OnAddSlot()
        {
            var slot = new SCanvasPanelSlot(this);
			_childrens.Add(slot);
			return slot;
        }

		/// <inheritdoc/>
        protected override void OnRemoveSlot(Index index)
        {
			_childrens.RemoveAt(index);
        }

        /// <inheritdoc/>
        protected override void OnPaint(SlatePaintArgs paintArgs, Geometry allottedGeometry)
        {
            ArrangedChildren arranged = new();
            ArrangeChildren(arranged, allottedGeometry);

            foreach (ArrangedWidget curWidget in arranged.GetWidgets())
            {
                curWidget.Widget?.Paint(paintArgs, curWidget.Geometry);
            }
        }

		struct ChildZOrder
        {
			public int ChildIndex;
			public float ZOrder;
        }

		int CompareAscending(int lh, int rh)
		{
			return lh == rh ? 0 : lh < rh ? -1 : 1;
		}

		int CompareAscending(float lh, float rh)
		{
			return lh == rh ? 0 : lh < rh ? -1 : 1;
		}

		int SortSlotsByZOrder(ChildZOrder lh, ChildZOrder rh)
		{
			return lh.ZOrder == rh.ZOrder
				 ? CompareAscending(lh.ChildIndex, rh.ChildIndex)
				 : CompareAscending(lh.ZOrder, rh.ZOrder);
		}

		TArray<SCanvasPanelSlot> _childrens = new();

		/// <inheritdoc/>
		public override void ArrangeChildren(ArrangedChildren arrangedChildren, Geometry allottedGeometry)
        {            
			if (_childrens.Count > 0)
			{
				// Sort the children based on zorder.
				TArray<ChildZOrder> slotOrder = new(_childrens.Count);

				for (int childIndex = 0; childIndex < _childrens.Count; ++childIndex)
				{
					var curChild = _childrens[childIndex];

					ChildZOrder order = new();
					order.ChildIndex = childIndex;
					order.ZOrder = curChild.ZOrder;
					slotOrder.Add(order);
				}

				slotOrder.Sort(SortSlotsByZOrder);

				// Arrange the children now in their proper z-order.
				for (int childIndex = 0; childIndex < _childrens.Count; ++childIndex)
				{
					ChildZOrder curSlot = slotOrder[childIndex];
					var curChild = _childrens[curSlot.ChildIndex];
					SWidget curWidget = curChild.Content;

					SlateVisibility childVisibility = curWidget.Visibility;
					if (arrangedChildren.Accepts(childVisibility))
					{
						Margin offset = curChild.Offset;
						Vector2 alignment = curChild.Alignment;
						Anchors anchors = curChild.Anchors;

						bool autoSize = curChild.AutoSize;

						var anchorPixels =
							new Margin(anchors.Minimum.X * allottedGeometry.Size.X,
							anchors.Minimum.Y * allottedGeometry.Size.Y,
							anchors.Maximum.X * allottedGeometry.Size.X,
							anchors.Maximum.Y * allottedGeometry.Size.Y);

						bool isHorizontalStretch = anchors.Minimum.X != anchors.Maximum.X;
						bool isVerticalStretch = anchors.Minimum.Y != anchors.Maximum.Y;

						var slotSize = new Vector2(offset.Right, offset.Bottom);
						var Size = autoSize ? curWidget.GetDesiredSize() : slotSize;

						// Calculate the offset based on the pivot position.
						Vector2 alignmentOffset = Size * alignment;

						// Calculate the local position based on the anchor and position offset.
						Vector2 localPosition, localSize;

						// Calculate the position and size based on the horizontal stretch or non-stretch
						if (isHorizontalStretch)
						{
							localPosition.X = anchorPixels.Left + offset.Left;
							localSize.X = anchorPixels.Right - localPosition.X - offset.Right;
						}
						else
						{
							localPosition.X = anchorPixels.Left + offset.Left - alignmentOffset.X;
							localSize.X = Size.X;
						}

						// Calculate the position and size based on the vertical stretch or non-stretch
						if (isVerticalStretch)
						{
							localPosition.Y = anchorPixels.Top + offset.Top;
							localSize.Y = anchorPixels.Bottom - localPosition.Y - offset.Bottom;
						}
						else
						{
							localPosition.Y = anchorPixels.Top + offset.Top - alignmentOffset.Y;
							localSize.Y = Size.Y;
						}

						// Add the information about this child to the output list (ArrangedChildren)
						arrangedChildren.AddWidget(childVisibility, allottedGeometry.MakeChild(
							// The child widget being arranged
							curWidget,
							// Child's local position (i.e. position within parent)
							localPosition,
							// Child's size
							localSize
						));
					}
				}
			}
        }
    }
}
