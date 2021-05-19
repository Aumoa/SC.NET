// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.FileSystem;
using SC.Engine.Runtime.Core.Mathematics;
using SC.Engine.Runtime.Core.Numerics;
using SC.Engine.Runtime.GameFramework.Slate.Panel;
using SC.Engine.Runtime.RenderCore;
using SC.Engine.Runtime.RenderCore.Slate;
using SC.Engine.Runtime.RenderCore.Slate.Application;
using SC.Engine.Runtime.RenderCore.Slate.Layout;
using SC.Engine.Runtime.RenderCore.Slate.Widgets;
using SC.ThirdParty.WinAPI;
using SC.ThirdParty.WindowsCodecs;

namespace SC.Engine.Runtime.GameFramework.Slate
{
    class SGameWindow : SWindow
    {
        CoreWindow _target;

        SCanvasPanel _canvasPanel = new();
        RHITexture2D _texture;
        RHIShaderResourceView _srv;

        SImage _image;

        public SGameWindow(CoreWindow target, RHIDeviceBundle deviceBundle) : base()
        {
            _target = target;

            _texture = deviceBundle.CreateTexture2D(new FileReference("dtd.jpg"), ImagePixelFormat.R8G8B8A8_UNORM);
            _srv = new RHIShaderResourceView(deviceBundle, 1);
            _srv.CreateShaderResourceView(0, _texture);

            SlateBrush brush = new(_srv, new Vector2(100, 100));

            _canvasPanel
            .AddSlot()
            [
                new SImage()
                {
                    Brush = brush,
                    Visibility = SlateVisibility.Collapsed
                }
            ]
            .Init
            (
                Anchors: new Anchors(0, 0),
                Offset: new Margin(0, 0, 100, 100)
            )
            .AddSlot()
            [
                new SImage()
                {
                    Brush = brush
                }
            ]
            .Init
            (
                Anchors: new Anchors(1, 0),
                Offset: new Margin(0, 0, 100, 100),
                Alignment: new Vector2(1, 0)
            )
            .AddSlot()
            [
                new SImage()
                {
                    Brush = brush
                }
            ].Init
            (
                Anchors: new Anchors(1, 1),
                Offset: new Margin(0, 0, 100, 100),
                Alignment: new Vector2(1, 1)
            )
            .AddSlot()
            [
                new SImage()
                {
                    Brush = brush
                }
            ]
            .Init
            (
                Anchors: new Anchors(0, 1),
                Offset: new Margin(0, 0, 100, 100),
                Alignment: new Vector2(0, 1)
            )
            .AddSlot()
            [
                new SHorizontalBoxPanel()
                {
                }
                .AddSlot()
                [
                    new SImage()
                    {
                        Brush = brush,
                    }
                ].Init
                (
                    HAlignment: HorizontalAlignment.Left,
                    SizeParam: new SizeParam(SizeRule.Auto, 1.0f),
                    SlotPadding: new Margin(10)
                )
                .AddSlot()
                [
                    new SImage()
                    {
                        Brush = brush
                    }
                ].Init
                (
                    HAlignment: HorizontalAlignment.Fill,
                    SizeParam: new SizeParam(SizeRule.Stretch, 1.0f),
                    SlotPadding: new Margin(0, 10)
                )
                .AddSlot()
                [
                    new SImage()
                    {
                        Brush = brush
                    }
                ].Init
                (
                    HAlignment: HorizontalAlignment.Right,
                    SizeParam: new SizeParam(SizeRule.Auto, 1.0f),
                    SlotPadding: new Margin(10)
                )
            ].Init
            (
                Anchors: new Anchors(0, 0),
                Offset: new Margin(0, 0, 1500, 100),
                Alignment: new Vector2(0, 0),
                AutoSize: true
            )
            .AddSlot()
            [
                _image = new SImage()
                {
                    Brush = brush
                }
            ]
            .Init
            (
                Offset: new Margin(100, 100, 100, 100),
                Anchors: new Anchors(0, 0, 1, 1),
                AutoSize: true
            );
        }

        public override void Tick(Geometry allottedGeometry, double inCurrentTime, float inDeltaTime)
        {
            base.Tick(allottedGeometry, inCurrentTime, inDeltaTime);

            _image.RenderTransform = new SlateRenderTransform(Matrix2x2.Rotation(((float)inCurrentTime).ToRadians()));
            _image.RenderTransformPivot = new Vector2(0.5f);
        }

        public override void Dispose()
        {
            _texture?.Dispose();
            _srv?.Dispose();

            base.Dispose();
        }

        public override Vector2 GetDesiredSize()
        {
            var sz = _target.GetClientSize();
            return new Vector2(sz.Width, sz.Height);
        }

        protected override void OnArrangeChildren(ArrangedChildren arrangedChildren, Geometry allottedGeometry)
        {
            _canvasPanel.ArrangeChildren(arrangedChildren, allottedGeometry);
        }
    }
}
