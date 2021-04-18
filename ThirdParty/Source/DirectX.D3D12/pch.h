// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

#undef _MANAGED

#include <Windows.h>
#include <d3d12.h>
#include <wrl/client.h>
#include <vector>
#include <msclr/marshal.h>
#include <string>

#undef RegisterClass

using Microsoft::WRL::ComPtr;

using byte_ = unsigned __int8;
using sbyte_ = __int8;
using short_ = __int16;
using ushort_ = unsigned __int16;
using int_ = __int32;
using uint_ = unsigned __int32;
using long_ = __int64;
using ulong_ = unsigned __int64;

#include "D3D12.h"
#include "CComObject.h"
#include "CD3D12Object.h"
#include "CD3D12DeviceChild.h"
#include "CD3D12Pageable.h"
#include "CD3D12PipelineState.h"
#include "CD3D12Heap.h"
#include "CD3D12Resource.h"
#include "CD3D12RootSignature.h"
#include "CD3D12QueryHeap.h"
#include "CD3D12Fence.h"
#include "CD3D12CommandAllocator.h"
#include "CD3D12CommandList.h"
#include "CD3D12CommandQueue.h"
#include "CD3D12CommandSignature.h"
#include "CD3D12DescriptorHeap.h"
#include "CD3D12Device.h"
#include "CD3D12GraphicsCommandList.h"
#include "CD3D12Debug.h"
#include "D3D12RootSignatureDescExtensions.h"

template< class T >
T* Take(SC::ThirdParty::DirectX::IUnknown^ pUnknown)
{
	auto ref = (SC::ThirdParty::DirectX::ComObject^)pUnknown;
	return ref ? (T*)ref->Handle.ToPointer() : nullptr;
}

template< class T >
void SafeDeleteArray(T*& ptr)
{
	if (ptr)
	{
		delete[] ptr;
		ptr = nullptr;
	}
}

template< class T >
void SafeDelete(T*& ptr)
{
	if (ptr)
	{
		delete ptr;
		ptr = nullptr;
	}
}

System::Guid FromGUID(const _GUID& guid);
_GUID ToGUID(System::Guid& guid);

void Assign( std::wstring& left, System::String^ right );
void Assign( System::String^% left, std::wstring& right );
void Assign( D3D12_HEAP_DESC& left, SC::ThirdParty::DirectX::D3D12HeapDesc% right );
void Assign( SC::ThirdParty::DirectX::D3D12HeapDesc% left, D3D12_HEAP_DESC& right );
void Assign( D3D12_HEAP_PROPERTIES& left, SC::ThirdParty::DirectX::D3D12HeapProperties% right );
void Assign( SC::ThirdParty::DirectX::D3D12HeapProperties% left, D3D12_HEAP_PROPERTIES& right );
void Assign( D3D12_RANGE& left, SC::ThirdParty::DirectX::D3D12Range% right );
void Assign( SC::ThirdParty::DirectX::D3D12Range% left, D3D12_RANGE& right );
void Assign( D3D12_RESOURCE_DESC& left, SC::ThirdParty::DirectX::D3D12ResourceDesc% right );
void Assign( SC::ThirdParty::DirectX::D3D12ResourceDesc% left, D3D12_RESOURCE_DESC& right );
void Assign( DXGI_SAMPLE_DESC& left, SC::ThirdParty::DirectX::DXGISampleDesc% right );
void Assign( SC::ThirdParty::DirectX::DXGISampleDesc% left, DXGI_SAMPLE_DESC& right );
void Assign( D3D12_BOX& left, SC::ThirdParty::DirectX::D3D12Box% right );
void Assign( SC::ThirdParty::DirectX::D3D12Box% left, D3D12_BOX& right );
void Assign( D3D12_TILED_RESOURCE_COORDINATE& left, SC::ThirdParty::DirectX::D3D12TiledResourceCoordinate% right );
void Assign( SC::ThirdParty::DirectX::D3D12TiledResourceCoordinate% left, D3D12_TILED_RESOURCE_COORDINATE& right );
void Assign( D3D12_TILE_REGION_SIZE& left, SC::ThirdParty::DirectX::D3D12TileRegionSize% right );
void Assign( SC::ThirdParty::DirectX::D3D12TileRegionSize% left, D3D12_TILE_REGION_SIZE& right );
void Assign( D3D12_COMMAND_QUEUE_DESC& left, SC::ThirdParty::DirectX::D3D12CommandQueueDesc% right );
void Assign( SC::ThirdParty::DirectX::D3D12CommandQueueDesc% left, D3D12_COMMAND_QUEUE_DESC& right );
void Assign( D3D12_DESCRIPTOR_HEAP_DESC& left, SC::ThirdParty::DirectX::D3D12DescriptorHeapDesc% right );
void Assign( SC::ThirdParty::DirectX::D3D12DescriptorHeapDesc% left, D3D12_DESCRIPTOR_HEAP_DESC& right );
void Assign( D3D12_GRAPHICS_PIPELINE_STATE_DESC& left, SC::ThirdParty::DirectX::D3D12GraphicsPipelineStateDesc% right );
void Assign( SC::ThirdParty::DirectX::D3D12GraphicsPipelineStateDesc% left, D3D12_GRAPHICS_PIPELINE_STATE_DESC& right );
void Assign( D3D12_SHADER_BYTECODE& left, SC::ThirdParty::DirectX::D3D12ShaderBytecode% right );
void Assign( SC::ThirdParty::DirectX::D3D12ShaderBytecode% left, D3D12_SHADER_BYTECODE& right );
void Assign( D3D12_STREAM_OUTPUT_DESC& left, SC::ThirdParty::DirectX::D3D12StreamOutputDesc% right );
void Assign( SC::ThirdParty::DirectX::D3D12StreamOutputDesc% left, D3D12_STREAM_OUTPUT_DESC& right );
void Assign( D3D12_BLEND_DESC& left, SC::ThirdParty::DirectX::D3D12BlendDesc% right );
void Assign( SC::ThirdParty::DirectX::D3D12BlendDesc% left, D3D12_BLEND_DESC& right );
void Assign( D3D12_RASTERIZER_DESC& left, SC::ThirdParty::DirectX::D3D12RasterizerDesc% right );
void Assign( SC::ThirdParty::DirectX::D3D12RasterizerDesc% left, D3D12_RASTERIZER_DESC& right );
void Assign( D3D12_DEPTH_STENCIL_DESC& left, SC::ThirdParty::DirectX::D3D12DepthStencilDesc% right );
void Assign( SC::ThirdParty::DirectX::D3D12DepthStencilDesc% left, D3D12_DEPTH_STENCIL_DESC& right );
void Assign( D3D12_INPUT_LAYOUT_DESC& left, SC::ThirdParty::DirectX::D3D12InputLayoutDesc% right );
void Assign( SC::ThirdParty::DirectX::D3D12InputLayoutDesc% left, D3D12_INPUT_LAYOUT_DESC& right );
void Assign( D3D12_CACHED_PIPELINE_STATE& left, SC::ThirdParty::DirectX::D3D12CachedPipelineState% right );
void Assign( SC::ThirdParty::DirectX::D3D12CachedPipelineState% left, D3D12_CACHED_PIPELINE_STATE& right );
void Assign( D3D12_SO_DECLARATION_ENTRY& left, SC::ThirdParty::DirectX::D3D12SODeclarationEntry% right );
void Assign( SC::ThirdParty::DirectX::D3D12SODeclarationEntry% left, D3D12_SO_DECLARATION_ENTRY& right );
void Assign( D3D12_RENDER_TARGET_BLEND_DESC& left, SC::ThirdParty::DirectX::D3D12RenderTargetBlendDesc% right );
void Assign( SC::ThirdParty::DirectX::D3D12RenderTargetBlendDesc% left, D3D12_RENDER_TARGET_BLEND_DESC& right );
void Assign( D3D12_DEPTH_STENCILOP_DESC& left, SC::ThirdParty::DirectX::D3D12DepthStencilOPDesc% right );
void Assign( SC::ThirdParty::DirectX::D3D12DepthStencilOPDesc% left, D3D12_DEPTH_STENCILOP_DESC& right );
void Assign( D3D12_INPUT_ELEMENT_DESC& left, SC::ThirdParty::DirectX::D3D12InputElementDesc% right );
void Assign( SC::ThirdParty::DirectX::D3D12InputElementDesc% left, D3D12_INPUT_ELEMENT_DESC& right );
void Assign( D3D12_COMPUTE_PIPELINE_STATE_DESC& left, SC::ThirdParty::DirectX::D3D12ComputePipelineStateDesc% right );
void Assign( SC::ThirdParty::DirectX::D3D12ComputePipelineStateDesc% left, D3D12_COMPUTE_PIPELINE_STATE_DESC& right );
void Assign( D3D12_CONSTANT_BUFFER_VIEW_DESC& left, SC::ThirdParty::DirectX::D3D12ConstantBufferViewDesc% right );
void Assign( D3D12_SHADER_RESOURCE_VIEW_DESC& left, SC::ThirdParty::DirectX::D3D12ShaderResourceViewDesc% right );
void Assign( D3D12_UNORDERED_ACCESS_VIEW_DESC& left, SC::ThirdParty::DirectX::D3D12UnorderedAccessViewDesc% right );
void Assign( D3D12_RENDER_TARGET_VIEW_DESC& left, SC::ThirdParty::DirectX::D3D12RenderTargetViewDesc% right );
void Assign( D3D12_DEPTH_STENCIL_VIEW_DESC& left, SC::ThirdParty::DirectX::D3D12DepthStencilViewDesc% right );
void Assign( D3D12_ROOT_SIGNATURE_DESC& left, SC::ThirdParty::DirectX::D3D12RootSignatureDesc% right );
void Assign( D3D12_ROOT_PARAMETER& left, SC::ThirdParty::DirectX::D3D12RootParameter% right );
void Assign( D3D12_STATIC_SAMPLER_DESC& left, SC::ThirdParty::DirectX::D3D12StaticSamplerDesc% right );
void Assign( D3D12_ROOT_DESCRIPTOR& left, SC::ThirdParty::DirectX::D3D12RootDescriptor% right );
void Assign( D3D12_ROOT_CONSTANTS& left, SC::ThirdParty::DirectX::D3D12RootConstants% right );
void Assign( D3D12_ROOT_DESCRIPTOR_TABLE& left, SC::ThirdParty::DirectX::D3D12RootDescriptorTable% right );
void Assign( D3D12_DESCRIPTOR_RANGE& left, SC::ThirdParty::DirectX::D3D12DescriptorRange% right );
void Assign( D3D12_VIEWPORT& left, SC::ThirdParty::DirectX::D3D12Viewport% right );
void Assign( D3D12_RECT& left, SC::Engine::Runtime::Core::Numerics::Rectangle% right );
void Assign( D3D12_RESOURCE_BARRIER& left, SC::ThirdParty::DirectX::D3D12ResourceBarrier% right );
void Assign( D3D12_RESOURCE_TRANSITION_BARRIER& left, SC::ThirdParty::DirectX::D3D12ResourceTransitionBarrier% right );
void Assign( D3D12_RESOURCE_ALIASING_BARRIER& left, SC::ThirdParty::DirectX::D3D12ResourceAliasingBarrier% right );
void Assign( D3D12_RESOURCE_UAV_BARRIER& left, SC::ThirdParty::DirectX::D3D12ResourceUAVBarrier% right );
void Assign( D3D12_INDEX_BUFFER_VIEW& left, SC::ThirdParty::DirectX::D3D12IndexBufferView% right );
void Assign( D3D12_VERTEX_BUFFER_VIEW& left, SC::ThirdParty::DirectX::D3D12VertexBufferView% right );
void Assign( D3D12_STREAM_OUTPUT_BUFFER_VIEW& left, SC::ThirdParty::DirectX::D3D12StreamOutputBufferView% right );
void Assign( D3D12_DISCARD_REGION& left, SC::ThirdParty::DirectX::D3D12DiscardRegion% right );
void Assign( D3D12_SAMPLER_DESC& left, SC::ThirdParty::DirectX::D3D12SamplerDesc% right );
void Assign( SC::ThirdParty::DirectX::D3D12ResourceAllocationInfo% left, D3D12_RESOURCE_ALLOCATION_INFO& right );
void Assign( D3D12_CLEAR_VALUE& left, SC::ThirdParty::DirectX::D3D12ClearValue% right );
void Assign( D3D12_PLACED_SUBRESOURCE_FOOTPRINT& left, SC::ThirdParty::DirectX::D3D12PlacedSubresourceFootprint% right );
void Assign( SC::ThirdParty::DirectX::D3D12PlacedSubresourceFootprint% left, D3D12_PLACED_SUBRESOURCE_FOOTPRINT& right );
void Assign( SC::ThirdParty::DirectX::D3D12SubresourceFootprint% left, D3D12_SUBRESOURCE_FOOTPRINT& right );
void Assign( D3D12_SUBRESOURCE_FOOTPRINT& left, SC::ThirdParty::DirectX::D3D12SubresourceFootprint% right );
void Assign( D3D12_QUERY_HEAP_DESC& left, SC::ThirdParty::DirectX::D3D12QueryHeapDesc% right );
void Assign( D3D12_COMMAND_SIGNATURE_DESC& left, SC::ThirdParty::DirectX::D3D12CommandSignatureDesc% right );
void Assign( D3D12_INDIRECT_ARGUMENT_DESC& left, SC::ThirdParty::DirectX::D3D12IndirectArgumentDesc% right );
void Assign( D3D12_TEXTURE_COPY_LOCATION& left, SC::ThirdParty::DirectX::D3D12TextureCopyLocation% right );

void Cleanup( D3D12_STREAM_OUTPUT_DESC& block );
void Cleanup( D3D12_GRAPHICS_PIPELINE_STATE_DESC& block );
void Cleanup( D3D12_INPUT_LAYOUT_DESC& block );
void Cleanup( D3D12_SO_DECLARATION_ENTRY& block );
void Cleanup( D3D12_ROOT_SIGNATURE_DESC& block );
void Cleanup( D3D12_ROOT_DESCRIPTOR_TABLE& block );
void Cleanup( D3D12_DISCARD_REGION& block );
void Cleanup( D3D12_COMMAND_SIGNATURE_DESC& block );