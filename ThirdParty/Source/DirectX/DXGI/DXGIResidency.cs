// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// 자원의 메모리 위치를 나타내는 속성입니다.
    /// </summary>
    public enum DXGIResidency
	{
		/// <summary>
		/// 리소스 전체가 비디오 메모리에 존재함을 의미합니다.
		/// </summary>
		FullyResident = 1,

		/// <summary>
		/// 일부 리소스가 공유 메모리 영역에 있음을 의미합니다.
		/// </summary>
		ResidentInSharedMemory = 2,

		/// <summary>
		/// 일부 리소스가 하드 디스크로 페이징되어 있음을 의미합니다.
		/// </summary>
		EvictedToDisk = 3
	}
}
