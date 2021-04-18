// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 루트 서명 서술자에 대한 정보를 서술합니다.
    /// </summary>
    public struct D3D12RootDescriptor
	{
		/// <summary>
		/// 셰이더 레지스터 번호를 나타냅니다.
		/// </summary>
		public uint ShaderRegister;

		/// <summary>
		/// 레지스터 공간을 나타냅니다.
		/// </summary>
		public uint RegisterSpace;
	}
}
