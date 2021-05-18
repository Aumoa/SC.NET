// Copyright 2020-2021 Aumoa.lib. All right reserved.

namespace SC.Engine.Runtime.RenderCore.Slate.Layout
{
    /// <summary>
    /// 수직 및 수평 정렬 매개변수를 사용하는 슬롯 형식에 대한 공통 함수를 제공합니다.
    /// </summary>
    public interface IAlignmentSlot
    {
        /// <summary>
        /// 수평 정렬 위치를 가져오거나 설정합니다.
        /// </summary>
        HorizontalAlignment HAlignment { get; set; }

        /// <summary>
        /// 수직 정렬 위치를 가져오거나 설정합니다.
        /// </summary>
        VerticalAlignment VAlignment { get; set; }
    }
}
