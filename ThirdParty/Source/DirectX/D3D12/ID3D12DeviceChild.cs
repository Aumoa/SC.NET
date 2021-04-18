using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
	/// <summary>
	/// D3D12 장치에서 파생된 개체에 대한 공통 함수를 제공합니다.
	/// </summary>
	[Guid( "905DB94B-A00C-4140-9DF5-2B64CA9EA357" )]
	[ComVisible( true )]
	public interface ID3D12DeviceChild : ID3D12Object
	{
		/// <summary>
		/// 장치 개체를 가져옵니다.
		/// </summary>
		/// <param name="riid"> 장치 인터페이스의 GUID를 전달합니다. </param>
		/// <param name="device"> 장치 인터페이스 개체를 받을 변수의 참조를 전달합니다. </param>
		void GetDevice( Guid riid, out IUnknown device );
	}
}
