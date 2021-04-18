// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 간접 상수 매개변수 정보를 나타냅니다.
    /// </summary>
    public struct D3D12IndirectConstantArgument
	{
		/// <summary>
		/// 
		/// </summary>
		public uint RootParameterIndex;

		/// <summary>
		/// 
		/// </summary>
		public uint DestOffsetIn32BitValues;

		/// <summary>
		/// 
		/// </summary>
		public uint Num32BitValuesToSet;
	}
}
