// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::DirectX
{
	ref class CDXGIAdapter : CDXGIObject, IDXGIAdapter
	{
		::IDXGIAdapter* pAdapter;

		virtual System::Collections::IEnumerator^ GetEnumerator1() sealed = System::Collections::IEnumerable::GetEnumerator;

	public:
		CDXGIAdapter( ::IDXGIAdapter* pAdapter );
		static void RegisterClass();

		System::String^ ToString() override;

		virtual System::Collections::Generic::IEnumerator<IDXGIOutput^>^ GetEnumerator();

		virtual DXGIAdapterDesc GetDesc();
		virtual System::Nullable<long long> CheckInterfaceSupport( System::Guid interfaceName );

	private:
		static IUnknown^ CoCreateInstance( System::IntPtr pUnknown )
		{
			return gcnew CDXGIAdapter( ( ::IDXGIAdapter* )pUnknown.ToPointer() );
		}
	};
}