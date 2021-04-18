// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 컬러 쓰기 활성화 상태를 나타냅니다.
    /// </summary>
    [Flags]
	public enum D3D12ColorWriteEnable
	{
		/// <summary>
		/// 활성화하지 않습니다.
		/// </summary>
		None = 0,

		/// <summary>
		/// 빨간색 값을 활성화합니다.
		/// </summary>
		Red = 1,

		/// <summary>
		/// 초록색 값을 활성화합니다.
		/// </summary>
		Green = 2,

		/// <summary>
		/// 파란색 값을 활성화합니다.
		/// </summary>
		Blue = 4,

		/// <summary>
		/// 알파 값을 활성화합니다.
		/// </summary>
		Alpha = 8,

		/// <summary>
		/// 모든 값을 활성화합니다.
		/// </summary>
		All = Red | Green | Blue | Alpha
	}
}
