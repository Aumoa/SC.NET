// Copyright 2020 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
	/// <summary>
	/// D2D1 기하 모형에 대한 제어를 제공합니다.
	/// </summary>
	[Guid( "2cd906a1-12e2-11dc-9fed-001143a055f9" )]
	[ComVisible( true )]
	public interface ID2D1Geometry : ID2D1Resource
	{
		/// <summary>
		/// 이 모형에 대한 경계 사각형을 가져옵니다.
		/// </summary>
		/// <param name="worldTransform"> 트랜스폼을 전달합니다. </param>
		/// <returns> 경계 사각형이 반환됩니다. </returns>
		Rectangle GetBounds( Matrix3x2? worldTransform = null );

		/// <summary>
		/// 선분의 스타일 등으로 확장된 경계 사각형을 가져옵니다.
		/// </summary>
		/// <param name="strokeWidth"> 선분의 굵기를 전달합니다. </param>
		/// <param name="strokeStyle"> 선분 스타일을 전달합니다. </param>
		/// <param name="worldTransform"> 트랜스폼을 전달합니다. </param>
		/// <param name="flatteningTolerance"></param>
		/// <returns> 경계 사각형이 반환됩니다. </returns>
		Rectangle GetWidenedBounds( float strokeWidth, ID2D1StrokeStyle strokeStyle, Matrix3x2? worldTransform = null, float flatteningTolerance = 0.0f );
	}
}
