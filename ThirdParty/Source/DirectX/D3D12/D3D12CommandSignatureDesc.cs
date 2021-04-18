// Copyright 2020 Aumoa.lib. All right reserved.

using System.Collections.Generic;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 명령 서명 정보를 서술합니다.
    /// </summary>
    public struct D3D12CommandSignatureDesc
	{
		/// <summary>
		/// 
		/// </summary>
		public uint ByteStride;

		/// <summary>
		/// 
		/// </summary>
		public IList<D3D12IndirectArgumentDesc> ArgumentDescs;

		/// <summary>
		/// 
		/// </summary>
		public uint NodeMask;
	}
}
