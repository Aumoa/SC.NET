// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.FileSystem;
using SC.Engine.Runtime.Core.Numerics;
using SC.ThirdParty.WindowsCodecs;

namespace SC.Engine.Runtime.RenderCore.Slate.Application
{
    /// <summary>
    /// UI로 구성되는 애플리케이션을 표현합니다.
    /// </summary>
    public class SApplication : SLeafWidget
    {
        RHITexture2D _texture;
        RHIShaderResourceView _srv;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SApplication(RHIDeviceBundle deviceBundle)
        {
            _texture = deviceBundle.CreateTexture2D(new FileReference("dtd.jpg"), ImagePixelFormat.R8G8B8A8_UNORM);
            _srv = new RHIShaderResourceView(deviceBundle, 1);
            _srv.CreateShaderResourceView(0, _texture._resource, null);
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            _texture?.Dispose();
            _srv?.Dispose();

            base.Dispose();
        }

        /// <inheritdoc/>
        protected override sealed void OnPaint(SlatePaintArgs paintArgs, SlateTransform allottedTransform)
        {
            paintArgs.ScreenSize = GetDesiredSize();

            SlateDrawElement sd = new();
            sd.Brush = new SlateBrush();
            sd.Brush.ImageSource = _srv;
            sd.Transform.Location = Vector2.Zero;
            sd.Transform.Size = _texture.GetDesiredSize();

            paintArgs.AddElement(sd, 0);
        }
    }
}
