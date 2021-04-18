// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// <see cref="D3DPrimitiveTopology"/> 열거형에 대한 확장 메서드를 제공합니다.
    /// </summary>
    public static class D3DPrimitiveTopologyExtensions
	{
		/// <summary>
		/// N개의 제어점을 가지는 패치 리스트 형식에서 제어점의 개수를 변경합니다.
		/// </summary>
		/// <param name="this"> 열거형을 전달합니다. </param>
		/// <param name="offset"> 변경될 개수를 전달합니다. </param>
		public static D3DPrimitiveTopology ControlPointOffset( this D3DPrimitiveTopology @this, int offset )
		{
			int value = ( int )@this;
			if ( !CheckIsControlPoint( value ) ) throw new ArgumentOutOfRangeException( "열거형 값이 열거형 범위 [D3DPrimitiveTopology.ControlPointPatchListBegin, D3DPrimitiveTopology.ControlPointPatchListEnd]를 벗어납니다." );

			value += offset;
			if ( !CheckIsControlPoint( value ) ) throw new ArgumentOutOfRangeException( "이동된 열거형 값이 열거형 범위 [D3DPrimitiveTopology.ControlPointPatchListBegin, D3DPrimitiveTopology.ControlPointPatchListEnd]를 벗어납니다." );

			return ( D3DPrimitiveTopology )value;
		}

		static bool CheckIsControlPoint( int value )
		{
			if ( value >= ( int )D3DPrimitiveTopology.ControlPointPatchListBegin && value <= ( int )D3DPrimitiveTopology.ControlPointPatchListEnd )
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
