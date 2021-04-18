// Copyright 2020 Aumoa.lib. All right reserved.

#pragma once

#undef _MANAGED
#define _D2D1_HELPER_H_
#define _D2D1_1HELPER_H_
#include <Windows.h>
#include <d2d1_1.h>
#include <dwrite.h>
#include <wrl/client.h>
#include <vector>
#include <string>
#include <msclr/marshal.h>

#undef RegisterClass

using Microsoft::WRL::ComPtr;

#include "D2D1.h"
#include "CComObject.h"
#include "CD2D1Resource.h"
#include "CD2D1Image.h"
#include "CD2D1Bitmap.h"
#include "CD2D1Bitmap1.h"
#include "CD2D1ColorContext.h"
#include "CD2D1RenderTarget.h"
#include "CD2D1DeviceContext.h"
#include "CD2D1Device.h"
#include "CD2D1Factory.h"
#include "CD2D1Brush.h"
#include "CD2D1SolidColorBrush.h"
#include "CD2D1SimplifiedGeometrySink.h"
#include "CD2D1GeometrySink.h"
#include "CD2D1Geometry.h"
#include "CD2D1PathGeometry.h"

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
void Assign( D2D1_PIXEL_FORMAT& left, SC::ThirdParty::DirectX::D2D1PixelFormat% right );
void Assign( SC::ThirdParty::DirectX::D2D1PixelFormat% left, D2D1_PIXEL_FORMAT& right );
void Assign( D2D1_COLOR_F& left, SC::Engine::Runtime::Core::Numerics::Color% right );
void Assign( SC::Engine::Runtime::Core::Numerics::Color% left, D2D1_COLOR_F& right );
void Assign( D2D1_BITMAP_PROPERTIES1& left, SC::ThirdParty::DirectX::D2D1BitmapProperties1% right );
void Assign( D2D1_CREATION_PROPERTIES& left, SC::ThirdParty::DirectX::D2D1CreationProperties% right );
void Assign( D2D1_MATRIX_3X2_F& left, SC::Engine::Runtime::Core::Numerics::Matrix3x2% right );
void Assign( SC::Engine::Runtime::Core::Numerics::Matrix3x2% left, D2D1_MATRIX_3X2_F& right );
void Assign( D2D1_RECT_F& left, SC::Engine::Runtime::Core::Numerics::Rectangle% right );
void Assign( D2D1_ROUNDED_RECT& left, SC::ThirdParty::DirectX::D2D1RoundedRect% right );
void Assign( D2D1_ELLIPSE& left, SC::ThirdParty::DirectX::D2D1Ellipse% right );
void Assign( D2D1_POINT_2F& left, SC::Engine::Runtime::Core::Numerics::Vector2% right );
void Assign( DWRITE_GLYPH_RUN& left, SC::ThirdParty::DirectX::DWriteGlyphRun% right );
void Assign( DWRITE_GLYPH_OFFSET& left, SC::ThirdParty::DirectX::DWriteGlyphOffset% right );

void Cleanup( DWRITE_GLYPH_RUN& value );