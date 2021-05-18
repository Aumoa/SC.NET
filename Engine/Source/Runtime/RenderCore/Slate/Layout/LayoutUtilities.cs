// Copyright 2020-2021 Aumoa.lib. All right reserved.

namespace SC.Engine.Runtime.RenderCore.Slate.Layout
{
    /// <summary>
    /// 슬레이트 레이아웃 관련 도우미 함수를 제공합니다.
    /// </summary>
    public static class LayoutUtilities
    {
        /// <summary>
        /// 진행 방향에 따라 여백을 정렬합니다.
        /// </summary>
        /// <param name="inPadding"> 여백을 전달합니다. </param>
        /// <param name="inLayoutFlow"> 진행 방향을 전달합니다. </param>
        /// <returns> 정렬된 여백 값이 반환됩니다. </returns>
        public static Margin LayoutPaddingWithFlow(this Margin inPadding, FlowDirection inLayoutFlow)
        {
            Margin returnPadding = inPadding;
            if (inLayoutFlow == FlowDirection.RightToLeft)
            {
                float tmp = returnPadding.Left;
                returnPadding.Left = returnPadding.Right;
                returnPadding.Right = tmp;
            }
            return returnPadding;
        }

        /// <summary>
        /// 자식 위젯의 정렬 형식을 정수형으로 가져옵니다.
        /// </summary>
        /// <param name="orientation"> 방향을 전달합니다. </param>
        /// <param name="inFlowDirection"> 진행 방향을 전달합니다. </param>
        /// <param name="inAlignmentSlot"> 슬롯 개체를 전달합니다. </param>
        /// <returns> 정수형 값이 반환됩니다. </returns>
        public static int GetChildAlignmentAsInt(this Orientation orientation, FlowDirection inFlowDirection, IAlignmentSlot inAlignmentSlot)
        {
            if (orientation == Orientation.Horizontal)
            {
			    switch (inFlowDirection)
			    {
			        default:
			        case FlowDirection.LeftToRight:
				        return (int)inAlignmentSlot.HAlignment;
			        case FlowDirection.RightToLeft:
				        switch (inAlignmentSlot.HAlignment)
				        {
				        case HorizontalAlignment.Left:
					        return (int)HorizontalAlignment.Right;
				        case HorizontalAlignment.Right:
					        return (int)HorizontalAlignment.Left;
				        default:
					        return (int)inAlignmentSlot.HAlignment;
				        }
			    }
            }
            else
            {
                // InFlowDirection has no effect in vertical orientations.
                return (int)inAlignmentSlot.VAlignment;
            }
        }
    }
}
