// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 버퍼 셰이더 자원 서술자 속성을 나타냅니다.
    /// </summary>
    public enum D3D12BufferSRVFlags
	{
		/// <summary>
		/// 속성 없음을 나타냅니다.
		/// </summary>
		None = 0,

		/// <summary>
		/// 원시 데이터를 사용함을 나타냅니다.
		/// </summary>
		Raw = 0x1,
	}
}
