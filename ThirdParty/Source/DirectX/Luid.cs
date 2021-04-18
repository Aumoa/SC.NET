// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// 개체의 범위 내에서만 사용되는 지역 고유 ID를 표현합니다.
    /// </summary>
    public struct Luid : IEquatable<Luid>
	{
		/// <summary>
		/// LowPart 값을 표현합니다.
		/// </summary>
		public uint LowPart;

		/// <summary>
		/// HighPart 값을 표현합니다.
		/// </summary>
		public int HighPart;

		/// <summary>
		/// <see cref="Luid"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="lowPart"> LowPart 값을 전달합니다. </param>
		/// <param name="highPart"> HighPart 값을 전달합니다. </param>
		public Luid(uint lowPart, int highPart)
		{
			this.LowPart = lowPart;
			this.HighPart = highPart;
		}

		/// <summary>
		/// 두 개체가 같은지 비교합니다.
		/// </summary>
		/// <param name="right"> 비교 대상 개체를 전달합니다. </param>
		/// <returns> 비교 결과를 반환합니다. </returns>
		public override bool Equals(object right)
		{
			if (right is Luid range) {
				return Equals(range);
			}
			return false;
		}

		/// <summary>
		/// 두 개체가 같은지 비교합니다.
		/// </summary>
		/// <param name="right"> 비교 대상 개체를 전달합니다. </param>
		/// <returns> 비교 결과를 반환합니다. </returns>
		public bool Equals(Luid right)
		{
			return LowPart == right.LowPart
				&& HighPart == right.HighPart;
		}

		/// <summary>
		/// 구조체의 간단한 해쉬 값을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 해쉬 값이 반환됩니다. </returns>
		public override int GetHashCode()
		{
			return LowPart.GetHashCode() ^ HighPart.GetHashCode();
		}
	}
}
