// Copyright 2020 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite 텍스트 렌더러의 픽셀 스내핑 속성을 정의합니다.
    /// </summary>
    [Guid( "eaf3a2da-ecf4-4d24-b644-b34f6842024b" )]
	[ComVisible( true )]
	public interface IDWritePixelSnapping : IUnknown
	{
		/// <summary>
		/// 픽셀 스내핑 속성이 활성화됐는지 여부를 가져옵니다.
		/// </summary>
		/// <param name="clientDrawingContext"> 클라이언트 렌더링 컨텍스트가 전달됩니다. </param>
		/// <returns> 활성화 여부가 반환됩니다. </returns>
		bool IsPixelSnappingDisabled( object clientDrawingContext );

		/// <summary>
		/// 추상 좌표를 DIP에 매핑하는 트랜스폼을 가져옵니다.
		/// </summary>
		/// <param name="clientDrawingContext"> 클라이언트 렌더링 컨텍스트가 전달됩니다. </param>
		/// <returns> 트랜스폼이 반환됩니다. </returns>
		Matrix3x2 GetCurrentTransform( object clientDrawingContext );

		/// <summary>
		/// DPI당 물리적 픽셀 수를 가져옵니다.
		/// </summary>
		/// <param name="clientDrawingContext"> 클라이언트 렌더링 컨텍스트가 전달됩니다. </param>
		/// <returns> DPI당 물리적 픽셀 수가 반환됩니다. </returns>
		float GetPixelsPerDip( object clientDrawingContext );
	}
}
