// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 공유된 자원에 대한 핸들을 표현합니다.
    /// </summary>
    public struct DXGISharedResource
	{
		/// <summary>
		/// 핸들을 표현합니다.
		/// </summary>
		public IntPtr Handle;

		/// <summary>
		/// <see cref="DXGISharedResource"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="handle"> 핸들을 전달합니다. </param>
		public DXGISharedResource( IntPtr handle )
		{
			this.Handle = handle;
		}
	}
}
