// Copyright 2020 Aumoa.lib. All right reserved.

using System.Collections.Generic;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 스트림 출력 정보를 서술합니다.
    /// </summary>
    public struct D3D12StreamOutputDesc
	{
		/// <summary>
		/// 스트림 출력 선언 목록을 나타냅니다.
		/// </summary>
		public IList<D3D12SODeclarationEntry> SODeclaration;

		/// <summary>
		/// 버퍼 간격 목록을 나타냅니다.
		/// </summary>
		public IList<uint> BufferStrides;

		/// <summary>
		/// 
		/// </summary>
		public uint RasterizedStream;
	}
}
