// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 블렌드 정보를 표현합니다.
    /// </summary>
    public struct D3D12BlendDesc
	{
		D3D12RenderTargetBlendDesc[] renderTarget;

		/// <summary>
		/// 알파 값을 포괄도로 변경하는지 여부를 나타냅니다.
		/// </summary>
		public bool AlphaToCoverageEnable;

		/// <summary>
		/// 블렌드 정보가 각각의 렌더 타겟 정보를 사용하도록 하는 값을 나타냅니다.
		/// </summary>
		public bool IndependentBlendEnable;

		/// <summary>
		/// 각 렌더 타겟에 대한 블렌드 정보를 서술합니다. 8개의 값을 담는 고정 배열입니다.
		/// </summary>
		public D3D12RenderTargetBlendDesc[] RenderTarget
		{
			get => renderTarget ??= new D3D12RenderTargetBlendDesc[8];
		}

		/// <summary>
		/// <see cref="D3D12BlendDesc"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="blendDescs"> 블렌드 정보 서술 구조체 목록을 전달합니다. </param>
		public D3D12BlendDesc( params D3D12RenderTargetBlendDesc[] blendDescs )
		{
			if ( blendDescs.Length > 8 ) throw new ArgumentException( "블렌드 상태 서술 구조체는 8개 이상일 수 없습니다." );

			renderTarget = new D3D12RenderTargetBlendDesc[8];
			AlphaToCoverageEnable = false;
			IndependentBlendEnable = false;

			blendDescs.CopyTo( RenderTarget, 0 );
		}
	}
}
