// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3D12CommandSignature : CD3D12Pageable, ID3D12CommandSignature
	{
		::ID3D12CommandSignature* pCommandSignature;

	public:
		CD3D12CommandSignature( ::ID3D12CommandSignature* pCommandSignature );
		static void RegisterClass();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}