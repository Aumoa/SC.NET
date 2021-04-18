// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 렌더 타겟 접근 서술자 정보를 표현합니다.
    /// </summary>
    public struct D3D12BufferRTV
	{
		/// <summary>
		/// 처음 원소의 위치를 나타냅니다.
		/// </summary>
		public ulong FirstElement;

		/// <summary>
		/// 원소의 개수를 나타냅니다.
		/// </summary>
		public uint NumElement;
	}
}
