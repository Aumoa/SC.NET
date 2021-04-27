// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.ThirdParty.DirectX;
using SC.ThirdParty.WinAPI;

namespace SC.Engine.Runtime.RenderCore
{
    /// <summary>
    /// 스왑 체인을 표현합니다.
    /// </summary>
    public class RHISwapChain : RHIDeviceResource
    {
        IDXGISwapChain3 _swapChain;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="deviceBundle"> 디바이스 개체를 전달합니다. </param>
        /// <param name="target"> 렌더 타겟을 전달합니다. </param>
        public RHISwapChain(RHIDeviceBundle deviceBundle, CoreWindow target) : base(deviceBundle)
        {
            RHICommandQueue queue = deviceBundle.GetPrimaryQueue();
            IDXGIFactory1 factory = deviceBundle.GetFactory();

            DXGISwapChainDesc desc = new();
            desc.BufferDesc = new DXGIModeDesc(0, 0, DXGIFormat.B8G8R8A8_UNORM);
            desc.SampleDesc = new DXGISampleDesc(1, 0);
            desc.BufferUsage = DXGIUsage.BackBuffer;
            desc.BufferCount = 3;
            desc.SwapEffect = DXGISwapEffect.FlipDiscard;
            desc.OutputWindow = target;
            desc.Windowed = true;

            using (IDXGISwapChain swapChain = factory.CreateSwapChain(queue.GetQueue(), desc))
            {
                _swapChain = swapChain.QueryInterface<IDXGISwapChain3>();
            }
        }

        /// <summary>
        /// 후면 버퍼 내용을 화면에 출력합니다.
        /// </summary>
        public void Present()
        {
            _swapChain.Present();
        }

        /// <summary>
        /// 버퍼의 크기를 조절합니다.
        /// </summary>
        /// <param name="resolutionX"> X축 해상도를 전달합니다. </param>
        /// <param name="resolutionY"> Y축 해상도를 전달합니다. </param>
        public void ResizeBuffers(int resolutionX, int resolutionY)
        {
            _swapChain.ResizeBuffers(resolutionX, resolutionY);
        }

        internal ID3D12Resource GetBuffer(int index)
        {
            return _swapChain.GetBuffer<ID3D12Resource>(index);
        }

        internal int GetCurrentBackBufferIndex()
        {
            return (int)_swapChain.GetCurrentBackBufferIndex();
        }
    }
}
