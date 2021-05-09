// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Diagnostics;
using SC.Engine.Runtime.GameCore;
using SC.Engine.Runtime.GameFramework.SceneRendering;
using SC.Engine.Runtime.GameFramework.Slate;
using SC.Engine.Runtime.RenderCore;
using SC.Engine.Runtime.RenderCore.Slate.Application;
using SC.ThirdParty.WinAPI;

using static SC.Engine.Runtime.GameCore.Diagnostics.LoggingSystem;
using static SC.Engine.Runtime.GameCore.Diagnostics.LogVerbosity;

namespace SC.Engine.Runtime.GameFramework
{
    /// <summary>
    /// 게임 엔진을 나타냅니다.
    /// </summary>
    public class SGameEngine : SGameObject
    {
        static SGameEngine _engine;

        RHIDeviceBundle _device;
        RHICommandQueue _queue;
        SApplication _slateApp;

        StepTimer _tickTimer = new();
        RHIGameViewport _gameViewport;
        RHIAutoFence _fence;
        RenderThread _renderThread;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SGameEngine()
        {
            if (_engine is not null)
            {
                Log(Fatal, "Engine", "엔진 개체가 두 번 초기화되었습니다.");
            }

            _engine = this;
        }

        /// <summary>
        /// 엔진을 초기화합니다.
        /// </summary>
        public virtual void Init(CoreWindow target)
        {
            bool debugFlag = false;
#if DEBUG
            debugFlag = true;
#endif
            _device = new RHIDeviceBundle(debugFlag);
            _queue = _device.GetPrimaryQueue();
            _slateApp = CreateApplication(target);
            _fence = new RHIAutoFence(_device);
            _gameViewport = new RHIGameViewport(_device, target, _fence);
            _renderThread = new RenderThread(_device, _slateApp, _gameViewport);
            _renderThread.Init();
        }

        /// <summary>
        /// 엔진 사용을 종료합니다.
        /// </summary>
        public virtual void Shutdown()
        {
            _renderThread?.Dispose();
            _gameViewport?.Dispose();
            _slateApp?.Dispose();
            _queue?.Dispose();
            _fence?.Dispose();
            _device?.Dispose();
        }

        /// <summary>
        /// 게임 엔진의 주 루프를 진행합니다.
        /// </summary>
        public virtual void Tick()
        {
            _fence.Wait();
            _tickTimer.Tick();
            _renderThread.Execute();
            _gameViewport.Flush();
            _fence.Signal(_queue);
        }

        /// <summary>
        /// 게임 영역에 사용되는 뷰포트를 가져옵니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        public RHIGameViewport GetGameViewport()
        {
            return _gameViewport;
        }

        /// <summary>
        /// 전역 엔진 개체를 가져옵니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        public static SGameEngine GetEngine()
        {
            return _engine;
        }

        /// <summary>
        /// 엔진에서 사용할 주 애플리케이션 슬레이트를 제공합니다.
        /// </summary>
        /// <param name="target"> 애플리케이션 타깃이 전달됩니다. </param>
        /// <returns> 개체를 반환합니다. </returns>
        protected virtual SApplication CreateApplication(CoreWindow target)
        {
            return new SGameApplication(target, _device);
        }
    }
}
