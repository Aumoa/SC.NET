// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3D12CommandQueue : CD3D12Pageable, ID3D12CommandQueue
	{
		::ID3D12CommandQueue* pCommandQueue;

	public:
		CD3D12CommandQueue( ::ID3D12CommandQueue* pCommandQueue );
		static void RegisterClass();

		virtual void UpdateTileMappings(
			ID3D12Resource^ resource,
			System::Collections::Generic::IList<D3D12TiledResourceCoordinate>^ resourceRegionStartCoordinates,
			System::Collections::Generic::IList<D3D12TileRegionSize>^ resourceRegionSizes,
			ID3D12Heap^ heap,
			System::Collections::Generic::IList<D3D12TileRangeFlags>^ rangeFlags,
			System::Collections::Generic::IList<unsigned int>^ heapRangeStartOffsets,
			System::Collections::Generic::IList<unsigned int>^ rangeTileCounts,
			D3D12TileMappingFlags flags
		);
		virtual void CopyTileMappings(
			ID3D12Resource^ dstResource,
			D3D12TiledResourceCoordinate dstRegionStartCoordinate,
			ID3D12Resource^ srcResource,
			D3D12TiledResourceCoordinate srcRegionStartCoordinate,
			D3D12TileRegionSize regionSize,
			D3D12TileMappingFlags flags
		);
		virtual void ExecuteCommandLists( System::Collections::Generic::IList<ID3D12CommandList^>^ commandLists );
		virtual void Signal( ID3D12Fence^ fence, unsigned long long value );
		virtual void Wait( ID3D12Fence^ fence, unsigned long long value );
		virtual unsigned long long GetTimestampFrequency();
		virtual void GetClockCalibration( unsigned long long% gpuTimestamp, unsigned long long% cpuTimestamp );
		virtual D3D12CommandQueueDesc GetDesc();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}