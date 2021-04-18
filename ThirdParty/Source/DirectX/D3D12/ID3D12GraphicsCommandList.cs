// Copyright 2020 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 그래픽 관련 명령을 처리할 수 있는 명령 목록에 대한 공통 메서드를 제공합니다.
    /// </summary>
    [Guid( "5B160D0F-AC1B-4185-8BA8-B3AE42A5A455" )]
	[ComVisible( true )]
	public interface ID3D12GraphicsCommandList : ID3D12CommandList
	{
		/// <summary>
		/// 명령 목록을 닫습니다. 이후 명령을 추가할 수 없습니다.
		/// </summary>
		void Close();

		/// <summary>
		/// 명령 목록을 초기화하고 명령 목록을 엽니다. 이후 명령을 추가할 수 있습니다.
		/// </summary>
		/// <param name="allocator"> 명령 할당기 개체를 전달합니다. </param>
		/// <param name="initialPipelineState"> 초기 상태로 사용할 파이프라인 개체를 전달합니다. </param>
		void Reset( ID3D12CommandAllocator allocator, ID3D12PipelineState initialPipelineState = null );

		/// <summary>
		/// 현재 셰이더 상태를 초기화합니다.
		/// </summary>
		/// <param name="pipelineState"> 초기 상태로 사용할 파이프라인 개체를 전달합니다. </param>
		void ClearState( ID3D12PipelineState pipelineState = null );

		/// <summary>
		/// 설정된 정점 버퍼 데이터로 기하 모형을 렌더링합니다.
		/// </summary>
		/// <param name="vertexCountPerInstance"> 렌더링에 필요한 정점 개수를 전달합니다. </param>
		/// <param name="instanceCount"> 렌더링 인스턴스 개수를 전달합니다. </param>
		/// <param name="startVertexLocation"> 정점 버퍼에서 필요한 정점의 시작 위치를 전달합니다. </param>
		/// <param name="startInstanceLocation"> 인스턴스 시작 위치를 전달합니다. </param>
		void DrawInstanced( uint vertexCountPerInstance, uint instanceCount = 1, uint startVertexLocation = 0, uint startInstanceLocation = 0 );

		/// <summary>
		/// 설정된 정점 버퍼 데이터 및 인덱스 버퍼 데이터로 기하 모형을 렌더링합니다.
		/// </summary>
		/// <param name="indexCountPerInstance"> 렌더링에 필요한 인덱스 개수를 전달합니다. </param>
		/// <param name="instanceCount"> 렌더링 인스턴스 개수를 전달합니다. </param>
		/// <param name="startIndexLocation"> 인덱스 버퍼에서 필요한 인덱스의 시작 위치를 전달합니다. </param>
		/// <param name="baseVertexLocation"> 각 인덱스가 가리키는 정점 오프셋의 이동량을 전달합니다. </param>
		/// <param name="startInstanceLocation"> 인스턴스 시작 위치를 전달합니다. </param>
		void DrawIndexedInstanced( uint indexCountPerInstance, uint instanceCount = 1, uint startIndexLocation = 0, int baseVertexLocation = 0, uint startInstanceLocation = 0 );

		/// <summary>
		/// 계산 명령을 배치합니다.
		/// </summary>
		/// <param name="threadGroupCountX"> X축 스레드 그룹의 개수를 전달합니다. </param>
		/// <param name="threadGroupCountY"> Y축 스레드 그룹의 개수를 전달합니다. </param>
		/// <param name="threadGroupCountZ"> Z축 스레드 그룹의 개수를 전달합니다. </param>
		void Dispatch( uint threadGroupCountX, uint threadGroupCountY, uint threadGroupCountZ = 1 );

		/// <summary>
		/// <paramref name="srcBuffer"/> 자원의 데이터를 <paramref name="dstBuffer"/> 자원으로 GPU 차원에서 전송합니다.
		/// </summary>
		/// <param name="dstBuffer"> 복사 대상 자원을 전달합니다. </param>
		/// <param name="dstOffset"> 복사 대상 바이트 위치를 전달합니다. </param>
		/// <param name="srcBuffer"> 복사 원본 자원을 전달합니다. </param>
		/// <param name="srcOffset"> 복사 원본 바이트 위치를 전달합니다. </param>
		/// <param name="numBytes"> 복사 바이트 단위 크기를 전달합니다. </param>
		void CopyBufferRegion( ID3D12Resource dstBuffer, ulong dstOffset, ID3D12Resource srcBuffer, ulong srcOffset, ulong numBytes );

		/// <summary>
		/// 베치된 텍스처 데이터를 대상 텍스처 자원에 전송합니다.
		/// </summary>
		/// <param name="dst"> 복사 대상 정보를 전달합니다. </param>
		/// <param name="dstX"> 복사 대상의 X축 시작 위치를 전달합니다. </param>
		/// <param name="dstY"> 복사 대상의 Y축 시작 위치를 전달합니다. </param>
		/// <param name="dstZ"> 복사 대상의 Z축 시작 위치를 전달합니다. </param>
		/// <param name="src"> 복사 원본 정보를 전달합니다. </param>
		/// <param name="pSrcBox"> 복사 원본의 복사 영역을 전달합니다. null을 전달할 경우 전체 영역이 복사됩니다. </param>
		void CopyTextureRegion( D3D12TextureCopyLocation dst, uint dstX, uint dstY, uint dstZ, D3D12TextureCopyLocation src, D3D12Box? pSrcBox );

		/// <summary>
		/// <paramref name="srcResource"/> 자원의 데이터를 <paramref name="dstResource"/> 자원으로 GPU 차원에서 단순 전송합니다. 두 자원의 형식 및 크기는 같아야 합니다.
		/// </summary>
		/// <param name="dstResource"> 복사 대상 자원을 전달합니다. </param>
		/// <param name="srcResource"> 복사 원본 자원을 전달합니다. </param>
		void CopyResource( ID3D12Resource dstResource, ID3D12Resource srcResource );

		/// <summary>
		/// 타일 리소스를 복사합니다.
		/// </summary>
		/// <param name="tiledResource"> 대상 타일 리소스를 전달합니다. </param>
		/// <param name="tileRegionStartCoordinate"> 복사 대상 시작 위치를 전달합니다. </param>
		/// <param name="tileRegionSize"> 복사 대상 크기를 전달합니다. </param>
		/// <param name="buffer"> 복사 원본 버퍼를 전달합니다. </param>
		/// <param name="bufferStartOffsetInBytes"> 복사 시작 바이트 위치를 전달합니다. </param>
		/// <param name="flags"> 복사 속성을 전달합니다. </param>
		void CopyTiles( ID3D12Resource tiledResource, D3D12TiledResourceCoordinate tileRegionStartCoordinate, D3D12TileRegionSize tileRegionSize, ID3D12Resource buffer, ulong bufferStartOffsetInBytes, D3D12TileCopyFlags flags );

		/// <summary>
		/// 멀티 샘플 리소스를 일반 리소스에 복사합니다.
		/// </summary>
		/// <param name="dstResource"> 대상 일반 리소스를 전달합니다. </param>
		/// <param name="dstSubresource"> 대상 일반 리소스의 서브리소스 인덱스를 전달합니다. </param>
		/// <param name="srcResource"> 원본 멀티 샘플 리소스를 전달합니다. </param>
		/// <param name="srcSubresource"> 원본 멀티 샘플 리소스의 서브리소스 인덱스를 전달합니다. </param>
		/// <param name="format"> 일반 리소스로 나타낼 형식을 전달합니다. </param>
		void ResolveSubresource( ID3D12Resource dstResource, uint dstSubresource, ID3D12Resource srcResource, uint srcSubresource, DXGIFormat format );

		/// <summary>
		/// 기하 렌더링에 사용되는 최소 기하 모형 정보를 설정합니다.
		/// </summary>
		/// <param name="primitiveTopology"> 최소 기하 모형을 전달합니다. </param>
		void IASetPrimitiveTopology( D3DPrimitiveTopology primitiveTopology );

		/// <summary>
		/// 뷰포트를 설정합니다.
		/// </summary>
		/// <param name="viewports"> 뷰포트 목록을 전달합니다. </param>
		void RSSetViewports( IList<D3D12Viewport> viewports );

		/// <summary>
		/// 절단 영역을 설정합니다.
		/// </summary>
		/// <param name="rects"> 절단 영역 목록을 전달합니다. </param>
		void RSSetScissorRects( IList<Rectangle> rects );

		/// <summary>
		/// 사용자 지정 블렌딩 계수를 설정합니다. 
		/// </summary>
		/// <param name="blendFactor"> 블렌딩 계수를 전달합니다. </param>
		void OMSetBlendFactor( Vector4 blendFactor );

		/// <summary>
		/// 사용자 지정 스텐실 값을 설정합니다.
		/// </summary>
		/// <param name="stencilRef"> 스텐실 값을 전달합니다. </param>
		void OMSetStencilRef( uint stencilRef );

		/// <summary>
		/// 파이프라인 상태 개체를 설정합니다.
		/// </summary>
		/// <param name="pipelineState"> 파이프라인 개체를 전달합니다. </param>
		void SetPipelineState( ID3D12PipelineState pipelineState );

		/// <summary>
		/// 자원 상태 장벽을 설정합니다.
		/// </summary>
		/// <param name="barriers"> 자원 상태 장벽 목록을 전달합니다. </param>
		void ResourceBarrier( IList<D3D12ResourceBarrier> barriers );

		/// <summary>
		/// 묶음 그래픽 명령을 실행합니다.
		/// </summary>
		/// <param name="bundleCommandList"> 묶음 그래픽 명령 목록 개체를 전달합니다. </param>
		void ExecuteBundle( ID3D12GraphicsCommandList bundleCommandList );

		/// <summary>
		/// 서술자 힙 개체를 설정합니다.
		/// </summary>
		/// <param name="descriptorHeaps"> 서술자 힙 개체 목록을 전달합니다. </param>
		void SetDescriptorHeaps( IList<ID3D12DescriptorHeap> descriptorHeaps );

		/// <summary>
		/// 계산 루트 서명 개체를 설정합니다.
		/// </summary>
		/// <param name="rootSignature"> 루트 서명 개체를 전달합니다. </param>
		void SetComputeRootSignature( ID3D12RootSignature rootSignature );

		/// <summary>
		/// 그래픽 루트 서명 개체를 설정합니다.
		/// </summary>
		/// <param name="rootSignature"> 루트 서명 개체를 전달합니다. </param>
		void SetGraphicsRootSignature( ID3D12RootSignature rootSignature );

		/// <summary>
		/// 컴퓨트 루트 서명 서술자 테이블을 설정합니다.
		/// </summary>
		/// <param name="rootParameterIndex"> 매개변수 인덱스를 전달합니다. </param>
		/// <param name="baseDescriptor"> GPU 서술자 핸들을 전달합니다. </param>
		void SetComputeRootDescriptorTable( uint rootParameterIndex, D3D12GPUDescriptorHandle baseDescriptor );

		/// <summary>
		/// 그래픽 루트 서명 서술자 테이블을 설정합니다.
		/// </summary>
		/// <param name="rootParameterIndex"> 매개변수 인덱스를 전달합니다. </param>
		/// <param name="baseDescriptor"> GPU 서술자 핸들을 전달합니다. </param>
		void SetGraphicsRootDescriptorTable( uint rootParameterIndex, D3D12GPUDescriptorHandle baseDescriptor );

		/// <summary>
		/// 32비트 컴퓨트 루트 서명 값을 설정합니다.
		/// </summary>
		/// <param name="rootParameterIndex"> 매개변수 인덱스를 전달합니다. </param>
		/// <param name="srcData"> 설정할 값을 전달합니다. </param>
		/// <param name="destOffsetIn32BitValues"> 값을 복사할 대상 바이트 위치를 전달합니다. </param>
		void SetComputeRoot32BitConstant( uint rootParameterIndex, uint srcData, uint destOffsetIn32BitValues );

		/// <summary>
		/// 32비트 그래픽 루트 서명 값을 설정합니다.
		/// </summary>
		/// <param name="rootParameterIndex"> 매개변수 인덱스를 전달합니다. </param>
		/// <param name="srcData"> 설정할 값을 전달합니다. </param>
		/// <param name="destOffsetIn32BitValues"> 값을 복사할 대상 바이트 위치를 전달합니다. </param>
		void SetGraphicsRoot32BitConstant( uint rootParameterIndex, uint srcData, uint destOffsetIn32BitValues );

		/// <summary>
		/// 32비트 컴퓨트 루트 서명 값을 설정합니다.
		/// </summary>
		/// <param name="rootParameterIndex"> 매개변수 인덱스를 전달합니다. </param>
		/// <param name="num32BitValuesToSet"> 설정할 32비트 값을의 개수를 전달합니다. </param>
		/// <param name="pSrcData"> 설정할 데이터를 전달합니다. </param>
		/// <param name="destOffsetIn32BitValues"> 값을 복사할 대상 바이트 위치를 전달합니다. </param>
		void SetComputeRoot32BitConstants( uint rootParameterIndex, uint num32BitValuesToSet, IntPtr pSrcData, uint destOffsetIn32BitValues );

		/// <summary>
		/// 32비트 그래픽 루트 서명 값을 설정합니다.
		/// </summary>
		/// <param name="rootParameterIndex"> 매개변수 인덱스를 전달합니다. </param>
		/// <param name="num32BitValuesToSet"> 설정할 32비트 값을의 개수를 전달합니다. </param>
		/// <param name="pSrcData"> 설정할 데이터를 전달합니다. </param>
		/// <param name="destOffsetIn32BitValues"> 값을 복사할 대상 바이트 위치를 전달합니다. </param>
		void SetGraphicsRoot32BitConstants( uint rootParameterIndex, uint num32BitValuesToSet, IntPtr pSrcData, uint destOffsetIn32BitValues );

		/// <summary>
		/// 컴퓨트 루트 상수 버퍼 서술자를 설정합니다.
		/// </summary>
		/// <param name="rootParameterIndex"> 매개변수 인덱스를 전달합니다. </param>
		/// <param name="bufferLocation"> 버퍼의 바이트 단위 위치를 전달합니다. </param>
		void SetComputeRootConstantBufferView( uint rootParameterIndex, ulong bufferLocation );

		/// <summary>
		/// 그래픽 루트 상수 버퍼 서술자를 설정합니다.
		/// </summary>
		/// <param name="rootParameterIndex"> 매개변수 인덱스를 전달합니다. </param>
		/// <param name="bufferLocation"> 버퍼의 바이트 단위 위치를 전달합니다. </param>
		void SetGraphicsRootConstantBufferView( uint rootParameterIndex, ulong bufferLocation );

		/// <summary>
		/// 컴퓨트 루트 셰이더 자원 서술자를 설정합니다.
		/// </summary>
		/// <param name="rootParameterIndex"> 매개변수 인덱스를 전달합니다. </param>
		/// <param name="bufferLocation"> 버퍼의 바이트 단위 위치를 전달합니다. </param>
		void SetComputeRootShaderResourceView( uint rootParameterIndex, ulong bufferLocation );

		/// <summary>
		/// 그래픽 루트 셰이더 자원 서술자를 설정합니다.
		/// </summary>
		/// <param name="rootParameterIndex"> 매개변수 인덱스를 전달합니다. </param>
		/// <param name="bufferLocation"> 버퍼의 바이트 단위 위치를 전달합니다. </param>
		void SetGraphicsRootShaderResourceView( uint rootParameterIndex, ulong bufferLocation );

		/// <summary>
		/// 컴퓨트 루트 순서없는 접근 서술자를 설정합니다.
		/// </summary>
		/// <param name="rootParameterIndex"> 매개변수 인덱스를 전달합니다. </param>
		/// <param name="bufferLocation"> 버퍼의 바이트 단위 위치를 전달합니다. </param>
		void SetComputeRootUnorderedAccessView( uint rootParameterIndex, ulong bufferLocation );

		/// <summary>
		/// 그래픽 루트 순서없는 접근 서술자를 설정합니다.
		/// </summary>
		/// <param name="rootParameterIndex"> 매개변수 인덱스를 전달합니다. </param>
		/// <param name="bufferLocation"> 버퍼의 바이트 단위 위치를 전달합니다. </param>
		void SetGraphicsRootUnorderedAccessView( uint rootParameterIndex, ulong bufferLocation );

		/// <summary>
		/// 색인 버퍼 서술 정보를 설정합니다.
		/// </summary>
		/// <param name="view"> 서술 정보 구조체를 전달합니다. </param>
		void IASetIndexBuffer( D3D12IndexBufferView? view );

		/// <summary>
		/// 정점 버퍼 서술 정보를 설정합니다.
		/// </summary>
		/// <param name="startSlot"> 설정할 슬롯 인덱스를 전달합니다. </param>
		/// <param name="views"> 서술 정보 구조체 목록을 전달합니다. </param>
		void IASetVertexBuffers( uint startSlot, IList<D3D12VertexBufferView> views );

		/// <summary>
		/// 스트림 출력 서술 정보를 설정합니다.
		/// </summary>
		/// <param name="startSlot"> 설정할 슬롯 인덱스를 전달합니다. </param>
		/// <param name="views"> 서술 정보 구조체 목록을 전달합니다. </param>
		void SOSetTargets( uint startSlot, IList<D3D12StreamOutputBufferView> views );

		/// <summary>
		/// 렌더 타겟을 설정합니다.
		/// </summary>
		/// <param name="numRenderTargetDescriptors"> 렌더 타겟 서술자 개수를 전달합니다. </param>
		/// <param name="renderTargetDescriptors"> 렌더 타겟 서술자 목록을 전달합니다. </param>
		/// <param name="depthStencilDescriptor"> 깊이 스텐실 서술자를 전달합니다. </param>
		void OMSetRenderTargets( uint numRenderTargetDescriptors, IList<D3D12CPUDescriptorHandle> renderTargetDescriptors, D3D12CPUDescriptorHandle? depthStencilDescriptor );

		/// <summary>
		/// 렌더 타겟을 설정합니다.
		/// </summary>
		/// <param name="numRenderTargetDescriptors"> 렌더 타겟 연속된 서술자 개수를 전달합니다. </param>
		/// <param name="renderTargetDescriptor"> 렌더 타겟 서술자 목록을 전달합니다. </param>
		/// <param name="depthStencilDescriptor"> 깊이 스텐실 서술자를 전달합니다. </param>
		void OMSetRenderTargets( uint numRenderTargetDescriptors, D3D12CPUDescriptorHandle renderTargetDescriptor, D3D12CPUDescriptorHandle? depthStencilDescriptor );

		/// <summary>
		/// 깊이 스텐실 텍스처를 초기화합니다.
		/// </summary>
		/// <param name="depthStencilView"> 깊이 스텐실 서술자를 전달합니다. </param>
		/// <param name="clearFlags"> 초기화 플래그를 전달합니다. </param>
		/// <param name="depth"> 초기화 깊이 값을 전달합니다. </param>
		/// <param name="stencil"> 초기화 스텐실 값을 전달합니다. </param>
		/// <param name="rects"> 초기화 영역 목록을 전달합니다. </param>
		void ClearDepthStencilView( D3D12CPUDescriptorHandle depthStencilView, D3D12ClearFlags clearFlags, float depth, uint stencil, IList<Rectangle> rects = null );

		/// <summary>
		/// 렌더 타겟 텍스처를 초기화합니다.
		/// </summary>
		/// <param name="renderTargetView"> 렌더 타겟 서술자를 전달합니다. </param>
		/// <param name="color"> 초기화 색상 값을 전달합니다. </param>
		/// <param name="rects"> 초기화 영역 목록을 전달합니다. </param>
		void ClearRenderTargetView( D3D12CPUDescriptorHandle renderTargetView, Color color, IList<Rectangle> rects );

		/// <summary>
		/// 순서없는 접근 텍스처를 초기화합니다.
		/// </summary>
		/// <param name="viewGPUHandleInCurrentHeap"> 서술자의 GPU 핸들을 전달합니다. 서술자 힙이 <see cref="SetDescriptorHeaps(IList{ID3D12DescriptorHeap})"/> 메서드로 선택되어 있어야 합니다. </param>
		/// <param name="viewCPUHandle"> 서술자의 CPU 핸들을 전달합니다. </param>
		/// <param name="resource"> 자원을 전달합니다. </param>
		/// <param name="values"> 초기화 값을 전달합니다. </param>
		/// <param name="rects"> 초기화 영역 목록을 전달합니다. </param>
		void ClearUnorderedAccessViewUint( D3D12GPUDescriptorHandle viewGPUHandleInCurrentHeap, D3D12CPUDescriptorHandle viewCPUHandle, ID3D12Resource resource, D3D12UInt4 values, IList<Rectangle> rects );

		/// <summary>
		/// 순서없는 접근 텍스처를 초기화합니다.
		/// </summary>
		/// <param name="viewGPUHandleInCurrentHeap"> 서술자의 GPU 핸들을 전달합니다. 서술자 힙이 <see cref="SetDescriptorHeaps(IList{ID3D12DescriptorHeap})"/> 메서드로 선택되어 있어야 합니다. </param>
		/// <param name="viewCPUHandle"> 서술자의 CPU 핸들을 전달합니다. </param>
		/// <param name="resource"> 자원을 전달합니다. </param>
		/// <param name="values"> 초기화 값을 전달합니다. </param>
		/// <param name="rects"> 초기화 영역 목록을 전달합니다. </param>
		void ClearUnorderedAccessViewFloat( D3D12GPUDescriptorHandle viewGPUHandleInCurrentHeap, D3D12CPUDescriptorHandle viewCPUHandle, ID3D12Resource resource, Color values, IList<Rectangle> rects );

		/// <summary>
		/// 자원의 내용을 버립니다. 자원의 내용을 보존할 필요가 없음을 의미합니다.
		/// </summary>
		/// <param name="resource"> 대상 자원을 전달합니다. </param>
		/// <param name="region"> 버릴 영역을 전달합니다. null을 경우 자원 전체가 사용됩니다. </param>
		void DiscardResource( ID3D12Resource resource, D3D12DiscardRegion? region = null );

		/// <summary>
		/// GPU를 대상으로 정보 요청을 시작합니다.
		/// </summary>
		/// <param name="queryHeap"> 요청 결과를 받을 힙을 전달합니다. </param>
		/// <param name="type"> 요청 형식을 전달합니다. </param>
		/// <param name="index"> 대상 인덱스를 전달합니다. </param>
		void BeginQuery( ID3D12QueryHeap queryHeap, D3D12QueryType type, uint index );

		/// <summary>
		/// GPU를 대상으로 정보 요청을 종료합니다.
		/// </summary>
		/// <param name="queryHeap"> 요청 결과를 받을 힙을 전달합니다. </param>
		/// <param name="type"> 요청 형식을 전달합니다. </param>
		/// <param name="index"> 대상 인덱스를 전달합니다. </param>
		void EndQuery( ID3D12QueryHeap queryHeap, D3D12QueryType type, uint index );

		/// <summary>
		/// 정보 요청 결과를 버퍼로 전송합니다.
		/// </summary>
		/// <param name="queryHeap"> 요청 결과 힙을 전달합니다. </param>
		/// <param name="type"> 요청 형식을 전달합니다. </param>
		/// <param name="startIndex"> 결과를 가져올 인덱스 시작 위치를 전달합니다. </param>
		/// <param name="numQueries"> 결과를 가져올 인덱스 개수를 전달합니다. </param>
		/// <param name="destinationBuffer"> 결과를 가져올 버퍼를 전달합니다. </param>
		/// <param name="alignedDestinationBufferOffset"> 값을 쓰기 시작할, 정렬된 바이트 단위 오프셋을 전달합니다. </param>
		void ResolveQueryData( ID3D12QueryHeap queryHeap, D3D12QueryType type, uint startIndex, uint numQueries, ID3D12Resource destinationBuffer, ulong alignedDestinationBufferOffset );

		/// <summary>
		/// Predication 상태를 설정합니다.
		/// </summary>
		/// <param name="buffer"> 설정할 대상 자원을 전달합니다. </param>
		/// <param name="alignedBufferOffset"> 정렬된 버퍼 오프셋을 전달합니다. </param>
		/// <param name="operation"> 연산 방식을 전달합니다. </param>
		void SetPredication( ID3D12Resource buffer, ulong alignedBufferOffset, D3D12PredicationOP operation );

		/// <summary>
		/// 간접적으로 명령을 실행합니다.
		/// </summary>
		/// <param name="commandSignature"> 명령 서명 개체를 전달합니다. <paramref name="argumentBuffer"/>의 데이터는 명령 서명의 명령 내용에 의해 유연하게 해석됩니다. </param>
		/// <param name="maxCommandCount"> 최대 명령 수를 전달합니다. <paramref name="countBuffer"/>가 null일 경우 이 값은 명령 수를 나타냅니다. 아닐 경우, 수행할 실제 명령 수는 이 값의 최소 값과 <paramref name="countBuffer"/>에 포함된 32비트 부호없는 정수로 정의됩니다. </param>
		/// <param name="argumentBuffer"> 명령에 따라 해석될 매개 변수 버퍼를 전달합니다. </param>
		/// <param name="argumentBufferOffset"> 매개 변수 버퍼의 오프셋을 전달합니다. </param>
		/// <param name="countBuffer"> 작업 횟수 버퍼를 전달합니다. </param>
		/// <param name="countBufferOffset"> 작업 횟수 버퍼의 오프셋을 전달합니다. </param>
		void ExecuteIndirect( ID3D12CommandSignature commandSignature, uint maxCommandCount, ID3D12Resource argumentBuffer, ulong argumentBufferOffset, ID3D12Resource countBuffer = null, ulong countBufferOffset = 0 );
	}
}
