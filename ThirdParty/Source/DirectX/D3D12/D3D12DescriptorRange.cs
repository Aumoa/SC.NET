// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 서술자 범위에 대한 정보를 서술합니다.
    /// </summary>
    public struct D3D12DescriptorRange
	{
		/// <summary>
		/// 서술자 범위 유형을 나타냅니다.
		/// </summary>
		public D3D12DescriptorRangeType RangeType;

		/// <summary>
		/// 서술자 개수를 나타냅니다.
		/// </summary>
		public uint NumDescriptors;

		/// <summary>
		/// 서술자의 레지스터 번호의 첫 번째를 나타냅니다.
		/// </summary>
		public uint BaseShaderRegister;

		/// <summary>
		/// 레지스터 공간을 나타냅니다.
		/// </summary>
		public uint RegisterSpace;

		/// <summary>
		/// 테이블 시작 지점으로부터의 오프셋을 나타냅니다.
		/// </summary>
		public uint OffsetInDescriptorsFromTableStart;
	}
}
