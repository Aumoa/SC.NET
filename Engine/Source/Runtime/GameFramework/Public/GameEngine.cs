// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Diagnostics;
using SC.ThirdParty.DirectX;
using SC.ThirdParty.WinAPI;

namespace SC.Engine.Runtime.GameFramework
{
    /// <summary>
    /// 게임 엔진을 나타냅니다.
    /// </summary>
    public class GameEngine : IDisposable
    {
        DeviceBundle _device;
        CommandQueue _queue;
        SwapChain _chain;

        StepTimer _tickTimer = new();

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public GameEngine()
        {

        }

        /// <inheritdoc/>
        public virtual void Dispose()
        {
            _chain?.Dispose();
            _queue?.Dispose();
            _device?.Dispose();
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
            _device = new DeviceBundle(debugFlag);
            _queue = _device.CreateCommandQueue();
            _chain = _device.CreateSwapChain(target, _queue);
        }

        /// <summary>
        /// 엔진 사용을 종료합니다.
        /// </summary>
        public virtual void Shutdown()
        {

        }

        /// <summary>
        /// 게임 엔진의 주 루프를 진행합니다.
        /// </summary>
        public virtual void Tick()
        {
            _tickTimer.Tick();

            _chain.Present();
        }
    }
}
