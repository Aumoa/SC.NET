// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3D12Device : CD3D12Object, ID3D12Device
	{
		::ID3D12Device* pDevice;

	public:
		CD3D12Device( ::ID3D12Device* pDevice );
		static void RegisterClass();

		virtual unsigned int GetNodeCount();
		virtual void CreateCommandQueue( D3D12CommandQueueDesc desc, System::Guid riid, IUnknown^% ppCommandQueue );
		virtual void CreateCommandAllocator( D3D12CommandListType type, System::Guid riid, IUnknown^% ppCommandAllocator );
		virtual void CreateGraphicsPipelineState( D3D12GraphicsPipelineStateDesc desc, System::Guid riid, IUnknown^% ppPipelineState );
		virtual void CreateComputePipelineState( D3D12ComputePipelineStateDesc desc, System::Guid riid, IUnknown^% ppPipelineState );
		virtual void CreateCommandList( unsigned int nodeMask, D3D12CommandListType type, ID3D12CommandAllocator^ pCommandAllocator, ID3D12PipelineState^ pInitialPipelineState, System::Guid riid, IUnknown^% ppCommandList );
		virtual void CheckFeatureSupport( System::ValueType^% pFeatureSupportData );
		virtual void CreateDescriptorHeap( D3D12DescriptorHeapDesc descriptorHeapDesc, System::Guid riid, IUnknown^% ppHeap );
		virtual unsigned int GetDescriptorHandleIncrementSize( D3D12DescriptorHeapType descriptorHeapType );
		virtual void CreateRootSignature( unsigned int nodeMask, System::IntPtr pBlobWithRootSignature, unsigned long long blobLengthInBytes, System::Guid riid, IUnknown^% ppRootSignature );
		virtual void CreateConstantBufferView( D3D12ConstantBufferViewDesc desc, D3D12CPUDescriptorHandle handle );
		virtual void CreateShaderResourceView( ID3D12Resource^ pResource, System::Nullable<D3D12ShaderResourceViewDesc> desc, D3D12CPUDescriptorHandle handle );
		virtual void CreateUnorderedAccessView( ID3D12Resource^ pResource, ID3D12Resource^ pCounterResource, System::Nullable<D3D12UnorderedAccessViewDesc> desc, D3D12CPUDescriptorHandle handle );
		virtual void CreateRenderTargetView( ID3D12Resource^ pResource, System::Nullable<D3D12RenderTargetViewDesc> desc, D3D12CPUDescriptorHandle handle );
		virtual void CreateDepthStencilView( ID3D12Resource^ pResource, System::Nullable<D3D12DepthStencilViewDesc> desc, D3D12CPUDescriptorHandle handle );
		virtual void CreateSampler( D3D12SamplerDesc desc, D3D12CPUDescriptorHandle handle );
		virtual void CopyDescriptors(
			System::Collections::Generic::IList<D3D12CPUDescriptorHandle>^ destDescriptorRangeStarts, 
			System::Collections::Generic::IList<unsigned int>^ destDescriptorRangeSizes, 
			System::Collections::Generic::IList<D3D12CPUDescriptorHandle>^ srcDescriptorRangeStarts, 
			System::Collections::Generic::IList<unsigned int>^ srcDescriptorRangeSizes,
			D3D12DescriptorHeapType descriptorHeapType
		);
		virtual void CopyDescriptorsSimple( unsigned int numDescriptors,
			D3D12CPUDescriptorHandle destDescriptorRangeStart, 
			D3D12CPUDescriptorHandle srcDescriptorRangeStart,
			D3D12DescriptorHeapType descriptorHeapsType
		);
		virtual D3D12ResourceAllocationInfo GetResourceAllocationInfo(
			unsigned int visibleMask,
			System::Collections::Generic::IList<D3D12ResourceDesc>^ resourceDescs 
		);
		virtual D3D12HeapProperties GetCustomHeapProperties( unsigned int nodeMask, D3D12HeapType heapType );
		virtual void CreateCommittedResource( D3D12HeapProperties heapProperties, D3D12HeapFlags heapFlags, D3D12ResourceDesc desc, D3D12ResourceStates initialResourceState, System::Nullable<D3D12ClearValue> optimizedClearValue, System::Guid riid, IUnknown^% ppResource );
		virtual void CreateHeap( D3D12HeapDesc desc, System::Guid riid, IUnknown^% ppHeap );
		virtual void CreatePlacedResource(
			ID3D12Heap^ pHeap,
			unsigned long long heapOffset,
			D3D12ResourceDesc desc,
			D3D12ResourceStates initialResourceState,
			System::Nullable<D3D12ClearValue> optimizedClearValue,
			System::Guid riid,
			IUnknown^% ppResource
		);
		virtual void CreateReservedResource(
			D3D12ResourceDesc desc,
			D3D12ResourceStates initialResourceState,
			System::Nullable<D3D12ClearValue> optimizedClearValue,
			System::Guid riid, IUnknown^% ppResource
		);
		virtual WinAPI::IPlatformHandle^ CreateSharedHandle( ID3D12DeviceChild^ pObject, System::IntPtr pAttributes, WinAPI::GenericAccess access, System::String^ name );
		virtual void OpenSharedHandle(WinAPI::IPlatformHandle^ ntHandle, System::Guid riid, IUnknown^% ppObject );
		virtual WinAPI::IPlatformHandle^ OpenSharedHandleByName( System::String^ name, WinAPI::GenericAccess access );
		virtual void MakeResident( System::Collections::Generic::IList<ID3D12Pageable^>^ ppObjects );
		virtual void Evict( System::Collections::Generic::IList<ID3D12Pageable^>^ ppObjects );
		virtual void CreateFence( unsigned long long initialValue, D3D12FenceFlags flags, System::Guid riid, IUnknown^% ppFence );
		virtual cli::array<D3D12PlacedSubresourceFootprint>^ GetCopyableFootprints(
			D3D12ResourceDesc resourceDesc,
			unsigned int firstSubresource,
			unsigned int numSubresources,
			unsigned long long baseOffset,
			cli::array<unsigned int>^% numRows,
			cli::array<unsigned long long>^% rowSizeInBytes,
			unsigned long long% totalBytes
		);
		virtual void CreateQueryHeap( D3D12QueryHeapDesc desc, System::Guid riid, IUnknown^% ppHeap );
		virtual void SetStablePowerState( bool enable );
		virtual void CreateCommandSignature( D3D12CommandSignatureDesc desc, ID3D12RootSignature^ pRootSignature, System::Guid riid, IUnknown^% ppCommandSignature );
		virtual cli::array<D3D12SubresourceTiling>^ GetResourceTiling(
			ID3D12Resource^ pTiledResource,
			uint_% numTilesForEntireResource,
			D3D12PackedMipInfo% packedMipDesc,
			D3D12TileShape% standardTileShapeForNonPackedMips,
			uint_ firstSubresourceTilingToGet
		);
		virtual Luid GetAdapterLuid();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}