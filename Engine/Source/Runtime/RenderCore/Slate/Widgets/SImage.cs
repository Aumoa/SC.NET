// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;
using SC.Engine.Runtime.RenderCore.Slate.Layout;

namespace SC.Engine.Runtime.RenderCore.Slate.Widgets
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
        protected override void OnPaint(SlatePaintArgs paintArgs, Geometry allottedTransform)
        {
            SlateDrawElement sd = new();
            sd.Brush = Brush;
            sd.Transform = allottedTransform;

            paintArgs.AddElement(sd, 0);
        }

        /// <inheritdoc/>
        public override Vector2 GetDesiredSize()
        {
            return Brush.ImageSize;
        }

        /// <summary>
        /// 브러시를 나타냅니다.
        /// </summary>
        public SlateBrush Brush
        {
            get;
            set;
        }
    }
}
