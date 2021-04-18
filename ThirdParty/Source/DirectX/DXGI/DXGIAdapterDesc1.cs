// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DXGI 그래픽 어댑터에 대한 정보를 서술합니다.
    /// </summary>
    public struct DXGIAdapterDesc1
	{
		/// <summary>
		/// 장치에 대한 설명을 표현합니다.
		/// </summary>
		public string Description;

		/// <summary>
		/// 장치 공급자의 PCI ID를 표현합니다.
		/// </summary>
		public uint VendorId;

		/// <summary>
		/// 하드웨어 장치의 PCI ID를 표현합니다.
		/// </summary>
		public uint DeviceId;

		/// <summary>
		/// 서브 시스템의 PCI ID를 표현합니다.
		/// </summary>
		public uint SubSysId;

		/// <summary>
		/// 어댑터의 개정 PCI ID를 표현합니다.
		/// </summary>
		public uint Revision;

		/// <summary>
		/// CPU와 공유되지 않는 GPU 전용 비디오 메모리의 바이트 단위 용량을 표현합니다.
		/// </summary>
		public ulong DedicatedVideoMemory;

		/// <summary>
		/// CPU와 공유하지 않는 GPU 전용 시스템 메모리의 바이트 단위 용량을 표현합니다.
		/// </summary>
		public ulong DedicatedSystemMemory;

		/// <summary>
		/// 공유 시스템 메모리의 바이트 단위 용량을 표현합니다.
		/// </summary>
		public ulong SharedSystemMemory;

		/// <summary>
		/// 어댑터를 식별하는 고유한 값을 나타냅니다.
		/// </summary>
		public Luid AdapterLuid;

		/// <summary>
		/// 어댑터의 속성을 표현합니다.
		/// </summary>
		public DXGIAdapterFlags Flags;

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format( "{0}: {1}, VideoMemory = {2:N} MB", base.ToString(), Description, ( double )DedicatedVideoMemory / 1024.0 / 1024.0 );
		}
	}
}
