// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System.Drawing;

using SC.Engine.Runtime.Core.FileSystem;
using SC.Engine.Runtime.Core.Mathematics;
using SC.Engine.Runtime.Core.Numerics;
using SC.Engine.Runtime.GameFramework.Slate.Panel;
using SC.Engine.Runtime.RenderCore;
using SC.Engine.Runtime.RenderCore.Slate;
using SC.Engine.Runtime.RenderCore.Slate.Application;
using SC.Engine.Runtime.RenderCore.Slate.Layout;
using SC.Engine.Runtime.RenderCore.Slate.WidgetEvents;
using SC.Engine.Runtime.RenderCore.Slate.Widgets;
using SC.ThirdParty.WinAPI;
using SC.ThirdParty.WindowsCodecs;

namespace SC.Engine.Runtime.GameFramework.Slate
{
    class SGameWindow : SWindow
    {
        CoreWindow _target;

        SCanvasPanel _canvasPanel = new()
        {
            Visibility = SlateVisibility.Visible
        };

        RHITexture2D _texture;
        RHIShaderResourceView _srv;

        SHorizontalBoxPanel _box;

        public SGameWindow(CoreWindow target, RHIDeviceBundle deviceBundle) : base()
        {
            _target = target;

            // Register slate event handlers.
            target.LeftButtonDown += Target_LeftButtonDown;
            target.RightButtonDown += Target_RightButtonDown;
            target.LeftButtonUp += Target_LeftButtonUp;
            target.RightButtonUp += Target_RightButtonUp;
            target.MouseMove += Target_MouseMove;

            _texture = deviceBundle.CreateTexture2D(new FileReference("dtd.jpg"), ImagePixelFormat.R8G8B8A8_UNORM);
            _srv = new RHIShaderResourceView(deviceBundle, 1);
            _srv.CreateShaderResourceView(0, _texture);

            SlateBrush brush = new(_srv, new Vector2(100, 100));

            _canvasPanel
            //.AddSlot()
            //[
            //    new SImage()
            //    {
            //        Brush = brush
            //    }
            //]
            //.Init
            //(
            //    Anchors: new Anchors(0, 0),
            //    Offset: new Margin(0, 0, 100, 100)
            //)
            //.AddSlot()
            //[
            //    new SImage()
            //    {
            //        Brush = brush
            //    }
            //]
            //.Init
            //(
            //    Anchors: new Anchors(1, 0),
            //    Offset: new Margin(0, 0, 100, 100),
            //    Alignment: new Vector2(1, 0)
            //)
            //.AddSlot()
            //[
            //    new SImage()
            //    {
            //        Brush = brush
            //    }
            //].Init
            //(
            //    Anchors: new Anchors(1, 1),
            //    Offset: new Margin(0, 0, 100, 100),
            //    Alignment: new Vector2(1, 1)
            //)
            //.AddSlot()
            //[
            //    new SImage()
            //    {
            //        Brush = brush
            //    }
            //]
            //.Init
            //(
            //    Offset: new Margin(-250, -250, 500, 500),
            //    Anchors: new Anchors(0.5f)
            //)
            .AddSlot()
            [
                _box = new SHorizontalBoxPanel()
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
                Offset: new Margin(-250, -250, 500, 500),
                Anchors: new Anchors(0.5f)
            );
        }

        Vector2? _cursorPrevious;

        WidgetPointerEventArgs UpdateMouseEvent(int x, int y, WidgetPointerEventArgs.ButtonType? buttonType)
        {
            Vector2 current = new(x, y);
            Vector2 delta = current - (_cursorPrevious ?? current);
            _cursorPrevious = current;

            return new()
            {
                Parent = this,
                CursorLocation = current,
                CursorLocationDelta = delta,
                Type = buttonType
            };
        }

        private void Target_MouseMove(int x, int y) =>
            MouseMove(MakeRootGeometry(), UpdateMouseEvent(x, y, null));

        private void Target_LeftButtonDown(int x, int y) =>
            MouseDown(MakeRootGeometry(), UpdateMouseEvent(x, y, WidgetPointerEventArgs.ButtonType.Left));

        private void Target_RightButtonDown(int x, int y) =>
            MouseDown(MakeRootGeometry(), UpdateMouseEvent(x, y, WidgetPointerEventArgs.ButtonType.Right));

        private void Target_LeftButtonUp(int x, int y) =>
            MouseUp(MakeRootGeometry(), UpdateMouseEvent(x, y, WidgetPointerEventArgs.ButtonType.Left));

        private void Target_RightButtonUp(int x, int y) =>
            MouseUp(MakeRootGeometry(), UpdateMouseEvent(x, y, WidgetPointerEventArgs.ButtonType.Right));

        public override void Tick(Geometry allottedGeometry, double inCurrentTime, float inDeltaTime)
        {
            base.Tick(allottedGeometry, inCurrentTime, inDeltaTime);

            _box.RenderTransform ??= SlateRenderTransform.Identity;
            _box.RenderTransform = _box.RenderTransform.Value.Concatenate(new SlateRenderTransform(Matrix2x2.Rotation(inDeltaTime.ToRadians())));
            _box.RenderTransformPivot = new Vector2(0.5f);
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
