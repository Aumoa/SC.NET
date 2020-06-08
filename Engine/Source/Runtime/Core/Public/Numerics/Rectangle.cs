// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.Core.Numerics
{
    /// <summary>
    /// 직사각형 위치 값을 사용하는 사각 영역을 정의합니다.
    /// </summary>
    public struct Rectangle : INearlyEquatable<Rectangle, float>, IFormattable, IVectorType
    {
		/// <summary>
		/// 왼쪽 위치를 나타냅니다.
		/// </summary>
		public float Left;

		/// <summary>
		/// 상단 위치를 나타냅니다.
		/// </summary>
		public float Top;

		/// <summary>
		/// 오른쪽 위치를 나타냅니다.
		/// </summary>
		public float Right;

		/// <summary>
		/// 하단 위치를 나타냅니다.
		/// </summary>
		public float Bottom;

		/// <summary>
		/// 모든 값을 지정하여 <see cref="Rectangle"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="left"> 왼쪽 위치를 전달합니다. </param>
		/// <param name="top"> 상단 위치를 전달합니다. </param>
		/// <param name="right"> 오른쪽 위치를 전달합니다. </param>
		/// <param name="bottom"> 하단 위치를 전달합니다. </param>
		public Rectangle(float left, float top, float right, float bottom)
		{
			Left = left;
			Top = top;
			Right = right;
			Bottom = bottom;
		}

		/// <summary>
		/// 왼쪽 위 위치를 지정하는 벡터와 오른쪽 아래 위치를 지정하는 벡터를 사용하여 <see cref="Rectangle"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="leftTop"> 왼쪽 위 위치를 전달합니다. </param>
		/// <param name="rightBottom"> 오른쪽 아래 위치를 전달합니다. </param>
		public Rectangle(Vector2 leftTop, Vector2 rightBottom)
		{
			Left = leftTop.X;
			Top = leftTop.Y;
			Right = rightBottom.X;
			Bottom = rightBottom.Y;
		}

		/// <summary>
		/// 대상 오브젝트가 사각형일 경우, 두 사각형이 서로 같은지 비교합니다.
		/// </summary>
		/// <param name="obj"> 대상 오브젝트를 전달합니다. </param>
		/// <returns> 비교 결과가 반환됩니다. </returns>
		public override bool Equals(object obj)
        {
			if (obj is Rectangle r)
            {
				return Equals(r);
            }
			else
            {
				return base.Equals(obj);
            }
        }

		/// <summary>
		/// 사각형의 전체 값의 해시 코드를 가져옵니다.
		/// </summary>
		/// <returns> 해시 코드가 반환됩니다. </returns>
		public override int GetHashCode()
		{
			return Left.GetHashCode() ^ Top.GetHashCode() ^ Right.GetHashCode() ^ Bottom.GetHashCode();
		}

		/// <summary>
		/// {LT: {X, Y}, RB: {X, Y}, [Width * Height]} 형식의 문자열을 가져옵니다.
		/// </summary>
		/// <returns> 생성된 문자열이 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format(
				"{{LB: {0}, RB: {1}, [{2} * {3}]}}",
				LeftTop,
				RightBottom,
				Width,
				Height
			);
		}

		/// <summary>
		/// 두 사각형 서로 같은지 비교합니다.
		/// </summary>
		/// <param name="v"> 대상 사각형을 전달합니다. </param>
		/// <returns> 비교 결과가 반환됩니다. </returns>
		public bool Equals(Rectangle v)
        {
			return this == v;
        }

		/// <inheritdoc/>
		public bool NearlyEquals(in Rectangle right, float epsilon)
		{
			return Math.Abs(Left - right.Left) <= epsilon
				&& Math.Abs(Top - right.Top) <= epsilon
				&& Math.Abs(Right - right.Right) <= epsilon
				&& Math.Abs(Bottom - right.Bottom) <= epsilon;
		}

		/// <summary>
		/// 서식을 지정하여 {Left, Top, Right, Bottom} 형식의 문자열을 가져옵니다.
		/// </summary>
		/// <param name="format"> 서식 문자열을 전달합니다. </param>
		/// <param name="formatProvider"> 문화권 정보를 전달합니다. </param>
		/// <returns> 생성된 문자열이 반환됩니다. </returns>
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format(
				"{{LB: {0}, RB: {1}, [{2} * {3}]}}",
				LeftTop.ToString(format, formatProvider),
				RightBottom.ToString(format, formatProvider),
				Width.ToString(format, formatProvider),
				Height.ToString(format, formatProvider)
			);
		}

		/// <inheritdoc/>
		public float GetComponentOrDefault(int index)
		{
            return index switch
            {
                0 => Left,
                1 => Top,
                2 => Right,
                3 => Bottom,
                _ => 0,
            };
        }

		/// <inheritdoc/>
		public void Construct<T>(in T vector) where T : IVectorType
		{
			if (vector is not null)
			{
				Left = vector.GetComponentOrDefault(0);
				Top = vector.GetComponentOrDefault(1);
				Right = vector.GetComponentOrDefault(2);
				Bottom = vector.GetComponentOrDefault(3);
			}
			else
			{
				Left = 0;
				Top = 0;
				Right = 0;
				Bottom = 0;
			}
		}

		/// <inheritdoc/>
		public T Convert<T>() where T : IVectorType, new()
		{
			var value = new T();
			value.Construct(this);
			return value;
		}

		/// <inheritdoc/>
		public bool Contains(int index)
		{
			return index >= 0 && index < 3;
		}

		/// <inheritdoc/>
		public float this[int index]
		{
			get => GetComponentOrDefault(index);
			set
            {
                switch (index)
                {
					case 0:
						Left = value;
						break;
					case 1:
						Top = value;
						break;
					case 2:
						Right = value;
						break;
					case 3:
						Bottom = value;
						break;
                }					
            }
		}

		/// <inheritdoc/>
		public int Count
		{
			get => 4;
		}

		/// <summary>
		/// 위치가 이 사각형 내부에 존재하는지 검사합니다.
		/// </summary>
		/// <param name="point"> 위치 벡터를 전달합니다. </param>
		/// <returns> 내부에 존재할 경우 true를 반환합니다. </returns>
		public bool IsOverlap(Vector2 point)
		{
			if (point.X >= Left && point.X <= Right &&
				point.Y >= Top && point.Y <= Bottom)
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// 사각형이 서로 겹치는지 검사합니다.
		/// </summary>
		/// <param name="rect"> 사각형을 전달합니다. </param>
		/// <returns> 서로 겹칠 경우 true를 반환합니다. </returns>
		public bool IsOverlap(Rectangle rect)
		{
			return !(Left > rect.Right ||
					 Right < rect.Left ||
					 Top > rect.Bottom ||
					 Bottom < rect.Top);
		}

		/// <summary>
		/// 광선이 이 사각형 내부를 통과하는지 검사합니다.
		/// </summary>
		/// <param name="ray"> 광선을 전달합니다. </param>
		/// <returns> 내부를 통과할 경우 true를 반환합니다. </returns>
		public bool IsOverlap(Ray2 ray)
		{
			return IsIntersect(ray).HasValue;
		}

		/// <summary>
		/// 사각형이 서로 겹치는지 검사합니다. 겹칠 경우 겹친 영역을 반환합니다.
		/// </summary>
		/// <param name="rect"> 사각형을 전달합니다. </param>
		/// <returns> 서로 겹칠 경우 겹친 영역을, 그렇지 않을 경우 null을 반환합니다. </returns>
		public Rectangle? IsIntersect(Rectangle rect)
		{
			float left = Math.Max(Left, rect.Left);
			float top = Math.Max(Top, rect.Top);
			float right = Math.Min(Right, rect.Right);
			float bottom = Math.Min(Bottom, rect.Bottom);

			if (right >= left && bottom >= top)
			{
				return new Rectangle(left, top, right, bottom);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 광선이 이 사각형 내부를 통과하는지 검사합니다. 통과할 경우 최초 통과 지점까지 가는 광선의 거리가 반환됩니다.
		/// </summary>
		/// <param name="ray"> 광선을 전달합니다. </param>
		/// <returns> 내부를 통과할 경우 최초 통과 지점까지 가는 광선의 거리가, 그렇지 않을 경우 null을 반환합니다. </returns>
		public float? IsIntersect(Ray2 ray)
		{
			Vector2 dirinv = 1.0f / ray.Direction;

			float t1 = (Left - ray.Origin.X) * dirinv.X;
			float t2 = (Right - ray.Origin.X) * dirinv.X;
			float t3 = (Bottom - ray.Origin.Y) * dirinv.Y;
			float t4 = (Top - ray.Origin.Y) * dirinv.Y;

			float tmin = Math.Max(Math.Min(t1, t2), Math.Min(t3, t4));
			float tmax = Math.Min(Math.Max(t1, t2), Math.Max(t3, t4));

			if (tmax < 0)
			{
				return null;
			}

			if (tmin > tmax)
			{
				return null;
			}

			return tmin;
		}

		/// <summary>
		/// 왼쪽 위 위치 벡터를 설정하거나 가져옵니다.
		/// </summary>
		public Vector2 LeftTop
		{
			get => new Vector2(Left, Top);
			set
            {
				Left = value.X;
				Top = value.Y;
            }
		}

		/// <summary>
		/// 오른쪽 아래 위치 벡터를 설정하거나 가져옵니다.
		/// </summary>
		public Vector2 RightBottom
		{
			get => new Vector2(Right, Bottom);
			set
            {
				Right = value.X;
				Bottom = value.Y;
            }
		}

		/// <summary>
		/// 사각형의 너비를 설정하거나 가져옵니다. 설정할 경우 오른쪽 위치가 변경됩니다.
		/// </summary>
		public float Width
		{
			get => Right - Left;
			set => Right = Left + value;
		}

		/// <summary>
		/// 사각형의 높이를 설정하거나 가져옵니다. 설정할 경우 하단 위치가 변경됩니다.
		/// </summary>
		public float Height
		{
			get => Bottom - Top;
			set => Bottom = Top + value;
		}

		/// <summary>
		/// 사각형의 내부 크기를 가져옵니다.
		/// </summary>
		public float Area
		{
			get => Width * Height;
		}

		/// <summary>
		/// 두 사각형이 서로 같은지 비교합니다.
		/// </summary>
		/// <param name="left"> 첫 번째 사각형을 전달합니다. </param>
		/// <param name="right"> 두 번째 사각형을 전달합니다. </param>
		/// <returns> 비교 결과가 반환됩니다. </returns>
		public static bool operator ==(in Rectangle left, in Rectangle right)
		{
			return left.Left == right.Left && left.Top == right.Top && left.Right == right.Right && left.Bottom == right.Bottom;
		}

		/// <summary>
		/// 두 사각형이 서로 같지 않은지 비교합니다.
		/// </summary>
		/// <param name="left"> 첫 번째 사각형을 전달합니다. </param>
		/// <param name="right"> 두 번째 사각형을 전달합니다. </param>
		/// <returns> 비교 결과가 반환됩니다. </returns>
		public static bool operator !=(in Rectangle left, in Rectangle right)
		{
			return left.Left != right.Left || left.Top != right.Top || left.Right != right.Right || left.Bottom != right.Bottom;
		}
    }
}
