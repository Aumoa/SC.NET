// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using SC::ThirdParty::DirectX::CD3D12PipelineState;

CD3D12PipelineState::CD3D12PipelineState( ::ID3D12PipelineState* pPipelineState ) : CD3D12Pageable( pPipelineState )
{
	this->pPipelineState = pPipelineState;
}

void CD3D12PipelineState::RegisterClass()
{
	RegisterCLSID( ID3D12PipelineState::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

auto CD3D12PipelineState::GetCachedBlob() -> ID3DBlob^
{
	ComPtr<::ID3D10Blob> pBlob;
	HR( pPipelineState->GetCachedBlob( &pBlob ) );

	return ( ID3DBlob^ )CoCreateInstance( ID3DBlob::typeid->GUID, IntPtr( pBlob.Detach() ) );
}

auto CD3D12PipelineState::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD3D12PipelineState( ( ::ID3D12PipelineState* )pUnknown.ToPointer() );
}