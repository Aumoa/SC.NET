// Copyright 2020 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D2D1 타원 영역을 정의합니다.
    /// </summary>
    public struct D2D1Ellipse
	{
		/// <summary>
		/// 타원의 중앙 지점을 나타냅니다.
		/// </summary>
		public Vector2 Point;

		/// <summary>
		/// X축 반지름을 나타냅니다.
		/// </summary>
		public float RadiusX;

		/// <summary>
		/// Y축 반지름을 나타냅니다.
		/// </summary>
		public float RadiusY;

		/// <summary>
		/// <see cref="D2D1Ellipse"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="pointX"> X축 중앙 지점 값을 전달합니다. </param>
		/// <param name="pointY"> Y축 중앙 지점 값을 전달합니다. </param>
		/// <param name="radius"> 반지름 값을 일괄 전달합니다. </param>
		public D2D1Ellipse( float pointX, float pointY, float radius )
		{
			this.Point = new Vector2( pointX, pointY );
			this.RadiusX = radius;
			this.RadiusY = radius;
		}

		/// <summary>
		/// <see cref="D2D1Ellipse"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="point"> 중앙 지점 값을 전달합니다. </param>
		/// <param name="radiusX"> X축 반지름 값을 일괄 전달합니다. </param>
		/// <param name="radiusY"> Y축 반지름 값을 일괄 전달합니다. </param>
		public D2D1Ellipse( Vector2 point, float radiusX, float radiusY )
		{
			this.Point = point;
			this.RadiusX = radiusX;
			this.RadiusY = radiusY;
		}

		/// <summary>
		/// 반지름 값을 일괄 설정합니다.
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
