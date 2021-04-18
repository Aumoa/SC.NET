// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::ThirdParty::DirectX;

using namespace System;
using namespace System::Collections::Generic;

using namespace std;

Guid FromGUID( const _GUID& guid )
{
    return System::Guid(
        guid.Data1, guid.Data2, guid.Data3,
        guid.Data4[0], guid.Data4[1],
        guid.Data4[2], guid.Data4[3],
        guid.Data4[4], guid.Data4[5],
        guid.Data4[6], guid.Data4[7]
    );
}

_GUID ToGUID( Guid& guid )
{
    cli::array<System::Byte>^ guidData = guid.ToByteArray();
    pin_ptr<System::Byte> data = &( guidData[0] );

    return *( _GUID* )data;
}

void Assign( wstring& left, String^ right )
{
    left.resize( right->Length + 1 );

    for ( int i = 0; i < right->Length; ++i )
    {
        left[i] = right[i];
    }
}

void Assign( String^% left, wstring& right )
{
    left = gcnew String( right.c_str() );
}

void Assign( D3D11_RESOURCE_FLAGS& left, D3D11ResourceFlags% right )
{
    left.BindFlags = ( UINT )right.BindFlags;
    left.MiscFlags = ( UINT )right.MiscFlags;
    left.CPUAccessFlags = ( UINT )right.CPUAccessFlags;
    left.StructureByteStride = right.StructureByteStride;
}