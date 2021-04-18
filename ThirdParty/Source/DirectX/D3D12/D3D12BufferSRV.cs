// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 버퍼 셰이더 자원 서술자 정보를 표현합니다.
    /// </summary>
    public struct D3D12BufferSRV
	{
		/// <summary>
		/// 처음 원소의 위치를 나타냅니다.
		/// </summary>
		public ulong FirstElement;

		/// <summary>
		/// 원소의 개수를 나타냅니다.
		/// </summary>
		public uint NumElement;

		/// <summary>
		/// 원소의 바이트 단위 크기를 나타냅니다.
		/// </summary>
		public uint StructureByteStride;

		/// <summary>
		/// 버퍼의 셰이더 자원 서술자 속성을 나타냅니다.
		/// </summary>
		public D3D12BufferSRVFlags Flags;

		/// <summary>
		/// 개체의 단순 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
			=> $"{base.ToString()}: FirstElement = {FirstElement}, NumElement = {NumElement}, StructureByteStride = {StructureByteStride}";
	}
}
