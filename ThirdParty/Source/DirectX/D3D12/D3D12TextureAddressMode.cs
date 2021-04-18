// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 텍스처 좌표 모드를 표현합니다.
    /// </summary>
    public enum D3D12TextureAddressMode
	{
		/// <summary>
		/// 좌표가 범위를 벗어나면 시작 위치에서 다시 시작합니다.
		/// </summary>
		Wrap = 1,

		/// <summary>
		/// 좌표가 범위를 벗어나면 반대 방향으로 전진합니다.
		/// </summary>
		Mirror = 2,

		/// <summary>
		/// 좌표가 범위를 벗어나면 좌표의 값을 범위로 한정합니다.
		/// </summary>
		Clamp = 3,

		/// <summary>
		/// 좌표가 범위를 벗어나면 지정한 경계선 색을 사용하도록 합니다.
		/// </summary>
		Border = 4,

		/// <summary>
		/// 텍스처 좌표의 절대값을 가져온 다음, 최대 값으로 고정합니다.
		/// </summary>
		MirrorOnce = 5
	}
}
