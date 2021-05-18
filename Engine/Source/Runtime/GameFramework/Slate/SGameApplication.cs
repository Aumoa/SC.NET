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
    class SGameApplication : SApplication
    {
        CoreWindow _target;

        SCanvasPanel _canvasPanel = new();
        RHITexture2D _texture;
        RHIShaderResourceView _srv;

        SImage _image;
        SImage[] _corner = new SImage[4];

        public SGameApplication(CoreWindow target, RHIDeviceBundle deviceBundle) : base(deviceBundle)
        {
            _target = target;

            _texture = deviceBundle.CreateTexture2D(new FileReference("dtd.jpg"), ImagePixelFormat.R8G8B8A8_UNORM);
            _srv = new RHIShaderResourceView(deviceBundle, 1);
            _srv.CreateShaderResourceView(0, _texture);

            _canvasPanel.AddSlot<SCanvasPanelSlot>()
            [
                _image = new SImage()
                {
                    Brush = new SlateBrush(_srv, _texture.GetDesiredSize())
                }
            ].Init
            (
                Offset: new Margin(100, 100, 100, 100),
                Anchors: new Anchors(0, 0, 1, 1)
            );

            _canvasPanel.AddSlot<SCanvasPanelSlot>()
            [
                new SImage()
                {
                    Brush = new SlateBrush(_srv, _texture.GetDesiredSize())
                }
            ].Init
            (
                Anchors: new Anchors(0, 0),
                Offset: new Margin(0, 0, 100, 100)
            );

            _canvasPanel.AddSlot<SCanvasPanelSlot>()
            [
                new SImage()
                {
                    Brush = new SlateBrush(_srv, _texture.GetDesiredSize())
                }
            ].Init
            (
                Anchors: new Anchors(1, 0),
                Offset: new Margin(0, 0, 100, 100),
                Alignment: new Vector2(1, 0)
            );

            _canvasPanel.AddSlot<SCanvasPanelSlot>()
            [
                new SImage()
                {
                    Brush = new SlateBrush(_srv, _texture.GetDesiredSize())
                }
            ].Init
            (
                Anchors: new Anchors(1, 1),
                Offset: new Margin(0, 0, 100, 100),
                Alignment: new Vector2(1, 1)
            );

            _canvasPanel.AddSlot<SCanvasPanelSlot>()
            [
                new SImage()
                {
                    Brush = new SlateBrush(_srv, _texture.GetDesiredSize())
                }
            ].Init
            (
                Anchors: new Anchors(0, 1),
                Offset: new Margin(0, 0, 100, 100),
                Alignment: new Vector2(0, 1)
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

        protected override SPanelWidget CreateApplicationPanel()
        {
            return _canvasPanel;
        }
    }
}
