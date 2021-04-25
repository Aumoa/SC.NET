﻿// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Collections.Generic;

using SC.ThirdParty.DirectX;

namespace SC.Engine.Runtime.RenderCore
{
    /// <summary>
    /// 디바이스 컨텍스트를 표현합니다.
    /// </summary>
    public class RHIDeviceContext : RHIDeviceResource
    {
        ID3D12Device _device;
        ID3D12CommandAllocator _allocator;
        ID3D12GraphicsCommandList _commandList;
        bool _hasBegunDraw;

        List<object> _pendingReferences = new();

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="deviceBundle"> 디바이스 개체를 전달합니다. </param>
        public RHIDeviceContext(RHIDeviceBundle deviceBundle) : base(deviceBundle)
        {
            _device = deviceBundle.GetDevice();
            _allocator = deviceBundle.GetDevice().CreateCommandAllocator(D3D12CommandListType.Direct);
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            base.Dispose();

            _device?.Release();
            _allocator?.Release();
            _commandList?.Release();

            foreach (object pendingResource in _pendingReferences)
            {
                if (pendingResource is IUnknown unknown)
                {
                    unknown?.Release();
                }
                else if (pendingResource is IDisposable disposable)
                {
                    disposable?.Dispose();
                }
            }
        }

        /// <summary>
        /// 렌더링을 시작합니다.
        /// </summary>
        public virtual void BeginDraw()
        {
            _allocator.Reset();
            if (_commandList is null)
            {
                _commandList = _device.CreateCommandList(D3D12CommandListType.Direct, _allocator);
            }
            else
            {
                _commandList.Reset(_allocator);
            }
            _hasBegunDraw = true;
        }

        /// <summary>
        /// 렌더링을 종료합니다.
        /// </summary>
        public virtual void EndDraw()
        {
            _commandList.Close();
            _hasBegunDraw = false;
        }

        /// <summary>
        /// 종료 대기 리소스를 추가합니다.
        /// </summary>
        /// <param name="pendingReference"> 개체를 전달합니다. </param>
        public void AddPendingReference(IDisposable pendingReference)
        {
            _pendingReferences.Add(pendingReference);
        }

        /// <summary>
        /// 종료 대기 리소스를 추가합니다.
        /// </summary>
        /// <param name="pendingReference"> 개체를 전달합니다. </param>
        public void AddPendingReference(IUnknown pendingReference)
        {
            _pendingReferences.Add(pendingReference);
        }

        internal ID3D12GraphicsCommandList GetCommandList()
        {
            return _commandList;
        }

        /// <summary>
        /// 렌더링이 시작되었는지 나타내는 값을 가져옵니다.
        /// </summary>
        public bool HasBegunDraw => _hasBegunDraw;

        /// <summary>
        /// 대상 할당기 개체와 교환합니다.
        /// </summary>
        /// <param name="target"> 개체의 참조를 전달합니다. </param>
        internal protected void SwapCommandAllocator(ref ID3D12CommandAllocator target)
        {
            ID3D12CommandAllocator tmp = target;
            target = _allocator;
            _allocator = tmp;
        }
    }
}