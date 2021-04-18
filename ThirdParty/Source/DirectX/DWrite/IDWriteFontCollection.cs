// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite 폰트 패밀리에 대한 컬렉션을 캡슐화합니다.
    /// </summary>
    [Guid( "a84cee02-3eea-4eee-a827-87c1a02a0fcc" )]
	[ComVisible( true )]
	public interface IDWriteFontCollection : IUnknown
	{
		/// <summary>
		/// 폰트 패밀리 개수를 가져옵니다.
		/// </summary>
		/// <returns> 개수가 반환됩니다. </returns>
		uint GetFontFamilyCount();
	}
}
