// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
	/// <summary>
	/// D2D1 자원을 관리하는 팩토리 개체에 대한 공통 메서드를 제공합니다.
	/// </summary>
	[Guid( "06152247-6f50-465a-9245-118bfd3b6007" )]
	[ComVisible( true )]
	public interface ID2D1Factory : IUnknown
	{
		/// <summary>
		/// 패스 기하 인터페이스를 생성합니다.
		/// </summary>
		/// <returns> 생성된 인터페이스 개체가 반환됩니다. </returns>
		ID2D1PathGeometry CreatePathGeometry();
	}
}
