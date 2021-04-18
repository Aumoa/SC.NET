// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::ThirdParty::DirectX;

using namespace System;
using namespace System::Collections::Generic;

using namespace std;

CD3D12CommandQueue::CD3D12CommandQueue( ::ID3D12CommandQueue* pCommandQueue ) : CD3D12Pageable( pCommandQueue )
{
	this->pCommandQueue = pCommandQueue;
}

void CD3D12CommandQueue::RegisterClass()
{
	RegisterCLSID( ID3D12CommandQueue::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

void CD3D12CommandQueue::UpdateTileMappings(
	ID3D12Resource^ resource,
	IList<D3D12TiledResourceCoordinate>^ resourceRegionStartCoordinates,
	IList<D3D12TileRegionSize>^ resourceRegionSizes,
	ID3D12Heap^ heap,
	IList<D3D12TileRangeFlags>^ rangeFlags,
	IList<unsigned int>^ heapRangeStartOffsets,
	IList<unsigned int>^ rangeTileCounts,
	D3D12TileMappingFlags flags
)
{
	vector<D3D12_TILED_RESOURCE_COORDINATE> resourceRegionStartCoordinates_;
	if ( resourceRegionStartCoordinates != nullptr ) resourceRegionStartCoordinates_.resize( resourceRegionStartCoordinates->Count );
	vector<D3D12_TILE_REGION_SIZE> resourceRegionSizes_;
	if ( resourceRegionSizes != nullptr ) resourceRegionSizes_.resize( resourceRegionSizes->Count );
	::ID3D12Heap* heap_ = ( heap != nullptr ) ? Take<::ID3D12Heap>( heap ) : nullptr;
	vector<D3D12_TILE_RANGE_FLAGS> rangeFlags_;
	if ( rangeFlags != nullptr ) rangeFlags_.resize( rangeFlags->Count );
	vector<UINT> heapRangeStartOffsets_;
	if ( heapRangeStartOffsets != nullptr ) heapRangeStartOffsets_.resize( heapRangeStartOffsets->Count );
	vector<UINT> rangeTileCounts_;
	if ( rangeTileCounts != nullptr ) rangeTileCounts_.resize( rangeTileCounts->Count );

	for ( int i = 0; i < ( int )resourceRegionStartCoordinates_.size(); ++i )
	{
		Assign( resourceRegionStartCoordinates_[i], resourceRegionStartCoordinates[i] );
	}

	for ( int i = 0; i < ( int )resourceRegionSizes_.size(); ++i )
	{
		Assign( resourceRegionSizes_[i], resourceRegionSizes[i] );
	}

	for ( int i = 0; i < ( int )rangeFlags_.size(); ++i )
	{
		rangeFlags_[i] = ( D3D12_TILE_RANGE_FLAGS )rangeFlags[i];
	}

	for ( int i = 0; i < ( int )heapRangeStartOffsets_.size(); ++i )
	{
		heapRangeStartOffsets_[i] = ( UINT )heapRangeStartOffsets[i];
	}

	for ( int i = 0; i < ( int )rangeTileCounts_.size(); ++i )
	{
		rangeTileCounts_[i] = ( UINT )rangeTileCounts[i];
	}

	pCommandQueue->UpdateTileMappings(
		Take<::ID3D12Resource>( resource ),
		( UINT )resourceRegionStartCoordinates_.size(),
		resourceRegionStartCoordinates != nullptr ? resourceRegionStartCoordinates_.data() : nullptr,
		resourceRegionSizes != nullptr ? resourceRegionSizes_.data() : nullptr,
		heap != nullptr ? Take<::ID3D12Heap>( heap ) : nullptr,
		( UINT )rangeFlags_.size(),
		rangeFlags != nullptr ? rangeFlags_.data() : nullptr,
		heapRangeStartOffsets != nullptr ? heapRangeStartOffsets_.data() : nullptr,
		rangeTileCounts != nullptr ? rangeTileCounts_.data() : nullptr,
		( D3D12_TILE_MAPPING_FLAGS )flags
	);
}

void CD3D12CommandQueue::CopyTileMappings(
	ID3D12Resource^ dstResource,
	D3D12TiledResourceCoordinate dstRegionStartCoordinate,
	ID3D12Resource^ srcResource,
	D3D12TiledResourceCoordinate srcRegionStartCoordinate,
	D3D12TileRegionSize regionSize,
	D3D12TileMappingFlags flags
)
{
	D3D12_TILED_RESOURCE_COORDINATE dstRegionStartCoordinate_;
	D3D12_TILED_RESOURCE_COORDINATE srcRegionStartCoordinate_;
	D3D12_TILE_REGION_SIZE regionSize_;

	Assign( dstRegionStartCoordinate_, dstRegionStartCoordinate );
	Assign( srcRegionStartCoordinate_, srcRegionStartCoordinate );
	Assign( regionSize_, regionSize );

	pCommandQueue->CopyTileMappings(
		Take<::ID3D12Resource>( dstResource ),
		&dstRegionStartCoordinate_,
		Take<::ID3D12Resource>( srcResource ),
		&srcRegionStartCoordinate_,
		&regionSize_,
		( D3D12_TILE_MAPPING_FLAGS )flags
	);
}

void CD3D12CommandQueue::ExecuteCommandLists( IList<ID3D12CommandList^>^ commandLists )
{
	vector<::ID3D12CommandList*> commandLists_( commandLists->Count );

	for ( int i = 0; i < commandLists->Count; ++i )
	{
		commandLists_[i] = Take<::ID3D12CommandList>( commandLists[i] );
	}

	pCommandQueue->ExecuteCommandLists( ( UINT )commandLists_.size(), commandLists_.data() );
}

void CD3D12CommandQueue::Signal( ID3D12Fence^ fence, unsigned long long value )
{
	HR( pCommandQueue->Signal( Take<::ID3D12Fence>( fence ), value ) );
}

void CD3D12CommandQueue::Wait( ID3D12Fence^ fence, unsigned long long value )
{
	HR( pCommandQueue->Wait( Take<::ID3D12Fence>( fence ), value ) );
}

unsigned long long CD3D12CommandQueue::GetTimestampFrequency()
{
	UINT64 freq;
	HR( pCommandQueue->GetTimestampFrequency( &freq ) );
	return freq;
}

void CD3D12CommandQueue::GetClockCalibration( unsigned long long% gpuTimestamp, unsigned long long% cpuTimestamp )
{
	UINT64 g, c;
	HR( pCommandQueue->GetClockCalibration( &g, &c ) );
	gpuTimestamp = g;
	cpuTimestamp = c;
}

D3D12CommandQueueDesc CD3D12CommandQueue::GetDesc()
{
	D3D12CommandQueueDesc left;
	Assign( left, pCommandQueue->GetDesc() );
	return left;
}

auto CD3D12CommandQueue::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD3D12CommandQueue( ( ::ID3D12CommandQueue* )pUnknown.ToPointer() );
}