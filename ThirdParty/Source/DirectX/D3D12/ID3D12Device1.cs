// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

using SC.ThirdParty.WinAPI;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 자원 관리를 수행하는 개체에 대한 공통 메서드를 제공합니다.
    /// </summary>
    [Guid("77acce80-638e-4e65-8895-c1f23386863e")]
    [ComVisible(true)]
    public interface ID3D12Device1 : ID3D12Object
    {
        /// <summary>
        /// Creates a cached pipeline library. For pipeline state objects (PSOs) that are expected to share data together, grouping them into a library before serializing them means that there's less overhead due to metadata, as well as the opportunity to avoid redundant or duplicated data from being written to disk.
        /// </summary>
        /// <param name="libraryBlob"> If the input library blob is empty, then the initial content of the library is empty. If the input library blob is not empty, then it is validated for integrity, parsed, and the pointer is stored. The pointer provided as input to this method must remain valid for the lifetime of the object returned. For efficiency reasons, the data is not copied. </param>
        /// <param name="riid"> Specifies a unique REFIID for the ID3D12PipelineLibrary object. </param>
        /// <param name="ppResource"> Returns a pointer to the created library. </param>
        void CreatePipelineLibrary(byte[] libraryBlob, Guid riid, out IUnknown ppResource);

        /// <summary>
        /// Specifies an event that should be fired when one or more of a collection of fences reach specific values.
        /// </summary>
        /// <param name="ppFences"> An array that specifies the <see cref="ID3D12Fence"/> objects. </param>
        /// <param name="fenceValues"> An array of length of <paramref name="ppFences"/> that specifies the fence values required for the event is to be signaled. </param>
        /// <param name="flags"> Specifies one of the <see cref="D3D12MultipleFenceWaitFlags"/> that determines how to proceed. </param>
        /// <param name="hEvent"> A handle to the event object. </param>
        void SetEventOnMultipleFenceCompletion(ID3D12Fence[] ppFences, ulong[] fenceValues, D3D12MultipleFenceWaitFlags flags, IPlatformHandle hEvent);

        /// <summary>
        /// This method sets residency priorities of a specified list of objects.
        /// </summary>
        /// <param name="ppObjects"> Specifies an array, containing references to <see cref="ID3D12Pageable"/> objects. </param>
        /// <param name="priorities"> Specifies an array, of <see cref="D3D12ResidencyPriority"/> values for the list of objects. </param>
        void SetResidencyPriority(ID3D12Pageable[] ppObjects, D3D12ResidencyPriority[] priorities);
    }
}
