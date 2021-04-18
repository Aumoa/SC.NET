// Copyright 2020 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

using System.Collections.Generic;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 디스플레이 출력 매개변수를 표현합니다.
    /// </summary>
    public struct DXGIPresentParameters
	{
		/// <summary>
		/// 업데이트 된 그래픽 내용의 사각 영역 목록입니다. 이 작업으로 런타임은 디스플레이 출력을 최적화할 수 있습니다. 사각 영역 이외에 영역에 렌더링 된 부분은 정의되지 않습니다.
		/// </summary>
		public IList<Rectangle> DirtyRects;

		/// <summary>
		/// 스크롤 된 사각 영역을 가리킵니다. 이 영역은 내용이 전송되기 전 이전 프레임의 사각형입니다. null을 지정할 경우 스크롤 되지 않음을 나타냅니다.
		/// </summary>
		public Rectangle? ScrollRect;

		/// <summary>
		/// 이전 프레임의 사각 영역에서 현재 프레임의 사각 영역으로 이동하는 값을 나타냅니다. null을 지정할 경우 이동하지 않음을 나타냅니다.
		/// </summary>
		public Vector2? ScrollOffset;

		/// <summary>
		/// <see cref="DXGIPresentParameters"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="dirtyRects"> 업데이트된 사각 영역 목록을 전달합니다. </param>
		public DXGIPresentParameters( params Rectangle[] dirtyRects )
		{
			this.DirtyRects = dirtyRects;
			ScrollRect = null;
			ScrollOffset = null;
		}
	}
}
