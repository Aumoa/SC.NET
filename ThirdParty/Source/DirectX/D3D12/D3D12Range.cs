// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 메모리 공간 범위를 표현합니다.
    /// </summary>
    public struct D3D12Range : IEquatable<D3D12Range>
	{
		/// <summary>
		/// 범위의 시작 위치를 나타냅니다.
		/// </summary>
		public ulong Begin;

		/// <summary>
		/// 범위의 끝 위치를 나타냅니다.
		/// </summary>
		public ulong End;

		/// <summary>
		/// <see cref="D3D12Range"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="begin"> 범위의 시작 위치를 전달합니다.</param>
		/// <param name="width"> 범위의 크기를 전달합니다. </param>
		public D3D12Range( ulong begin, ulong width )
		{
			this.Begin = begin;
			this.End = begin + width;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format( "{2}: [{0}, {1})", Begin, End, base.ToString() );
		}

		/// <summary>
		/// 두 개체가 같은지 비교합니다.
		/// </summary>
		/// <param name="right"> 비교 대상 개체를 전달합니다. </param>
		/// <returns> 비교 결과를 반환합니다. </returns>
		public override bool Equals( object right )
		{
			if ( right is D3D12Range range )
			{
				return Equals( range );
			}
			return false;
		}

		/// <summary>
		/// 개체의 간단한 해쉬 값을 가져옵니다.
		/// </summary>
		/// <returns> 해쉬 값을 반환합니다. </returns>
		public override int GetHashCode()
		{
			return Begin.GetHashCode() ^ End.GetHashCode();
		}

		/// <summary>
		/// 두 개체가 같은지 비교합니다.
		/// </summary>
		/// <param name="right"> 비교 대상 개체를 전달합니다. </param>
		/// <returns> 비교 결과를 반환합니다. </returns>
		public bool Equals( D3D12Range right )
		{
			return Begin == right.Begin
				&& End == right.End;
		}

		/// <summary>
		/// 범위의 시작 위치 및 종료 위치를 함께 이동합니다.
		/// </summary>
		/// <param name="offset"> 이동량을 전달합니다. </param>
		public void Offset( long offset )
		{
			Begin = ( ulong )( ( long )Begin + offset );
			End = ( ulong )( ( long )End + offset );
		}

		/// <summary>
		/// 범위의 크기를 설정하거나 가져옵니다.
		/// </summary>
		public ulong Width
		{
			get => End - Begin;
			set => End = Begin + value;
		}
	}
}
