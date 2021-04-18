// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 텍스처 복사 서술 유형을 표현합니다.
    /// </summary>
    public enum D3D12TextureCopyType
	{
		/// <summary>
		/// 서브리소스 인덱스 정보를 사용하여 텍스처 복사 위치를 지정합니다.
		/// </summary>
		SubresourceIndex = 0,

		/// <summary>
		/// 리소스 배치 정보를 사용하여 버퍼 복사 위치를 지정합니다.
		/// </summary>
		PlacedFootprint = 1
	}
}
