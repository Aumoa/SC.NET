// Copyright 2020 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;

using System;
using System.Runtime.InteropServices;

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// <see cref="ID3D12GraphicsCommandList"/> 인터페이스 개체에 대한 확장 메서드를 제공합니다.
    /// </summary>
    public static class ID3D12GraphicsCommandListExtensions
	{
		[StructLayout( LayoutKind.Explicit )]
		struct ReinterpretCast
		{
			[FieldOffset( 0 )]
			public int SourceN;

			[FieldOffset( 0 )]
			public float SourceF;

			[FieldOffset( 0 )]
			public uint Dest;
		}

		/// <summary>
		/// <paramref name="srcBuffer"/> 자원의 데이터를 <paramref name="dstBuffer"/> 자원으로 GPU 차원에서 단순 복사를 수행합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="dstBuffer"> 복사 대상 자원을 전달합니다. </param>
		/// <param name="srcBuffer"> 복사 원본 자원을 전달합니다. </param>
		public static void CopyBufferRegion( this ID3D12GraphicsCommandList @this, ID3D12Resource dstBuffer, ID3D12Resource srcBuffer )
		{
			var dstInfo = dstBuffer.GetDesc();
			var srcInfo = srcBuffer.GetDesc();

			ulong minWidth = Math.Min( dstInfo.Width, srcInfo.Width );

			@this.CopyBufferRegion( dstBuffer, 0, srcBuffer, 0, minWidth );
		}

		/// <summary>
		/// 멀티 샘플 리소스를 일반 리소스에 복사합니다. 서브리소스 인덱스는 0번이며, 자원의 형식은 대상 일반 리소스의 형식을 참조합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="dstResource"> 대상 일반 리소스를 전달합니다. </param>
		/// <param name="srcResource"> 원본 멀티 샘플 리소스를 전달합니다. </param>
		public static void ResolveSubresource( this ID3D12GraphicsCommandList @this, ID3D12Resource dstResource, ID3D12Resource srcResource )
			=> @this.ResolveSubresource( dstResource, 0, srcResource, 0, dstResource.GetDesc().Format );

		/// <summary>
		/// 뷰포트를 설정합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="viewports"> 뷰포트 목록을 전달합니다. </param>
		public static void RSSetViewports( this ID3D12GraphicsCommandList @this, params D3D12Viewport[] viewports )
			=> @this.RSSetViewports( viewports );

		/// <summary>
		/// 절단 영역을 설정합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="rects"> 절단 영역 목록을 전달합니다. </param>
		public static void RSSetScissorRects( this ID3D12GraphicsCommandList @this, params Rectangle[] rects )
			=> @this.RSSetScissorRects( rects );

		/// <summary>
		/// 자원 상태 장벽을 설정합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="barriers"> 자원 상태 장벽 목록을 전달합니다. </param>
		public static void ResourceBarrier( this ID3D12GraphicsCommandList @this, params D3D12ResourceBarrier[] barriers )
			=> @this.ResourceBarrier( barriers );

		/// <summary>
		/// 서술자 힙 개체를 설정합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="descriptorHeaps"></param>
		public static void SetDescriptorHeaps( this ID3D12GraphicsCommandList @this, params ID3D12DescriptorHeap[] descriptorHeaps )
			=> @this.SetDescriptorHeaps( descriptorHeaps );

		/// <summary>
		/// 32비트 컴퓨트 루트 서명 값을 설정합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="rootParameterIndex"> 매개변수 인덱스를 전달합니다. </param>
		/// <param name="srcData"> 설정할 값을 전달합니다. </param>
		/// <param name="destOffsetIn32BitValues"> 값을 복사할 대상 바이트 위치를 전달합니다. </param>
		public static void SetComputeRoot32BitConstant( this ID3D12GraphicsCommandList @this, uint rootParameterIndex, float srcData, uint destOffsetIn32BitValues )
		{
			var cast = new ReinterpretCast();
			cast.SourceF = srcData;
			@this.SetComputeRoot32BitConstant( rootParameterIndex, cast.Dest, destOffsetIn32BitValues );
		}

		/// <summary>
		/// 32비트 컴퓨트 루트 서명 값을 설정합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="rootParameterIndex"> 매개변수 인덱스를 전달합니다. </param>
		/// <param name="srcData"> 설정할 값을 전달합니다. </param>
		/// <param name="destOffsetIn32BitValues"> 값을 복사할 대상 바이트 위치를 전달합니다. </param>
		public static void SetComputeRoot32BitConstant( this ID3D12GraphicsCommandList @this, uint rootParameterIndex, int srcData, uint destOffsetIn32BitValues )
		{
			var cast = new ReinterpretCast();
			cast.SourceN = srcData;
			@this.SetComputeRoot32BitConstant( rootParameterIndex, cast.Dest, destOffsetIn32BitValues );
		}

		/// <summary>
		/// 32비트 그래픽 루트 서명 값을 설정합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="rootParameterIndex"> 매개변수 인덱스를 전달합니다. </param>
		/// <param name="srcData"> 설정할 값을 전달합니다. </param>
		/// <param name="destOffsetIn32BitValues"> 값을 복사할 대상 바이트 위치를 전달합니다. </param>
		public static void SetGraphicsRoot32BitConstant( this ID3D12GraphicsCommandList @this, uint rootParameterIndex, float srcData, uint destOffsetIn32BitValues )
		{
			var cast = new ReinterpretCast();
			cast.SourceF = srcData;
			@this.SetGraphicsRoot32BitConstant( rootParameterIndex, cast.Dest, destOffsetIn32BitValues );
		}

		/// <summary>
		/// 32비트 그래픽 루트 서명 값을 설정합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="rootParameterIndex"> 매개변수 인덱스를 전달합니다. </param>
		/// <param name="srcData"> 설정할 값을 전달합니다. </param>
		/// <param name="destOffsetIn32BitValues"> 값을 복사할 대상 바이트 위치를 전달합니다. </param>
		public static void SetGraphicsRoot32BitConstant( this ID3D12GraphicsCommandList @this, uint rootParameterIndex, int srcData, uint destOffsetIn32BitValues )
		{
			var cast = new ReinterpretCast();
			cast.SourceN = srcData;
			@this.SetGraphicsRoot32BitConstant( rootParameterIndex, cast.Dest, destOffsetIn32BitValues );
		}

		/// <summary>
		/// 32비트 컴퓨트 루트 서명 값을 설정합니다.
		/// </summary>
		/// <typeparam name="T"> 설정할 값의 형식을 전달합니다. </typeparam>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="rootParameterIndex"> 매개변수 인덱스를 전달합니다. </param>
		/// <param name="srcData"> 설정할 값을 전달합니다. </param>
		/// <param name="destOffsetIn32BitValues"> 값을 복사할 대상 바이트 위치를 전달합니다. </param>
		public static unsafe void SetComputeRoot32BitConstants<T>( this ID3D12GraphicsCommandList @this, uint rootParameterIndex, T srcData, uint destOffsetIn32BitValues ) where T : unmanaged
		{
			uint size = ( uint )sizeof( T );
			uint num32BitValues = ( size - 1 ) / 4 + 1;
			@this.SetComputeRoot32BitConstants( rootParameterIndex, num32BitValues, new IntPtr( &srcData ), destOffsetIn32BitValues );
		}

		/// <summary>
		/// 32비트 그래픽 루트 서명 값을 설정합니다.
		/// </summary>
		/// <typeparam name="T"> 설정할 값의 형식을 전달합니다. </typeparam>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="rootParameterIndex"> 매개변수 인덱스를 전달합니다. </param>
		/// <param name="srcData"> 설정할 값을 전달합니다. </param>
		/// <param name="destOffsetIn32BitValues"> 값을 복사할 대상 바이트 위치를 전달합니다. </param>
		public static unsafe void SetGraphicsRoot32BitConstants<T>( this ID3D12GraphicsCommandList @this, uint rootParameterIndex, T srcData, uint destOffsetIn32BitValues ) where T : unmanaged
		{
			uint size = ( uint )sizeof( T );
			uint num32BitValues = ( size - 1 ) / 4 + 1;
			@this.SetGraphicsRoot32BitConstants( rootParameterIndex, num32BitValues, new IntPtr( &srcData ), destOffsetIn32BitValues );
		}

		/// <summary>
		/// 정점 버퍼 서술 정보를 설정합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="startSlot"> 설정할 슬롯 인덱스를 전달합니다. </param>
		/// <param name="views"> 서술 정보 구조체 목록을 전달합니다. </param>
		public static void IASetVertexBuffers( this ID3D12GraphicsCommandList @this, uint startSlot, params D3D12VertexBufferView[] views )
			=> @this.IASetVertexBuffers( startSlot, views );

		/// <summary>
		/// 스트림 출력 서술 정보를 설정합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="startSlot"> 설정할 슬롯 인덱스를 전달합니다. </param>
		/// <param name="views"> 서술 정보 구조체 목록을 전달합니다. </param>
		public static void SOSetTargets( this ID3D12GraphicsCommandList @this, uint startSlot, params D3D12StreamOutputBufferView[] views )
			=> @this.SOSetTargets( startSlot, views );

		/// <summary>
		/// 깊이 스텐실 텍스처를 초기화합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="depthStencilView"> 깊이 스텐실 서술자를 전달합니다. </param>
		/// <param name="clearFlags"> 초기화 플래그를 전달합니다. </param>
		/// <param name="depth"> 초기화 깊이 값을 전달합니다. </param>
		/// <param name="stencil"> 초기화 스텐실 값을 전달합니다. </param>
		/// <param name="rects"> 초기화 영역 목록을 전달합니다. </param>
		public static void ClearDepthStencilView( this ID3D12GraphicsCommandList @this, D3D12CPUDescriptorHandle depthStencilView, D3D12ClearFlags clearFlags, float depth, uint stencil, params Rectangle[] rects )
			=> @this.ClearDepthStencilView( depthStencilView, clearFlags, depth, stencil, rects );

		/// <summary>
		/// 깊이 스텐실 텍스처의 깊이를 초기화합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="depthStencilView"> 깊이 스텐실 서술자를 전달합니다. </param>
		/// <param name="depth"> 초기화 깊이 값을 전달합니다. </param>
		/// <param name="rects"> 초기화 영역 목록을 전달합니다. </param>
		public static void ClearDepthStencilView( this ID3D12GraphicsCommandList @this, D3D12CPUDescriptorHandle depthStencilView, float depth, params Rectangle[] rects )
			=> @this.ClearDepthStencilView( depthStencilView, D3D12ClearFlags.Depth, depth, 0, rects );

		/// <summary>
		/// 깊이 스텐실 텍스처의 스텐실을 초기화합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="depthStencilView"> 깊이 스텐실 서술자를 전달합니다. </param>
		/// <param name="stencil"> 초기화 스텐실 값을 전달합니다. </param>
		/// <param name="rects"> 초기화 영역 목록을 전달합니다. </param>
		public static void ClearDepthStencilView( this ID3D12GraphicsCommandList @this, D3D12CPUDescriptorHandle depthStencilView, uint stencil, params Rectangle[] rects )
			=> @this.ClearDepthStencilView( depthStencilView, D3D12ClearFlags.Stencil, 1.0f, stencil, rects );

		/// <summary>
		/// 렌더 타겟 텍스처를 초기화합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="renderTargetView"> 렌더 타겟 서술자를 전달합니다. </param>
		/// <param name="color"> 초기화 색상 값을 전달합니다. </param>
		/// <param name="rects"> 초기화 영역 목록을 전달합니다. </param>>
		public static void ClearRenderTargetView( this ID3D12GraphicsCommandList @this, D3D12CPUDescriptorHandle renderTargetView, Color color, params Rectangle[] rects )
			=> @this.ClearRenderTargetView( renderTargetView, color, rects );

		/// <summary>
		/// 순서없는 접근 텍스처를 초기화합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="viewGPUHandleInCurrentHeap"> 서술자의 GPU 핸들을 전달합니다. 서술자 힙이 <see cref="ID3D12GraphicsCommandList.SetDescriptorHeaps(System.Collections.Generic.IList{ID3D12DescriptorHeap})"/> 메서드로 선택되어 있어야 합니다. </param>
		/// <param name="viewCPUHandle"> 서술자의 CPU 핸들을 전달합니다. </param>
		/// <param name="resource"> 자원을 전달합니다. </param>
		/// <param name="values"> 초기화 값을 전달합니다. </param>
		/// <param name="rects"> 초기화 영역 목록을 전달합니다. </param>
		public static void ClearUnorderedAccessViewUint( this ID3D12GraphicsCommandList @this, D3D12GPUDescriptorHandle viewGPUHandleInCurrentHeap, D3D12CPUDescriptorHandle viewCPUHandle, ID3D12Resource resource, D3D12UInt4 values, params Rectangle[] rects )
			=> @this.ClearUnorderedAccessViewUint( viewGPUHandleInCurrentHeap, viewCPUHandle, resource, values, rects );

		/// <summary>
		/// 순서없는 접근 텍스처를 초기화합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="viewGPUHandleInCurrentHeap"> 서술자의 GPU 핸들을 전달합니다. 서술자 힙이 <see cref="ID3D12GraphicsCommandList.SetDescriptorHeaps(System.Collections.Generic.IList{ID3D12DescriptorHeap})"/> 메서드로 선택되어 있어야 합니다. </param>
		/// <param name="viewCPUHandle"> 서술자의 CPU 핸들을 전달합니다. </param>
		/// <param name="resource"> 자원을 전달합니다. </param>
		/// <param name="values"> 초기화 값을 전달합니다. </param>
		/// <param name="rects"> 초기화 영역 목록을 전달합니다. </param>
		public static void ClearUnorderedAccessViewFloat( this ID3D12GraphicsCommandList @this, D3D12GPUDescriptorHandle viewGPUHandleInCurrentHeap, D3D12CPUDescriptorHandle viewCPUHandle, ID3D12Resource resource, Color values, params Rectangle[] rects )
			=> @this.ClearUnorderedAccessViewFloat( viewGPUHandleInCurrentHeap, viewCPUHandle, resource, values, rects );

		/// <summary>
		/// 자원 상태 전이 장벽을 설정합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="resource"> 대상 자원 개체를 전달합니다. </param>
		/// <param name="stateBefore"> 이전 상태를 전달합니다. </param>
		/// <param name="stateAfter"> 이후 상태를 전달합니다. </param>
		/// <param name="subresource"> 서브리소스 인덱스를 전달합니다. </param>
		public static void TransitionBarrier( this ID3D12GraphicsCommandList @this, ID3D12Resource resource, D3D12ResourceStates stateBefore, D3D12ResourceStates stateAfter, uint subresource )
			=> @this.ResourceBarrier( new D3D12ResourceBarrier(
				new D3D12ResourceTransitionBarrier
				{
					pResource = resource,
					StateBefore = stateBefore,
					StateAfter = stateAfter,
					Subresource = subresource
				} ) );

		/// <summary>
		/// <paramref name="srcBuffer"/> 자원의 데이터를 <paramref name="dstBuffer"/> 자원으로 GPU 차원에서 전송합니다.
		/// </summary>
		/// <param name="this"> 개체를 전달합니다. </param>
		/// <param name="dstBuffer"> 복사 대상 자원을 전달합니다. </param>
		/// <param name="srcBuffer"> 복사 원본 자원을 전달합니다. </param>
		/// <param name="numBytes"> 복사 바이트 단위 크기를 전달합니다. </param>
		public static void CopyBufferRegion( this ID3D12GraphicsCommandList @this, ID3D12Resource dstBuffer, ID3D12Resource srcBuffer, ulong numBytes )
			=> @this.CopyBufferRegion( dstBuffer, 0, srcBuffer, 0, numBytes );
	}
}
