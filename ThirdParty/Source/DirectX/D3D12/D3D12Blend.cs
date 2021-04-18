// Copyright 2020 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 블렌드 계수를 나타냅니다.
    /// </summary>
    public enum D3D12Blend
	{
		/// <summary>
		/// 값에 0을 곱합니다.
		/// </summary>
		Zero = 1,

		/// <summary>
		/// 값에 1을 곱합니다.
		/// </summary>
		One = 2,

		/// <summary>
		/// 값에 원본 색을 곱합니다.
		/// </summary>
		SrcColor = 3,
		
		/// <summary>
		/// 값에 반전된 원본 색을 곱합니다.
		/// </summary>
		InvSrcColor = 4,

		/// <summary>
		/// 원본 알파 값을 곱합니다.
		/// </summary>
		SrcAlpha = 5,

		/// <summary>
		/// 값에 반전된 원본 알파 값을 곱합니다.
		/// </summary>
		InvSrcAlpha = 6,

		/// <summary>
		/// 값에 대상 알파 값을 곱합니다.
		/// </summary>
		DestAlpha = 7,

		/// <summary>
		/// 값에 반전된 대상 알파 값을 곱합니다.
		/// </summary>
		InvDestAlpha = 8,

		/// <summary>
		/// 값에 대상 색을 곱합니다.
		/// </summary>
		DestColor = 9,

		/// <summary>
		/// 값에 반전된 대상 색을 곱합니다.
		/// </summary>
		InvDestColor = 10,

		/// <summary>
		/// 값에 원본 알파를 곱합니다. 값은 0에서 1로 한정합니다.
		/// </summary>
		SrcAlphaSat = 11,

		/// <summary>
		/// 값에 사용자 지정 블렌드 계수를 곱합니다. 사용자 지정 블렌드 계수는 <see cref="ID3D12GraphicsCommandList.OMSetBlendFactor(Vector4)"/> 메서드를 통해 설정합니다.
		/// </summary>
		BlendFactor = 14,

		/// <summary>
		/// 값에 반전된 사용자 지정 블렌드 계수를 곱합니다. 사용자 지정 블렌드 계수는 <see cref="ID3D12GraphicsCommandList.OMSetBlendFactor(Vector4)"/> 메서드를 통해 설정합니다.
		/// </summary>
		InvBlendFactor = 15,

		/// <summary>
		/// 
		/// </summary>
		Src1Color = 16,

		/// <summary>
		/// 
		/// </summary>
		InvSrc1Color = 17,

		/// <summary>
		/// 
		/// </summary>
		Src1Alpha = 18,

		/// <summary>
		/// 
		/// </summary>
		InvSrc1Alpha = 19
	}
}
