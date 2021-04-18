// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 셰이더 파이프라인 상태를 나타냅니다.
    /// </summary>
    [Guid( "765A30F3-F624-4C6F-A828-ACE948622445" )]
	[ComVisible( true )]
	public interface ID3D12PipelineState : ID3D12Pageable
	{
		/// <summary>
		/// 파이프라인 상태의 캐시 데이터 블록을 가져옵니다.
		/// </summary>
		/// <returns> 캐시 데이터 블록 개체가 반환됩니다. </returns>
		ID3DBlob GetCachedBlob();
	}
}
