// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 리소스 할당 정보를 표현합니다.
    /// </summary>
    public struct D3D12ResourceAllocationInfo
	{
		/// <summary>
		/// 할당 크기를 바이트 단위로 표현합니다.
		/// </summary>
		public ulong SizeInBytes;

		/// <summary>
		/// 할당 정렬을 바이트 단위로 표현합니다.
		/// </summary>
		public ulong Alignment;

		/// <summary>
		/// 개체의 간단한 정보를 텍스트 형식으로 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
			=> $"{base.ToString()}: SizeInBytes = {SizeInBytes}, Alignment = {Alignment}";
	}
}
