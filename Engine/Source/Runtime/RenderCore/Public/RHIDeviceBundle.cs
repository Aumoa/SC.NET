// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

using SC.Engine.Runtime.Core.FileSystem;
using SC.ThirdParty.DirectX;
using SC.ThirdParty.WindowsCodecs;

namespace SC.Engine.Runtime.RenderCore
{
    /// <summary>
    /// DirectX 디바이스 집합을 표현합니다.
    /// </summary>
    public unsafe class RHIDeviceBundle : IDisposable
    {
        IDXGIFactory1 _dxgiFactory;
        ID3D12Device _device;
        ImagingFactory _imagingFactory;

        ID3D11Device _device11;
        ID3D11On12Device _device11On12;
        ID3D11DeviceContext _immCon11;

        ID2D1Device _device2d;
        ID2D1DeviceContext _deviceContext2d;

        RHICommandQueue _primaryQueue;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="debugEnabled"> 디버그 모드로 개체를 생성합니다. </param>
        public RHIDeviceBundle(bool debugEnabled)
        {
            DXGI.CoInitialize();
            D3D12.CoInitialize();
            D3D11.CoInitialize();
            D2D1.CoInitialize();

            if (debugEnabled)
            {
                EnableDebugLayer();
            }

            // DXGI 팩토리 개체를 생성합니다.
            _dxgiFactory = ComObject.CoCreateInstance<IDXGIFactory1>();

            // 사용 가능한 어댑터를 열거하여 가장 적합한 어댑터를 선택합니다.
            for (IEnumerator<IDXGIAdapter> enumerator = _dxgiFactory.GetEnumerator(); enumerator.MoveNext();)
            {
                using (IDXGIAdapter adapter = enumerator.Current)
                {
                    if (!IsAdapterSuitable(adapter))
                    {
                        continue;
                    }

                    ID3D12Device device = null;
                    try
                    {
                        device = D3D12.D3D12CreateDevice(adapter, D3DFeatureLevel.Level11_0);
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    if (!IsDeviceSuitable(device))
                    {
                        device.Release();
                        continue;
                    }

                    _device = device;
                    break;
                }
            }

            if (_device is null)
            {
                throw new COMException("Cannot found suitable device.");
            }

            D3D11CreateDeviceFlags d3d11Flags = D3D11CreateDeviceFlags.BGRASupport;
            if (debugEnabled)
            {
                d3d11Flags |= D3D11CreateDeviceFlags.Debug;
            }

            _primaryQueue = new RHICommandQueue(this);
            _device11 = D3D11.D3D11On12CreateDevice(_device, d3d11Flags, _primaryQueue.GetQueue(), out _immCon11);
            _device11On12 = _device11.QueryInterface<ID3D11On12Device>();

            using (IDXGIDevice dxgiDevice = _device11On12.QueryInterface<IDXGIDevice>())
            {
                _device2d = D2D1.D2D1CreateDevice(dxgiDevice, new D2D1CreationProperties()
                {
                    ThreadingMode = D2D1ThreadingMode.SingleThreaded,
                    DebugLevel = D2D1DebugLevel.None,
                    Options = D2D1DeviceContextOptions.EnableMultithreadedOptimizations
                });
                _deviceContext2d = _device2d.CreateDeviceContext(D2D1DeviceContextOptions.EnableMultithreadedOptimizations);
            }

            _imagingFactory = new ImagingFactory();
        }

        /// <inheritdoc/>
        public virtual void Dispose()
        {
            _dxgiFactory?.Release();
            _device?.Release();

            _device11?.Release();
            _device11On12?.Release();
            _immCon11?.Release();

            _device2d?.Release();
            _deviceContext2d?.Release();

            _imagingFactory?.Dispose();
        }

        /// <summary>
        /// 디바이스의 주 명령 대기열 개체를 가져옵니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        public RHICommandQueue GetPrimaryQueue() => _primaryQueue;

        /// <summary>
        /// 이미지 파일로부터 텍스처를 생성합니다.
        /// </summary>
        /// <param name="fr"> 파일 레퍼런스를 전달합니다. </param>
        /// <param name="format"> 이미지 픽셀 형식을 전달합니다. </param>
        /// <returns> 개체가 반환됩니다. </returns>
        public RHITexture2D CreateTexture2D(FileReference fr, ImagePixelFormat format)
        {
            using (var img = new ImageLoader(_imagingFactory, fr))
            using (ImageFrame frame = img.GetFrame(0))
            using (ImageFormatConverter converter = new(_imagingFactory))
            {
                converter.Initialize(frame, format);
                return RHITexture2D.LoadFromImage(this, converter);
            }
        }

        internal IDXGIFactory1 GetFactory() => _dxgiFactory;
        internal ID3D12Device GetDevice() => _device;
        internal ID3D11On12Device GetInteropDevice() => _device11On12;
        internal ID2D1DeviceContext GetDeviceContext2D() => _deviceContext2d;
        internal ID3D11DeviceContext GetDeviceContext() => _immCon11;
        internal ID2D1Device GetDevice2D() => _device2d;
        internal ImagingFactory GetImagingFactory() => _imagingFactory;

        internal ID3D12Resource CreateTexture2D(int width, int height, DXGIFormat format, D3D12ResourceFlags flags = D3D12ResourceFlags.None, D3D12ClearValue? clearValue = null, D3D12ResourceStates initialState = D3D12ResourceStates.PixelShaderResource)
        {
            D3D12HeapProperties heapProp = new();
            heapProp.Type = D3D12HeapType.Default;

            D3D12ResourceDesc textureDesc = new();
            textureDesc.Dimension = D3D12ResourceDimension.Texture2D;
            textureDesc.Width = (ulong)width;
            textureDesc.Height = (uint)height;
            textureDesc.DepthOrArraySize = 1;
            textureDesc.MipLevels = 1;
            textureDesc.Format = format;
            textureDesc.SampleDesc = DXGISampleDesc.One;
            textureDesc.Flags = flags;
            return _device.CreateCommittedResource(heapProp, D3D12HeapFlags.None, textureDesc, initialState, clearValue);
        }

        internal ID3D12Resource CreateUploadHeap(ID3D12Resource resource, out D3D12PlacedSubresourceFootprint footprint)
        {
            D3D12ResourceDesc textureDesc = resource.GetDesc();
            if (textureDesc.Dimension is not D3D12ResourceDimension.Texture2D)
            {
                throw new ArgumentException("textureDesc.Dimension is not D3D12ResourceDimension.Texture2D");
            }

            D3D12PlacedSubresourceFootprint[] footprints = _device.GetCopyableFootprints(textureDesc, 0, 1, 0, out var _, out var _, out ulong totalSize);
            footprint = footprints[0];

            D3D12HeapProperties heapProp = new();
            heapProp.Type = D3D12HeapType.Upload;

            D3D12ResourceDesc bufferDesc = new();
            bufferDesc.Dimension = D3D12ResourceDimension.Buffer;
            bufferDesc.Width = totalSize;
            bufferDesc.Height = 1;
            bufferDesc.DepthOrArraySize = 1;
            bufferDesc.MipLevels = 1;
            bufferDesc.SampleDesc = DXGISampleDesc.One;
            bufferDesc.Layout = D3D12TextureLayout.RowMajor;

            return _device.CreateCommittedResource(heapProp, D3D12HeapFlags.None, bufferDesc, D3D12ResourceStates.GenericRead, null);
        }

        bool IsAdapterSuitable(IDXGIAdapter adapter)
        {
            using (IDXGIAdapter1 adapter1 = adapter.QueryInterface<IDXGIAdapter1>())
            {
                DXGIAdapterDesc1 desc = adapter1.GetDesc1();
                if (desc.Flags == DXGIAdapterFlags.Remote || desc.Flags == DXGIAdapterFlags.Software)
                {
                    return false;
                }
            }

            return true;
        }

        bool IsDeviceSuitable(ID3D12Device device)
        {
            return true;
        }
        
        void EnableDebugLayer()
        {
            try
            {
                using (ID3D12Debug debug = ComObject.CoCreateInstance<ID3D12Debug>())
                {
                    debug.EnableDebugLayer();
                }
            }
            catch (COMException)
            {
            }
        }
    }
}