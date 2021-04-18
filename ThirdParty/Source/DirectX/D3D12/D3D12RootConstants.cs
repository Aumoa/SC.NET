// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 루트 서명 32비트 상수에 대한 정보를 서술합니다.
    /// </summary>
    public struct D3D12RootConstants
	{
		/// <summary>
		/// 셰이더 레지스터 번호를 나타냅니다.
		/// </summary>
		public uint ShaderRegister;

		/// <summary>
		/// 레지스터 공간을 나타냅니다.
		/// </summary>
		public uint RegisterSpace;

		/// <summary>
		/// 32비트 값의 개수를 나타냅니다.
		/// </summary>
		public uint Num32BitValues;
	}
}
