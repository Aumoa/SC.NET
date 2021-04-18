// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 힙 유형을 나타냅니다.
    /// </summary>
    public enum D3D12HeapType
	{
		/// <summary>
		/// 기본 힙 유형을 사용합니다. 일반적으로, GPU에서 읽기 및 쓰기가 가능하며 CPU에선 접근할 수 없습니다.
		/// </summary>
		Default = 1,

		/// <summary>
		/// 업로드 힙 유형을 사용합니다. 일반적으로, GPU에서 읽기가 가능하며 CPU에서 쓰기가 가능합니다.
		/// </summary>
		Upload = 2,

		/// <summary>
		/// CPU에서 읽기 위한 힙 유형입니다. 일반적으로, GPU에서 쓰기가 가능하며 CPU에서 읽기가 가능합니다.
		/// </summary>
		Readback = 3,

		/// <summary>
		/// 힙 유형을 직접 지정합니다.
		/// </summary>
		Custom = 4
	}
}
