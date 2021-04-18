// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 캐시된 파이프라인 상태에 대한 정보를 나타냅니다.
    /// </summary>
    public struct D3D12CachedPipelineState
	{
		/// <summary>
		/// 캐시된 데이터 블록의 네이티브 포인터를 나타냅니다.
		/// </summary>
		public IntPtr pCachedBlob;

		/// <summary>
		/// 캐시된 데이터 블록의 바이트 단위 사이즈를 나타냅니다.
		/// </summary>
		public ulong CachedBlobSizeInBytes;

		/// <summary>
		/// <see cref="D3D12CachedPipelineState"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="pCachedBlob"> 캐시된 데이터 블록의 네이티브 포인터를 전달합니다. </param>
		/// <param name="cachedBlobSizeInBytes"> 캐시된 데이터 블록의 바이트 단위 사이즈를 나타냅니다. </param>
		public D3D12CachedPipelineState( IntPtr pCachedBlob, ulong cachedBlobSizeInBytes )
		{
			this.pCachedBlob = pCachedBlob;
			this.CachedBlobSizeInBytes = cachedBlobSizeInBytes;
		}
	}
}
