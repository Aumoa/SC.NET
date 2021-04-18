// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::ThirdParty::DirectX;

using namespace System;
using namespace System::Collections::Generic;

System::Collections::IEnumerator^ CDXGIAdapter::GetEnumerator1()
{
	return GetEnumerator();
}

CDXGIAdapter::CDXGIAdapter( ::IDXGIAdapter* pAdapter ) : CDXGIObject( pAdapter )
{
	this->pAdapter = pAdapter;
}

void CDXGIAdapter::RegisterClass()
{
	RegisterCLSID( IDXGIAdapter::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

String^ CDXGIAdapter::ToString()
{
	auto desc = GetDesc();
	return String::Format(L"IDXGIAdapter: {0}", desc.Description);
}

auto CDXGIAdapter::GetEnumerator() -> IEnumerator<IDXGIOutput^>^
{
	return gcnew OutputEnumerator( pAdapter );
}

DXGIAdapterDesc CDXGIAdapter::GetDesc()
{
	DXGI_ADAPTER_DESC desc;
	HR( pAdapter->GetDesc( &desc ) );

	DXGIAdapterDesc desc_;
	Assign( desc_, desc );

	return desc_;
}

Nullable<long long> CDXGIAdapter::CheckInterfaceSupport( Guid interfaceName )
{
	LARGE_INTEGER v;
	if ( FAILED( pAdapter->CheckInterfaceSupport( ToGUID( interfaceName ), &v ) ) )
	{
		return Nullable<long long>();
	}
	return v.QuadPart;
}