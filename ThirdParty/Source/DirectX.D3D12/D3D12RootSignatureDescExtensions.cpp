// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::ThirdParty::DirectX;

using namespace System;

auto D3D12RootSignatureDescExtensions::Serialize( D3D12RootSignatureDesc _this ) -> ID3DBlob^
{
	return D3D12::D3D12SerializeRootSignature( _this );
}