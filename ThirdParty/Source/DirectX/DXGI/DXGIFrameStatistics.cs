// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// 프레임 통계를 표현합니다.
    /// </summary>
    public struct DXGIFrameStatistics
	{
		/// <summary>
		/// 화면의 출력 횟수를 표현합니다.
		/// </summary>
		public uint PresentCount;

		/// <summary>
		/// 
		/// </summary>
		public uint PresentRefreshCount;

		/// <summary>
		/// 
		/// </summary>
		public uint SyncRefreshCount;

		/// <summary>
		/// 
		/// </summary>
		public long SyncQPCTime;

		/// <summary>
		/// 
		/// </summary>
		public long SyncGPUTime;

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format( "{0}: PresentCount = {1}", base.ToString(), base.ToString(), PresentCount );
		}
	}
}
