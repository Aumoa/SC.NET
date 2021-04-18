// Copyright 2020 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

using System.Collections.Generic;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 버려질 영역에 대한 정보를 나타냅니다.
    /// </summary>
    public struct D3D12DiscardRegion
	{
		/// <summary>
		/// 버려질 영역 목록을 표현합니다. null일 경우 전체 영역을 사용합니다.
		/// </summary>
		public IList<Rectangle> Rects;

		/// <summary>
		/// 첫 번째 서브리소스 인덱스를 표현합니다.
		/// </summary>
		public uint FirstSubresource;

		/// <summary>
		/// 서브리소스 개수를 표현합니다.
		/// </summary>
		public uint NumSubresources;

		/// <summary>
		/// <see cref="D3D12DiscardRegion"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="numSubresources"> 서브리소스 개수를 전달합니다. </param>
		public D3D12DiscardRegion( uint numSubresources )
		{
			this.Rects = null;
			this.FirstSubresource = 0;
			this.NumSubresources = numSubresources;
		}
	}
}
