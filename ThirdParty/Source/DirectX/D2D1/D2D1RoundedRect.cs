// Copyright 2020 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D2D1 둥근 사각형을 정의합니다.
    /// </summary>
    public struct D2D1RoundedRect
	{
		/// <summary>
		/// 사각 영역을 나타냅니다.
		/// </summary>
		public Rectangle Rect;

		/// <summary>
		/// X축 둥근 범위를 나타냅니다.
		/// </summary>
		public float RadiusX;

		/// <summary>
		/// Y축 둥근 범위를 나타냅니다.
		/// </summary>
		public float RadiusY;

		/// <summary>
		/// <see cref="D2D1RoundedRect"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="rect"> 사각 영역을 전달합니다. </param>
		/// <param name="radiusX"> X축 둥근 범위를 전달합니다. </param>
		/// <param name="radiusY"> Y축 둥근 범위를 전달합니다. </param>
		public D2D1RoundedRect( Rectangle rect, float radiusX, float radiusY )
		{
			this.Rect = rect;
			this.RadiusX = radiusX;
			this.RadiusY = radiusY;
		}

		/// <summary>
		/// 둥근 영역의 범위를 일괄 설정합니다.
		/// </summary>
		public float Radius
		{
			set
			{
				this.RadiusX = value;
				this.RadiusY = value;
			}
		}
	}
}
