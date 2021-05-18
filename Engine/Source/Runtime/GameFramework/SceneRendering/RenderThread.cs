// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Numerics;
using SC.Engine.Runtime.RenderCore;
using SC.Engine.Runtime.RenderCore.RenderPass;
using SC.Engine.Runtime.RenderCore.Slate;
using SC.Engine.Runtime.RenderCore.Slate.Application;
using SC.Engine.Runtime.RenderCore.Slate.Layout;

namespace SC.Engine.Runtime.GameFramework.SceneRendering
{
    class RenderThread : IDisposable
    {
        RHIGeometryRenderPass _geometryPass;
        RHISlateRenderPass _slatePass;

        RHIDeferredContext _deviceContext;

        SWindow _slateApp;
        RHIGameViewport _gameViewport;
        RHICommandQueue _primaryQueue;

        public RenderThread(RHIDeviceBundle deviceBundle, SWindow sApp, RHIGameViewport gameViewport)
        {
            _geometryPass = new RHIGeometryRenderPass(deviceBundle);
            _slatePass = new RHISlateRenderPass(deviceBundle);

            _deviceContext = new RHIDeferredContext(deviceBundle, true);

            _slateApp = sApp;
            _gameViewport = gameViewport;
            _primaryQueue = deviceBundle.GetPrimaryQueue();
        }

        public void Init()
        {
            _geometryPass.CompileShader();
            _slatePass.CompileShader();
        }

        public virtual void Dispose()
        {
            _geometryPass?.Dispose();
            _slatePass?.Dispose();

            _deviceContext?.Dispose();
        }

        public void Execute()
        {
            _deviceContext.BeginDraw();

            RenderGeometry();
            RenderSlate();

            _deviceContext.EndDraw();
            _primaryQueue.ExecuteCommandLists(_deviceContext);
        }

        void RenderGeometry()
        {
            _geometryPass.BeginPass(_deviceContext, _gameViewport.GetRenderTarget());
            _geometryPass.EndPass(_deviceContext);
        }

        void RenderSlate()
        {
            SlateWindowElementList elements = new(_slateApp);

            _slatePass.BeginPass(_deviceContext, _gameViewport.GetRenderTarget());
            _slateApp.Paint(elements);
            _slatePass.RenderElements(_deviceContext, elements);
            _slatePass.EndPass(_deviceContext);
        }
    }
}
