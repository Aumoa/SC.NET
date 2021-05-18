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
        protected override int OnPaint(SlatePaintArgs paintArgs, Geometry allottedGeometry, Rectangle myCullingRect, SlateWindowElementList drawElements, int layer, bool parentEnabled)
        {
            SlateDrawElement sd = new()
            {
                Brush = Brush,
                Transform = allottedGeometry.ToPaintGeometry(),
                Layer = layer,
            };

            drawElements.AddElement(sd);
            return layer;
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
