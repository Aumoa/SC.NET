// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
	/// <summary>
	/// D2D1 간략화된 기하 정보를 서술하는 개체에 대한 공통 제어 메서드를 제공합니다.
	/// </summary>
	[Guid( "2cd9069e-12e2-11dc-9fed-001143a055f9" )]
	[ComVisible( true )]
	public interface ID2D1SimplifiedGeometrySink : IUnknown
	{
		/// <summary>
		/// 도형 채우기 모드를 설정합니다.
		/// </summary>
		/// <param name="fillMode"> 채우기 모드를 전달합니다. </param>
		void SetFillMode( D2D1FillMode fillMode );

		/// <summary>
		/// 기하 모형 작성을 종료합니다.
		/// </summary>
		void Close();
	}
}
