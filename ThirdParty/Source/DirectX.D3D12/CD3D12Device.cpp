// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::ThirdParty::WinAPI;

using namespace System;
using namespace System::Collections::Generic;

using namespace std;

using SC::ThirdParty::DirectX::CD3D12Device;

CD3D12Device::CD3D12Device( ::ID3D12Device1* pDevice ) : CD3D12Object( pDevice )
{
	this->pDevice = pDevice;
}

void CD3D12Device::RegisterClass()
{
	RegisterCLSID( ID3D12Device::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

unsigned int CD3D12Device::GetNodeCount()
{
	return pDevice->GetNodeCount();
}

void CD3D12Device::CreateCommandQueue( D3D12CommandQueueDesc desc, Guid riid, IUnknown^% ppCommandQueue )
{
	D3D12_COMMAND_QUEUE_DESC desc_;
	Assign( desc_, desc );

	ComPtr<::IUnknown> pUnknown;
	HR( pDevice->CreateCommandQueue( &desc_, ToGUID( riid ), &pUnknown ) );

	ppCommandQueue = CoCreateInstance( riid, IntPtr( pUnknown.Detach() ) );
}

void CD3D12Device::CreateCommandAllocator( D3D12CommandListType type, Guid riid, IUnknown^% ppCommandAllocator )
{
	ComPtr<::IUnknown> pUnknown;
	HR( pDevice->CreateCommandAllocator( ( D3D12_COMMAND_LIST_TYPE )type, ToGUID( riid ), &pUnknown ) );

	ppCommandAllocator = CoCreateInstance( riid, IntPtr( pUnknown.Detach() ) );
}

void CD3D12Device::CreateGraphicsPipelineState( D3D12GraphicsPipelineStateDesc desc, Guid riid, IUnknown^% ppPipelineState )
{
	D3D12_GRAPHICS_PIPELINE_STATE_DESC desc_;
	Assign( desc_, desc );

	ComPtr<::IUnknown> pUnknown;
	HR( pDevice->CreateGraphicsPipelineState( &desc_, ToGUID( riid ), &pUnknown ) );

	Cleanup( desc_ );

	ppPipelineState = CoCreateInstance( riid, IntPtr( pUnknown.Detach() ) );
}

void CD3D12Device::CreateComputePipelineState( D3D12ComputePipelineStateDesc desc, Guid riid, IUnknown^% ppPipelineState )
{
	D3D12_COMPUTE_PIPELINE_STATE_DESC desc_;
	Assign( desc_, desc );

	ComPtr<::IUnknown> pUnknown;
	HR( pDevice->CreateComputePipelineState( &desc_, ToGUID( riid ), &pUnknown ) );

	ppPipelineState = CoCreateInstance( riid, IntPtr( pUnknown.Detach() ) );
}

void CD3D12Device::CreateCommandList( unsigned int nodeMask, D3D12CommandListType type, ID3D12CommandAllocator^ pCommandAllocator, ID3D12PipelineState^ pInitialPipelineState, Guid riid, IUnknown^% ppCommandList )
{
	ComPtr<::IUnknown> pUnknown;
	HR( pDevice->CreateCommandList( nodeMask, ( D3D12_COMMAND_LIST_TYPE )type, Take<::ID3D12CommandAllocator>( pCommandAllocator ), pInitialPipelineState != nullptr ? Take<::ID3D12PipelineState>( pInitialPipelineState ) : nullptr, ToGUID( riid ), &pUnknown ) );

	ppCommandList = CoCreateInstance( riid, IntPtr( pUnknown.Detach() ) );
}

void CD3D12Device::CheckFeatureSupport( ValueType^% pFeatureSupportData )
{
	throw gcnew NotImplementedException();
}

void CD3D12Device::CreateDescriptorHeap( D3D12DescriptorHeapDesc descriptorHeapDesc, Guid riid, IUnknown^% ppHeap )
{
	D3D12_DESCRIPTOR_HEAP_DESC desc;
	Assign( desc, descriptorHeapDesc );

	ComPtr<::IUnknown> pUnknown;
	HR( pDevice->CreateDescriptorHeap( &desc, ToGUID( riid ), &pUnknown ) );

	ppHeap = CoCreateInstance( riid, IntPtr( pUnknown.Detach() ) );
}

unsigned int CD3D12Device::GetDescriptorHandleIncrementSize( D3D12DescriptorHeapType descriptorHeapType )
{
	return pDevice->GetDescriptorHandleIncrementSize( ( D3D12_DESCRIPTOR_HEAP_TYPE )descriptorHeapType );
}

void CD3D12Device::CreateRootSignature( unsigned int nodeMask, IntPtr pBlobWithRootSignature, unsigned long long blobLengthInBytes, Guid riid, IUnknown^% ppRootSignature )
{
	ComPtr<::IUnknown> pUnknown;
	HR( pDevice->CreateRootSignature( nodeMask, pBlobWithRootSignature.ToPointer(), ( SIZE_T )blobLengthInBytes, ToGUID( riid ), &pUnknown ) );

	ppRootSignature = CoCreateInstance( riid, IntPtr( pUnknown.Detach() ) );
}

void CD3D12Device::CreateConstantBufferView( D3D12ConstantBufferViewDesc desc, D3D12CPUDescriptorHandle handle )
{
	D3D12_CONSTANT_BUFFER_VIEW_DESC left;
	Assign( left, desc );
	
	pDevice->CreateConstantBufferView( &left, D3D12_CPU_DESCRIPTOR_HANDLE{ ( SIZE_T )handle.ptr.ToInt64() } );
}

void CD3D12Device::CreateShaderResourceView( ID3D12Resource^ pResource, Nullable<D3D12ShaderResourceViewDesc> desc, D3D12CPUDescriptorHandle handle )
{
	D3D12_SHADER_RESOURCE_VIEW_DESC left;
	if ( desc.HasValue ) Assign( left, desc.Value );

	pDevice->CreateShaderResourceView( Take<::ID3D12Resource>( pResource ), desc.HasValue ? &left : nullptr, D3D12_CPU_DESCRIPTOR_HANDLE{ ( SIZE_T )handle.ptr.ToInt64() } );
}

void CD3D12Device::CreateUnorderedAccessView( ID3D12Resource^ pResource, ID3D12Resource^ pCounterResource, Nullable<D3D12UnorderedAccessViewDesc> desc, D3D12CPUDescriptorHandle handle )
{
	D3D12_UNORDERED_ACCESS_VIEW_DESC left;
	if ( desc.HasValue ) Assign( left, desc.Value );

	pDevice->CreateUnorderedAccessView( Take<::ID3D12Resource>( pResource ), Take<::ID3D12Resource>( pCounterResource ), desc.HasValue ? &left : nullptr, D3D12_CPU_DESCRIPTOR_HANDLE{ ( SIZE_T )handle.ptr.ToInt64() } );
}

void CD3D12Device::CreateRenderTargetView( ID3D12Resource^ pResource, Nullable<D3D12RenderTargetViewDesc> desc, D3D12CPUDescriptorHandle handle )
{
	D3D12_RENDER_TARGET_VIEW_DESC left;
	if ( desc.HasValue ) Assign( left, desc.Value );

	pDevice->CreateRenderTargetView( Take<::ID3D12Resource>( pResource ), desc.HasValue ? &left : nullptr, D3D12_CPU_DESCRIPTOR_HANDLE{ ( SIZE_T )handle.ptr.ToInt64() } );
}

void CD3D12Device::CreateDepthStencilView( ID3D12Resource^ pResource, Nullable<D3D12DepthStencilViewDesc> desc, D3D12CPUDescriptorHandle handle )
{
	D3D12_DEPTH_STENCIL_VIEW_DESC left;
	if ( desc.HasValue ) Assign( left, desc.Value );

	pDevice->CreateDepthStencilView( Take<::ID3D12Resource>( pResource ), desc.HasValue ? &left : nullptr, D3D12_CPU_DESCRIPTOR_HANDLE{ ( SIZE_T )handle.ptr.ToInt64() } );
}

void CD3D12Device::CreateSampler( D3D12SamplerDesc desc, D3D12CPUDescriptorHandle handle )
{
	D3D12_SAMPLER_DESC desc_;
	Assign( desc_, desc );

	pDevice->CreateSampler( &desc_, { ( SIZE_T )handle.ptr.ToInt64() } );
}

void CD3D12Device::CopyDescriptors(
	IList<D3D12CPUDescriptorHandle>^ destDescriptorRangeStarts,
	IList<uint_>^ destDescriptorRangeSizes,
	IList<D3D12CPUDescriptorHandle>^ srcDescriptorRangeStarts,
	IList<uint_>^ srcDescriptorRangeSizes,
	D3D12DescriptorHeapType descriptorHeapType
)
{
	vector<D3D12_CPU_DESCRIPTOR_HANDLE> destDescriptorRangeStarts_( destDescriptorRangeStarts->Count );
	vector<uint_> destDescriptorRangeSizes_( destDescriptorRangeSizes->Count );
	vector<D3D12_CPU_DESCRIPTOR_HANDLE> srcDescriptorRangeStarts_( srcDescriptorRangeStarts->Count );
	vector<uint_> srcDescriptorRangeSizes_( srcDescriptorRangeSizes->Count );

	for ( int i = 0; i < destDescriptorRangeStarts->Count; ++i )
	{
		destDescriptorRangeStarts_[i].ptr = ( SIZE_T )destDescriptorRangeStarts[i].ptr.ToInt64();
		destDescriptorRangeSizes_[i] = destDescriptorRangeSizes[i];
	}

	for ( int i = 0; i < srcDescriptorRangeStarts->Count; ++i )
	{
		srcDescriptorRangeStarts_[i].ptr = ( SIZE_T )srcDescriptorRangeStarts[i].ptr.ToInt64();
		srcDescriptorRangeSizes_[i] = srcDescriptorRangeSizes[i];
	}

	pDevice->CopyDescriptors(
		( UINT )destDescriptorRangeSizes->Count,
		destDescriptorRangeStarts_.data(),
		destDescriptorRangeSizes_.data(),
		( UINT )srcDescriptorRangeSizes->Count,
		srcDescriptorRangeStarts_.data(),
		srcDescriptorRangeSizes_.data(),
		( D3D12_DESCRIPTOR_HEAP_TYPE )descriptorHeapType
	);
}

void CD3D12Device::CopyDescriptorsSimple(
	uint_ numDescriptors,
	D3D12CPUDescriptorHandle destDescriptorRangeStart,
	D3D12CPUDescriptorHandle srcDescriptorRangeStart,
	D3D12DescriptorHeapType descriptorHeapsType
)
{
	pDevice->CopyDescriptorsSimple(
		numDescriptors,
		{ ( SIZE_T )destDescriptorRangeStart.ptr.ToInt64() },
		{ ( SIZE_T )srcDescriptorRangeStart.ptr.ToInt64() },
		( D3D12_DESCRIPTOR_HEAP_TYPE )descriptorHeapsType
	);
}

auto CD3D12Device::GetResourceAllocationInfo(
	uint_ visibleMask,
	IList<D3D12ResourceDesc>^ resourceDescs
) -> D3D12ResourceAllocationInfo
{
	vector<D3D12_RESOURCE_DESC> resourceDescs_( resourceDescs->Count );
	for ( int i = 0; i < resourceDescs->Count; ++i )
	{
		Assign( resourceDescs_[i], resourceDescs[i] );
	}

	auto alloc = pDevice->GetResourceAllocationInfo( visibleMask, ( UINT )resourceDescs->Count, resourceDescs_.data() );
	D3D12ResourceAllocationInfo alloc_;
	Assign( alloc_, alloc );

	return alloc_;
}

auto CD3D12Device::GetCustomHeapProperties( uint_ nodeMask, D3D12HeapType heapType ) -> D3D12HeapProperties
{
	D3D12HeapProperties heap;
	Assign( heap, pDevice->GetCustomHeapProperties( nodeMask, ( D3D12_HEAP_TYPE )heapType ) );
	return heap;
}

void CD3D12Device::CreateCommittedResource(
	D3D12HeapProperties heapProperties,
	D3D12HeapFlags heapFlags,
	D3D12ResourceDesc desc,
	D3D12ResourceStates initialResourceState,
	Nullable<D3D12ClearValue> optimizedClearValue,
	Guid riid,
	IUnknown^% ppResource
)
{
	D3D12_HEAP_PROPERTIES heapProperties_;
	Assign( heapProperties_, heapProperties );

	D3D12_RESOURCE_DESC desc_;
	Assign( desc_, desc );

	D3D12_CLEAR_VALUE optimizedClearValue_;
	if ( optimizedClearValue.HasValue ) Assign( optimizedClearValue_, optimizedClearValue.Value );

	ComPtr<::IUnknown> pUnknown;
	HR( pDevice->CreateCommittedResource(
		&heapProperties_,
		( D3D12_HEAP_FLAGS )heapFlags,
		&desc_,
		( D3D12_RESOURCE_STATES )initialResourceState,
		optimizedClearValue.HasValue ? &optimizedClearValue_ : nullptr,
		ToGUID( riid ),
		&pUnknown
	) );

	ppResource = CoCreateInstance( riid, IntPtr( pUnknown.Detach() ) );
}

void CD3D12Device::CreateHeap( D3D12HeapDesc desc, Guid riid, IUnknown^% ppHeap )
{
	D3D12_HEAP_DESC desc_;
	Assign( desc_, desc );

	ComPtr<::IUnknown> pUnknown;
	HR( pDevice->CreateHeap(
		&desc_,
		ToGUID( riid ),
		&pUnknown
	) );

	ppHeap = CoCreateInstance( riid, IntPtr( pUnknown.Detach() ) );
}

void CD3D12Device::CreatePlacedResource(
	ID3D12Heap^ pHeap,
	ulong_ heapOffset,
	D3D12ResourceDesc desc,
	D3D12ResourceStates initialResourceState,
	Nullable<D3D12ClearValue> optimizedClearValue,
	Guid riid,
	IUnknown^% ppResource
)
{
	D3D12_RESOURCE_DESC desc_;
	Assign( desc_, desc );

	D3D12_CLEAR_VALUE optimizedClearValue_;
	if ( optimizedClearValue.HasValue ) Assign( optimizedClearValue_, optimizedClearValue.Value );

	ComPtr<::IUnknown> pUnknown;
	HR( pDevice->CreatePlacedResource(
		Take<::ID3D12Heap>( pHeap ),
		heapOffset,
		&desc_,
		( D3D12_RESOURCE_STATES )initialResourceState,
		optimizedClearValue.HasValue ? &optimizedClearValue_ : nullptr,
		ToGUID( riid ),
		&pUnknown
	) );

	ppResource = CoCreateInstance( riid, IntPtr( pUnknown.Detach() ) );
}

void CD3D12Device::CreateReservedResource( D3D12ResourceDesc desc, D3D12ResourceStates initialResourceState, Nullable<D3D12ClearValue> optimizedClearValue, Guid riid, IUnknown^% ppResource )
{
	D3D12_RESOURCE_DESC desc_;
	Assign( desc_, desc );

	D3D12_CLEAR_VALUE optimizedClearValue_;
	if ( optimizedClearValue.HasValue ) Assign( optimizedClearValue_, optimizedClearValue.Value );

	ComPtr<::IUnknown> pUnknown;
	HR( pDevice->CreateReservedResource(
		&desc_,
		( D3D12_RESOURCE_STATES )initialResourceState,
		optimizedClearValue.HasValue ? &optimizedClearValue_ : nullptr,
		ToGUID( riid ),
		&pUnknown
	) );

	ppResource = CoCreateInstance( riid, IntPtr( pUnknown.Detach() ) );
}

IPlatformHandle^ CD3D12Device::CreateSharedHandle( ID3D12DeviceChild^ pObject, IntPtr pAttributes, GenericAccess access, String^ name )
{
	msclr::interop::marshal_context context;
	auto str = context.marshal_as<const wchar_t*>( name );

	HANDLE handle;
	HR( pDevice->CreateSharedHandle( Take<::ID3D12DeviceChild>( pObject ), ( SECURITY_ATTRIBUTES* )pAttributes.ToPointer(), ( DWORD )access, str, &handle ) );

	return gcnew GeneralHandle( IntPtr( handle ) );
}

void CD3D12Device::OpenSharedHandle( IPlatformHandle^ ntHandle, Guid riid, IUnknown^% ppObject )
{
	ComPtr<::IUnknown> pUnknown;
	HR( pDevice->OpenSharedHandle( ntHandle->GetHandle().ToPointer(), ToGUID( riid ), &pUnknown ) );

	ppObject = CoCreateInstance( riid, IntPtr( pUnknown.Detach() ) );
}

IPlatformHandle^ CD3D12Device::OpenSharedHandleByName( String^ name, GenericAccess access )
{
	msclr::interop::marshal_context context;
	auto str = context.marshal_as<const wchar_t*>( name );

	HANDLE handle;
	HR( pDevice->OpenSharedHandleByName( str, ( DWORD )access, &handle ) );

	return gcnew GeneralHandle( IntPtr( handle ) );
}

void CD3D12Device::MakeResident( IList<ID3D12Pageable^>^ ppObjects )
{
	vector<::ID3D12Pageable*> ppObjects_( ppObjects->Count );
	for ( int i = 0; i < ppObjects->Count; ++i )
	{
		ppObjects_[i] = Take<::ID3D12Pageable>( ppObjects[i] );
	}
	pDevice->MakeResident( ( UINT )ppObjects->Count, ppObjects_.data() );
}

void CD3D12Device::Evict( IList<ID3D12Pageable^>^ ppObjects )
{
	vector<::ID3D12Pageable*> ppObjects_( ppObjects->Count );
	for ( int i = 0; i < ppObjects->Count; ++i )
	{
		ppObjects_[i] = Take<::ID3D12Pageable>( ppObjects[i] );
	}
	pDevice->Evict( ( UINT )ppObjects->Count, ppObjects_.data() );
}

void CD3D12Device::CreateFence( unsigned long long initialValue, D3D12FenceFlags flags, Guid riid, IUnknown^% ppFence )
{
	ComPtr<::IUnknown> pUnknown;
	HR( pDevice->CreateFence( initialValue, ( D3D12_FENCE_FLAGS )flags, ToGUID( riid ), &pUnknown ) );

	ppFence = CoCreateInstance( riid, IntPtr( pUnknown.Detach() ) );
}

auto CD3D12Device::GetCopyableFootprints(
	D3D12ResourceDesc resourceDesc, uint_ firstSubresource,
	uint_ numSubresources,
	ulong_ baseOffset,
	cli::array<uint_>^% numRows,
	cli::array<ulong_>^% rowSizeInBytes,
	ulong_% totalBytes
) -> cli::array<D3D12PlacedSubresourceFootprint>^
{
	D3D12_RESOURCE_DESC resourceDesc_;
	Assign( resourceDesc_, resourceDesc );

	vector<UINT> numRows_( numSubresources );
	vector<UINT64> rowSizeInBytes_( numSubresources );
	vector<D3D12_PLACED_SUBRESOURCE_FOOTPRINT> layout_( numSubresources );
	UINT64 totalBytes_;

	pDevice->GetCopyableFootprints( &resourceDesc_, firstSubresource, numSubresources, baseOffset, layout_.data(), numRows_.data(), rowSizeInBytes_.data(), &totalBytes_ );

	auto layout = gcnew cli::array<D3D12PlacedSubresourceFootprint>( numSubresources );
	numRows = gcnew cli::array<uint_>( numSubresources );
	rowSizeInBytes = gcnew cli::array<ulong_>( numSubresources );
	for ( int i = 0; i < ( int )numSubresources; ++i )
	{
		Assign( layout[i], layout_[i] );
		numRows[i] = numRows_[i];
		rowSizeInBytes[i] = rowSizeInBytes_[i];
	}

	totalBytes = totalBytes_;

	return layout;
}

void CD3D12Device::CreateQueryHeap( D3D12QueryHeapDesc desc, Guid riid, IUnknown^% ppHeap )
{
	D3D12_QUERY_HEAP_DESC desc_;
	Assign( desc_, desc );

	ComPtr<::IUnknown> pUnknown;
	HR( pDevice->CreateQueryHeap( &desc_, ToGUID( riid ), &pUnknown ) );

	ppHeap = CoCreateInstance( riid, IntPtr( pUnknown.Detach() ) );
}

void CD3D12Device::SetStablePowerState( bool enable )
{
	HR( pDevice->SetStablePowerState( enable ) );
}

void CD3D12Device::CreateCommandSignature( D3D12CommandSignatureDesc desc, ID3D12RootSignature^ pRootSignature, Guid riid, IUnknown^% ppCommandSignature )
{
	D3D12_COMMAND_SIGNATURE_DESC desc_;
	Assign( desc_, desc );

	ComPtr<::IUnknown> pUnknown;
	HR( pDevice->CreateCommandSignature( &desc_, Take<::ID3D12RootSignature>( pRootSignature ), ToGUID( riid ), &pUnknown ) );

	ppCommandSignature = CoCreateInstance( riid, IntPtr( pUnknown.Detach() ) );
}

auto CD3D12Device::GetResourceTiling(
	ID3D12Resource^ pTiledResource,
	uint_% numTilesForEntireResource,
	D3D12PackedMipInfo% packedMipDesc, 
	D3D12TileShape% standardTileShapeForNonPackedMips, 
	uint_ firstSubresourceTilingToGet
) -> cli::array<D3D12SubresourceTiling>^
{
	throw gcnew NotImplementedException();
}

auto CD3D12Device::GetAdapterLuid() -> Luid
{
	Luid luid;
	auto luid_ = pDevice->GetAdapterLuid();
	luid.LowPart = luid_.LowPart;
	luid.HighPart = luid_.HighPart;
	return luid;
}

void CD3D12Device::CreatePipelineLibrary(cli::array<unsigned char>^ libraryBlob, Guid riid, IUnknown^% ppResource)
{
	pin_ptr<unsigned char> pLibraryBlob = &libraryBlob[0];
	ComPtr<::IUnknown> pUnknown;
	HR(pDevice->CreatePipelineLibrary(pLibraryBlob, libraryBlob->Length, ToGUID(riid), &pUnknown));

	ppResource = CoCreateInstance(riid, IntPtr(pUnknown.Detach()));
}

void CD3D12Device::SetEventOnMultipleFenceCompletion(cli::array<ID3D12Fence^>^ ppFences, cli::array<unsigned __int64>^ fenceValues, D3D12MultipleFenceWaitFlags flags, IPlatformHandle^ hEvent)
{
	vector<::ID3D12Fence*> fences(ppFences->Length);
	pin_ptr<unsigned __int64> values = &fenceValues[0];
	for (int i = 0; i < ppFences->Length; ++i)
	{
		fences[i] = (::ID3D12Fence*)((ComObject^)ppFences[i])->Handle.ToPointer();
	}

	HANDLE h = (HANDLE)hEvent->GetHandle().ToPointer();
	HR(pDevice->SetEventOnMultipleFenceCompletion(fences.data(), values, (UINT)ppFences->Length, (D3D12_MULTIPLE_FENCE_WAIT_FLAGS)flags, h));
}

void CD3D12Device::SetResidencyPriority(cli::array<ID3D12Pageable^>^ ppObjects, cli::array<D3D12ResidencyPriority>^ priorities)
{
	vector<::ID3D12Pageable*> pageables(ppObjects->Length);
	pin_ptr<D3D12ResidencyPriority> prio = &priorities[0];
	for (int i = 0; i < ppObjects->Length; ++i)
	{
		pageables[i] = (::ID3D12Pageable*)((ComObject^)ppObjects[i])->Handle.ToPointer();
	}

	HR(pDevice->SetResidencyPriority(ppObjects->Length, pageables.data(), (const D3D12_RESIDENCY_PRIORITY*)prio));
}

auto CD3D12Device::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD3D12Device( ( ::ID3D12Device1* )pUnknown.ToPointer() );
}