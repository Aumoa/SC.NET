// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// <see cref="ID3D12Device"/> 인터페이스 개체에 대한 확장 메서드를 제공합니다.
    /// </summary>
    public static class ID3D12DeviceExtensions
	{
		/// <summary>
		/// 명령 대기열 개체를 생성합니다.
		/// </summary>
		/// <typeparam name="T"> 개체의 인터페이스 형식을 전달합니다. </typeparam>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="desc"> 명령 대기열 서술 정보를 전달합니다. </param>
		/// <returns> 생성된 인터페이스 개체가 반환됩니다. </returns>
		public static T CreateCommandQueue<T>(
			this ID3D12Device @this,
			D3D12CommandQueueDesc desc
			) where T : class
		{
			@this.CreateCommandQueue( desc, typeof( T ).GUID, out var ppUnknown );
			return ppUnknown as T;
		}

		/// <summary>
		/// 명령 대기열 개체를 생성합니다.
		/// </summary>
		/// <typeparam name="T"> 개체의 인터페이스 형식을 전달합니다. </typeparam>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="type"> 명령 목록 유형을 전달합니다. </param>
		/// <param name="priority"> 대기열의 우선 순위를 전달합니다. </param>
		/// <returns> 생성된 인터페이스 개체가 반환됩니다. </returns>
		public static T CreateCommandQueue<T>(
			this ID3D12Device @this,
			D3D12CommandListType type,
			D3D12CommandQueuePriority priority = D3D12CommandQueuePriority.Normal
			) where T : class
		{
			var desc = new D3D12CommandQueueDesc
			{
				Type = type,
				Priority = priority,
				Flags = D3D12CommandQueueFlags.None
			};

			return @this.CreateCommandQueue<T>( desc );
		}

		/// <summary>
		/// 명령 대기열 개체를 생성합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="type"> 명령 목록 유형을 전달합니다. </param>
		/// <param name="priority"> 대기열의 우선 순위를 전달합니다. </param>
		/// <returns> 생성된 인터페이스 개체가 반환됩니다. </returns>
		public static ID3D12CommandQueue CreateCommandQueue(
			this ID3D12Device @this,
			D3D12CommandListType type,
			D3D12CommandQueuePriority priority = D3D12CommandQueuePriority.Normal
			)
			=> @this.CreateCommandQueue<ID3D12CommandQueue>( type, priority );

		/// <summary>
		/// 펜스 개체를 생성합니다.
		/// </summary>
		/// <typeparam name="T"> 개체의 인터페이스 형식을 전달합니다. </typeparam>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="initialValue"> 초기 값을 전달합니다. </param>
		/// <param name="flags"> 펜스 속성을 전달합니다. </param>
		/// <returns> 생성된 인터페이스 개체가 반환됩니다. </returns>
		public static T CreateFence<T>(
			this ID3D12Device @this,
			ulong initialValue = 0,
			D3D12FenceFlags flags = D3D12FenceFlags.None
			) where T : class
		{
			@this.CreateFence( initialValue, flags, typeof( T ).GUID, out var unknown );
			return unknown as T;
		}

		/// <summary>
		/// 펜스 개체를 생성합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="initialValue"> 초기 값을 전달합니다. </param>
		/// <param name="flags"> 펜스 속성을 전달합니다. </param>
		/// <returns> 생성된 인터페이스 개체가 반환됩니다. </returns>
		public static ID3D12Fence CreateFence(
			this ID3D12Device @this,
			ulong initialValue = 0,
			D3D12FenceFlags flags = D3D12FenceFlags.None
			)
			=> @this.CreateFence<ID3D12Fence>( initialValue, flags );

		/// <summary>
		/// 명령 할당기 개체를 생성합니다.
		/// </summary>
		/// <typeparam name="T"> 개체의 인터페이스 형식을 전달합니다. </typeparam>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="type"> 명령 목록 유형을 전달합니다. </param>
		/// <returns> 생성된 인터페이스 개체가 반환됩니다. </returns>
		public static T CreateCommandAllocator<T>(
			this ID3D12Device @this,
			D3D12CommandListType type
			) where T : class
		{
			@this.CreateCommandAllocator( type, typeof( T ).GUID, out var ppCommandAllocator );
			return ppCommandAllocator as T;
		}

		/// <summary>
		/// 명령 할당기 개체를 생성합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="type"> 명령 목록 유형을 전달합니다. </param>
		/// <returns> 생성된 인터페이스 개체가 반환됩니다. </returns>
		public static ID3D12CommandAllocator CreateCommandAllocator(
			this ID3D12Device @this,
			D3D12CommandListType type
			)
			=> @this.CreateCommandAllocator<ID3D12CommandAllocator>( type );

		/// <summary>
		/// 그래픽 명령 목록 개체를 생성합니다.
		/// </summary>
		/// <typeparam name="T"> 개체의 인터페이스 형식을 전달합니다. </typeparam>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="type"> 명령 목록 유형을 전달합니다. </param>
		/// <param name="pCommandAllocator"> 명령 할당기 개체를 전달합니다. </param>
		/// <param name="pInitialPipelineState"> 초기 파이프라인 상태 개체를 전달합니다. </param>
		/// <returns> 생성된 인터페이스 개체가 반환됩니다. </returns>
		public static T CreateCommandList<T>(
			this ID3D12Device @this,
			D3D12CommandListType type,
			ID3D12CommandAllocator pCommandAllocator,
			ID3D12PipelineState pInitialPipelineState = null
			) where T : class
		{
			@this.CreateCommandList( 0, type, pCommandAllocator, pInitialPipelineState, typeof( T ).GUID, out var ppCommandList );
			return ppCommandList as T;
		}

		/// <summary>
		/// 그래픽 명령 목록 개체를 생성합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="type"> 명령 목록 유형을 전달합니다. </param>
		/// <param name="pCommandAllocator"> 명령 할당기 개체를 전달합니다. </param>
		/// <param name="pInitialPipelineState"> 초기 파이프라인 상태 개체를 전달합니다. </param>
		/// <returns> 생성된 인터페이스 개체가 반환됩니다. </returns>
		public static ID3D12GraphicsCommandList CreateCommandList(
			this ID3D12Device @this,
			D3D12CommandListType type,
			ID3D12CommandAllocator pCommandAllocator,
			ID3D12PipelineState pInitialPipelineState = null
			)
			=> @this.CreateCommandList<ID3D12GraphicsCommandList>( type, pCommandAllocator, pInitialPipelineState );

		/// <summary>
		/// 서술자 힙 개체를 생성합니다. 
		/// </summary>
		/// <typeparam name="T"> 개체의 인터페이스 형식을 전달합니다. </typeparam>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="type"> 서술자 유형을 전달합니다. </param>
		/// <param name="numDescriptors"> 서술자 개수를 전달합니다. </param>
		/// <param name="flags"> 서술자 속성을 전달합니다. </param>
		/// <returns> 생성된 인터페이스 개체가 반환됩니다. </returns>
		public static T CreateDescriptorHeap<T>(
			this ID3D12Device @this,
			D3D12DescriptorHeapType type,
			uint numDescriptors,
			D3D12DescriptorHeapFlags flags = D3D12DescriptorHeapFlags.None
			) where T : class
		{
			@this.CreateDescriptorHeap( new D3D12DescriptorHeapDesc
			{
				Type = type,
				NumDescriptors = numDescriptors,
				Flags = flags
			}, typeof( T ).GUID, out var ppHeap );

			return ppHeap as T;
		}

		/// <summary>
		/// 서술자 힙 개체를 생성합니다. 
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="type"> 서술자 유형을 전달합니다. </param>
		/// <param name="numDescriptors"> 서술자 개수를 전달합니다. </param>
		/// <param name="flags"> 서술자 속성을 전달합니다. </param>
		/// <returns> 생성된 인터페이스 개체가 반환됩니다. </returns>
		public static ID3D12DescriptorHeap CreateDescriptorHeap(
			this ID3D12Device @this,
			D3D12DescriptorHeapType type,
			uint numDescriptors,
			D3D12DescriptorHeapFlags flags = D3D12DescriptorHeapFlags.None
			)
			=> @this.CreateDescriptorHeap<ID3D12DescriptorHeap>( type, numDescriptors, flags );

		/// <summary>
		/// 미리 커밋된 자원을 생성합니다.
		/// </summary>
		/// <typeparam name="T"> 개체의 인터페이스 형식을 전달합니다. </typeparam>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="heapProperties"> 힙 속성을 전달합니다. </param>
		/// <param name="heapFlags"> 힙 속성을 전달합니다. </param>
		/// <param name="desc"> 자원 정보 구조체를 전달합니다. </param>
		/// <param name="initialResourceState"> 초기 자원 상태를 전달합니다. </param>
		/// <param name="optimizedClearValue"> 최적화된 초기화 값을 전달합니다. </param>
		/// <returns> 생성된 인터페이스 개체가 반환됩니다. </returns>
		public static T CreateCommittedResource<T>( 
			this ID3D12Device @this,
			D3D12HeapProperties heapProperties,
			D3D12HeapFlags heapFlags,
			D3D12ResourceDesc desc,
			D3D12ResourceStates initialResourceState,
			D3D12ClearValue? optimizedClearValue
			) where T : class
		{
			@this.CreateCommittedResource( heapProperties, heapFlags, desc, initialResourceState, optimizedClearValue, typeof( T ).GUID, out var ppUnknown );
			return ppUnknown as T;
		}

		/// <summary>
		/// 미리 커밋된 자원을 생성합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="heapProperties"> 힙 속성을 전달합니다. </param>
		/// <param name="heapFlags"> 힙 속성을 전달합니다. </param>
		/// <param name="desc"> 자원 정보 구조체를 전달합니다. </param>
		/// <param name="initialResourceState"> 초기 자원 상태를 전달합니다. </param>
		/// <param name="optimizedClearValue"> 최적화된 초기화 값을 전달합니다. </param>
		/// <returns> 생성된 인터페이스 개체가 반환됩니다. </returns>
		public static ID3D12Resource CreateCommittedResource(
			this ID3D12Device @this,
			D3D12HeapProperties heapProperties,
			D3D12HeapFlags heapFlags,
			D3D12ResourceDesc desc,
			D3D12ResourceStates initialResourceState,
			D3D12ClearValue? optimizedClearValue
			)
			=> @this.CreateCommittedResource<ID3D12Resource>( heapProperties, heapFlags, desc, initialResourceState, optimizedClearValue );

		/// <summary>
		/// 루트 서명 개체를 생성합니다.
		/// </summary>
		/// <typeparam name="T"> 개체의 인터페이스 형식을 전달합니다. </typeparam>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="pBlobWithRootSignature"> 입력 서명 데이터 블록을 전달합니다. </param>
		/// <returns> 생성된 인터페이스 개체가 반환됩니다. </returns>
		public static T CreateRootSignature<T>( this ID3D12Device @this, ID3DBlob pBlobWithRootSignature ) where T : class
		{
			@this.CreateRootSignature( 0, pBlobWithRootSignature.GetBufferPointer(), pBlobWithRootSignature.GetBufferSize(), typeof( T ).GUID, out var ppRootSignature );
			return ppRootSignature as T;
		}

		/// <summary>
		/// 루트 서명 개체를 생성합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="pBlobWithRootSignature"> 입력 서명 데이터 블록을 전달합니다. </param>
		/// <returns> 생성된 인터페이스 개체가 반환됩니다. </returns>
		public static ID3D12RootSignature CreateRootSignature( this ID3D12Device @this, ID3DBlob pBlobWithRootSignature )
			=> @this.CreateRootSignature<ID3D12RootSignature>( pBlobWithRootSignature );

		/// <summary>
		/// 그래픽 파이프라인 개체를 생성합니다.
		/// </summary>
		/// <typeparam name="T"> 개체의 인터페이스 형식을 전달합니다. </typeparam>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="desc"> 그래픽 파이프라인 정보 서술 구조체를 전달합니다. </param>
		/// <returns> 생성된 인터페이스 개체가 반환됩니다. </returns>
		public static T CreatePipelineState<T>( this ID3D12Device @this, D3D12GraphicsPipelineStateDesc desc ) where T : class
		{
			@this.CreateGraphicsPipelineState( desc, typeof( T ).GUID, out var ppPipelineState );
			return ppPipelineState as T;
		}

		/// <summary>
		/// 그래픽 파이프라인 개체를 생성합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="desc"> 그래픽 파이프라인 정보 서술 구조체를 전달합니다. </param>
		/// <returns> 생성된 인터페이스 개체가 반환됩니다. </returns>
		public static ID3D12PipelineState CreatePipelineState( this ID3D12Device @this, D3D12GraphicsPipelineStateDesc desc )
			=> @this.CreatePipelineState<ID3D12PipelineState>( desc );

		/// <summary>
		/// 계산 파이프라인 개체를 생성합니다.
		/// </summary>
		/// <typeparam name="T"> 개체의 인터페이스 형식을 전달합니다. </typeparam>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="desc"> 계산 파이프라인 정보 서술 구조체를 전달합니다. </param>
		/// <returns> 생성된 인터페이스 개체가 반환됩니다. </returns>
		public static T CreatePipelineState<T>( this ID3D12Device @this, D3D12ComputePipelineStateDesc desc ) where T : class
		{
			@this.CreateComputePipelineState( desc, typeof( T ).GUID, out var ppPipelineState );
			return ppPipelineState as T;
		}

		/// <summary>
		/// 계산 파이프라인 개체를 생성합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="desc"> 계산 파이프라인 정보 서술 구조체를 전달합니다. </param>
		/// <returns> 생성된 인터페이스 개체가 반환됩니다. </returns>
		public static ID3D12PipelineState CreatePipelineState( this ID3D12Device @this, D3D12ComputePipelineStateDesc desc )
			=> @this.CreatePipelineState<ID3D12PipelineState>( desc );
	}
}
