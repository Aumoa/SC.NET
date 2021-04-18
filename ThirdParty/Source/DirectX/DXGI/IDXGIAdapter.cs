// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// 시스템에 설치된 물리 또는 소프트웨어 어댑터를 제어하기 위한 공통 함수를 제공합니다.
    /// </summary>
    [Guid( "2411E7E1-12AC-4CCF-BD14-9798E8534DC0" )]
	[ComVisible( true )]
	public interface IDXGIAdapter : IDXGIObject, IEnumerable<IDXGIOutput>
	{
		/// <summary>
		/// GPU 어댑터의 정보를 가져옵니다.
		/// </summary>
		/// <returns> 정보를 표현하는 구조체를 반환합니다. </returns>
		DXGIAdapterDesc GetDesc();

		/// <summary>
		/// 시스템이 그래픽 구성 요소에 대한 장치 인터페이스를 지원하는지 확인합니다.
		/// </summary>
		/// <param name="interfaceName"> 지원을 확인할 장치 인터페이스의 GUID를 전달합니다. </param>
		/// <returns> 인터페이스의 지원되는 드라이버 버전을 반환합니다. 지원되지 않을 경우 null이 반환됩니다. </returns>
		long? CheckInterfaceSupport( Guid interfaceName );
	}
}
