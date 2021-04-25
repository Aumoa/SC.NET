﻿// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using SC.ThirdParty.DirectX;

namespace SC.Engine.Runtime.RenderCore
{
    /// <summary>
    /// DirectX 디바이스 집합을 표현합니다.
    /// </summary>
    public unsafe class RHIDeviceBundle : IDisposable
    {
        IDXGIFactory1 _dxgiFactory;
        ID3D12Device _device;

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

            DXGICreateFlags dxgiFlags = 0;

            if (debugEnabled)
            {
                EnableDebugLayer();
                dxgiFlags |= DXGICreateFlags.Debug;
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
        }

        /// <summary>
        /// 디바이스의 주 명령 대기열 개체를 가져옵니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        public RHICommandQueue GetPrimaryQueue() => _primaryQueue;

        internal IDXGIFactory1 GetFactory() => _dxgiFactory;
        internal ID3D12Device GetDevice() => _device;
        internal ID3D11On12Device GetInteropDevice() => _device11On12;
        internal ID2D1DeviceContext GetDeviceContext2D() => _deviceContext2d;
        internal ID3D11DeviceContext GetDeviceContext() => _immCon11;

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
                ID3D12Debug debug = ComObject.CoCreateInstance<ID3D12Debug>();
            }
            catch (COMException)
            {

            }
        }
    }
}