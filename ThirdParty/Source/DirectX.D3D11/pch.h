// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

#undef _MANAGED

#include <Windows.h>
#include <d3d11.h>
#include <d3d11on12.h>
#include <wrl/client.h>
#include <vector>
#include <msclr/marshal.h>
#include <string>

#undef RegisterClass

using Microsoft::WRL::ComPtr;

using byte_ = unsigned __int8;
using sbyte_ = __int8;
using short_ = __int16;
using ushort_ = unsigned __int16;
using int_ = __int32;
using uint_ = unsigned __int32;
using long_ = __int64;
using ulong_ = unsigned __int64;

#include "D3D11.h"
#include "CComObject.h"
#include "CD3D11Device.h"
#include "CD3D11DeviceChild.h"
#include "CD3D11DeviceContext.h"
#include "CD3D11On12Device.h"
#include "CD3D11Resource.h"

template< class T >
T* Take( SC::ThirdParty::DirectX::IUnknown^ pUnknown )
{
	if ( pUnknown != nullptr )
	{
		auto ref = ( SC::ThirdParty::DirectX::ComObject^ )pUnknown;
		return ( T* )ref->Handle.ToPointer();
	}
	else
	{
		return nullptr;
	}
}

template< class T >
void SafeDeleteArray( T*& ptr )
{
	if ( ptr )
	{
		delete[] ptr;
		ptr = nullptr;
	}
}

template< class T >
void SafeDelete( T*& ptr )
{
	if ( ptr )
	{
		delete ptr;
		ptr = nullptr;
	}
}

System::Guid FromGUID( const _GUID& guid );
_GUID ToGUID( System::Guid& guid );

void Assign( std::wstring& left, System::String^ right );
void Assign( System::String^% left, std::wstring& right );
void Assign( D3D11_RESOURCE_FLAGS& left, SC::ThirdParty::DirectX::D3D11ResourceFlags% right );