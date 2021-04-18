// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 자원 상태 전이 장벽을 표현합니다.
    /// </summary>
    public struct D3D12ResourceTransitionBarrier
	{
		/// <summary>
		/// 대상 자원을 나타냅니다.
		/// </summary>
		public ID3D12Resource pResource;

		/// <summary>
		/// 서브리소스 인덱스를 나타냅니다.
		/// </summary>
		public uint Subresource;

		/// <summary>
		/// 이전 상태를 나타냅니다.
		/// </summary>
		public D3D12ResourceStates StateBefore;

		/// <summary>
		/// 변경 이후 상태를 나타냅니다.
		/// </summary>
		public D3D12ResourceStates StateAfter;

		/// <summary>
		/// <see cref="D3D12ResourceTransitionBarrier"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="resource"> 대상 자원 개체를 전달합니다. </param>
		/// <param name="stateBefore"> 변환 이전 상태를 나타냅니다. </param>
		/// <param name="stateAfter"> 변환 이후 상태를 나타냅니다. </param>
		public D3D12ResourceTransitionBarrier( ID3D12Resource resource, D3D12ResourceStates stateBefore, D3D12ResourceStates stateAfter )
		{
			this.pResource = resource;
			this.Subresource = 0;
			this.StateBefore = stateBefore;
			this.StateAfter = stateAfter;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format( "{0}: {1}[{2}] ({3} --> {4})", base.ToString(), pResource, Subresource, StateBefore, StateAfter );
		}

		/// <summary>
		/// 자원의 변환 이전 상태와 이후 상태를 교환합니다.
		/// </summary>
		public void Swap()
		{
			var left = this.StateBefore;
			this.StateBefore = this.StateAfter;
			this.StateAfter = left;
		}
	}
}
