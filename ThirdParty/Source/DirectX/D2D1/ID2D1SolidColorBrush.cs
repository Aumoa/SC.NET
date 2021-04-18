// Copyright 2020 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D2D1 단색 브러시 개체에 대한 공통 메서드를 제공합니다.
    /// </summary>
    [Guid( "2cd906a9-12e2-11dc-9fed-001143a055f9" )]
	[ComVisible( true )]
	public interface ID2D1SolidColorBrush : ID2D1Brush
	{
		/// <summary>
		/// 브러시의 단색 값을 설정합니다.
		/// </summary>
		/// <param name="color"> 색을 전달합니다. </param>
		void SetColor( Color color );

		/// <summary>
		/// 브러시의 단색 값을 가져옵니다.
		/// </summary>
		/// <returns> 단색 값이 반환됩니다. </returns>
		Color GetColor();
	}
}
