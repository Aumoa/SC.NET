// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.RenderCore.Slate.Layout;
using SC.Engine.Runtime.RenderCore.Slate.Widgets;

namespace SC.Engine.Runtime.GameFramework.Slate.Panel
{
    /// <summary>
    /// 여러 개의 위젯을 수직 규칙에 맞게 배열하는 컨테이너입니다.
    /// </summary>
    public class SVerticalBoxPanel : SBoxPanel
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SVerticalBoxPanel() : base(Orientation.Vertical)
        {
        }

        /// <summary>
        /// <see cref="SVerticalBoxPanel"/> 위젯의 슬롯을 표현합니다.
        /// </summary>
        public new class SSlot : SBoxPanel.SSlot
        {
            /// <summary>
            /// 개체를 초기화합니다.
            /// </summary>
            /// <param name="owner"> 이 슬롯의 소유자를 전달합니다. </param>
            public SSlot(SVerticalBoxPanel owner) : base(owner)
            {
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

            /// <summary>
            /// 특성을 초기화합니다.
            /// </summary>
            /// <param name="HAlignment"> 수평 정렬 위치를 가져오거나 설정합니다. </param>
            /// <param name="VAlignment"> 수직 정렬 위치를 가져오거나 설정합니다. </param>
            /// <param name="SizeParam"> 크기 매개변수를 가져오거나 설정합니다. </param>
            /// <param name="SlotPadding"> 슬롯의 각 위치로부터 여백을 가져오거나 설정합니다. </param>
            /// <param name="MaxSize"> 슬롯의 최대 크기를 가져오거나 설정합니다. 0일 경우 최댓값이 없습니다. </param>
            /// <returns> 작업 체인이 반환됩니다. </returns>
            public new SVerticalBoxPanel Init(HorizontalAlignment? HAlignment = null, VerticalAlignment? VAlignment = null, SizeParam SizeParam = null, Margin? SlotPadding = null, float? MaxSize = null)
            {
                return base.Init(HAlignment, VAlignment, SizeParam, SlotPadding, MaxSize) as SVerticalBoxPanel;
            }
        }

        /// <summary>
        /// 새 슬롯을 추가합니다.
        /// </summary>
        /// <returns> 생성된 슬롯이 반환됩니다. </returns>
        public override SSlot AddSlot()
        {
            var slot = new SSlot(this);
            Childrens.Add(slot);
            return slot;
        }

        /// <summary>
        /// 지정한 위치에 슬롯을 추가합니다.
        /// </summary>
        /// <param name="index"> 위치를 전달합니다. </param>
        /// <returns> 생성된 슬롯이 반환됩니다. </returns>
        public SSlot InsertSlot(Index index) => InsertSlot(IndexToInt(index));

        /// <summary>
        /// 지정한 위치에 슬롯을 추가합니다.
        /// </summary>
        /// <param name="index"> 위치를 전달합니다. </param>
        /// <returns> 생성된 슬롯이 반환됩니다. </returns>
        public SSlot InsertSlot(int index)
        {
            var slot = new SSlot(this);
            Childrens.Insert(index, slot);
            return slot;
        }

        int IndexToInt(Index index)
        {
            if (index.IsFromEnd)
            {
                return Childrens.Count - index.Value;
            }
            else
            {
                return index.Value;
            }
        }
    }
}
