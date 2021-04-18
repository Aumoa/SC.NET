// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CD3D11On12Device : CComObject, ID3D11On12Device
	{
		::ID3D11On12Device* pDevice11On12;

	public:
		CD3D11On12Device( ::ID3D11On12Device* pDevice11On12 );
		static void RegisterClass();

		virtual void CreateWrappedResource( IUnknown^ pResource12, D3D11ResourceFlags resourceFlags, D3D12ResourceStates inState, D3D12ResourceStates outState, System::Guid riid, [System::Runtime::InteropServices::Out] IUnknown^% ppResource11 );
		virtual void AcquireWrappedResources( System::Collections::Generic::IList<ID3D11Resource^>^ ppResources );
		virtual void ReleaseWrappedResources( System::Collections::Generic::IList<ID3D11Resource^>^ ppResources );

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown );
	};
}