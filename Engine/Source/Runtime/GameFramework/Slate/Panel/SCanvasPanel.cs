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
		/// <see cref="SCanvasPanel"/>의 슬롯을 표현합니다.
		/// </summary>
		public class SSlot : SSlotBase
		{
			/// <summary>
			/// 개체를 초기화합니다.
			/// </summary>
			/// <param name="sourcePanel"> 슬롯의 소유자를 전달합니다. </param>
			public SSlot(SCanvasPanel sourcePanel) : base(sourcePanel)
			{
			}

			/// <summary>
			/// 슬롯의 오프셋을 설정하거나 가져옵니다.
			/// </summary>
			public Margin Offset { get; set; } = new Margin(0, 0, 100, 100);

			/// <summary>
			/// 슬롯의 고정점 영역을 설정하거나 가져옵니다.
			/// </summary>
			public Anchors Anchors { get; set; }

			/// <summary>
			/// 정렬 계수를 설정하거나 가져옵니다.
			/// </summary>
			public Vector2 Alignment { get; set; }

			/// <summary>
			/// Z 순서를 설정하거나 가져옵니다.
			/// </summary>
			public float ZOrder { get; set; }

			/// <summary>
			/// 슬롯의 크기를 컨텐츠의 크기에 맞게 자동으로 결정합니다.
			/// </summary>
			public bool AutoSize { get; set; }

			/// <summary>
			/// 특성을 초기화합니다.
			/// </summary>
			/// <param name="Offset"> 슬롯의 오프셋을 전달합니다. </param>
			/// <param name="Anchors"> 슬롯의 고정점 영역을 전달합니다. </param>
			/// <param name="Alignment"> 정렬 계수를 전달합니다. </param>
			/// <param name="ZOrder"> Z 순서를 전달합니다. </param>
			/// <param name="AutoSize"> 자동 크기 조절 설정 여부를 전달합니다. </param>
			/// <returns> 작업 체인이 반환됩니다. </returns>
			public SCanvasPanel Init(Margin? Offset = null, Anchors? Anchors = null, Vector2? Alignment = null, float? ZOrder = null, bool? AutoSize = null)
			{
				this.Offset = Offset ?? new Margin(0, 0, 100, 100);
				this.Anchors = Anchors ?? default;
				this.Alignment = Alignment ?? default;
				this.ZOrder = ZOrder ?? default;
				this.AutoSize = AutoSize ?? default;
				return SourcePanel as SCanvasPanel;
			}

			/// <summary>
			/// 슬롯의 컨텐츠를 설정합니다.
			/// </summary>
			/// <param name="content"> 컨텐츠를 전달합니다. </param>
			/// <returns> 작업 체인이 반환됩니다. </returns>
			public SSlot this[SWidget content]
			{
				get
				{
					Content = content;
					return this;
				}
			}
		}

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SCanvasPanel() : base()
        {
		}

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
		/// 새 슬롯을 추가합니다.
		/// </summary>
		/// <returns> 생성된 슬롯이 반환됩니다. </returns>
		public SSlot AddSlot()
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
		protected override int OnPaint(SlatePaintArgs paintArgs, Geometry allottedGeometry, Rectangle myCullingRect, SlateWindowElementList drawElements, int layer, bool parentEnabled)
        {
            ArrangedChildren arrangedChildren = new(SlateVisibility.Visible);
            ArrangeChildren(arrangedChildren, allottedGeometry);

			bool forwardedEnabled = ShouldBeEnabled(parentEnabled);
			int maxLayer = layer;

			SlatePaintArgs newArgs = paintArgs with { Parent = this };
			foreach (ArrangedWidget curWidget in arrangedChildren.GetWidgets())
			{
				if (!IsChildWidgetCulled(myCullingRect, curWidget))
				{
					int curWidgetsMaxLayerId = curWidget.Widget.Paint(
						newArgs,
						curWidget.Geometry,
						myCullingRect,
						drawElements,
						layer,
						forwardedEnabled);

					maxLayer = Math.Max(maxLayer, curWidgetsMaxLayerId);
				}
			}

			return maxLayer;
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

		TArray<SSlot> _childrens = new();

		/// <inheritdoc/>
		protected override void OnArrangeChildren(ArrangedChildren arrangedChildren, Geometry allottedGeometry)
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
