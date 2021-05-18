// Copyright 2020-2021 Aumoa.lib. All right reserved.

namespace SC.Engine.Runtime.GameFramework.Slate.Panel
{
    /// <summary>
    /// 레이아웃의 크기 매개변수를 표현합니다.
    /// </summary>
    public record SizeParam
    {
        /// <summary>
        /// 크기 규칙을 나타냅니다.
        /// </summary>
        public SizeRule SizeRule;

        /// <summary>
        /// 규칙 매개변수를 나타냅니다.
        /// </summary>
        public float Value;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="sizeRule"> 크기 규칙을 전달합니다. </param>
        /// <param name="value"> 규칙 매개변수 값을 전달합니다. </param>
        public SizeParam(SizeRule sizeRule, float value)
        {
            SizeRule = sizeRule;
            Value = value;
        }
    }
}
