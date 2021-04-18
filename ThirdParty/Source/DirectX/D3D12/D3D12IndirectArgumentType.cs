// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 간접 명령 유형을 나타냅니다.
    /// </summary>
    public enum D3D12IndirectArgumentType
	{
		/// <summary>
		/// 
		/// </summary>
		Draw = 0,

		/// <summary>
		/// 
		/// </summary>
		DrawIndexed,

		/// <summary>
		/// 
		/// </summary>
		Dispatch,

		/// <summary>
		/// 
		/// </summary>
		VertexBufferView,

		/// <summary>
		/// 
		/// </summary>
		IndexBufferView,

		/// <summary>
		/// 
		/// </summary>
		Constant,

		/// <summary>
		/// 
		/// </summary>
		ConstantBufferView,

		/// <summary>
		/// 
		/// </summary>
		ShaderResourceView,

		/// <summary>
		/// 
		/// </summary>
		UnorderedAccessView,
	}
}
