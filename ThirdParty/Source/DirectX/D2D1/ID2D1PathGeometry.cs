// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
	/// <summary>
	/// D2D1 아치, 커브 및 라인 등에 대한 복합 모양에 대한 제어를 제공합니다.
	/// </summary>
	[Guid( "2cd906a5-12e2-11dc-9fed-001143a055f9" )]
	[ComVisible( true )]
	public interface ID2D1PathGeometry : ID2D1Geometry
	{
		/// <summary>
		/// Geometry sink를 오픈합니다.
		/// </summary>
		/// <returns> 기하 모형을 제어할 수 있는 개체에 대한 인터페이스가 반환됩니다. </returns>
		ID2D1GeometrySink Open();
	}
}
