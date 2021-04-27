// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Numerics;
using SC.ThirdParty.DirectX;
using SC.ThirdParty.WinAPI;

namespace SC.Engine.Runtime.RenderCore
{
    /// <summary>
    /// RHI 게임 뷰포트를 표현합니다.
    /// </summary>
    public class RHIGameViewport : IDisposable
    {
        RHIDeviceBundle _deviceBundle;
        RHISwapChain _swapChain;
        RHIAutoFence _fence;

        int _resolutionX;
        int _resolutionY;

        ID3D12Resource[] _resources = new ID3D12Resource[3];
        ID3D11Resource[] _interopResources = new ID3D11Resource[3];
        ID2D1Bitmap1[] _bitmaps = new ID2D1Bitmap1[3];

        RHIRenderTargetView _rtv;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="deviceBundle"> 디바이스를 전달합니다. </param>
        /// <param name="target"> 창 개체를 전달합니다. </param>
        /// <param name="fence"> 펜스 개체를 전달합니다. </param>
        public RHIGameViewport(RHIDeviceBundle deviceBundle, CoreWindow target, RHIAutoFence fence)
        {
            _deviceBundle = deviceBundle;
            _swapChain = new RHISwapChain(deviceBundle, target);
            _fence = fence;
            _rtv = new RHIRenderTargetView(deviceBundle, 3);

            System.Drawing.Size clientSize = target.GetClientSize();
            _resolutionX = clientSize.Width;
            _resolutionY = clientSize.Height;

            target.Sizing += ResizeBuffers;
        }

        /// <inheritdoc/>
        public virtual void Dispose()
        {
            for (int i = 0; i < _resources.Length; ++i)
            {
                _resources[i]?.Release();
                _interopResources[i]?.Release();
                _bitmaps[i]?.Release();
            }

            _deviceBundle.GetDeviceContext().Flush();
            _fence.Wait();
            _swapChain?.Dispose();
        }

        /// <summary>
        /// 화면에 출력합니다.
        /// </summary>
        public void Flush()
        {
            _swapChain.Present();
        }

        /// <summary>
        /// 렌더 타겟을 가져옵니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        public RHIRenderTarget GetRenderTarget()
        {
            int index = _swapChain.GetCurrentBackBufferIndex();
            RHIRenderTarget renderTarget;
            renderTarget.Resource = _resources[index];
            renderTarget.CPUHandle = _rtv.GetCPUHandle(index);
            renderTarget.Description = $"RHIGameViewport.RenderTarget{index}";
            renderTarget.ClearColor = Color.Transparent;
            renderTarget.Bitmap = _bitmaps[index];
            return renderTarget;
        }

        /// <summary>
        /// 버퍼의 크기를 조절합니다.
        /// </summary>
        /// <param name="resolutionX"> X축 해상도를 전달합니다. </param>
        /// <param name="resolutionY"> Y축 해상도를 전달합니다. </param>
        public void ResizeBuffers(int resolutionX, int resolutionY)
        {
            for (int i = 0; i < _resources.Length; ++i)
            {
                _resources[i]?.Release();
                _interopResources[i]?.Release();
                _bitmaps[i]?.Release();
            }

            _deviceBundle.GetDeviceContext().Flush();
            _fence.Wait();
            _swapChain.ResizeBuffers(resolutionX, resolutionY);

            ID3D11On12Device interopDevice = _deviceBundle.GetInteropDevice();
            ID2D1DeviceContext deviceContext2d = _deviceBundle.GetDeviceContext2D();

            D2D1BitmapProperties1 bitmapProp = new()
            {
                BitmapOptions = D2D1BitmapOptions.Target | D2D1BitmapOptions.CannotDraw,
                PixelFormat = new() { AlphaMode = D2D1AlphaMode.Premultiplied, Format = DXGIFormat.B8G8R8A8_UNORM },
                DpiX = 96.0f,
                DpiY = 96.0f
            };

            for (int i = 0; i < _resources.Length; ++i)
            {
                _resources[i] = _swapChain.GetBuffer(i);
                _interopResources[i] = interopDevice.CreateWrappedResource(_resources[i], D3D11BindFlags.RenderTarget, D3D12ResourceStates.RenderTarget, D3D12ResourceStates.Present);

                using (IDXGISurface surface = _interopResources[i].QueryInterface<IDXGISurface>())
                {
                    _bitmaps[i] = deviceContext2d.CreateBitmapFromDxgiSurface(surface, bitmapProp);
                }

                _rtv.CreateView(i, _resources[i], null);
            }

            _resolutionX = resolutionX;
            _resolutionY = resolutionY;
        }

        /// <summary>
        /// X축 해상도를 나타냅니다.
        /// </summary>
        public int ResolutionX => _resolutionX;

        /// <summary>
        /// Y축 해상도를 나타냅니다.
        /// </summary>
        public int ResolutionY => _resolutionY;
    }
}
