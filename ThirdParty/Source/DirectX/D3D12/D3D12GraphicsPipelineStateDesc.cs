// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 그래픽 파이프라인 정보를 서술하는 구조체입니다.
    /// </summary>
    public struct D3D12GraphicsPipelineStateDesc
	{
		DXGIFormat[] rtvFormats;

		/// <summary>
		/// 입력 서명 개체를 나타냅니다.
		/// </summary>
		public ID3D12RootSignature pRootSignature;

		/// <summary>
		/// 정점 셰이더 바이트코드 데이터를 나타냅니다.
		/// </summary>
		public D3D12ShaderBytecode VS;

		/// <summary>
		/// 픽셀 셰이더 바이트코드 데이터를 나타냅니다.
		/// </summary>
		public D3D12ShaderBytecode PS;

		/// <summary>
		/// 영역 셰이더 바이트코드 데이터를 나타냅니다.
		/// </summary>
		public D3D12ShaderBytecode DS;

		/// <summary>
		/// 덮개 셰이더 바이트코드 데이터를 나타냅니다.
		/// </summary>
		public D3D12ShaderBytecode HS;

		/// <summary>
		/// 기하 셰이더 바이트코드 데이터를 나타냅니다.
		/// </summary>
		public D3D12ShaderBytecode GS;

		/// <summary>
		/// 스트림 출력 정보를 나타냅니다.
		/// </summary>
		public D3D12StreamOutputDesc StreamOutput;

		/// <summary>
		/// 블렌드 정보를 나타냅니다.
		/// </summary>
		public D3D12BlendDesc BlendState;

		/// <summary>
		/// 샘플 횟수를 나타냅니다.
		/// </summary>
		public uint SampleMask;

		/// <summary>
		/// 래스터라이저 서술 정보를 나타냅니다.
		/// </summary>
		public D3D12RasterizerDesc RasterizerState;

		/// <summary>
		/// 깊이 스텐실 상태 서술 정보를 나타냅니다.
		/// </summary>
		public D3D12DepthStencilDesc DepthStencilState;

		/// <summary>
		/// 입력 배치 정보를 나타냅니다.
		/// </summary>
		public D3D12InputLayoutDesc InputLayout;

		/// <summary>
		/// 인덱스 버퍼 스트립 절단 값을 나타냅니다.
		/// </summary>
		public D3D12IndexBufferStripCutValue IBStripCutValue;

		/// <summary>
		/// 기본 기하 도형의 유형을 나타냅니다.
		/// </summary>
		public D3D12PrimitiveTopologyType PrimitiveTopologyType;

		/// <summary>
		/// 설정한 렌더 타겟 개수를 나타냅니다.
		/// </summary>
		public uint NumRenderTargets;

		/// <summary>
		/// 렌더 타겟의 픽셀 형식 목록을 가져옵니다. 개체는 8개의 원소를 가지는 고정 배열입니다.
		/// </summary>
		public DXGIFormat[] RTVFormats
		{
			get => rtvFormats ??= new DXGIFormat[8];
		}

		/// <summary>
		/// 깊이 스텐실 버퍼의 픽셀 형식 목록을 나타냅니다.
		/// </summary>
		public DXGIFormat DSVFormat;

		/// <summary>
		/// 샘플 상태를 나타냅니다.
		/// </summary>
		public DXGISampleDesc SampleDesc;

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
		/// <see cref="D3D12GraphicsPipelineStateDesc"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="rootSignature"> 입력 서명 개체를 전달합니다. </param>
		public D3D12GraphicsPipelineStateDesc( ID3D12RootSignature rootSignature )
		{
			this.rtvFormats = new DXGIFormat[8]
			{
				DXGIFormat.Unknown, DXGIFormat.Unknown,
				DXGIFormat.Unknown, DXGIFormat.Unknown,
				DXGIFormat.Unknown, DXGIFormat.Unknown,
				DXGIFormat.Unknown, DXGIFormat.Unknown
			};

			this.pRootSignature = rootSignature;
			this.VS = new D3D12ShaderBytecode();
			this.PS = new D3D12ShaderBytecode();
			this.DS = new D3D12ShaderBytecode();
			this.HS = new D3D12ShaderBytecode();
			this.GS = new D3D12ShaderBytecode();
			this.StreamOutput = new D3D12StreamOutputDesc();
			this.BlendState = new D3D12BlendDesc( D3D12RenderTargetBlendDesc.Default, D3D12RenderTargetBlendDesc.Default, D3D12RenderTargetBlendDesc.Default, D3D12RenderTargetBlendDesc.Default, D3D12RenderTargetBlendDesc.Default, D3D12RenderTargetBlendDesc.Default, D3D12RenderTargetBlendDesc.Default, D3D12RenderTargetBlendDesc.Default );
			this.SampleMask = uint.MaxValue;
			this.RasterizerState = D3D12RasterizerDesc.Default;
			this.DepthStencilState = D3D12DepthStencilDesc.Default;
			this.InputLayout = new D3D12InputLayoutDesc();
			this.IBStripCutValue = D3D12IndexBufferStripCutValue.Disabled;
			this.PrimitiveTopologyType = D3D12PrimitiveTopologyType.Triangle;
			this.NumRenderTargets = 0;
			this.DSVFormat = DXGIFormat.Unknown;
			this.SampleDesc = DXGISampleDesc.One;
			this.NodeMask = 0;
			this.CachedPSO = new D3D12CachedPipelineState();
			this.Flags = D3D12PipelineStateFlags.None;
		}
	}
}
