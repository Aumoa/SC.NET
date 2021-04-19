// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Collections.Generic;

using SC.ThirdParty.DirectX;

namespace SC.Engine.Runtime.RenderCore
{
    /// <summary>
    /// 명령 대기열 개체를 표현합니다.
    /// </summary>
    public class CommandQueue : DeviceResource
    {
        ID3D12CommandQueue _queue;
        ID3D12Fence _fence;
        ulong _fenceValue;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="deviceBundle"> 디바이스 개체를 전달합니다. </param>
        public CommandQueue(DeviceBundle deviceBundle) : base(deviceBundle)
        {
            ID3D12Device device = deviceBundle.GetDevice();
            _queue = device.CreateCommandQueue(D3D12CommandListType.Direct);
            _fence = device.CreateFence(0);
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            base.Dispose();

            CollectPendingReferences();

            _queue?.Release();
            _fence?.Release();
        }

        /// <summary>
        /// 명령을 실행합니다.
        /// </summary>
        /// <param name="deviceContexts"> 디바이스 컨텍스트 목록을 전달합니다. </param>
        public void ExecuteCommandLists(params DeviceContext[] deviceContexts)
        {
            List<ID3D12CommandList> commandLists = new();

            for (int i = 0; i < deviceContexts?.Length; ++i)
            {
                ID3D12CommandList list = deviceContexts[i]?.GetCommandList();
                if (list is not null)
                {
                    commandLists.Add(list);
                }
            }

            if (commandLists.Count == 0)
            {
                return;
            }

            _queue.ExecuteCommandLists(commandLists);
            _queue.Signal(_fence, ++_fenceValue);
        }

        struct PendingReference
        {
            public ulong _fenceValue;
            public object _reference;
        }

        Queue<PendingReference> _pendingReferences = new();

        /// <summary>
        /// 종료 대기 리소스를 추가합니다.
        /// </summary>
        /// <param name="pr"> 개체를 전달합니다. </param>
        public void AddPendingReference(IDisposable pr)
        {
            _pendingReferences.Enqueue(new PendingReference { _fenceValue = _fenceValue, _reference = pr });
        }

        /// <summary>
        /// 종료 대기 리소스를 추가합니다.
        /// </summary>
        /// <param name="pr"> 개체를 전달합니다. </param>
        public void AddPendingReference(IUnknown pr)
        {
            _pendingReferences.Enqueue(new PendingReference { _fenceValue = _fenceValue, _reference = pr });
        }

        /// <summary>
        /// 종료 대기 리소스를 추가합니다.
        /// </summary>
        /// <param name="pr"> 개체를 전달합니다. </param>
        public void AddPendingReference(IList<IDisposable> pr)
        {
            _pendingReferences.Enqueue(new PendingReference { _fenceValue = _fenceValue, _reference = pr });
        }

        /// <summary>
        /// 종료 대기 리소스를 추가합니다.
        /// </summary>
        /// <param name="pr"> 개체를 전달합니다. </param>
        public void AddPendingReference(IList<IUnknown> pr)
        {
            _pendingReferences.Enqueue(new PendingReference { _fenceValue = _fenceValue, _reference = pr });
        }

        /// <summary>
        /// 종료 대기 리소스를 모두 해제합니다.
        /// </summary>
        public void CollectPendingReferences()
        {
            ulong completed = _fence.GetCompletedValue();
            while (_pendingReferences.Count != 0)
            {
                PendingReference pr = _pendingReferences.Peek();
                if (pr._fenceValue <= completed)
                {
                    if (pr._reference is IUnknown unknown)
                    {
                        unknown.Release();
                    }
                    else if (pr._reference is IDisposable disposable)
                    {
                        disposable.Dispose();
                    }
                    else if (pr._reference is IList<IUnknown> unknowns)
                    {
                        foreach (IUnknown unk in unknowns)
                        {
                            unk?.Release();
                        }
                    }
                    else if (pr._reference is IList<IDisposable> disps)
                    {
                        foreach (IDisposable disp in disps)
                        {
                            disp?.Dispose();
                        }
                    }

                    _pendingReferences.Dequeue();
                }
            }
        }

        internal ID3D12CommandQueue GetQueue()
        {
            return _queue;
        }
    }
}
