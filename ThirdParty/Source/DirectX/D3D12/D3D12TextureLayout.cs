// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// 텍스처 자원의 배치 레이아웃을 표현합니다.
    /// </summary>
    public enum D3D12TextureLayout
	{
		/// <summary>
		/// 알 수 없는 레이아웃을 표현합니다.
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// 열 우선 레이아웃을 표현합니다.
		/// </summary>
		RowMajor = 1,

		/// <summary>
		/// 
		/// </summary>
		UndefinedSwizzle64KB = 2,

		/// <summary>
		/// 
		/// </summary>
		StandardSwizzle64KB = 3
	}
}
