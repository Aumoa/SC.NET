// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 GPU 메모리 단계를 표현합니다.
    /// </summary>
    public enum D3D12MemoryPool
	{
		/// <summary>
		/// 알 수 없는 메모리 단계입니다.
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// L0 단계입니다.
		/// </summary>
		L0 = 1,

		/// <summary>
		/// L1 단계입니다.
		/// </summary>
		L1 = 2
	}
}
