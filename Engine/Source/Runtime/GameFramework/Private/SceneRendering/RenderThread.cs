// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.RenderCore;
using SC.Engine.Runtime.RenderCore.RenderPass;

namespace SC.Engine.Runtime.GameFramework.SceneRendering
{
    class RenderThread : IDisposable
    {
        RHIGeometryRenderPass _geometryPass;
        RHISlateRenderPass _slatePass;

        RHIDeferredContext _deviceContext;

        RHIGameViewport _gameViewport;
        RHICommandQueue _primaryQueue;

        public RenderThread(RHIDeviceBundle deviceBundle, RHIGameViewport gameViewport)
        {
            _geometryPass = new RHIGeometryRenderPass(deviceBundle);
            _slatePass = new RHISlateRenderPass(deviceBundle);

            _deviceContext = new RHIDeferredContext(deviceBundle, true);

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
            _geometryPass.BeginPass(_deviceContext, _gameViewport.GetRenderTarget());
            _geometryPass.EndPass(_deviceContext);
            _deviceContext.EndDraw();
            _primaryQueue.ExecuteCommandLists(_deviceContext);

            _slatePass.BeginPass(_deviceContext, _gameViewport.GetRenderTarget());
            _slatePass.EndPass(_deviceContext);
        }
    }
}
