// Copyright 2020 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
	/// <summary>
	/// D2D1 브러시 개체에 대한 공통 메서드를 제공합니다.
	/// </summary>
	[Guid( "2cd906a8-12e2-11dc-9fed-001143a055f9" )]
	[ComVisible( true )]
	public interface ID2D1Brush : ID2D1Resource
	{
		/// <summary>
		/// 불투명도 값을 설정합니다.
		/// </summary>
		/// <param name="opacity"> 불투명도 값을 전달합니다. </param>
		void SetOpacity( float opacity );
		
		/// <summary>
		/// 브러시의 트랜스폼을 설정합니다.
		/// </summary>
		/// <param name="transform"> 트랜스폼 값을 전달합니다. </param>
		void SetTransform( Matrix3x2 transform );

		/// <summary>
		/// 불투명도 값을 가져옵니다.
		/// </summary>
		/// <returns> 불투명도 값이 반환됩니다. </returns>
		float GetOpacity();

		/// <summary>
		/// 브러시의 트랜스폼 값을 가져옵니다.
		/// </summary>
		/// <returns> 트랜스폼 값이 반환됩니다. </returns>
		Matrix3x2 GetTransform();
	}
}
