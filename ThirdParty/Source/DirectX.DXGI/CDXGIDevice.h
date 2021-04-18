// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CDXGIDevice : CDXGIObject, IDXGIDevice
	{
		::IDXGIDevice* pDevice;

	public:
		CDXGIDevice( ::IDXGIDevice* pDevice );
		static void RegisterClass();

		virtual IDXGIAdapter^ GetAdapter();
		virtual cli::array<DXGIResidency>^ QueryResourceResidency( System::Collections::Generic::IList<IUnknown^>^ unknowns );
		virtual void SetGPUThreadPriority( int priority );
		virtual int GetGPUThreadPriority();

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown )
		{
			return gcnew CDXGIDevice( ( ::IDXGIDevice* )pUnknown.ToPointer() );
		}
	};
}