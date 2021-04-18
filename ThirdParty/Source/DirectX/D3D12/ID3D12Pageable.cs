// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// 개체가 GPU 메모리에 엑세스함을 나타냅니다.
    /// </summary>
    [Guid( "63EE58FB-1268-4835-86DA-F008CE62F0D6" )]
	[ComVisible( true )]
	public interface ID3D12Pageable : ID3D12DeviceChild
	{
	}
}
