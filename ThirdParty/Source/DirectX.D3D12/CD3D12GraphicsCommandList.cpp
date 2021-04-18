// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::Engine::Runtime::Core::Numerics;
using namespace SC::ThirdParty::DirectX;

using namespace System;
using namespace System::Collections::Generic;

using namespace std;

CD3D12GraphicsCommandList::CD3D12GraphicsCommandList( ::ID3D12GraphicsCommandList* pCommandList ) : CD3D12CommandList( pCommandList )
{
	this->pCommandList = pCommandList;
}

void CD3D12GraphicsCommandList::RegisterClass()
{
	RegisterCLSID( ID3D12GraphicsCommandList::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

void CD3D12GraphicsCommandList::Close()
{
	HR( pCommandList->Close() );
}

void CD3D12GraphicsCommandList::Reset( ID3D12CommandAllocator^ allocator, ID3D12PipelineState^ initialPipelineState )
{
	HR( pCommandList->Reset( Take<::ID3D12CommandAllocator>( allocator ), Take<::ID3D12PipelineState>( initialPipelineState ) ) );
}

void CD3D12GraphicsCommandList::ClearState( ID3D12PipelineState^ pipelineState )
{
	pCommandList->ClearState( Take<::ID3D12PipelineState>( pipelineState ) );
}

void CD3D12GraphicsCommandList::DrawInstanced( unsigned int vertexCountPerInstance, unsigned int instanceCount, unsigned int startVertexLocation, unsigned int startInstanceLocation )
{
	pCommandList->DrawInstanced( vertexCountPerInstance, instanceCount, startVertexLocation, startInstanceLocation );
}

void CD3D12GraphicsCommandList::DrawIndexedInstanced( unsigned int indexCountPerInstance, unsigned int instanceCount, unsigned int startIndexLocation, int baseVertexLocation, unsigned int startInstanceLocation )
{
	pCommandList->DrawIndexedInstanced( indexCountPerInstance, instanceCount, startIndexLocation, baseVertexLocation, startInstanceLocation );
}

void CD3D12GraphicsCommandList::Dispatch( unsigned int threadGroupCountX, unsigned int threadGroupCountY, unsigned int threadGroupCountZ )
{
	pCommandList->Dispatch( threadGroupCountX, threadGroupCountY, threadGroupCountZ );
}

void CD3D12GraphicsCommandList::CopyBufferRegion( ID3D12Resource^ dstBuffer, ulong_ dstOffset, ID3D12Resource^ srcBuffer, ulong_ srcOffset, ulong_ numBytes )
{
	pCommandList->CopyBufferRegion( Take<::ID3D12Resource>( dstBuffer ), dstOffset, Take<::ID3D12Resource>( srcBuffer ), srcOffset, numBytes );
}

void CD3D12GraphicsCommandList::CopyTextureRegion( D3D12TextureCopyLocation dst, unsigned int dstX, unsigned int dstY, unsigned int dstZ, D3D12TextureCopyLocation src, Nullable<D3D12Box> pSrcBox )
{
	D3D12_BOX pSrcBox_;
	if ( pSrcBox.HasValue ) Assign( pSrcBox_, pSrcBox.Value );

	D3D12_TEXTURE_COPY_LOCATION dst_, src_;
	Assign( dst_, dst );
	Assign( src_, src );

	pCommandList->CopyTextureRegion( &dst_, dstX, dstY, dstZ, &src_, pSrcBox.HasValue ? &pSrcBox_ : nullptr );
}

void CD3D12GraphicsCommandList::CopyResource( ID3D12Resource^ dstResource, ID3D12Resource^ srcResource )
{
	pCommandList->CopyResource( Take<::ID3D12Resource>( dstResource ), Take<::ID3D12Resource>( srcResource ) );
}

void CD3D12GraphicsCommandList::CopyTiles( ID3D12Resource^ tiledResource, D3D12TiledResourceCoordinate tileRegionStartCoordinate, D3D12TileRegionSize tileRegionSize, ID3D12Resource^ buffer, ulong_ bufferStartOffsetInBytes, D3D12TileCopyFlags flags )
{
	D3D12_TILED_RESOURCE_COORDINATE tileRegionStartCoordinate_;
	Assign( tileRegionStartCoordinate_, tileRegionStartCoordinate );
	D3D12_TILE_REGION_SIZE tileRegionSize_;
	Assign( tileRegionSize_, tileRegionSize );

	pCommandList->CopyTiles( Take<::ID3D12Resource>( tiledResource ), &tileRegionStartCoordinate_, &tileRegionSize_, Take<::ID3D12Resource>( buffer ), bufferStartOffsetInBytes, ( D3D12_TILE_COPY_FLAGS )flags );
}

void CD3D12GraphicsCommandList::ResolveSubresource( ID3D12Resource^ dstResource, uint_ dstSubresource, ID3D12Resource^ srcResource, uint_ srcSubresource, DXGIFormat format )
{
	pCommandList->ResolveSubresource( Take<::ID3D12Resource>( dstResource ), dstSubresource, Take<::ID3D12Resource>( srcResource ), srcSubresource, ( DXGI_FORMAT )format );
}

void CD3D12GraphicsCommandList::IASetPrimitiveTopology( D3DPrimitiveTopology primitiveTopology )
{
	pCommandList->IASetPrimitiveTopology( ( D3D12_PRIMITIVE_TOPOLOGY )primitiveTopology );
}

void CD3D12GraphicsCommandList::RSSetViewports( IList<D3D12Viewport>^ viewports )
{
	std::vector<D3D12_VIEWPORT> viewports_( viewports->Count );
	for ( int i = 0; i < viewports->Count; ++i )
	{
		Assign( viewports_[i], viewports[i] );
	}

	pCommandList->RSSetViewports( ( UINT )viewports->Count, viewports_.data() );
}

void CD3D12GraphicsCommandList::RSSetScissorRects( IList<SC::Engine::Runtime::Core::Numerics::Rectangle>^ rects )
{
	vector<D3D12_RECT> rects_( rects->Count );
	for ( int i = 0; i < rects->Count; ++i )
	{
		Assign( rects_[i], rects[i] );
	}

	pCommandList->RSSetScissorRects( ( UINT )rects->Count, rects_.data() );
}

void CD3D12GraphicsCommandList::OMSetBlendFactor( Vector4 blendFactor )
{
	FLOAT blendFactor_[4] = { (FLOAT)blendFactor.X, (FLOAT)blendFactor.Y, (FLOAT)blendFactor.Z, (FLOAT)blendFactor.W };
	pCommandList->OMSetBlendFactor( blendFactor_ );
}

void CD3D12GraphicsCommandList::OMSetStencilRef( uint_ stencilRef )
{
	pCommandList->OMSetStencilRef( stencilRef );
}

void CD3D12GraphicsCommandList::SetPipelineState( ID3D12PipelineState^ pipelineState )
{
	pCommandList->SetPipelineState( Take<::ID3D12PipelineState>( pipelineState ) );
}

void CD3D12GraphicsCommandList::ResourceBarrier( IList<D3D12ResourceBarrier>^ barriers )
{
	vector<D3D12_RESOURCE_BARRIER> barriers_( barriers->Count );
	for ( int i = 0; i < barriers->Count; ++i )
	{
		Assign( barriers_[i], barriers[i] );
	}

	pCommandList->ResourceBarrier( ( UINT )barriers->Count, barriers_.data() );
}

void CD3D12GraphicsCommandList::ExecuteBundle( ID3D12GraphicsCommandList^ bundleCommandList )
{
	pCommandList->ExecuteBundle( Take<::ID3D12GraphicsCommandList>( bundleCommandList ) );
}

void CD3D12GraphicsCommandList::SetDescriptorHeaps( IList<ID3D12DescriptorHeap^>^ descriptorHeaps )
{
	vector<::ID3D12DescriptorHeap*> descriptorHeaps_( descriptorHeaps->Count );
	for ( int i = 0; i < descriptorHeaps->Count; ++i )
	{
		descriptorHeaps_[i] = Take<::ID3D12DescriptorHeap>( descriptorHeaps[i] );
	}

	pCommandList->SetDescriptorHeaps( ( UINT )descriptorHeaps->Count, descriptorHeaps_.data() );
}

void CD3D12GraphicsCommandList::SetComputeRootSignature( ID3D12RootSignature^ rootSignature )
{
	pCommandList->SetComputeRootSignature( Take<::ID3D12RootSignature>( rootSignature ) );
}

void CD3D12GraphicsCommandList::SetGraphicsRootSignature( ID3D12RootSignature^ rootSignature )
{
	pCommandList->SetGraphicsRootSignature( Take<::ID3D12RootSignature>( rootSignature ) );
}

void CD3D12GraphicsCommandList::SetComputeRootDescriptorTable( uint_ rootParameterIndex, D3D12GPUDescriptorHandle baseDescriptor )
{
	pCommandList->SetComputeRootDescriptorTable( rootParameterIndex, D3D12_GPU_DESCRIPTOR_HANDLE{ baseDescriptor.ptr } );
}

void CD3D12GraphicsCommandList::SetGraphicsRootDescriptorTable( uint_ rootParameterIndex, D3D12GPUDescriptorHandle baseDescriptor )
{
	pCommandList->SetGraphicsRootDescriptorTable( rootParameterIndex, D3D12_GPU_DESCRIPTOR_HANDLE{ baseDescriptor.ptr } );
}

void CD3D12GraphicsCommandList::SetComputeRoot32BitConstant( uint_ rootParameterIndex, uint_ srcData, uint_ destOffsetIn32BitValues )
{
	pCommandList->SetComputeRoot32BitConstant( rootParameterIndex, srcData, destOffsetIn32BitValues );
}

void CD3D12GraphicsCommandList::SetGraphicsRoot32BitConstant( uint_ rootParameterIndex, uint_ srcData, uint_ destOffsetIn32BitValues )
{
	pCommandList->SetGraphicsRoot32BitConstant( rootParameterIndex, srcData, destOffsetIn32BitValues );
}

void CD3D12GraphicsCommandList::SetComputeRoot32BitConstants( uint_ rootParameterIndex, uint_ num32BitValuesToSet, IntPtr pSrcData, uint_ destOffsetIn32BitValues )
{
	pCommandList->SetComputeRoot32BitConstants( rootParameterIndex, num32BitValuesToSet, pSrcData.ToPointer(), destOffsetIn32BitValues );
}

void CD3D12GraphicsCommandList::SetGraphicsRoot32BitConstants( uint_ rootParameterIndex, uint_ num32BitValuesToSet, IntPtr pSrcData, uint_ destOffsetIn32BitValues )
{
	pCommandList->SetGraphicsRoot32BitConstants( rootParameterIndex, num32BitValuesToSet, pSrcData.ToPointer(), destOffsetIn32BitValues );
}

void CD3D12GraphicsCommandList::SetComputeRootConstantBufferView( uint_ rootParameterIndex, ulong_ bufferLocation )
{
	pCommandList->SetComputeRootConstantBufferView( rootParameterIndex, bufferLocation );
}

void CD3D12GraphicsCommandList::SetGraphicsRootConstantBufferView( uint_ rootParameterIndex, ulong_ bufferLocation )
{
	pCommandList->SetGraphicsRootConstantBufferView( rootParameterIndex, bufferLocation );
}

void CD3D12GraphicsCommandList::SetComputeRootShaderResourceView( uint_ rootParameterIndex, ulong_ bufferLocation )
{
	pCommandList->SetComputeRootShaderResourceView( rootParameterIndex, bufferLocation );
}

void CD3D12GraphicsCommandList::SetGraphicsRootShaderResourceView( uint_ rootParameterIndex, ulong_ bufferLocation )
{
	pCommandList->SetGraphicsRootShaderResourceView( rootParameterIndex, bufferLocation );
}

void CD3D12GraphicsCommandList::SetComputeRootUnorderedAccessView( uint_ rootParameterIndex, ulong_ bufferLocation )
{
	pCommandList->SetComputeRootUnorderedAccessView( rootParameterIndex, bufferLocation );
}

void CD3D12GraphicsCommandList::SetGraphicsRootUnorderedAccessView( uint_ rootParameterIndex, ulong_ bufferLocation )
{
	pCommandList->SetGraphicsRootUnorderedAccessView( rootParameterIndex, bufferLocation );
}

void CD3D12GraphicsCommandList::IASetIndexBuffer( Nullable<D3D12IndexBufferView> view )
{
	D3D12_INDEX_BUFFER_VIEW view_;
	if ( view.HasValue ) Assign( view_, view.Value );

	pCommandList->IASetIndexBuffer( view.HasValue ? &view_ : nullptr );
}

void CD3D12GraphicsCommandList::IASetVertexBuffers( uint_ startSlot, IList<D3D12VertexBufferView>^ views )
{
	vector<D3D12_VERTEX_BUFFER_VIEW> views_;
	if ( views != nullptr )
	{
		views_.resize( views->Count );
		for ( int i = 0; i < views->Count; ++i )
		{
			Assign( views_[i], views[i] );
		}
	}

	pCommandList->IASetVertexBuffers( startSlot, ( UINT )( views == nullptr ? 0 : views->Count ), views_.data() );
}

void CD3D12GraphicsCommandList::SOSetTargets( uint_ startSlot, IList<D3D12StreamOutputBufferView>^ views )
{
	vector<D3D12_STREAM_OUTPUT_BUFFER_VIEW> views_;
	if ( views != nullptr )
	{
		views_.resize( views->Count );
		for ( int i = 0; i < views->Count; ++i )
		{
			Assign( views_[i], views[i] );
		}
	}

	pCommandList->SOSetTargets( startSlot, ( UINT )( views == nullptr ? 0 : views->Count ), views_.data() );
}

void CD3D12GraphicsCommandList::OMSetRenderTargets( uint_ numRenderTargetDescriptors, IList<D3D12CPUDescriptorHandle>^ renderTargetDescriptors, Nullable<D3D12CPUDescriptorHandle> depthStencilDescriptor )
{
	vector<D3D12_CPU_DESCRIPTOR_HANDLE> renderTargetDescriptors_;
	
	if ( renderTargetDescriptors != nullptr )
	{
		renderTargetDescriptors_.resize( renderTargetDescriptors->Count );
		for ( int i = 0; i < renderTargetDescriptors->Count; ++i )
		{
			renderTargetDescriptors_[i].ptr = ( SIZE_T )renderTargetDescriptors[i].ptr.ToInt64();
		}
	}

	pCommandList->OMSetRenderTargets(
		numRenderTargetDescriptors,
		renderTargetDescriptors != nullptr ? renderTargetDescriptors_.data() : nullptr,
		FALSE,
		depthStencilDescriptor.HasValue ? &D3D12_CPU_DESCRIPTOR_HANDLE( { ( SIZE_T )depthStencilDescriptor.Value.ptr.ToInt64() } ) : nullptr
	);
}

void CD3D12GraphicsCommandList::OMSetRenderTargets( uint_ numRenderTargetDescriptors, D3D12CPUDescriptorHandle renderTargetDescriptor, Nullable<D3D12CPUDescriptorHandle> depthStencilDescriptor )
{
	pCommandList->OMSetRenderTargets(
		numRenderTargetDescriptors,
		&D3D12_CPU_DESCRIPTOR_HANDLE( { ( SIZE_T )renderTargetDescriptor.ptr.ToInt64() } ),
		TRUE,
		depthStencilDescriptor.HasValue ? &D3D12_CPU_DESCRIPTOR_HANDLE( { ( SIZE_T )depthStencilDescriptor.Value.ptr.ToInt64() } ) : nullptr
	);
}

void CD3D12GraphicsCommandList::ClearDepthStencilView( D3D12CPUDescriptorHandle depthStencilView, D3D12ClearFlags clearFlags, float depth, uint_ stencil, IList<SC::Engine::Runtime::Core::Numerics::Rectangle>^ rects )
{
	vector<D3D12_RECT> rects_;
	if ( rects != nullptr )
	{
		rects_.resize( rects->Count );
		for ( int i = 0; i < rects->Count; ++i )
		{
			Assign( rects_[i], rects[i] );
		}
	}

	pCommandList->ClearDepthStencilView(
		{ ( SIZE_T )depthStencilView.ptr.ToInt64() },
		( D3D12_CLEAR_FLAGS )clearFlags,
		depth,
		stencil,
		( UINT )rects_.size(),
		rects != nullptr ? rects_.data() : nullptr
	);
}

void CD3D12GraphicsCommandList::ClearRenderTargetView( D3D12CPUDescriptorHandle renderTargetView, Color color, IList<SC::Engine::Runtime::Core::Numerics::Rectangle>^ rects )
{
	FLOAT color_[] = { (FLOAT)color.R, (FLOAT)color.G, (FLOAT)color.B, (FLOAT)color.A };

	vector<D3D12_RECT> rects_;
	if ( rects != nullptr )
	{
		rects_.resize( rects->Count );
		for ( int i = 0; i < rects->Count; ++i )
		{
			Assign( rects_[i], rects[i] );
		}
	}

	pCommandList->ClearRenderTargetView(
		{ ( SIZE_T )renderTargetView.ptr.ToInt64() },
		color_,
		( UINT )rects_.size(),
		rects_.size() != 0 ? rects_.data() : nullptr
	);
}

void CD3D12GraphicsCommandList::ClearUnorderedAccessViewUint( D3D12GPUDescriptorHandle viewGPUHandleInCurrentHeap, D3D12CPUDescriptorHandle viewCPUHandle, ID3D12Resource^ resource, D3D12UInt4 values, IList<SC::Engine::Runtime::Core::Numerics::Rectangle>^ rects )
{
	UINT color_[] = { values.X, values.Y, values.Z, values.W };

	vector<D3D12_RECT> rects_;
	if ( rects != nullptr )
	{
		rects_.resize( rects->Count );
		for ( int i = 0; i < rects->Count; ++i )
		{
			Assign( rects_[i], rects[i] );
		}
	}

	pCommandList->ClearUnorderedAccessViewUint(
		{ viewGPUHandleInCurrentHeap.ptr },
		{ ( SIZE_T )viewCPUHandle.ptr.ToInt64() },
		Take<::ID3D12Resource>( resource ),
		color_,
		( UINT )rects_.size(),
		rects != nullptr ? rects_.data() : nullptr
	);
}

void CD3D12GraphicsCommandList::ClearUnorderedAccessViewFloat( D3D12GPUDescriptorHandle viewGPUHandleInCurrentHeap, D3D12CPUDescriptorHandle viewCPUHandle, ID3D12Resource^ resource, Color values, IList<SC::Engine::Runtime::Core::Numerics::Rectangle>^ rects )
{
	FLOAT color_[] = { (FLOAT)values.R, (FLOAT)values.G, (FLOAT)values.B, (FLOAT)values.A };

	vector<D3D12_RECT> rects_;
	if ( rects != nullptr )
	{
		rects_.resize( rects->Count );
		for ( int i = 0; i < rects->Count; ++i )
		{
			Assign( rects_[i], rects[i] );
		}
	}

	pCommandList->ClearUnorderedAccessViewFloat(
		{ viewGPUHandleInCurrentHeap.ptr },
		{ ( SIZE_T )viewCPUHandle.ptr.ToInt64() },
		Take<::ID3D12Resource>( resource ),
		color_,
		( UINT )rects_.size(),
		rects != nullptr ? rects_.data() : nullptr
	);
}

void CD3D12GraphicsCommandList::DiscardResource( ID3D12Resource^ resource, Nullable<D3D12DiscardRegion> region )
{
	D3D12_DISCARD_REGION region_;
	D3D12_DISCARD_REGION* regionp = nullptr;
	if ( region.HasValue )
	{
		Assign( region_, region.Value );
		regionp = &region_;
	}

	pCommandList->DiscardResource( Take<::ID3D12Resource>( resource ), regionp );
}

void CD3D12GraphicsCommandList::BeginQuery( ID3D12QueryHeap^ queryHeap, D3D12QueryType type, uint_ index )
{
	pCommandList->BeginQuery( Take<::ID3D12QueryHeap>( queryHeap ), ( D3D12_QUERY_TYPE )type, index );
}

void CD3D12GraphicsCommandList::EndQuery( ID3D12QueryHeap^ queryHeap, D3D12QueryType type, uint_ index )
{
	pCommandList->EndQuery( Take<::ID3D12QueryHeap>( queryHeap ), ( D3D12_QUERY_TYPE )type, index );
}

void CD3D12GraphicsCommandList::ResolveQueryData( ID3D12QueryHeap^ queryHeap, D3D12QueryType type, uint_ startIndex, uint_ numQueries, ID3D12Resource^ destinationBuffer, ulong_ alignedDestinationBufferOffset )
{
	pCommandList->ResolveQueryData( Take<::ID3D12QueryHeap>( queryHeap ), ( D3D12_QUERY_TYPE )type, startIndex, numQueries, Take<::ID3D12Resource>( destinationBuffer ), alignedDestinationBufferOffset );
}

void CD3D12GraphicsCommandList::SetPredication( ID3D12Resource^ buffer, ulong_ alignedBufferOffset, D3D12PredicationOP operation )
{
	pCommandList->SetPredication( Take<::ID3D12Resource>( buffer ), alignedBufferOffset, ( D3D12_PREDICATION_OP )operation );
}

void CD3D12GraphicsCommandList::ExecuteIndirect( ID3D12CommandSignature^ commandSignature, uint_ maxCommandCount, ID3D12Resource^ argumentBuffer, ulong_ argumentBufferOffset, ID3D12Resource^ countBuffer, ulong_ countBufferOffset )
{
	pCommandList->ExecuteIndirect(
		Take<::ID3D12CommandSignature>( commandSignature ),
		maxCommandCount,
		Take<::ID3D12Resource>( argumentBuffer ),
		argumentBufferOffset,
		Take<::ID3D12Resource>( countBuffer ),
		countBufferOffset
	);
}

auto CD3D12GraphicsCommandList::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD3D12GraphicsCommandList( ( ::ID3D12GraphicsCommandList* )pUnknown.ToPointer() );
}
