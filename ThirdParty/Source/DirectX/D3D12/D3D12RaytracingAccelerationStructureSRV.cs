// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 레이트레이싱 가속화 구조체 셰이더 자원 서술자 정보를 표현합니다.
    /// </summary>
    public struct D3D12RaytracingAccelerationStructureSRV
	{
		/// <summary>
		/// 가속화 구조체 자원의 GPU 가상 주소를 나타냅니다.
		/// </summary>
		public ulong Location;

		/// <summary>
		/// <see cref="D3D12RaytracingAccelerationStructureSRV"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="buffer"></param>
		public D3D12RaytracingAccelerationStructureSRV( ID3D12Resource buffer )
		{
			Location = buffer.GetGPUVirtualAddress();
		}
	}
}
