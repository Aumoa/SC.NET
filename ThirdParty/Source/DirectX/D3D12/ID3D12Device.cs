// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using SC.ThirdParty.WinAPI;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 자원 관리를 수행하는 개체에 대한 공통 메서드를 제공합니다.
    /// </summary>
    [Guid( "189819F1-1DB6-4B57-BE54-1821339B85F7" )]
	[ComVisible( true )]
	public interface ID3D12Device : ID3D12Object
	{
		/// <summary>
		/// 이 디바이스 개체와 연결된 물리 디바이스의 개수를 가져옵니다.
		/// </summary>
		/// <returns> 개수가 반환됩니다. </returns>
		uint GetNodeCount();

		/// <summary>
		/// 명령 대기열 개체를 생성합니다.
		/// </summary>
		/// <param name="desc"> 명령 대기열 서술 정보를 전달합니다. </param>
		/// <param name="riid"> 개체의 GUID를 전달합니다. </param>
		/// <param name="ppCommandQueue"> 인터페이스 개체를 받을 변수의 참조를 전달합니다. </param>
		void CreateCommandQueue( D3D12CommandQueueDesc desc, Guid riid, out IUnknown ppCommandQueue );

		/// <summary>
		/// 명령 할당기 개체를 생성합니다.
		/// </summary>
		/// <param name="type"> 명령 목록 유형을 전달합니다. </param>
		/// <param name="riid"> 개체의 GUID를 전달합니다. </param>
		/// <param name="ppCommandAllocator"> 인터페이스 개체를 받을 변수의 참조를 전달합니다. </param>
		void CreateCommandAllocator( D3D12CommandListType type, Guid riid, out IUnknown ppCommandAllocator );

		/// <summary>
		/// 그래픽 파이프라인 개체를 생성합니다.
		/// </summary>
		/// <param name="desc"> 그래픽 파이프라인 정보 서술 구조체를 전달합니다. </param>
		/// <param name="riid"> 개체의 GUID를 전달합니다. </param>
		/// <param name="ppPipelineState"> 인터페이스 개체를 받을 변수의 참조를 전달합니다. </param>
		void CreateGraphicsPipelineState( D3D12GraphicsPipelineStateDesc desc, Guid riid, out IUnknown ppPipelineState );

		/// <summary>
		/// 계산 파이프라인 개체를 생성합니다.
		/// </summary>
		/// <param name="desc"> 계산 파이프라인 정보 서술 구조체를 전달합니다. </param>
		/// <param name="riid"> 개체의 GUID를 전달합니다. </param>
		/// <param name="ppPipelineState"> 인터페이스 개체를 받을 변수의 참조를 전달합니다. </param>
		void CreateComputePipelineState( D3D12ComputePipelineStateDesc desc, Guid riid, out IUnknown ppPipelineState );

		/// <summary>
		/// 그래픽 명령 목록 개체를 생성합니다.
		/// </summary>
		/// <param name="nodeMask"> 장치 관측 노드 마스크를 전달합니다. </param>
		/// <param name="type"> 명령 목록 유형을 전달합니다. </param>
		/// <param name="pCommandAllocator"> 명령 할당기 개체를 전달합니다. </param>
		/// <param name="pInitialPipelineState"> 초기 파이프라인 상태 개체를 전달합니다. </param>
		/// <param name="riid"> 개체의 GUID를 전달합니다. </param>
		/// <param name="ppCommandList"> 인터페이스 개체를 받을 변수의 참조를 전달합니다. </param>
		void CreateCommandList( uint nodeMask, D3D12CommandListType type, ID3D12CommandAllocator pCommandAllocator, ID3D12PipelineState pInitialPipelineState, Guid riid, out IUnknown ppCommandList );

		/// <summary>
		/// 기능 레벨을 점검합니다.
		/// </summary>
		/// <param name="pFeatureSupportData"> 점검 대상 기능 레벨 구조체의 참조를 전달합니다. 매개변수는 입력 및 출력용으로 사용됩니다. </param>
		void CheckFeatureSupport( ref ValueType pFeatureSupportData );

		/// <summary>
		/// 서술자 힙 개체를 생성합니다. 
		/// </summary>
		/// <param name="descriptorHeapDesc"> 서술자 힙 정보를 서술하는 구조체를 전달합니다. </param>
		/// <param name="riid"> 개체의 GUID를 전달합니다. </param>
		/// <param name="ppHeap"> 인터페이스 개체를 받을 변수의 참조를 전달합니다. </param>
		void CreateDescriptorHeap( D3D12DescriptorHeapDesc descriptorHeapDesc, Guid riid, out IUnknown ppHeap );

		/// <summary>
		/// 서술자 힙의 핸들 크기를 가져옵니다.
		/// </summary>
		/// <param name="descriptorHeapType"> 서술자 힙 유형을 전달합니다. </param>
		/// <returns> 크기를 반환합니다. </returns>
		uint GetDescriptorHandleIncrementSize( D3D12DescriptorHeapType descriptorHeapType );

		/// <summary>
		/// 루트 서명 개체를 생성합니다.
		/// </summary>
		/// <param name="nodeMask"> 노드 마스크를 전달합니다. </param>
		/// <param name="pBlobWithRootSignature"> 입력 서명 데이터 블록을 전달합니다. </param>
		/// <param name="blobLengthInBytes"> 입력 서명 데이터의 바이트 단위 크기를 전달합니다. </param>
		/// <param name="riid"> 개체의 GUID를 전달합니다. </param>
		/// <param name="ppRootSignature"> 인터페이스 개체를 받을 변수의 참조를 전달합니다. </param>
		void CreateRootSignature( uint nodeMask, IntPtr pBlobWithRootSignature, ulong blobLengthInBytes, Guid riid, out IUnknown ppRootSignature );

		/// <summary>
		/// 상수 버퍼 서술자를 생성합니다.
		/// </summary>
		/// <param name="desc"> 상수 버퍼 서술 구조체를 전달합니다. </param>
		/// <param name="handle"> 서술자 힙 핸들을 전달합니다. </param>
		void CreateConstantBufferView( D3D12ConstantBufferViewDesc desc, D3D12CPUDescriptorHandle handle );

		/// <summary>
		/// 셰이더 자원 서술자를 생성합니다.
		/// </summary>
		/// <param name="pResource"> 셰이더 자원으로 사용할 리소스를 전달합니다. </param>
		/// <param name="desc"> 셰이더 자원 정보 서술 구조체를 전달합니다. null을 전달할 경우 자원 형식에 기초한 기본값이 사용됩니다. </param>
		/// <param name="handle"> 서술자 힙 핸들을 전달합니다. </param>
		void CreateShaderResourceView( ID3D12Resource pResource, D3D12ShaderResourceViewDesc? desc, D3D12CPUDescriptorHandle handle );

		/// <summary>
		/// 순서없는 접근 서술자를 생성합니다.
		/// </summary>
		/// <param name="pResource"> 순서없는 접근으로 사용할 리소스를 전달합니다. </param>
		/// <param name="pCounterResource"> 카운터 리소스를 전달합니다. </param>
		/// <param name="desc"> 순서없는 접근 정보 서술 구조체를 전달합니다. null을 전달할 경우 자원 형식에 기초한 기본값이 사용됩니다. </param>
		/// <param name="handle"> 서술자 힙 핸들을 전달합니다. </param>
		void CreateUnorderedAccessView( ID3D12Resource pResource, ID3D12Resource pCounterResource, D3D12UnorderedAccessViewDesc? desc, D3D12CPUDescriptorHandle handle );

		/// <summary>
		/// 렌더 타겟 서술자를 생성합니다.
		/// </summary>
		/// <param name="pResource"> 렌더 타겟으로 사용할 리소스를 전달합니다. </param>
		/// <param name="desc"> 렌더 타겟 정보 서술 구조체를 전달합니다. null을 전달할 경우 자원 형식에 기초한 기본값이 사용됩니다. </param>
		/// <param name="handle"> 서술자 힙 핸들을 전달합니다. </param>
		void CreateRenderTargetView( ID3D12Resource pResource, D3D12RenderTargetViewDesc? desc, D3D12CPUDescriptorHandle handle );

		/// <summary>
		/// 깊이 스텐실 서술자를 생성합니다.
		/// </summary>
		/// <param name="pResource"> 깊이 스텐실 대상으로 사용할 리소스를 전달합니다. </param>
		/// <param name="desc"> 깊이 스텐실 정보 서술 구조체를 전달합니다. null을 전달할 경우 자원 형식에 기초한 기본값이 사용됩니다. </param>
		/// <param name="handle"> 서술자 힙 핸들을 전달합니다. </param>
		void CreateDepthStencilView( ID3D12Resource pResource, D3D12DepthStencilViewDesc? desc, D3D12CPUDescriptorHandle handle );

		/// <summary>
		/// 샘플러 상태 서술자를 생성합니다.
		/// </summary>
		/// <param name="desc"> 샘플러 상태를 서술하는 구조체를 전달합니다. </param>
		/// <param name="handle"> 서술자 힙 핸들을 전달합니다. </param>
		void CreateSampler( D3D12SamplerDesc desc, D3D12CPUDescriptorHandle handle );

		/// <summary>
		/// 서술자 목록을 복사합니다.
		/// </summary>
		/// <param name="destDescriptorRangeStarts"> 서술자 복사 대상 위치 목록을 전달합니다. </param>
		/// <param name="destDescriptorRangeSizes"> 서술자 복사 대상의 크기 목록을 전달합니다. </param>
		/// <param name="srcDescriptorRangeStarts"> 서술자 복사 원본 위치 목록을 전달합니다. </param>
		/// <param name="srcDescriptorRangeSizes"> 서술자 복사 원본의 크기 목록을 전달합니다. </param>
		/// <param name="descriptorHeapType"> 서술자 힙 유형을 전달합니다. </param>
		void CopyDescriptors(
			IList<D3D12CPUDescriptorHandle> destDescriptorRangeStarts,
			IList<uint> destDescriptorRangeSizes,
			IList<D3D12CPUDescriptorHandle> srcDescriptorRangeStarts,
			IList<uint> srcDescriptorRangeSizes,
			D3D12DescriptorHeapType descriptorHeapType
			);

		/// <summary>
		/// 서술자를 복사합니다.
		/// </summary>
		/// <param name="numDescriptors"> 복사할 서술자 개수를 전달합니다. </param>
		/// <param name="destDescriptorRangeStart"> 서술자 복사 대상 위치를 전달합니다. </param>
		/// <param name="srcDescriptorRangeStart"> 서술자 복사 원본 위치를 전달합니다. </param>
		/// <param name="descriptorHeapsType"> 서술자힙 유형을 전달합니다. </param>
		void CopyDescriptorsSimple( uint numDescriptors, D3D12CPUDescriptorHandle destDescriptorRangeStart, D3D12CPUDescriptorHandle srcDescriptorRangeStart, D3D12DescriptorHeapType descriptorHeapsType );

		/// <summary>
		/// 리소스 할당 정보를 가져옵니다.
		/// </summary>
		/// <param name="visibleMask"> 장치 관측 마스크를 전달합니다. </param>
		/// <param name="resourceDescs"> 리소스 정보 구조체 목록을 전달합니다. </param>
		/// <returns> 리소스 할당 정보를 가져옵니다. </returns>
		D3D12ResourceAllocationInfo GetResourceAllocationInfo( uint visibleMask, IList<D3D12ResourceDesc> resourceDescs );

		/// <summary>
		/// 사용자 지정 힙의 속성을 가져옵니다.
		/// </summary>
		/// <param name="nodeMask"> 노드 마스크를 전달합니다. </param>
		/// <param name="heapType"> 힙 유형을 전달합니다. </param>
		/// <returns> 힙 속성 구조체를 반환합니다. </returns>
		D3D12HeapProperties GetCustomHeapProperties( uint nodeMask, D3D12HeapType heapType );

		/// <summary>
		/// 미리 커밋된 자원을 생성합니다.
		/// </summary>
		/// <param name="heapProperties"> 힙 속성을 전달합니다. </param>
		/// <param name="heapFlags"> 힙 속성을 전달합니다. </param>
		/// <param name="desc"> 자원 정보 구조체를 전달합니다. </param>
		/// <param name="initialResourceState"> 초기 자원 상태를 전달합니다. </param>
		/// <param name="optimizedClearValue"> 최적화된 초기화 값을 전달합니다. </param>
		/// <param name="riid"> 개체의 GUID를 전달합니다. </param>
		/// <param name="ppResource"> 인터페이스 개체를 받을 변수의 참조를 전달합니다. </param>
		void CreateCommittedResource(
			D3D12HeapProperties heapProperties,
			D3D12HeapFlags heapFlags,
			D3D12ResourceDesc desc,
			D3D12ResourceStates initialResourceState,
			D3D12ClearValue? optimizedClearValue,
			Guid riid,
			out IUnknown ppResource
			);

		/// <summary>
		/// 힙 개체를 생성합니다.
		/// </summary>
		/// <param name="desc"> 힙 정보를 전달합니다. </param>
		/// <param name="riid"> 개체의 GUID를 전달합니다. </param>
		/// <param name="ppHeap"> 인터페이스 개체를 받을 변수의 참조를 전달합니다. </param>
		void CreateHeap( D3D12HeapDesc desc, Guid riid, out IUnknown ppHeap );

		/// <summary>
		/// 배치된 자원을 생성합니다.
		/// </summary>
		/// <param name="pHeap"> 힙 개체를 전달합니다. </param>
		/// <param name="heapOffset"> 힙 오프셋을 전달합니다. </param>
		/// <param name="desc"> 자원 정보 구조체를 전달합니다. </param>
		/// <param name="initialResourceState"> 초기 자원 상태를 전달합니다. </param>
		/// <param name="optimizedClearValue"> 최적화된 초기화 값을 전달합니다. </param>
		/// <param name="riid"> 개체의 GUID를 전달합니다. </param>
		/// <param name="ppResource"> 인터페이스 개체를 받을 변수의 참조를 전달합니다. </param>
		void CreatePlacedResource(
			ID3D12Heap pHeap,
			ulong heapOffset,
			D3D12ResourceDesc desc,
			D3D12ResourceStates initialResourceState,
			D3D12ClearValue? optimizedClearValue,
			Guid riid,
			out IUnknown ppResource
			);

		/// <summary>
		/// 예약된 자원 개체를 생성합니다.
		/// </summary>
		/// <param name="desc"> 자원 정보 구조체를 전달합니다. </param>
		/// <param name="initialResourceState"> 초기 자원 상태를 전달합니다. </param>
		/// <param name="optimizedClearValue"> 최적화된 초기화 값을 전달합니다. </param>
		/// <param name="riid"> 개체의 GUID를 전달합니다. </param>
		/// <param name="ppResource"> 인터페이스 개체를 받을 변수의 참조를 전달합니다. </param>
		void CreateReservedResource(
			D3D12ResourceDesc desc,
			D3D12ResourceStates initialResourceState,
			D3D12ClearValue? optimizedClearValue,
			Guid riid,
			out IUnknown ppResource
			);

		/// <summary>
		/// 공유 가능한 개체에 대한 핸들을 생성합니다.
		/// </summary>
		/// <param name="pObject"> 공유 가능한 개체를 전달합니다. </param>
		/// <param name="pAttributes"> 보안 속성을 전달합니다. </param>
		/// <param name="access"> 핸들의 엑세스 가능성을 전달합니다. 현재 유일하게 허용되는 값은 <see cref="GenericAccess.All"/>입니다. </param>
		/// <param name="name"> 핸들의 이름을 전달합니다. </param>
		/// <returns> 생성된 핸들 개체가 반환됩니다. </returns>
		IPlatformHandle CreateSharedHandle( ID3D12DeviceChild pObject, IntPtr pAttributes, GenericAccess access, string name );

		/// <summary>
		/// 공유 가능한 개체에 대한 핸들을 엽니다.
		/// </summary>
		/// <param name="ntHandle"> 공유 핸들을 전달합니다. </param>
		/// <param name="riid"> 개체의 GUID를 전달합니다. </param>
		/// <param name="ppObject"> 인터페이스 개체를 받을 변수의 참조를 전달합니다. </param>
		void OpenSharedHandle(IPlatformHandle ntHandle, Guid riid, out IUnknown ppObject );

		/// <summary>
		/// 공유 가능한 개체에 대한 핸들을 엽니다.
		/// </summary>
		/// <param name="name"> 핸들의 이름을 전달합니다. </param>
		/// <param name="access"> 핸들의 엑세스 가능성을 전달합니다. </param>
		/// <returns> 열린 핸들 개체가 반환됩니다. </returns>
		IPlatformHandle OpenSharedHandleByName( string name, GenericAccess access );

		/// <summary>
		/// 개체를 GPU 메모리에 상주하도록 변경합니다.
		/// </summary>
		/// <param name="ppObjects"> 개체 목록을 전달합니다. </param>
		void MakeResident( IList<ID3D12Pageable> ppObjects );

		/// <summary>
		/// 개체를 GPU 메모리에 상주하지 않도록 변경합니다.
		/// </summary>
		/// <param name="ppObjects"> 개체 목록을 전달합니다. </param>
		void Evict( IList<ID3D12Pageable> ppObjects );

		/// <summary>
		/// 펜스 개체를 생성합니다.
		/// </summary>
		/// <param name="initialValue"> 초기 값을 전달합니다. </param>
		/// <param name="flags"> 펜스 속성을 전달합니다. </param>
		/// <param name="riid"> 개체의 GUID를 전달합니다. </param>
		/// <param name="ppFence"> 인터페이스 개체를 받을 변수의 참조를 전달합니다. </param>
		void CreateFence( ulong initialValue, D3D12FenceFlags flags, Guid riid, out IUnknown ppFence );

		/// <summary>
		/// 자원의 복사 가능한 배치 방식을 조회합니다.
		/// </summary>
		/// <param name="resourceDesc"> 자원 정보를 전달합니다. </param>
		/// <param name="firstSubresource"> 처음 서브리소스 인덱스를 전달합니다. </param>
		/// <param name="numSubresources"> 조회할 서브리소스 개수를 전달합니다. </param>
		/// <param name="baseOffset"> 기초 오프셋을 전달합니다. </param>
		/// <param name="numRows"> 각 서브리소스당 줄 개수를 가져옵니다. </param>
		/// <param name="rowSizeInBytes"> 각 서브리소스당 바이트 단위 너비를 가져옵니다. </param>
		/// <param name="totalBytes"> 최종 바이트 수를 가져옵니다. </param>
		/// <returns> 자원의 배치 형식을 서술하는 구조체가 반환됩니다. </returns>
		D3D12PlacedSubresourceFootprint[] GetCopyableFootprints( D3D12ResourceDesc resourceDesc, uint firstSubresource, uint numSubresources, ulong baseOffset, out uint[] numRows, out ulong[] rowSizeInBytes, out ulong totalBytes );

		/// <summary>
		/// 정보 요청 힙을 생성합니다.
		/// </summary>
		/// <param name="desc"> 정보 요청 힙 서술 구조체를 전달합니다. </param>
		/// <param name="riid"> 개체의 GUID를 전달합니다. </param>
		/// <param name="ppHeap"> 인터페이스 개체를 받을 변수의 참조를 전달합니다. </param>
		void CreateQueryHeap( D3D12QueryHeapDesc desc, Guid riid, out IUnknown ppHeap );

		/// <summary>
		/// 안정적인 전원 상태를 활성화합니다.
		/// </summary>
		/// <param name="enable"> 안정적 상태 활성화 여부를 전달합니다. </param>
		/// <remarks> 이 메서드는 기기가 개발자 모드로 설정된 경우에만 사용할 수 있습니다. 그 이외의 경우, 디바이스가 제거됩니다. </remarks>
		void SetStablePowerState( bool enable );

		/// <summary>
		/// 명령 서명 개체를 생성합니다.
		/// </summary>
		/// <param name="desc"> 명령 서명 개체에 대한 서술 정보를 전달합니다. </param>
		/// <param name="pRootSignature"> 입력 서명 개체를 전달합니다. </param>
		/// <param name="riid"> 개체의 GUID를 전달합니다. </param>
		/// <param name="ppCommandSignature"> 인터페이스 개체를 받을 변수의 참조를 전달합니다. </param>
		void CreateCommandSignature( D3D12CommandSignatureDesc desc, ID3D12RootSignature pRootSignature, Guid riid, out IUnknown ppCommandSignature );

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pTiledResource"></param>
		/// <param name="numTilesForEntireResource"></param>
		/// <param name="packedMipDesc"></param>
		/// <param name="standardTileShapeForNonPackedMips"></param>
		/// <param name="firstSubresourceTilingToGet"></param>
		/// <returns></returns>
		D3D12SubresourceTiling[] GetResourceTiling( ID3D12Resource pTiledResource, out uint numTilesForEntireResource, out D3D12PackedMipInfo packedMipDesc, out D3D12TileShape standardTileShapeForNonPackedMips, uint firstSubresourceTilingToGet );

		/// <summary>
		/// 어댑터의 LUID를 가져옵니다.
		/// </summary>
		/// <returns> LUID 개체가 반환됩니다. </returns>
		Luid GetAdapterLuid();
	}
}
