// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.RenderCore.Slate
{
    /// <summary>
    /// <see cref="SlateVisibility"/> 열거 형식에 대한 확장 함수를 제공합니다.
    /// </summary>
    public static class SlateVisibilityExtensions
    {
		/** Entity is visible */
		const int VISPRIVATE_Visible = 0x1 << 0;
		/** Entity is invisible and takes up no space */
		const int VISPRIVATE_Collapsed = 0x1 << 1;
		/** Entity is invisible, but still takes up space (layout pretends it is visible) */
		const int VISPRIVATE_Hidden = 0x1 << 2;
		/** Can we click on this widget or is it just non-interactive decoration? */
		const int VISPRIVATE_SelfHitTestVisible = 0x1 << 3;
		/** Can we click on this widget's child widgets? */
		const int VISPRIVATE_ChildrenHitTestVisible = 0x1 << 4;

        /** Default widget visibility - visible and can interactive with the cursor */
        const int VIS_Visible = VISPRIVATE_Visible | VISPRIVATE_SelfHitTestVisible | VISPRIVATE_ChildrenHitTestVisible;
		/** Not visible and takes up no space in the layout; can never be clicked on because it takes up no space. */
		const int VIS_Collapsed = VISPRIVATE_Collapsed;
		/** Not visible, but occupies layout space. Not interactive for obvious reasons. */
		const int VIS_Hidden = VISPRIVATE_Hidden;
		/** Visible to the user, but only as art. The cursors hit tests will never see this widget. */
		const int VIS_HitTestInvisible = VISPRIVATE_Visible;
		/** Same as HitTestInvisible, but doesn't apply to child widgets. */
		const int VIS_SelfHitTestInvisible = VISPRIVATE_Visible | VISPRIVATE_ChildrenHitTestVisible;

        /** Any visibility will do */
        const int VIS_All = VISPRIVATE_Visible | VISPRIVATE_Hidden | VISPRIVATE_Collapsed | VISPRIVATE_SelfHitTestVisible | VISPRIVATE_ChildrenHitTestVisible;

        /// <summary>
        /// 가시 상태 필터를 통과하는지 검사합니다.
        /// </summary>
        /// <param name="inVisibility"> 가시 상태를 전달합니다. </param>
        /// <param name="inVisibilityFilter"> 가시 상태 필터를 전달합니다. </param>
        /// <returns> 통과 여부가 반환됩니다. </returns>
        public static bool DoesVisibilityPassFilter(this SlateVisibility inVisibility, SlateVisibility inVisibilityFilter)
        {
            return 0 != (inVisibility.GetValue() & inVisibilityFilter.GetValue());
        }

        /// <summary>
        /// 자식 위젯이 히트 테스트 가능한지 검사합니다.
        /// </summary>
        /// <param name="inVisibility"> 가시 상태를 전달합니다. </param>
        /// <returns> 결과가 반환됩니다. </returns>
        public static bool AreChildrenHitTestVisible(this SlateVisibility inVisibility) => 0 != (inVisibility.GetValue() & VISPRIVATE_ChildrenHitTestVisible);

        /// <summary>
        /// 현재 위젯이 히트 테스트 가능한지 검사합니다.
        /// </summary>
        /// <param name="inVisibility"> 가시 상태를 전달합니다. </param>
        /// <returns> 결과가 반환됩니다. </returns>
        public static bool IsHitTestVisible(this SlateVisibility inVisibility) => 0 != (inVisibility.GetValue() & VISPRIVATE_SelfHitTestVisible);

        /// <summary>
        /// 현재 위젯이 화면에 보이는지 검사합니다.
        /// </summary>
        /// <param name="inVisibility"> 가시 상태를 전달합니다. </param>
        /// <returns> 결과가 반환됩니다. </returns>
        public static bool IsVisible(this SlateVisibility inVisibility) => 0 != (inVisibility.GetValue() & VIS_Visible);

        internal static int GetValue(this SlateVisibility inVisibility)
        {
            return inVisibility switch
            {
                SlateVisibility.Visible => VIS_Visible,
                SlateVisibility.Collapsed => VIS_Collapsed,
                SlateVisibility.Hidden => VIS_Hidden,
                SlateVisibility.HitTestInvisible => VIS_HitTestInvisible,
                SlateVisibility.SelfHitTestInvisible => VIS_SelfHitTestInvisible,
                _ => throw new ArgumentException("올바르지 않은 비저빌리티 플래그입니다.")
            };
        }
    }
}
