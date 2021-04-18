// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 계산 파이프라인 정보를 서술하는 구조체입니다.
    /// </summary>
    public struct D3D12ComputePipelineStateDesc
	{
		/// <summary>
		/// 입력 서명 개체를 나타냅니다.
		/// </summary>
		public ID3D12RootSignature pRootSignature;

		/// <summary>
		/// 계산 셰이더 바이트코드 데이터를 나타냅니다.
		/// </summary>
		public D3D12ShaderBytecode CS;

		/// <summary>
		/// 장치 관측 노드 마스크를 나타냅니다.
		/// </summary>
		public uint NodeMask;

		/// <summary>
		/// 캐시된 파이프라인 상태 데이터를 나타냅니다.
		/// </summary>
		public D3D12CachedPipelineState CachedPSO;

		/// <summary>
		/// 파이프라인 상태 속성을 나타냅니다.
		/// </summary>
		public D3D12PipelineStateFlags Flags;

		/// <summary>
		/// <see cref="D3D12ComputePipelineStateDesc"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="rootSignature"> 입력 서명 개체를 전달합니다. </param>
		public D3D12ComputePipelineStateDesc( ID3D12RootSignature rootSignature )
		{
			this.pRootSignature = rootSignature;
			this.CS = new D3D12ShaderBytecode();
			this.NodeMask = 0;
			this.CachedPSO = new D3D12CachedPipelineState();
			this.Flags = D3D12PipelineStateFlags.None;
		}
	}
}
