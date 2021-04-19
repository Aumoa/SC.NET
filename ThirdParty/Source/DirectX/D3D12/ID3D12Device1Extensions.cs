// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// <see cref="ID3D12Device1"/> 인터페이스 개체에 대한 확장 메서드를 제공합니다.
    /// </summary>
    public static class ID3D12Device1Extensions
    {
        /// <summary>
        /// Creates a cached pipeline library. For pipeline state objects (PSOs) that are expected to share data together, grouping them into a library before serializing them means that there's less overhead due to metadata, as well as the opportunity to avoid redundant or duplicated data from being written to disk.
        /// </summary>
		/// <typeparam name="T"> 개체의 인터페이스 형식을 전달합니다. </typeparam>
		/// <param name="this"> 개체를 전달합니다. </param>
        /// <param name="libraryBlob"> If the input library blob is empty, then the initial content of the library is empty. If the input library blob is not empty, then it is validated for integrity, parsed, and the pointer is stored. The pointer provided as input to this method must remain valid for the lifetime of the object returned. For efficiency reasons, the data is not copied. </param>
        /// <returns> Returns a pointer to the created library. </returns>
        public static T CreatePipelineLibrary<T>(this ID3D12Device1 @this, byte[] libraryBlob) where T : class
        {
            @this.CreatePipelineLibrary(libraryBlob, typeof(T).GUID, out var ppUnknown);
            return ppUnknown as T;
        }
    }
}
