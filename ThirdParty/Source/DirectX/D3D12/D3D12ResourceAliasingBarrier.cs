// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 자원 앨리어싱 장벽을 표현합니다.
    /// </summary>
    public struct D3D12ResourceAliasingBarrier
	{
		/// <summary>
		/// 이전 자원 상태를 전달합니다.
		/// </summary>
		public ID3D12Resource pResourceBefore;

		/// <summary>
		/// 이후 자원 상태를 전달합니다.
		/// </summary>
		public ID3D12Resource pResourceAfter;

		/// <summary>
		/// <see cref="D3D12ResourceAliasingBarrier"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="resourceBefore"> 이전 자원 상태를 전달합니다. </param>
		/// <param name="resourceAfter"> 이후 자원 상태를 전달합니다. </param>
		public D3D12ResourceAliasingBarrier( ID3D12Resource resourceBefore, ID3D12Resource resourceAfter )
		{
			this.pResourceBefore = resourceBefore;
			this.pResourceAfter = resourceAfter;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format( "{0}: {1} --> {2}", base.ToString(), pResourceBefore, pResourceAfter );
		}

		/// <summary>
		/// 자원의 변환 이전 상태와 이후 상태를 교환합니다.
		/// </summary>
		public void Swap()
		{
			var left = pResourceBefore;
			pResourceBefore = pResourceAfter;
			pResourceAfter = left;
		}
	}
}
