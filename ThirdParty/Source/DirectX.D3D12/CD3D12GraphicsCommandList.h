// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3D12GraphicsCommandList : CD3D12CommandList, ID3D12GraphicsCommandList
	{
		::ID3D12GraphicsCommandList* pCommandList;

	public:
		CD3D12GraphicsCommandList( ::ID3D12GraphicsCommandList* pCommandList );
		static void RegisterClass();

		virtual void Close();
		virtual void Reset( ID3D12CommandAllocator^ allocator, ID3D12PipelineState^ initialPipelineState );
		virtual void ClearState( ID3D12PipelineState^ pipelineState );
		virtual void DrawInstanced( unsigned int vertexCountPerInstance, unsigned int instanceCount, unsigned int startVertexLocation, unsigned int startInstanceLocation );
		virtual void DrawIndexedInstanced( unsigned int indexCountPerInstance, unsigned int instanceCount, unsigned int startIndexLocation, int baseVertexLocation, unsigned int startInstanceLocation );
		virtual void Dispatch( unsigned int threadGroupCountX, unsigned int threadGroupCountY, unsigned int threadGroupCountZ );
		virtual void CopyBufferRegion( ID3D12Resource^ dstBuffer, unsigned long long dstOffset, ID3D12Resource^ srcBuffer, unsigned long long srcOffset, unsigned long long numBytes );
		virtual void CopyTextureRegion( D3D12TextureCopyLocation dst, unsigned int dstX, unsigned int dstY, unsigned int dstZ, D3D12TextureCopyLocation src, System::Nullable<D3D12Box> pSrcBox );
		virtual void CopyResource( ID3D12Resource^ dstResource, ID3D12Resource^ srcResource );
		virtual void CopyTiles( ID3D12Resource^ tiledResource, D3D12TiledResourceCoordinate tileRegionStartCoordinate, D3D12TileRegionSize tileRegionSize, ID3D12Resource^ buffer, unsigned long long bufferStartOffsetInBytes, D3D12TileCopyFlags flags );
		virtual void ResolveSubresource( ID3D12Resource^ dstResource, unsigned int dstSubresource, ID3D12Resource^ srcResource, unsigned int srcSubresource, DXGIFormat format );
		virtual void IASetPrimitiveTopology( D3DPrimitiveTopology primitiveTopology );
		virtual void RSSetViewports( System::Collections::Generic::IList<D3D12Viewport>^ viewports );
		virtual void RSSetScissorRects( System::Collections::Generic::IList<SC::Engine::Runtime::Core::Numerics::Rectangle>^ rects );
		virtual void OMSetBlendFactor( SC::Engine::Runtime::Core::Numerics::Vector4 blendFactor );
		virtual void OMSetStencilRef( unsigned int stencilRef );
		virtual void SetPipelineState( ID3D12PipelineState^ pipelineState );
		virtual void ResourceBarrier( System::Collections::Generic::IList<D3D12ResourceBarrier>^ barriers );
		virtual void ExecuteBundle( ID3D12GraphicsCommandList^ bundleCommandList );
		virtual void SetDescriptorHeaps( System::Collections::Generic::IList<ID3D12DescriptorHeap^>^ descriptorHeaps );
		virtual void SetComputeRootSignature( ID3D12RootSignature^ rootSignature );
		virtual void SetGraphicsRootSignature( ID3D12RootSignature^ rootSignature );
		virtual void SetComputeRootDescriptorTable( unsigned int rootParameterIndex, D3D12GPUDescriptorHandle baseDescriptor );
		virtual void SetGraphicsRootDescriptorTable( unsigned int rootParameterIndex, D3D12GPUDescriptorHandle baseDescriptor );
		virtual void SetComputeRoot32BitConstant( unsigned int rootParameterIndex, unsigned int srcData, unsigned int destOffsetIn32BitValues );
		virtual void SetGraphicsRoot32BitConstant( unsigned int rootParameterIndex, unsigned int srcData, unsigned int destOffsetIn32BitValues );
		virtual void SetComputeRoot32BitConstants( unsigned int rootParameterIndex, unsigned int num32BitValuesToSet, System::IntPtr pSrcData, unsigned int destOffsetIn32BitValues );
		virtual void SetGraphicsRoot32BitConstants( unsigned int rootParameterIndex, unsigned int num32BitValuesToSet, System::IntPtr pSrcData, unsigned int destOffsetIn32BitValues );
		virtual void SetComputeRootConstantBufferView( unsigned int rootParameterIndex, unsigned long long bufferLocation );
		virtual void SetGraphicsRootConstantBufferView( unsigned int rootParameterIndex, unsigned long long bufferLocation );
		virtual void SetComputeRootShaderResourceView( unsigned int rootParameterIndex, unsigned long long bufferLocation );
		virtual void SetGraphicsRootShaderResourceView( unsigned int rootParameterIndex, unsigned long long bufferLocation );
		virtual void SetComputeRootUnorderedAccessView( unsigned int rootParameterIndex, unsigned long long bufferLocation );
		virtual void SetGraphicsRootUnorderedAccessView( unsigned int rootParameterIndex, unsigned long long bufferLocation );
		virtual void IASetIndexBuffer( System::Nullable<D3D12IndexBufferView> view );
		virtual void IASetVertexBuffers( unsigned int startSlot, System::Collections::Generic::IList<D3D12VertexBufferView>^ views );
		virtual void SOSetTargets( unsigned int startSlot, System::Collections::Generic::IList<D3D12StreamOutputBufferView>^ views );
		virtual void OMSetRenderTargets( unsigned int numRenderTargetDescriptors, System::Collections::Generic::IList<D3D12CPUDescriptorHandle>^ renderTargetDescriptors, System::Nullable<D3D12CPUDescriptorHandle> depthStencilDescriptor );
		virtual void OMSetRenderTargets( unsigned int numRenderTargetDescriptors, D3D12CPUDescriptorHandle renderTargetDescriptor, System::Nullable<D3D12CPUDescriptorHandle> depthStencilDescriptor );
		virtual void ClearDepthStencilView( D3D12CPUDescriptorHandle depthStencilView, D3D12ClearFlags clearFlags, float depth, unsigned int stencil, System::Collections::Generic::IList<SC::Engine::Runtime::Core::Numerics::Rectangle>^ rects );
		virtual void ClearRenderTargetView( D3D12CPUDescriptorHandle renderTargetView, SC::Engine::Runtime::Core::Numerics::Color color, System::Collections::Generic::IList<SC::Engine::Runtime::Core::Numerics::Rectangle>^ rects );
		virtual void ClearUnorderedAccessViewUint( D3D12GPUDescriptorHandle viewGPUHandleInCurrentHeap, D3D12CPUDescriptorHandle viewCPUHandle, ID3D12Resource^ resource, D3D12UInt4 values, System::Collections::Generic::IList<SC::Engine::Runtime::Core::Numerics::Rectangle>^ rects );
		virtual void ClearUnorderedAccessViewFloat( D3D12GPUDescriptorHandle viewGPUHandleInCurrentHeap, D3D12CPUDescriptorHandle viewCPUHandle, ID3D12Resource^ resource, SC::Engine::Runtime::Core::Numerics::Color values, System::Collections::Generic::IList<SC::Engine::Runtime::Core::Numerics::Rectangle>^ rects );
		virtual void DiscardResource( ID3D12Resource^ resource, System::Nullable<D3D12DiscardRegion> region );
		virtual void BeginQuery( ID3D12QueryHeap^ queryHeap, D3D12QueryType type, unsigned int index );
		virtual void EndQuery( ID3D12QueryHeap^ queryHeap, D3D12QueryType type, unsigned int index );
		virtual void ResolveQueryData( ID3D12QueryHeap^ queryHeap, D3D12QueryType type, unsigned int startIndex, unsigned int numQueries, ID3D12Resource^ destinationBuffer, unsigned long long alignedDestinationBufferOffset );
		virtual void SetPredication( ID3D12Resource^ buffer, unsigned long long alignedBufferOffset, D3D12PredicationOP operation );
		virtual void ExecuteIndirect( ID3D12CommandSignature^ commandSignature, unsigned int maxCommandCount, ID3D12Resource^ argumentBuffer, unsigned long long argumentBufferOffset, ID3D12Resource^ countBuffer, unsigned long long countBufferOffset );

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}