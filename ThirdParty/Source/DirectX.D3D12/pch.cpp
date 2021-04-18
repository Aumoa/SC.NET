// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::Engine::Runtime::Core::Numerics;
using namespace SC::ThirdParty::DirectX;

using namespace System;
using namespace System::Collections::Generic;

using namespace std;

Guid FromGUID( const _GUID& guid )
{
    return System::Guid(
        guid.Data1, guid.Data2, guid.Data3,
        guid.Data4[0], guid.Data4[1],
        guid.Data4[2], guid.Data4[3],
        guid.Data4[4], guid.Data4[5],
        guid.Data4[6], guid.Data4[7]
    );
}

_GUID ToGUID( Guid& guid )
{
    cli::array<System::Byte>^ guidData = guid.ToByteArray();
    pin_ptr<System::Byte> data = &( guidData[0] );

    return *( _GUID* )data;
}

void Assign( wstring& left, String^ right )
{
    left.resize( right->Length + 1 );
    
    for ( int i = 0; i < right->Length; ++i )
    {
        left[i] = right[i];
    }
}

void Assign( String^% left, wstring& right )
{
    left = gcnew String( right.c_str() );
}

void Assign( D3D12_HEAP_DESC& left, D3D12HeapDesc% right )
{
    left.SizeInBytes = right.SizeInBytes;
    Assign( left.Properties, right.Properties );
    left.Alignment = right.Alignment;
    left.Flags = ( D3D12_HEAP_FLAGS )right.Flags;
}

void Assign( D3D12HeapDesc% left, D3D12_HEAP_DESC& right )
{
    left.SizeInBytes = right.SizeInBytes;
    Assign( left.Properties, right.Properties );
    left.Alignment = right.Alignment;
    left.Flags = ( D3D12HeapFlags )right.Flags;
}

void Assign( D3D12_HEAP_PROPERTIES& left, D3D12HeapProperties% right )
{
    left.Type = ( D3D12_HEAP_TYPE )right.Type;
    left.CPUPageProperty = ( D3D12_CPU_PAGE_PROPERTY )right.CPUPageProperty;
    left.MemoryPoolPreference = ( D3D12_MEMORY_POOL )right.MemoryPoolPreference;
    left.CreationNodeMask = right.CreationNodeMask;
    left.VisibleNodeMask = right.VisibleNodeMask;
}

void Assign( D3D12HeapProperties% left, D3D12_HEAP_PROPERTIES& right )
{
    left.Type = ( D3D12HeapType )right.Type;
    left.CPUPageProperty = ( D3D12CPUPageProperty )right.CPUPageProperty;
    left.MemoryPoolPreference = ( D3D12MemoryPool )right.MemoryPoolPreference;
    left.CreationNodeMask = right.CreationNodeMask;
    left.VisibleNodeMask = right.VisibleNodeMask;
}

void Assign( D3D12_RANGE& left, D3D12Range% right )
{
    left.Begin = ( SIZE_T )right.Begin;
    left.End = ( SIZE_T )right.End;
}

void Assign( D3D12Range% left, D3D12_RANGE& right )
{
    left.Begin = right.Begin;
    left.End = right.End;
}

void Assign( D3D12_RESOURCE_DESC& left, D3D12ResourceDesc% right )
{
    left.Dimension = ( D3D12_RESOURCE_DIMENSION )right.Dimension;
    left.Alignment = right.Alignment;
    left.Width = right.Width;
    left.Height = right.Height;
    left.DepthOrArraySize = right.DepthOrArraySize;
    left.MipLevels = right.MipLevels;
    left.Format = ( DXGI_FORMAT )right.Format;
    Assign( left.SampleDesc, right.SampleDesc );
    left.Layout = ( D3D12_TEXTURE_LAYOUT )right.Layout;
    left.Flags = ( D3D12_RESOURCE_FLAGS )right.Flags;
}

void Assign( D3D12ResourceDesc% left, D3D12_RESOURCE_DESC& right )
{
    left.Dimension = ( D3D12ResourceDimension )right.Dimension;
    left.Alignment = right.Alignment;
    left.Width = right.Width;
    left.Height = right.Height;
    left.DepthOrArraySize = right.DepthOrArraySize;
    left.MipLevels = right.MipLevels;
    left.Format = ( DXGIFormat )right.Format;
    Assign( left.SampleDesc, right.SampleDesc );
    left.Layout = ( D3D12TextureLayout )right.Layout;
    left.Flags = ( D3D12ResourceFlags )right.Flags;
}

void Assign( DXGI_SAMPLE_DESC& left, DXGISampleDesc% right )
{
    left.Count = right.Count;
    left.Quality = right.Quality;
}

void Assign( DXGISampleDesc% left, DXGI_SAMPLE_DESC& right )
{
    left.Count = right.Count;
    left.Quality = right.Quality;
}

void Assign( D3D12_BOX& left, D3D12Box% right )
{
    left.left = right.Left;
    left.top = right.Top;
    left.right = right.Right;
    left.bottom = right.Bottom;
    left.front = right.Front;
    left.back = right.Back;
}

void Assign( D3D12Box% left, D3D12_BOX& right )
{
    left.Left = right.left;
    left.Top = right.top;
    left.Right = right.right;
    left.Bottom = right.bottom;
    left.Front = right.front;
    left.Back = right.back;
}

void Assign( D3D12_TILED_RESOURCE_COORDINATE& left, D3D12TiledResourceCoordinate% right )
{
    left.X = right.X;
    left.Y = right.Y;
    left.Z = right.Z;
    left.Subresource = right.Subresource;
}

void Assign( D3D12TiledResourceCoordinate% left, D3D12_TILED_RESOURCE_COORDINATE& right )
{
    left.X = right.X;
    left.Y = right.Y;
    left.Z = right.Z;
    left.Subresource = right.Subresource;
}

void Assign( D3D12_TILE_REGION_SIZE& left, D3D12TileRegionSize% right )
{
    left.NumTiles = right.NumTiles;
    left.UseBox = right.UseBox;
    left.Width = right.Width;
    left.Height = right.Height;
    left.Depth = right.Depth;
}

void Assign( D3D12TileRegionSize% left, D3D12_TILE_REGION_SIZE& right )
{
    left.NumTiles = right.NumTiles;
    left.UseBox = right.UseBox;
    left.Width = right.Width;
    left.Height = right.Height;
    left.Depth = right.Depth;
}

void Assign( D3D12_COMMAND_QUEUE_DESC& left, D3D12CommandQueueDesc% right )
{
    left.Type = ( D3D12_COMMAND_LIST_TYPE )right.Type;
    left.Priority = ( INT )right.Priority;
    left.Flags = ( D3D12_COMMAND_QUEUE_FLAGS )right.Flags;
    left.NodeMask = right.NodeMask;
}

void Assign( D3D12CommandQueueDesc% left, D3D12_COMMAND_QUEUE_DESC& right )
{
    left.Type = ( D3D12CommandListType )right.Type;
    left.Priority = ( D3D12CommandQueuePriority )right.Priority;
    left.Flags = ( D3D12CommandQueueFlags )right.Flags;
    left.NodeMask = right.NodeMask;
}

void Assign( D3D12_DESCRIPTOR_HEAP_DESC& left, D3D12DescriptorHeapDesc% right )
{
    left.Type = ( D3D12_DESCRIPTOR_HEAP_TYPE )right.Type;
    left.NumDescriptors = right.NumDescriptors;
    left.Flags = ( D3D12_DESCRIPTOR_HEAP_FLAGS )right.Flags;
    left.NodeMask = right.NodeMask;
}

void Assign( D3D12DescriptorHeapDesc% left, D3D12_DESCRIPTOR_HEAP_DESC& right )
{
    left.Type = ( D3D12DescriptorHeapType )right.Type;
    left.NumDescriptors = right.NumDescriptors;
    left.Flags = ( D3D12DescriptorHeapFlags )right.Flags;
    left.NodeMask = right.NodeMask;
}

void Assign( D3D12_GRAPHICS_PIPELINE_STATE_DESC& left, D3D12GraphicsPipelineStateDesc% right )
{
    left.pRootSignature = Take<::ID3D12RootSignature>( right.pRootSignature );
    Assign( left.VS, right.VS );
    Assign( left.PS, right.PS );
    Assign( left.DS, right.DS );
    Assign( left.HS, right.HS );
    Assign( left.GS, right.GS );
    Assign( left.StreamOutput, right.StreamOutput );
    Assign( left.BlendState, right.BlendState );
    left.SampleMask = right.SampleMask;
    Assign( left.RasterizerState, right.RasterizerState );
    Assign( left.DepthStencilState, right.DepthStencilState );
    Assign( left.InputLayout, right.InputLayout );
    left.IBStripCutValue = ( D3D12_INDEX_BUFFER_STRIP_CUT_VALUE )right.IBStripCutValue;
    left.PrimitiveTopologyType = ( D3D12_PRIMITIVE_TOPOLOGY_TYPE )right.PrimitiveTopologyType;
    left.NumRenderTargets = right.NumRenderTargets;
    left.RTVFormats[0] = ( DXGI_FORMAT )right.RTVFormats[0];
    left.RTVFormats[1] = ( DXGI_FORMAT )right.RTVFormats[1];
    left.RTVFormats[2] = ( DXGI_FORMAT )right.RTVFormats[2];
    left.RTVFormats[3] = ( DXGI_FORMAT )right.RTVFormats[3];
    left.RTVFormats[4] = ( DXGI_FORMAT )right.RTVFormats[4];
    left.RTVFormats[5] = ( DXGI_FORMAT )right.RTVFormats[5];
    left.RTVFormats[6] = ( DXGI_FORMAT )right.RTVFormats[6];
    left.RTVFormats[7] = ( DXGI_FORMAT )right.RTVFormats[7];
    left.DSVFormat = ( DXGI_FORMAT )right.DSVFormat;
    Assign( left.SampleDesc, right.SampleDesc );
    left.NodeMask = right.NodeMask;
    Assign( left.CachedPSO, right.CachedPSO );
    left.Flags = ( D3D12_PIPELINE_STATE_FLAGS )right.Flags;
}

void Assign( D3D12GraphicsPipelineStateDesc% left, D3D12_GRAPHICS_PIPELINE_STATE_DESC& right )
{
    left.pRootSignature = gcnew CD3D12RootSignature( right.pRootSignature );
    Assign( left.VS, right.VS );
    Assign( left.PS, right.PS );
    Assign( left.DS, right.DS );
    Assign( left.HS, right.HS );
    Assign( left.GS, right.GS );
    Assign( left.StreamOutput, right.StreamOutput );
    Assign( left.BlendState, right.BlendState );
    left.SampleMask = right.SampleMask;
    Assign( left.RasterizerState, right.RasterizerState );
    Assign( left.DepthStencilState, right.DepthStencilState );
    Assign( left.InputLayout, right.InputLayout );
    left.IBStripCutValue = ( D3D12IndexBufferStripCutValue )right.IBStripCutValue;
    left.PrimitiveTopologyType = ( D3D12PrimitiveTopologyType )right.PrimitiveTopologyType;
    left.NumRenderTargets = right.NumRenderTargets;
    left.RTVFormats[0] = ( DXGIFormat )right.RTVFormats[0];
    left.RTVFormats[1] = ( DXGIFormat )right.RTVFormats[1];
    left.RTVFormats[2] = ( DXGIFormat )right.RTVFormats[2];
    left.RTVFormats[3] = ( DXGIFormat )right.RTVFormats[3];
    left.RTVFormats[4] = ( DXGIFormat )right.RTVFormats[4];
    left.RTVFormats[5] = ( DXGIFormat )right.RTVFormats[5];
    left.RTVFormats[6] = ( DXGIFormat )right.RTVFormats[6];
    left.RTVFormats[7] = ( DXGIFormat )right.RTVFormats[7];
    left.DSVFormat = ( DXGIFormat )right.DSVFormat;
    Assign( left.SampleDesc, right.SampleDesc );
    left.NodeMask = right.NodeMask;
    Assign( left.CachedPSO, right.CachedPSO );
    left.Flags = ( D3D12PipelineStateFlags )right.Flags;
}

void Assign( D3D12_SHADER_BYTECODE& left, D3D12ShaderBytecode% right )
{
    left.BytecodeLength = right.BytecodeLength;
    left.pShaderBytecode = right.pShaderBytecode.ToPointer();
}

void Assign( D3D12ShaderBytecode% left, D3D12_SHADER_BYTECODE& right )
{
    left.BytecodeLength = right.BytecodeLength;
    left.pShaderBytecode = IntPtr( ( void* )right.pShaderBytecode );
}

void Assign( D3D12_STREAM_OUTPUT_DESC& left, D3D12StreamOutputDesc% right )
{
    if ( right.SODeclaration != nullptr )
    {
        left.pSODeclaration = new D3D12_SO_DECLARATION_ENTRY[right.SODeclaration->Count];
        for ( int i = 0; i < right.SODeclaration->Count; ++i )
        {
            Assign( ( D3D12_SO_DECLARATION_ENTRY& )left.pSODeclaration[i], right.SODeclaration[i] );
        }
        left.NumEntries = ( UINT )right.SODeclaration->Count;
    }
    else
    {
        left.pSODeclaration = nullptr;
        left.NumEntries = 0;
    }

    if ( right.BufferStrides != nullptr )
    {
        left.pBufferStrides = new UINT[right.BufferStrides->Count];
        for ( int i = 0; i < right.BufferStrides->Count; ++i )
        {
            ( UINT& )left.pBufferStrides[i] = right.BufferStrides[i];
        }

        left.NumStrides = ( UINT )right.BufferStrides->Count;
    }
    else
    {
        left.pBufferStrides = nullptr;
        left.NumStrides = 0;
    }

    left.RasterizedStream = right.RasterizedStream;
}

void Assign( D3D12StreamOutputDesc% left, D3D12_STREAM_OUTPUT_DESC& right )
{
    if ( right.NumEntries != 0 )
    {
        left.SODeclaration = ( IList<D3D12SODeclarationEntry>^ )gcnew cli::array<D3D12SODeclarationEntry>( right.NumEntries );
        for ( int i = 0; i < ( int )right.NumEntries; ++i )
        {
            Assign( left.SODeclaration[i], ( D3D12_SO_DECLARATION_ENTRY& )right.pSODeclaration[i] );
        }
    }

    if ( right.NumStrides != 0 )
    {
        left.BufferStrides = ( IList<unsigned int>^ )gcnew cli::array<unsigned int>( right.NumStrides );
        for ( int i = 0; i < ( int )right.NumStrides; ++i )
        {
            left.BufferStrides[i] = right.pBufferStrides[i];
        }
    }

    left.RasterizedStream = right.RasterizedStream;
}

void Assign( D3D12_BLEND_DESC& left, D3D12BlendDesc% right )
{
    left.AlphaToCoverageEnable = right.AlphaToCoverageEnable;
    left.IndependentBlendEnable = right.IndependentBlendEnable;
    for ( int i = 0; i < 8; ++i )
    {
        Assign( left.RenderTarget[i], right.RenderTarget[i] );
    }
}

void Assign( D3D12BlendDesc% left, D3D12_BLEND_DESC& right )
{
    left.AlphaToCoverageEnable = right.AlphaToCoverageEnable;
    left.IndependentBlendEnable = right.IndependentBlendEnable;
    for ( int i = 0; i < 8; ++i )
    {
        Assign( left.RenderTarget[i], right.RenderTarget[i] );
    }
}

void Assign( D3D12_RASTERIZER_DESC& left, D3D12RasterizerDesc% right )
{
    left.FillMode = ( D3D12_FILL_MODE )right.FillMode;
    left.CullMode = ( D3D12_CULL_MODE )right.CullMode;
    left.FrontCounterClockwise = right.FrontCounterClockwise;
    left.DepthBias = right.DepthBias;
    left.DepthBiasClamp = right.DepthBiasClamp;
    left.SlopeScaledDepthBias = right.SlopeScaledDepthBias;
    left.DepthClipEnable = right.DepthClipEnable;
    left.MultisampleEnable = right.MultisampleEnable;
    left.AntialiasedLineEnable = right.AntialiasedLineEnable;
    left.ForcedSampleCount = right.ForcedSampleCount;
    left.ConservativeRaster = ( D3D12_CONSERVATIVE_RASTERIZATION_MODE )right.ConservativeRaster;
}

void Assign( D3D12RasterizerDesc% left, D3D12_RASTERIZER_DESC& right )
{
    left.FillMode = ( D3D12FillMode )right.FillMode;
    left.CullMode = ( D3D12CullMode )right.CullMode;
    left.FrontCounterClockwise = right.FrontCounterClockwise;
    left.DepthBias = right.DepthBias;
    left.DepthBiasClamp = right.DepthBiasClamp;
    left.SlopeScaledDepthBias = right.SlopeScaledDepthBias;
    left.DepthClipEnable = right.DepthClipEnable;
    left.MultisampleEnable = right.MultisampleEnable;
    left.AntialiasedLineEnable = right.AntialiasedLineEnable;
    left.ForcedSampleCount = right.ForcedSampleCount;
    left.ConservativeRaster = ( D3D12ConservativeRasterizationMode )right.ConservativeRaster;
}

void Assign( D3D12_DEPTH_STENCIL_DESC& left, D3D12DepthStencilDesc% right )
{
    left.DepthEnable = right.DepthEnable;
    left.DepthWriteMask = ( D3D12_DEPTH_WRITE_MASK )right.DepthWriteMask;
    left.DepthFunc = ( D3D12_COMPARISON_FUNC )right.DepthFunc;
    left.StencilEnable = right.StencilEnable;
    left.StencilReadMask = right.StencilReadMask;
    left.StencilWriteMask = right.StencilWriteMask;
    Assign( left.FrontFace, right.FrontFace );
    Assign( left.BackFace, right.BackFace );
}

void Assign( D3D12DepthStencilDesc% left, D3D12_DEPTH_STENCIL_DESC& right )
{
    left.DepthEnable = right.DepthEnable;
    left.DepthWriteMask = ( D3D12DepthWriteMask )right.DepthWriteMask;
    left.DepthFunc = ( D3D12ComparisonFunc )right.DepthFunc;
    left.StencilEnable = right.StencilEnable;
    left.StencilReadMask = right.StencilReadMask;
    left.StencilWriteMask = right.StencilWriteMask;
    Assign( left.FrontFace, right.FrontFace );
    Assign( left.BackFace, right.BackFace );
}

void Assign( D3D12_INPUT_LAYOUT_DESC& left, D3D12InputLayoutDesc% right )
{
    if ( right.InputElementDescs != nullptr )
    {
        left.NumElements = ( UINT )right.InputElementDescs->Count;
        left.pInputElementDescs = new D3D12_INPUT_ELEMENT_DESC[left.NumElements];

        for ( int i = 0; i < ( int )left.NumElements; ++i )
        {
            Assign( ( D3D12_INPUT_ELEMENT_DESC& )left.pInputElementDescs[i], right.InputElementDescs[i] );
        }
    }
    else
    {
        left.NumElements = 0;
        left.pInputElementDescs = nullptr;
    }
}

void Assign( D3D12InputLayoutDesc% left, D3D12_INPUT_LAYOUT_DESC& right )
{
    if ( right.pInputElementDescs != nullptr )
    {
        left.InputElementDescs = ( IList<D3D12InputElementDesc>^ )gcnew cli::array<D3D12InputElementDesc>( right.NumElements );

        for ( int i = 0; i < ( int )right.NumElements; ++i )
        {
            Assign( left.InputElementDescs[i], ( D3D12_INPUT_ELEMENT_DESC& )right.pInputElementDescs[i] );
        }
    }
}

void Assign( D3D12_CACHED_PIPELINE_STATE& left, D3D12CachedPipelineState% right )
{
    left.pCachedBlob = right.pCachedBlob.ToPointer();
    left.CachedBlobSizeInBytes = right.CachedBlobSizeInBytes;
}

void Assign( D3D12CachedPipelineState% left, D3D12_CACHED_PIPELINE_STATE& right )
{
    left.pCachedBlob = IntPtr( ( void* )right.pCachedBlob );
    left.CachedBlobSizeInBytes = right.CachedBlobSizeInBytes;
}

void Assign( D3D12_SO_DECLARATION_ENTRY& left, D3D12SODeclarationEntry% right )
{
    left.Stream = right.Stream;
    left.SemanticName = ( LPCSTR )new char[right.SemanticName->Length + 1]{ };
    left.SemanticIndex = right.SemanticIndex;
    left.StartComponent = right.StartComponent;
    left.ComponentCount = right.ComponentCount;
    left.OutputSlot = right.OutputSlot;

    for ( int i = 0; i < right.SemanticName->Length; ++i )
    {
        ( char& )left.SemanticName[i] = ( char )right.SemanticName[i];
    }
}

void Assign( D3D12SODeclarationEntry% left, D3D12_SO_DECLARATION_ENTRY& right )
{
    left.Stream = right.Stream;
    left.SemanticName = gcnew String( right.SemanticName );
    left.SemanticIndex = right.SemanticIndex;
    left.StartComponent = right.StartComponent;
    left.ComponentCount = right.ComponentCount;
    left.OutputSlot = right.OutputSlot;
}

void Assign( D3D12_RENDER_TARGET_BLEND_DESC& left, D3D12RenderTargetBlendDesc% right )
{
    left.BlendEnable = right.BlendEnable;
    left.LogicOpEnable = right.LogicOpEnable;
    left.SrcBlend = ( D3D12_BLEND )right.SrcBlend;
    left.DestBlend = ( D3D12_BLEND )right.DestBlend;
    left.BlendOp = ( D3D12_BLEND_OP )right.BlendOp;
    left.SrcBlendAlpha = ( D3D12_BLEND )right.SrcBlendAlpha;
    left.DestBlendAlpha = ( D3D12_BLEND )right.DestBlendAlpha;
    left.BlendOpAlpha = ( D3D12_BLEND_OP )right.BlendOpAlpha;
    left.LogicOp = ( D3D12_LOGIC_OP )right.LogicOp;
    left.RenderTargetWriteMask = ( UINT8 )right.RenderTargetWriteMask;
}

void Assign( D3D12RenderTargetBlendDesc% left, D3D12_RENDER_TARGET_BLEND_DESC& right )
{
    left.BlendEnable = right.BlendEnable;
    left.LogicOpEnable = right.LogicOpEnable;
    left.SrcBlend = ( D3D12Blend )right.SrcBlend;
    left.DestBlend = ( D3D12Blend )right.DestBlend;
    left.BlendOp = ( D3D12BlendOP )right.BlendOp;
    left.SrcBlendAlpha = ( D3D12Blend )right.SrcBlendAlpha;
    left.DestBlendAlpha = ( D3D12Blend )right.DestBlendAlpha;
    left.BlendOpAlpha = ( D3D12BlendOP )right.BlendOpAlpha;
    left.LogicOp = ( D3D12LogicOP )right.LogicOp;
    left.RenderTargetWriteMask = ( D3D12ColorWriteEnable )right.RenderTargetWriteMask;
}

void Assign( D3D12_DEPTH_STENCILOP_DESC& left, D3D12DepthStencilOPDesc% right )
{
    left.StencilFailOp = ( D3D12_STENCIL_OP )right.StencilFailOp;
    left.StencilDepthFailOp = ( D3D12_STENCIL_OP )right.StencilDepthFailOp;
    left.StencilPassOp = ( D3D12_STENCIL_OP )right.StencilPassOp;
    left.StencilFunc = ( D3D12_COMPARISON_FUNC )right.StencilFunc;
}

void Assign( D3D12DepthStencilOPDesc% left, D3D12_DEPTH_STENCILOP_DESC& right )
{
    left.StencilFailOp = ( D3D12StencilOP )right.StencilFailOp;
    left.StencilDepthFailOp = ( D3D12StencilOP )right.StencilDepthFailOp;
    left.StencilPassOp = ( D3D12StencilOP )right.StencilPassOp;
    left.StencilFunc = ( D3D12ComparisonFunc )right.StencilFunc;
}

void Assign( D3D12_INPUT_ELEMENT_DESC& left, D3D12InputElementDesc% right )
{
    left.SemanticName = new char[right.SemanticName->Length + 1];
    left.SemanticIndex = right.SemanticIndex;
    left.Format = ( DXGI_FORMAT )right.Format;
    left.InputSlot = right.InputSlot;
    left.AlignedByteOffset = right.AlignedByteOffset;
    left.InputSlotClass = ( D3D12_INPUT_CLASSIFICATION )right.InputSlotClass;
    left.InstanceDataStepRate = right.InstanceDataStepRate;

    for ( int i = 0; i < right.SemanticName->Length; ++i )
    {
        ( char& )left.SemanticName[i] = ( char )right.SemanticName[i];
    }
    ( char& )left.SemanticName[right.SemanticName->Length] = 0;
}

void Assign( D3D12InputElementDesc% left, D3D12_INPUT_ELEMENT_DESC& right )
{
    left.SemanticName = gcnew String( right.SemanticName );
    left.SemanticIndex = right.SemanticIndex;
    left.Format = ( DXGIFormat )right.Format;
    left.InputSlot = right.InputSlot;
    left.AlignedByteOffset = right.AlignedByteOffset;
    left.InputSlotClass = ( D3D12InputClassification )right.InputSlotClass;
    left.InstanceDataStepRate = right.InstanceDataStepRate;
}

void Assign( D3D12_COMPUTE_PIPELINE_STATE_DESC& left, D3D12ComputePipelineStateDesc% right )
{
    left.pRootSignature = Take<::ID3D12RootSignature>( right.pRootSignature );
    Assign( left.CS, right.CS );
    left.NodeMask = right.NodeMask;
    Assign( left.CachedPSO, right.CachedPSO );
    left.Flags = ( D3D12_PIPELINE_STATE_FLAGS )right.Flags;
}

void Assign( D3D12ComputePipelineStateDesc% left, D3D12_COMPUTE_PIPELINE_STATE_DESC& right )
{
    left.pRootSignature = gcnew CD3D12RootSignature( right.pRootSignature );
    Assign( left.CS, right.CS );
    left.NodeMask = right.NodeMask;
    Assign( left.CachedPSO, right.CachedPSO );
    left.Flags = ( D3D12PipelineStateFlags )right.Flags;
}

void Assign( D3D12_CONSTANT_BUFFER_VIEW_DESC& left, D3D12ConstantBufferViewDesc% right )
{
    left.BufferLocation = right.BufferLocation;
    left.SizeInBytes = right.SizeInBytes;
}

void Assign( D3D12_SHADER_RESOURCE_VIEW_DESC& left, D3D12ShaderResourceViewDesc% right )
{
    left.Format = ( DXGI_FORMAT )right.Format;
    left.ViewDimension = ( D3D12_SRV_DIMENSION )right.ViewDimension;
    left.Shader4ComponentMapping = ( UINT )right.Shader4ComponentMapping;

    switch ( left.ViewDimension )
    {
    case D3D12_SRV_DIMENSION_BUFFER:
        left.Buffer.FirstElement = right.Buffer.FirstElement;
        left.Buffer.NumElements = right.Buffer.NumElement;
        left.Buffer.StructureByteStride = right.Buffer.StructureByteStride;
        left.Buffer.Flags = ( D3D12_BUFFER_SRV_FLAGS )right.Buffer.Flags;
        break;
    case D3D12_SRV_DIMENSION_TEXTURE1D:
        left.Texture1D.MostDetailedMip = right.Texture1D.MostDetailedMip;
        left.Texture1D.MipLevels = right.Texture1D.MipLevels;
        left.Texture1D.ResourceMinLODClamp = right.Texture1D.ResourceMinLODClamp;
        break;
    case D3D12_SRV_DIMENSION_TEXTURE1DARRAY:
        left.Texture1DArray.MostDetailedMip = right.Texture1DArray.MostDetailedMip;
        left.Texture1DArray.MipLevels = right.Texture1DArray.MipLevels;
        left.Texture1DArray.FirstArraySlice = right.Texture1DArray.FirstArraySlice;
        left.Texture1DArray.ArraySize = right.Texture1DArray.ArraySize;
        left.Texture1DArray.ResourceMinLODClamp = right.Texture1DArray.ResourceMinLODClamp;
        break;
    case D3D12_SRV_DIMENSION_TEXTURE2D:
        left.Texture2D.MostDetailedMip = right.Texture2D.MostDetailedMip;
        left.Texture2D.MipLevels = right.Texture2D.MipLevels;
        left.Texture2D.PlaneSlice = right.Texture2D.PlaneSlice;
        left.Texture2D.ResourceMinLODClamp = right.Texture2D.ResourceMinLODClamp;
        break;
    case D3D12_SRV_DIMENSION_TEXTURE2DARRAY:
        left.Texture2DArray.MostDetailedMip = right.Texture2DArray.MostDetailedMip;
        left.Texture2DArray.MipLevels = right.Texture2DArray.MipLevels;
        left.Texture2DArray.FirstArraySlice = right.Texture2DArray.FirstArraySlice;
        left.Texture2DArray.ArraySize = right.Texture2DArray.ArraySize;
        left.Texture2DArray.PlaneSlice = right.Texture2DArray.PlaneSlice;
        left.Texture2DArray.ResourceMinLODClamp = right.Texture2DArray.ResourceMinLODClamp;
        break;
    case D3D12_SRV_DIMENSION_TEXTURE2DMS:
        break;
    case D3D12_SRV_DIMENSION_TEXTURE2DMSARRAY:
        left.Texture2DMSArray.FirstArraySlice = right.Texture2DMSArray.FirstArraySlice;
        left.Texture2DMSArray.ArraySize = right.Texture2DMSArray.ArraySize;
        break;
    case D3D12_SRV_DIMENSION_TEXTURE3D:
        left.Texture3D.MostDetailedMip = right.Texture3D.MostDetailedMip;
        left.Texture3D.MipLevels = right.Texture3D.MipLevels;
        left.Texture3D.ResourceMinLODClamp = right.Texture3D.ResourceMinLODClamp;
        break;
    case D3D12_SRV_DIMENSION_TEXTURECUBE:
        left.TextureCube.MostDetailedMip = right.TextureCube.MostDetailedMip;
        left.TextureCube.MipLevels = right.TextureCube.MipLevels;
        left.TextureCube.ResourceMinLODClamp = right.TextureCube.ResourceMinLODClamp;
        break;
    case D3D12_SRV_DIMENSION_TEXTURECUBEARRAY:
        left.TextureCubeArray.MostDetailedMip = right.TextureCubeArray.MostDetailedMip;
        left.TextureCubeArray.MipLevels = right.TextureCubeArray.MipLevels;
        left.TextureCubeArray.First2DArrayFace = right.TextureCubeArray.First2DArrayFace;
        left.TextureCubeArray.NumCubes = right.TextureCubeArray.NumCubes;
        left.TextureCubeArray.ResourceMinLODClamp = right.TextureCubeArray.ResourceMinLODClamp;
        break;
    case D3D12_SRV_DIMENSION_RAYTRACING_ACCELERATION_STRUCTURE:
        left.RaytracingAccelerationStructure.Location = right.RaytracingAccelerationStructure.Location;
        break;
    }
}

void Assign( D3D12_UNORDERED_ACCESS_VIEW_DESC& left, D3D12UnorderedAccessViewDesc% right )
{
    left.Format = ( DXGI_FORMAT )right.Format;
    left.ViewDimension = ( D3D12_UAV_DIMENSION )right.ViewDimension;

    switch ( left.ViewDimension )
    {
    case D3D12_UAV_DIMENSION_BUFFER:
        left.Buffer.FirstElement = right.Buffer.FirstElement;
        left.Buffer.NumElements = right.Buffer.NumElement;
        left.Buffer.StructureByteStride = right.Buffer.StructureByteStride;
        left.Buffer.CounterOffsetInBytes = right.Buffer.CounterOffsetInBytes;
        left.Buffer.Flags = ( D3D12_BUFFER_UAV_FLAGS )right.Buffer.Flags;
        break;
    case D3D12_UAV_DIMENSION_TEXTURE1D:
        left.Texture1D.MipSlice = right.Texture1D.MipSlice;
        break;
    case D3D12_UAV_DIMENSION_TEXTURE1DARRAY:
        left.Texture1DArray.MipSlice = right.Texture1DArray.MipSlice;
        left.Texture1DArray.FirstArraySlice = right.Texture1DArray.FirstArraySlice;
        left.Texture1DArray.ArraySize = right.Texture1DArray.ArraySize;
        break;
    case D3D12_UAV_DIMENSION_TEXTURE2D:
        left.Texture2D.MipSlice = right.Texture2D.MipSlice;
        left.Texture2D.PlaneSlice = right.Texture2D.PlaneSlice;
        break;
    case D3D12_UAV_DIMENSION_TEXTURE2DARRAY:
        left.Texture2DArray.MipSlice = right.Texture2DArray.MipSlice;
        left.Texture2DArray.FirstArraySlice = right.Texture2DArray.FirstArraySlice;
        left.Texture2DArray.ArraySize = right.Texture2DArray.ArraySize;
        left.Texture2DArray.PlaneSlice = right.Texture2DArray.PlaneSlice;
        break;
    case D3D12_UAV_DIMENSION_TEXTURE3D:
        left.Texture3D.MipSlice = right.Texture3D.MipSlice;
        left.Texture3D.FirstWSlice = right.Texture3D.FirstWSlice;
        left.Texture3D.WSize = right.Texture3D.WSize;
        break;
    }
}

void Assign( D3D12_RENDER_TARGET_VIEW_DESC& left, D3D12RenderTargetViewDesc% right )
{
    left.Format = ( DXGI_FORMAT )right.Format;
    left.ViewDimension = ( D3D12_RTV_DIMENSION )right.ViewDimension;

    switch ( left.ViewDimension )
    {
    case D3D12_RTV_DIMENSION_BUFFER:
        left.Buffer.FirstElement = right.Buffer.FirstElement;
        left.Buffer.NumElements = right.Buffer.NumElement;
        break;
    case D3D12_RTV_DIMENSION_TEXTURE1D:
        left.Texture1D.MipSlice = right.Texture1D.MipSlice;
        break;
    case D3D12_RTV_DIMENSION_TEXTURE1DARRAY:
        left.Texture1DArray.MipSlice = right.Texture1DArray.MipSlice;
        left.Texture1DArray.FirstArraySlice = right.Texture1DArray.FirstArraySlice;
        left.Texture1DArray.ArraySize = right.Texture1DArray.ArraySize;
        break;
    case D3D12_RTV_DIMENSION_TEXTURE2D:
        left.Texture2D.MipSlice = right.Texture2D.MipSlice;
        left.Texture2D.PlaneSlice = right.Texture2D.PlaneSlice;
        break;
    case D3D12_RTV_DIMENSION_TEXTURE2DARRAY:
        left.Texture2DArray.MipSlice = right.Texture2DArray.MipSlice;
        left.Texture2DArray.FirstArraySlice = right.Texture2DArray.FirstArraySlice;
        left.Texture2DArray.ArraySize = right.Texture2DArray.ArraySize;
        left.Texture2DArray.PlaneSlice = right.Texture2DArray.PlaneSlice;
        break;
    case D3D12_RTV_DIMENSION_TEXTURE2DMS:
        break;
    case D3D12_RTV_DIMENSION_TEXTURE2DMSARRAY:
        left.Texture2DMSArray.FirstArraySlice = right.Texture2DMSArray.FirstArraySlice;
        left.Texture2DMSArray.ArraySize = right.Texture2DMSArray.ArraySize;
        break;
    case D3D12_RTV_DIMENSION_TEXTURE3D:
        left.Texture3D.MipSlice = right.Texture3D.MipSlice;
        left.Texture3D.FirstWSlice = right.Texture3D.FirstWSlice;
        left.Texture3D.WSize = right.Texture3D.WSize;
        break;
    }
}

void Assign( D3D12_DEPTH_STENCIL_VIEW_DESC& left, D3D12DepthStencilViewDesc% right )
{
    left.Format = ( DXGI_FORMAT )right.Format;
    left.ViewDimension = ( D3D12_DSV_DIMENSION )right.ViewDimension;
    left.Flags = ( D3D12_DSV_FLAGS )right.Flags;

    switch ( left.ViewDimension )
    {
    case D3D12_DSV_DIMENSION_TEXTURE1D:
        left.Texture1D.MipSlice = right.Texture1D.MipSlice;
        break;
    case D3D12_DSV_DIMENSION_TEXTURE1DARRAY:
        left.Texture1DArray.MipSlice = right.Texture1DArray.MipSlice;
        left.Texture1DArray.FirstArraySlice = right.Texture1DArray.FirstArraySlice;
        left.Texture1DArray.ArraySize = right.Texture1DArray.ArraySize;
        break;
    case D3D12_DSV_DIMENSION_TEXTURE2D:
        left.Texture2D.MipSlice = right.Texture2D.MipSlice;
        break;
    case D3D12_DSV_DIMENSION_TEXTURE2DARRAY:
        left.Texture2DArray.MipSlice = right.Texture2DArray.MipSlice;
        left.Texture2DArray.FirstArraySlice = right.Texture2DArray.FirstArraySlice;
        left.Texture2DArray.ArraySize = right.Texture2DArray.ArraySize;
        break;
    case D3D12_DSV_DIMENSION_TEXTURE2DMS:
        break;
    case D3D12_DSV_DIMENSION_TEXTURE2DMSARRAY:
        left.Texture2DMSArray.FirstArraySlice = right.Texture2DMSArray.FirstArraySlice;
        left.Texture2DMSArray.ArraySize = right.Texture2DMSArray.ArraySize;
        break;
    }
}

void Assign( D3D12_ROOT_SIGNATURE_DESC& left, D3D12RootSignatureDesc% right )
{
    if ( right.Parameters != nullptr )
    {
        left.NumParameters = ( UINT )right.Parameters->Count;
        left.pParameters = new D3D12_ROOT_PARAMETER[left.NumParameters];

        for ( int i = 0; i < ( int )left.NumParameters; ++i )
        {
            Assign( ( D3D12_ROOT_PARAMETER& )left.pParameters[i], right.Parameters[i] );
        }
    }
    else
    {
        left.NumStaticSamplers = 0;
        left.pStaticSamplers = nullptr;
    }

    if ( right.StaticSamplers != nullptr )
    {
        left.NumStaticSamplers = ( UINT )right.StaticSamplers->Count;
        left.pStaticSamplers = new D3D12_STATIC_SAMPLER_DESC[left.NumStaticSamplers];

        for ( int i = 0; i < ( int )left.NumStaticSamplers; ++i )
        {
            Assign( ( D3D12_STATIC_SAMPLER_DESC& )left.pStaticSamplers[i], right.StaticSamplers[i] );
        }
    }
    else
    {
        left.NumStaticSamplers = 0;
        left.pStaticSamplers = nullptr;
    }

    left.Flags = ( D3D12_ROOT_SIGNATURE_FLAGS )right.Flags;
}

void Assign( D3D12_ROOT_PARAMETER& left, D3D12RootParameter% right )
{
    left.ParameterType = ( D3D12_ROOT_PARAMETER_TYPE )right.ParameterType;
    switch ( left.ParameterType )
    {
    case D3D12_ROOT_PARAMETER_TYPE_CBV:
    case D3D12_ROOT_PARAMETER_TYPE_SRV:
    case D3D12_ROOT_PARAMETER_TYPE_UAV:
        Assign( left.Descriptor, right.Descriptor );
        break;
    case D3D12_ROOT_PARAMETER_TYPE_32BIT_CONSTANTS:
        Assign( left.Constants, right.Constants );
        break;
    case D3D12_ROOT_PARAMETER_TYPE_DESCRIPTOR_TABLE:
        Assign( left.DescriptorTable, right.DescriptorTable );
        break;
    }
    left.ShaderVisibility = ( D3D12_SHADER_VISIBILITY )right.ShaderVisibility;
}

void Assign( D3D12_STATIC_SAMPLER_DESC& left, D3D12StaticSamplerDesc% right )
{
    left.Filter = ( D3D12_FILTER )right.Filter;
    left.AddressU = ( D3D12_TEXTURE_ADDRESS_MODE )right.AddressU;
    left.AddressV = ( D3D12_TEXTURE_ADDRESS_MODE )right.AddressV;
    left.AddressW = ( D3D12_TEXTURE_ADDRESS_MODE )right.AddressW;
    left.MipLODBias = right.MipLODBias;
    left.MaxAnisotropy = right.MaxAnisotropy;
    left.ComparisonFunc = ( D3D12_COMPARISON_FUNC )right.ComparisonFunc;
    left.BorderColor = ( D3D12_STATIC_BORDER_COLOR )right.BorderColor;
    left.MinLOD = right.MinLOD;
    left.MaxLOD = right.MaxLOD;
    left.ShaderRegister = right.ShaderRegister;
    left.RegisterSpace = right.RegisterSpace;
    left.ShaderVisibility = ( D3D12_SHADER_VISIBILITY )right.ShaderVisibility;
}

void Assign( D3D12_ROOT_DESCRIPTOR& left, D3D12RootDescriptor% right )
{
    left.RegisterSpace = right.RegisterSpace;
    left.ShaderRegister = right.ShaderRegister;
}

void Assign( D3D12_ROOT_CONSTANTS& left, D3D12RootConstants% right )
{
    left.Num32BitValues = right.Num32BitValues;
    left.RegisterSpace = right.RegisterSpace;
    left.ShaderRegister = right.ShaderRegister;
}

void Assign( D3D12_ROOT_DESCRIPTOR_TABLE& left, D3D12RootDescriptorTable% right )
{
    left.NumDescriptorRanges = right.DescriptorRanges->Count;
    left.pDescriptorRanges = new D3D12_DESCRIPTOR_RANGE[left.NumDescriptorRanges];
    for ( int i = 0; i < ( int )left.NumDescriptorRanges; ++i )
    {
        Assign( ( D3D12_DESCRIPTOR_RANGE& )left.pDescriptorRanges[i], right.DescriptorRanges[i] );
    }
}

void Assign( D3D12_DESCRIPTOR_RANGE& left, D3D12DescriptorRange% right )
{
    left.RangeType = ( D3D12_DESCRIPTOR_RANGE_TYPE )right.RangeType;
    left.NumDescriptors = right.NumDescriptors;
    left.BaseShaderRegister = right.BaseShaderRegister;
    left.RegisterSpace = right.RegisterSpace;
    left.OffsetInDescriptorsFromTableStart = right.OffsetInDescriptorsFromTableStart;
}

void Assign( D3D12_VIEWPORT& left, D3D12Viewport% right )
{
    left.TopLeftX = right.TopLeftX;
    left.TopLeftY = right.TopLeftY;
    left.Width = right.Width;
    left.Height = right.Height;
    left.MinDepth = right.MinDepth;
    left.MaxDepth = right.MaxDepth;
}

void Assign( D3D12_RECT& left, SC::Engine::Runtime::Core::Numerics::Rectangle% right )
{
    left.left = (LONG)right.Left;
    left.top = (LONG)right.Top;
    left.right = (LONG)right.Right;
    left.bottom = (LONG)right.Bottom;
}

void Assign( D3D12_RESOURCE_BARRIER& left, D3D12ResourceBarrier% right )
{
    left.Type = ( D3D12_RESOURCE_BARRIER_TYPE )right.Type;
    left.Flags = ( D3D12_RESOURCE_BARRIER_FLAGS )right.Flags;

    switch ( left.Type )
    {
    case D3D12_RESOURCE_BARRIER_TYPE_TRANSITION:
        Assign( left.Transition, right.Transition );
        break;
    case D3D12_RESOURCE_BARRIER_TYPE_ALIASING:
        Assign( left.Aliasing, right.Aliasing );
        break;
    case D3D12_RESOURCE_BARRIER_TYPE_UAV:
        Assign( left.UAV, right.UAV );
        break;
    }
}

void Assign( D3D12_RESOURCE_TRANSITION_BARRIER& left, D3D12ResourceTransitionBarrier% right )
{
    left.pResource = Take<::ID3D12Resource>( right.pResource );
    left.StateBefore = ( D3D12_RESOURCE_STATES )right.StateBefore;
    left.StateAfter = ( D3D12_RESOURCE_STATES )right.StateAfter;
    left.Subresource = right.Subresource;
}

void Assign( D3D12_RESOURCE_ALIASING_BARRIER& left, D3D12ResourceAliasingBarrier% right )
{
    left.pResourceBefore = Take<::ID3D12Resource>( right.pResourceBefore );
    left.pResourceAfter = Take<::ID3D12Resource>( right.pResourceAfter );
}

void Assign( D3D12_RESOURCE_UAV_BARRIER& left, D3D12ResourceUAVBarrier% right )
{
    left.pResource = Take<::ID3D12Resource>( right.pResource );
}

void Assign( D3D12_INDEX_BUFFER_VIEW& left, D3D12IndexBufferView% right )
{
    left.BufferLocation = right.BufferLocation;
    left.Format = ( DXGI_FORMAT )right.Format;
    left.SizeInBytes = right.SizeInBytes;
}

void Assign( D3D12_VERTEX_BUFFER_VIEW& left, D3D12VertexBufferView% right )
{
    left.BufferLocation = right.BufferLocation;
    left.SizeInBytes = right.SizeInBytes;
    left.StrideInBytes = right.StrideInBytes;
}

void Assign( D3D12_STREAM_OUTPUT_BUFFER_VIEW& left, D3D12StreamOutputBufferView% right )
{
    left.BufferLocation = right.BufferLocation;
    left.SizeInBytes = right.SizeInBytes;
    left.BufferFilledSizeLocation = right.BufferFilledSizeLocation;
}

void Assign( D3D12_DISCARD_REGION& left, D3D12DiscardRegion% right )
{
    left.NumRects = right.Rects->Count;
    left.pRects = new D3D12_RECT[right.Rects->Count];
    left.FirstSubresource = right.FirstSubresource;
    left.NumSubresources = right.NumSubresources;

    for ( int i = 0; i < right.Rects->Count; ++i )
    {
        Assign( ( D3D12_RECT& )left.pRects[i], right.Rects[i] );
    }
}

void Assign( D3D12_SAMPLER_DESC& left, D3D12SamplerDesc% right )
{
    left.Filter = ( D3D12_FILTER )right.Filter;
    left.AddressU = ( D3D12_TEXTURE_ADDRESS_MODE )right.AddressU;
    left.AddressV = ( D3D12_TEXTURE_ADDRESS_MODE )right.AddressV;
    left.AddressW = ( D3D12_TEXTURE_ADDRESS_MODE )right.AddressW;
    left.MipLODBias = right.MipLODBias;
    left.MaxAnisotropy = right.MaxAnisotropy;
    left.ComparisonFunc = ( D3D12_COMPARISON_FUNC )right.ComparisonFunc;
    left.BorderColor[0] = (float)right.BorderColor.R;
    left.BorderColor[1] = (float)right.BorderColor.G;
    left.BorderColor[2] = (float)right.BorderColor.B;
    left.BorderColor[3] = (float)right.BorderColor.A;
    left.MinLOD = right.MinLOD;
    left.MaxLOD = right.MaxLOD;
}

void Assign( D3D12ResourceAllocationInfo% left, D3D12_RESOURCE_ALLOCATION_INFO& right )
{
    left.SizeInBytes = right.SizeInBytes;
    left.Alignment = right.Alignment;
}

void Assign( D3D12_CLEAR_VALUE& left, D3D12ClearValue% right )
{
    left.Format = ( DXGI_FORMAT )right.Format;
    
    auto t = right.CurrentType;
    if ( t == SC::Engine::Runtime::Core::Numerics::Color::typeid )
    {
        auto color = right.Color;
        left.Color[0] = (float)right.Color.R;
        left.Color[1] = (float)right.Color.G;
        left.Color[2] = (float)right.Color.B;
        left.Color[3] = (float)right.Color.A;
    }
    else
    {
        auto ds = right.DepthStencil;
        left.DepthStencil.Depth = ds.Depth;
        left.DepthStencil.Stencil = ds.Stencil;
    }
}

void Assign( D3D12_PLACED_SUBRESOURCE_FOOTPRINT& left, D3D12PlacedSubresourceFootprint% right )
{
    left.Offset = right.Offset;
    Assign( left.Footprint, right.Footprint );
}

void Assign( D3D12PlacedSubresourceFootprint% left, D3D12_PLACED_SUBRESOURCE_FOOTPRINT& right )
{
    left.Offset = right.Offset;
    Assign( left.Footprint, right.Footprint );
}

void Assign( D3D12SubresourceFootprint% left, D3D12_SUBRESOURCE_FOOTPRINT& right )
{
    left.Format = ( DXGIFormat )right.Format;
    left.Width = right.Width;
    left.Height = right.Height;
    left.Depth = right.Depth;
    left.RowPitch = right.RowPitch;
}

void Assign( D3D12_SUBRESOURCE_FOOTPRINT& left, D3D12SubresourceFootprint% right )
{
    left.Format = ( DXGI_FORMAT )right.Format;
    left.Width = right.Width;
    left.Height = right.Height;
    left.Depth = right.Depth;
    left.RowPitch = right.RowPitch;
}

void Assign( D3D12_QUERY_HEAP_DESC& left, D3D12QueryHeapDesc% right )
{
    left.Type = ( D3D12_QUERY_HEAP_TYPE )right.Type;
    left.Count = right.Count;
    left.NodeMask = right.NodeMask;
}

void Assign( D3D12_COMMAND_SIGNATURE_DESC& left, D3D12CommandSignatureDesc% right )
{
    left.ByteStride = right.ByteStride;
    left.NumArgumentDescs = right.ArgumentDescs->Count;
    left.pArgumentDescs = new D3D12_INDIRECT_ARGUMENT_DESC[right.ArgumentDescs->Count];
    left.NodeMask = right.NodeMask;

    for ( int i = 0; i < right.ArgumentDescs->Count; ++i )
    {
        Assign( ( D3D12_INDIRECT_ARGUMENT_DESC& )left.pArgumentDescs[i], right.ArgumentDescs[i] );
    }
}

void Assign( D3D12_INDIRECT_ARGUMENT_DESC& left, D3D12IndirectArgumentDesc% right )
{
    left.Type = ( D3D12_INDIRECT_ARGUMENT_TYPE )right.Type;
    
    switch ( left.Type )
    {
    case D3D12_INDIRECT_ARGUMENT_TYPE_VERTEX_BUFFER_VIEW:
    {
        left.VertexBuffer.Slot = right.VertexBuffer.Slot;
        break;
    }
    case D3D12_INDIRECT_ARGUMENT_TYPE_CONSTANT:
    {
        auto constant = right.Constant;
        left.Constant.RootParameterIndex = constant.RootParameterIndex;
        left.Constant.DestOffsetIn32BitValues = constant.DestOffsetIn32BitValues;
        left.Constant.Num32BitValuesToSet = constant.Num32BitValuesToSet;
        break;
    }
    case D3D12_INDIRECT_ARGUMENT_TYPE_CONSTANT_BUFFER_VIEW:
    {
        auto cbv = right.ConstantBufferView;
        left.ConstantBufferView.RootParameterIndex = cbv.RootParameterIndex;
        break;
    }
    case D3D12_INDIRECT_ARGUMENT_TYPE_SHADER_RESOURCE_VIEW:
    {
        auto srv = right.ShaderResourceView;
        left.ShaderResourceView.RootParameterIndex = srv.RootParameterIndex;
        break;
    }
    case D3D12_INDIRECT_ARGUMENT_TYPE_UNORDERED_ACCESS_VIEW:
    {
        auto srv = right.UnorderedAccessView;
        left.UnorderedAccessView.RootParameterIndex = srv.RootParameterIndex;
        break;
    }
    }
}

void Assign( D3D12_TEXTURE_COPY_LOCATION& left, D3D12TextureCopyLocation% right )
{
    left.pResource = Take<::ID3D12Resource>( right.pResource );
    left.Type = ( D3D12_TEXTURE_COPY_TYPE )right.Type;

    switch ( left.Type )
    {
    case D3D12_TEXTURE_COPY_TYPE_PLACED_FOOTPRINT:
        Assign( left.PlacedFootprint, right.PlacedFootprint );
        break;
    case D3D12_TEXTURE_COPY_TYPE_SUBRESOURCE_INDEX:
        left.SubresourceIndex = right.SubresourceIndex;
        break;
    }
}

void Cleanup( D3D12_STREAM_OUTPUT_DESC& block )
{
    SafeDeleteArray( block.pSODeclaration );
    SafeDeleteArray( block.pBufferStrides );
}

void Cleanup( D3D12_GRAPHICS_PIPELINE_STATE_DESC& block )
{
    Cleanup( block.StreamOutput );
    Cleanup( block.InputLayout );
}

void Cleanup( D3D12_INPUT_LAYOUT_DESC& block )
{
    SafeDeleteArray( block.pInputElementDescs );
}

void Cleanup( D3D12_SO_DECLARATION_ENTRY& block )
{
    SafeDeleteArray( block.SemanticName );
}

void Cleanup( D3D12_ROOT_SIGNATURE_DESC& block )
{
    for ( int i = 0; i < ( int )block.NumParameters; ++i )
    {
        if ( block.pParameters[i].ParameterType == D3D12_ROOT_PARAMETER_TYPE_DESCRIPTOR_TABLE )
        {
            Cleanup( ( D3D12_ROOT_DESCRIPTOR_TABLE& )block.pParameters[i].DescriptorTable );
        }
    }
    SafeDeleteArray( block.pParameters );
    SafeDeleteArray( block.pStaticSamplers );
}

void Cleanup( D3D12_ROOT_DESCRIPTOR_TABLE& block )
{
    SafeDeleteArray( block.pDescriptorRanges );
}

void Cleanup( D3D12_DISCARD_REGION& block )
{
    SafeDeleteArray( block.pRects );
}

void Cleanup( D3D12_COMMAND_SIGNATURE_DESC& block )
{
    SafeDeleteArray( block.pArgumentDescs );
}