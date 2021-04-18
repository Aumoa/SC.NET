// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 서술자 힙 유형을 나타냅니다.
    /// </summary>
    [Flags]
	public enum D3D12DescriptorHeapFlags
	{
		/// <summary>
		/// 속성 없음을 나타냅니다.
		/// </summary>
		None = 0,

		/// <summary>
		/// 셰이더 관측 가능을 나타냅니다.
		/// </summary>
		ShaderVisible = 0x01
	}
}
