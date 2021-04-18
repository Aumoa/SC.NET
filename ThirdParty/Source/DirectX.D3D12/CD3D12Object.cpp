// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::ThirdParty::DirectX;

using namespace System;
using namespace System::Runtime::InteropServices;

CD3D12Object::CD3D12Object( ::ID3D12Object* pObject ) : CComObject( pObject )
{
	this->pObject = pObject;
}

void CD3D12Object::RegisterClass()
{
	RegisterCLSID( ID3D12Object::typeid->GUID, gcnew CoCreateInstanceDelegate( &CoCreateInstance ) );
}

void CD3D12Object::SetPrivateData( Guid riid, Object^ data )
{
	HR( pObject->SetPrivateData( ToGUID( riid ), sizeof( void* ), GCHandle::ToIntPtr( GCHandle::Alloc( data, GCHandleType::Weak ) ).ToPointer() ) );
}

Object^ CD3D12Object::GetPrivateData( Guid iid )
{
	UINT sizeInBytes = sizeof( void* );
	void* data = nullptr;
	HR( pObject->GetPrivateData( ToGUID( iid ), &sizeInBytes, &data ) );

	return GCHandle::FromIntPtr( IntPtr( data ) ).Target;
}

void CD3D12Object::SetName( String^ name )
{
	std::wstring name_;
}

auto CD3D12Object::CoCreateInstance( IntPtr pUnknown ) -> IUnknown^
{
	return gcnew CD3D12Object( ( ::ID3D12Object* )pUnknown.ToPointer() );
}