// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 입력 분류를 나타냅니다.
    /// </summary>
    public enum D3D12InputClassification
	{
		/// <summary>
		/// 입력이 정점 데이터와 매핑됨을 나타냅니다.
		/// </summary>
		PerVertexData = 0,

		/// <summary>
		/// 입력이 인스턴스 데이터와 매핑됨을 나타냅니다.
		/// </summary>
		PerInstanceData = 1
	}
}
