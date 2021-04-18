// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// Specifies multiple wait flags for multiple fences.
    /// </summary>
    [Flags]
    public enum D3D12MultipleFenceWaitFlags
    {
        /// <summary>
        /// No flags are being passed. This means to use the default behavior, which is to wait for all fences before signaling the event.
        /// </summary>
        None = 0,

        /// <summary>
        /// Modifies behavior to indicate that the event should be signaled after any one of the fence values has been reached by its corresponding fence.
        /// </summary>
        Any = 0x1,

        /// <summary>
        /// An alias for D3D12_MULTIPLE_FENCE_WAIT_FLAG_NONE, meaning to use the default behavior and wait for all fences.
        /// </summary>
        All = 0
    }
}
