// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 렌더 타겟에 대한 블렌드 정보를 서술합니다.
    /// </summary>
    public struct D3D12RenderTargetBlendDesc
	{
		/// <summary>
		/// 블렌드 활성화 상태를 나타냅니다.
		/// </summary>
		public bool BlendEnable;

		/// <summary>
		/// 논리 연산 활성화 상태를 나타냅니다.
		/// </summary>
		public bool LogicOpEnable;

		/// <summary>
		/// 원본 블렌드 계수를 나타냅니다.
		/// </summary>
		public D3D12Blend SrcBlend;

		/// <summary>
		/// 대상 블렌드 계수를 나타냅니다.
		/// </summary>
		public D3D12Blend DestBlend;

		/// <summary>
		/// 블렌드 연산자를 나타냅니다.
		/// </summary>
		public D3D12BlendOP BlendOp;

		/// <summary>
		/// 원본 알파 블렌드 계수를 나타냅니다.
		/// </summary>
		public D3D12Blend SrcBlendAlpha;

		/// <summary>
		/// 대상 알파 블렌드 계수를 나타냅니다.
		/// </summary>
		public D3D12Blend DestBlendAlpha;

		/// <summary>
		/// 알파 블렌드 연산자를 나타냅니다.
		/// </summary>
		public D3D12BlendOP BlendOpAlpha;

		/// <summary>
		/// 논리 연산자를 나타냅니다.
		/// </summary>
		public D3D12LogicOP LogicOp;

		/// <summary>
		/// 렌더 타겟 컬러 쓰기 활성화를 나타냅니다.
		/// </summary>
		public D3D12ColorWriteEnable RenderTargetWriteMask;

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
			=> BlendEnable switch
			{
				false => $"{base.ToString()}: BlendEnable = false, RenderTargetWriteMask = {RenderTargetWriteMask}",
				_ => $"{base.ToString()}: SrcBlend = {SrcBlend}, DestBlend = {DestBlend}, BlendOp = {BlendOp}, SrcBlendAlpha = {SrcBlendAlpha}, DestBlendAlpha = {DestBlendAlpha}, BlendOpAlpha = {BlendOpAlpha}, RenderTargetWriteMask = {RenderTargetWriteMask}"
			};

		/// <summary>
		/// 기본값으로 설정된 정보 서술 구조체를 가져옵니다.
		/// </summary>
		public static D3D12RenderTargetBlendDesc Default
		{
			get => new D3D12RenderTargetBlendDesc
			{
				BlendEnable = false,
				LogicOpEnable = false,
				RenderTargetWriteMask = D3D12ColorWriteEnable.All
			};
		}

		/// <summary>
		/// 알파 블렌드를 사용하는 정보 서술 구조체를 가져옵니다.
		/// </summary>
		public static D3D12RenderTargetBlendDesc AlphaBlend
		{
			get => new D3D12RenderTargetBlendDesc
			{
				BlendEnable = true,
				SrcBlend = D3D12Blend.SrcAlpha,
				DestBlend = D3D12Blend.InvSrcAlpha,
				BlendOp = D3D12BlendOP.Add,
				SrcBlendAlpha = D3D12Blend.One,
				DestBlendAlpha = D3D12Blend.Zero,
				BlendOpAlpha = D3D12BlendOP.Add,
				RenderTargetWriteMask = D3D12ColorWriteEnable.All,
			};
		}
	}
}
