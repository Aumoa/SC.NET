// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 추가 기능에 대한 기능 단계를 점검합니다.
    /// </summary>
    public struct D3D12FeatureDataD3D12Options1
	{
		/// <summary>
		/// 
		/// </summary>
		public bool WaveOps;

		/// <summary>
		/// 
		/// </summary>
		public uint WaveLaneCountMin;

		/// <summary>
		/// 
		/// </summary>
		public uint WaveLaneCountMax;

		/// <summary>
		/// 
		/// </summary>
		public uint TotalLaneCount;

		/// <summary>
		/// 
		/// </summary>
		public bool ExpandedComputeResourceStates;

		/// <summary>
		/// 
		/// </summary>
		public bool Int64ShaderOps;
	}
}
