// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 매핑된 표면 영역에 대한 정보를 나타냅니다.
    /// </summary>
    public struct DXGIMappedRect
	{
		/// <summary>
		/// 2차원 표면 영역의 너비 바이트 단위 크기를 표현합니다.
		/// </summary>
		public int Pitch;

		/// <summary>
		/// (네이티브) 2차원 표면 영역의 바이트 데이터를 표현합니다.
		/// </summary>
		public IntPtr pBits;
	}
}
