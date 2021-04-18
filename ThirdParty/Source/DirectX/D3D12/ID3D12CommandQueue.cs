// Copyright 2020 Aumoa.lib. All right reserved.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 명령 대기열 개체에 대한 공통 메서드를 제공합니다.
    /// </summary>
    [Guid( "0EC870A6-5D7E-4C22-8CFC-5BAAE07616ED" )]
	[ComVisible( true )]
	public interface ID3D12CommandQueue : ID3D12Pageable
	{
		/// <summary>
		/// 예약된 리소스의 타일 위치를 리소스 힙의 메모리 위치로 업데이트합니다.
		/// </summary>
		/// <param name="resource"> 예약된 자원을 전달합니다. </param>
		/// <param name="resourceRegionStartCoordinates"> 예약된 자원의 시작 위치 목록을 전달합니다. </param>
		/// <param name="resourceRegionSizes"> 예약된 자원의 크기 목록을 전달합니다. </param>
		/// <param name="heap"> 리소스 힙을 전달합니다. </param>
		/// <param name="rangeFlags"> 각 타일의 범위 속성을 전달합니다. </param>
		/// <param name="heapRangeStartOffsets"> 각 타일의 범위에 맞는 시작 위치를 전달합니다. 바이트 단위를 의미하지 않습니다. </param>
		/// <param name="rangeTileCounts"> 범위 타일 개수 목록을 전달합니다. </param>
		/// <param name="flags"> 타일 매핑 속성을 전달합니다. </param>
		void UpdateTileMappings(
			ID3D12Resource resource,
			IList<D3D12TiledResourceCoordinate> resourceRegionStartCoordinates,
			IList<D3D12TileRegionSize> resourceRegionSizes,
			ID3D12Heap heap,
			IList<D3D12TileRangeFlags> rangeFlags,
			IList<uint> heapRangeStartOffsets,
			IList<uint> rangeTileCounts,
			D3D12TileMappingFlags flags
			);

		/// <summary>
		/// 원본 예약 리소스에서 대상 예약 리소스로 복사합니다.
		/// </summary>
		/// <param name="dstResource"> 대상 예약 리소스를 전달합니다. </param>
		/// <param name="dstRegionStartCoordinate"> 대상 예약 리소스의 시작 좌표를 전달합니다. </param>
		/// <param name="srcResource"> 원본 예약 리소스를 전달합니다. </param>
		/// <param name="srcRegionStartCoordinate"> 원본 예약 리소스의 시작 좌표를 전달합니다. </param>
		/// <param name="regionSize"> 예약된 영역의 크기를 전달합니다. </param>
		/// <param name="flags"> 타일 매핑 속성을 전달합니다. </param>
		void CopyTileMappings(
			ID3D12Resource dstResource,
			D3D12TiledResourceCoordinate dstRegionStartCoordinate,
			ID3D12Resource srcResource,
			D3D12TiledResourceCoordinate srcRegionStartCoordinate,
			D3D12TileRegionSize regionSize,
			D3D12TileMappingFlags flags
			);

		/// <summary>
		/// 명령 목록을 이 대기열에서 실행합니다.
		/// </summary>
		/// <param name="commandLists"> 명령 목록 목록을 전달합니다. </param>
		void ExecuteCommandLists( IList<ID3D12CommandList> commandLists );

		/// <summary>
		/// 명령 대기열에 신호 명령을 추가합니다. 신호 명령이 실행될 경우 대상 펜스는 지정한 값으로 설정됩니다.
		/// </summary>
		/// <param name="fence"> 펜스 개체를 전달합니다. </param>
		/// <param name="value"> 설정할 값을 전달합니다. </param>
		void Signal( ID3D12Fence fence, ulong value );

		/// <summary>
		/// 명령 대기열에 대기 명령을 추가합니다. 대기 명령이 실행될 경우 대상 펜스의 값이 지정한 값으로 될 때까지 GPU는 대기합니다.
		/// </summary>
		/// <param name="fence"> 펜스 개체를 전달합니다. </param>
		/// <param name="value"> 설정할 값을 전달합니다. </param>
		void Wait( ID3D12Fence fence, ulong value );

		/// <summary>
		/// GPU 시간 측정 주파수를 가져옵니다.
		/// </summary>
		/// <returns> 주파수 값이 반환됩니다. </returns>
		ulong GetTimestampFrequency();

		/// <summary>
		/// CPU 시간 및 GPU 시간을 동시에 측정합니다.
		/// </summary>
		/// <param name="gpuTimestamp"> GPU 시간을 받을 변수의 참조를 전달합니다. </param>
		/// <param name="cpuTimestamp"> CPU 시간을 받을 변수의 참조를 전달합니다. </param>
		void GetClockCalibration( out ulong gpuTimestamp, out ulong cpuTimestamp );

		/// <summary>
		/// 명령 대기열의 정보를 서술하는 구조체를 가져옵니다.
		/// </summary>
		/// <returns> 서술 구조체가 반환됩니다. </returns>
		D3D12CommandQueueDesc GetDesc();
	}
}
