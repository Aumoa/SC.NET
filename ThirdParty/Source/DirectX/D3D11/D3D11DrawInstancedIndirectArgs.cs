// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D11 간접 DrawInstanced 명령의 매개변수를 표현합니다.
    /// </summary>
    public struct D3D11DrawInstancedIndirectArgs
	{
		/// <summary>
		/// 인스턴스당 정점 개수를 나타냅니다.
		/// </summary>
		public uint VertexCountPerInstance;

		/// <summary>
		/// 인스턴스 개수를 나타냅니다.
		/// </summary>
		public uint InstanceCount;

		/// <summary>
		/// 시작 정점 위치를 나타냅니다.
		/// </summary>
		public uint StartVertexLocation;

		/// <summary>
		/// 시작 인스턴스 위치를 나타냅니다.
		/// </summary>
		public uint StartInstanceLocation;
	}
}
