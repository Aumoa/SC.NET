// Copyright 2020-2021 Aumoa.lib. All right reserved.

namespace SC.Engine.Runtime.RenderCore.Slate
{
    /// <summary>
    /// UI 이미지를 표현합니다.
    /// </summary>
    public class SImage : SLeafWidget
    {
        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SImage()
        {
        }

        /// <inheritdoc/>
        public override void OnPaint(SlatePaintArgs paintArgs, SlateTransform allottedTransform)
        {
            base.OnPaint(paintArgs, allottedTransform);
        }
    }
}
