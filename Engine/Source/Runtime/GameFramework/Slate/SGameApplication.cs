// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.FileSystem;
using SC.Engine.Runtime.Core.Numerics;
using SC.Engine.Runtime.GameFramework.Slate.Panel;
using SC.Engine.Runtime.RenderCore;
using SC.Engine.Runtime.RenderCore.Slate;
using SC.Engine.Runtime.RenderCore.Slate.Application;
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

        public SGameApplication(CoreWindow target, RHIDeviceBundle deviceBundle) : base(deviceBundle)
        {
            _target = target;

            _texture = deviceBundle.CreateTexture2D(new FileReference("dtd.jpg"), ImagePixelFormat.R8G8B8A8_UNORM);
            _srv = new RHIShaderResourceView(deviceBundle, 1);
            _srv.CreateShaderResourceView(0, _texture);

            var slot = _canvasPanel.AddSlot<SCanvasPanelSlot>();
            var image = new SImage();
            image.Brush = new SlateBrush(_srv, _texture.GetDesiredSize());
            slot.Content = image;
        }

        public override void Dispose()
        {
            _texture?.Dispose();
            _srv?.Dispose();

            base.Dispose();
        }

        public override Vector2 GetDesiredSize()
        {
            System.Drawing.Size sz = _target.GetClientSize();
            return new Vector2(sz.Width, sz.Height);
        }

        protected override SPanelWidget CreateApplicationPanel()
        {
            return _canvasPanel;
        }
    }
}
