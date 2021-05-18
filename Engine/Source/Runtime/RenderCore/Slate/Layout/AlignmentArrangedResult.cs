// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.RenderCore.Slate.Layout
{
    /// <summary>
    /// 정렬된 재배치 결과를 표현합니다.
    /// </summary>
    public record AlignmentArrangeResult
    {
        /// <summary>
        /// 오프셋을 나타냅니다.
        /// </summary>
        public float Offset;

        /// <summary>
        /// 크기를 나타냅니다.
        /// </summary>
        public float Size;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="inOffset"> 오프셋을 전달합니다. </param>
        /// <param name="inSize"> 크기를 전달합니다. </param>
        public AlignmentArrangeResult(float inOffset, float inSize)
        {
            Offset = inOffset;
            Size = inSize;
        }
        
        /// <summary>
        /// 자식 위젯을 정렬합니다.
        /// </summary>
        /// <param name="orientation"> 방향을 전달합니다. </param>
        /// <param name="inLayoutFlow"> 진행 방향을 전달합니다. </param>
        /// <param name="allottedSize"> 할당된 크기를 전달합니다. </param>
        /// <param name="childToArrange"> 재배치할 슬롯을 전달합니다. </param>
        /// <param name="slotPadding"> 슬롯의 여백을 전달합니다. </param>
        /// <param name="contentScale"> 컨텐츠의 스케일 계수를 전달합니다. </param>
        /// <param name="clampToParent"> 부모 위젯에 한정할지 나타내는 값을 전달합니다. </param>
        /// <returns> 정렬된 결과가 반환됩니다. </returns>
        public static AlignmentArrangeResult AlignChild(Orientation orientation, FlowDirection inLayoutFlow, float allottedSize, IAlignmentSlot childToArrange, Margin slotPadding, float contentScale = 1.0f, bool clampToParent = true)
        {
            if (childToArrange is not SSlotBase slot)
            {
                throw new ArgumentException("슬롯 형식이 아닙니다.", nameof(childToArrange));
            }

	        Margin margin = slotPadding;
	        float totalMargin = margin.GetTotalSpaceAlong(orientation);
	        float marginPre = ( orientation == Orientation.Horizontal ) ? margin.Left : margin.Top;
	        float marginPost = ( orientation == Orientation.Horizontal ) ? margin.Right : margin.Bottom;

	        int alignment = orientation.GetChildAlignmentAsInt(inLayoutFlow, childToArrange);

	        switch (alignment)
	        {
	            case (int)HorizontalAlignment.Fill:
		            return new AlignmentArrangeResult(marginPre, (allottedSize - totalMargin) * contentScale);
	        }

	        float childDesiredSize = ( orientation == Orientation.Horizontal )
		        ? ( slot.Content.GetDesiredSize().X * contentScale )
		        : ( slot.Content.GetDesiredSize().Y * contentScale );

	        float childSize = clampToParent ? Math.Min(childDesiredSize, allottedSize - totalMargin) : childDesiredSize;

	        switch ( alignment )
	        {
	        case (int)HorizontalAlignment.Left: // same as Align_Top
		        return new AlignmentArrangeResult(marginPre, childSize);
	        case (int)HorizontalAlignment.Center:
		        return new AlignmentArrangeResult(( allottedSize - childSize ) / 2.0f + marginPre - marginPost, childSize);
	        case (int)HorizontalAlignment.Right: // same as Align_Bottom		
		        return new AlignmentArrangeResult(allottedSize - childSize - marginPost, childSize);
	        }

	        // Same as Fill
	        return new AlignmentArrangeResult(marginPre, (allottedSize - totalMargin) * contentScale);
        }
    }
}
