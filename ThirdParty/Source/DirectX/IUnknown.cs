// Copyright 2020 Aumoa.lib. All right reserved

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
	/// <summary>
	/// COM 구성 요소 개체에 대한 공통 함수를 제공합니다.
	/// </summary>
	[Guid("00000000-0000-0000-C000-000000000046")]
	[ComVisible(true)]
	public interface IUnknown : IDisposable
	{
		/// <summary>
		/// 개체의 참조 횟수를 1회 증가시킵니다.
		/// </summary>
		/// <returns> 개체의 현재 참조 횟수가 반환됩니다. </returns>
		long AddRef();

		/// <summary>
		/// 개체의 참조 횟수를 1회 감소시킵니다.
		/// </summary>
		/// <returns> 개체의 현재 참조 횟수가 반환됩니다. </returns>
		long Release();

		/// <summary>
		/// 사용 가능한 대상 인터페이스 개체를 조회합니다.
		/// </summary>
		/// <param name="iid"> 대상 인터페이스의 GUID를 전달합니다. </param>
		/// <param name="ppUnknown"> 인터페이스 개체를 받을 변수의 참조를 전달합니다. </param>
		void QueryInterface(Guid iid, out IUnknown ppUnknown);
	}
}
