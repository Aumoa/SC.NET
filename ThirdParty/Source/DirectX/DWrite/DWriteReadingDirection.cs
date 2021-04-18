// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite 읽기 방향을 표현합니다.
    /// </summary>
    public enum DWriteReadingDirection
	{
		/// <summary>
		/// 왼쪽부터 오른쪽으로 읽습니다.
		/// </summary>
		LeftToRight = 0,

		/// <summary>
		/// 오른쪽부터 왼쪽으로 읽습니다.
		/// </summary>
		RightToLeft = 1,

		/// <summary>
		/// 위부터 아래로 읽습니다.
		/// </summary>
		TopToBottom = 2,

		/// <summary>
		/// 아래부터 위로 읽습니다.
		/// </summary>
		BottomToTop = 3,
	}
}
