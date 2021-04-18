// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D11 간접 DrawIndexedInstanced 명령에 대한 매개변수를 표현합니다.
    /// </summary>
    public struct D3D11DrawIndexedInstancedIndirectArgs
	{
		/// <summary>
		/// 인스턴스당 인덱스 개수를 나타냅니다.
		/// </summary>
		public uint IndexCountPerInstance;

		/// <summary>
		/// 인스턴스 개수를 나타냅니다.
		/// </summary>
		public uint InstanceCount;

		/// <summary>
		/// 인덱스 시작 위치를 나타냅니다.
		/// </summary>
		public uint StartIndexLocation;
		
		/// <summary>
		/// 참조할 정점 위치의 시작 위치를 전달합니다.
		/// </summary>
		public int BaseVertexLocation;

		/// <summary>
		/// 시작 인스턴스 위치를 전달합니다.
		/// </summary>
		public uint StartInstanceLocation;
	}
}
