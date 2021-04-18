// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;
using namespace System::Runtime::InteropServices;

using SC::ThirdParty::DirectX::CDXGIObject;

CDXGIObject::CDXGIObject( ::IDXGIObject* pObject ) : CComObject( pObject )
{
	this->pDXGIObject = pObject;
}

void CDXGIObject::RegisterClass()
{
	RegisterCLSID( IDXGIObject::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

void CDXGIObject::SetPrivateData( Guid iid, Object^ data )
{
	HR( pDXGIObject->SetPrivateData( ToGUID( iid ), sizeof( void* ), GCHandle::ToIntPtr( GCHandle::Alloc( data, GCHandleType::Weak ) ).ToPointer() ) );
}

System::Object^ CDXGIObject::GetPrivateData( Guid iid )
{
	UINT sizeInBytes = sizeof( void* );
	void* data = nullptr;
	HR( pDXGIObject->GetPrivateData( ToGUID( iid ), &sizeInBytes, &data ) );

	return GCHandle::FromIntPtr( IntPtr( data ) ).Target;
}

void CDXGIObject::GetParent( Guid iid, IUnknown^% ppUnknown )
{
	ComPtr<::IUnknown> pRef;
	HR( pDXGIObject->QueryInterface( ToGUID( iid ), &pRef ) );


	if ( iid == IUnknown::typeid->GUID )
	{
		ppUnknown = gcnew CComObject( pRef.Detach() );
	}
	else
	{
		ppUnknown = CoCreateInstance( iid, IntPtr( pRef.Detach() ) );
	}
}

auto CDXGIObject::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CDXGIObject( ( ::IDXGIObject* )pUnknown.ToPointer() );
}