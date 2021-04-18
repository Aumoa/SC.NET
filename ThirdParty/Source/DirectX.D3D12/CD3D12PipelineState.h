// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3D12PipelineState : CD3D12Pageable, ID3D12PipelineState
	{
		::ID3D12PipelineState* pPipelineState;

	public:
		CD3D12PipelineState( ::ID3D12PipelineState* pPipelineState );
		static void RegisterClass();

		virtual ID3DBlob^ GetCachedBlob();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}