// Copyright 2020 Aumoa.lib. All right reserved.

using namespace System;

using namespace SC::Engine::Runtime::Core::Numerics;
using namespace SC::ThirdParty::DirectX;

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

void Assign( D2D1_PIXEL_FORMAT& left, D2D1PixelFormat% right )
{
    left.format = ( DXGI_FORMAT )right.Format;
    left.alphaMode = ( D2D1_ALPHA_MODE )right.AlphaMode;
}

void Assign( D2D1PixelFormat% left, D2D1_PIXEL_FORMAT& right )
{
    left.Format = ( DXGIFormat )right.format;
    left.AlphaMode = ( D2D1AlphaMode )right.alphaMode;
}

void Assign( D2D1_COLOR_F& left, Color% right )
{
    left.r = (FLOAT)right.R;
    left.g = (FLOAT)right.G;
    left.b = (FLOAT)right.B;
    left.a = (FLOAT)right.A;
}

void Assign( Color% left, D2D1_COLOR_F& right )
{
    left.R = right.r;
    left.G = right.g;
    left.B = right.b;
    left.A = right.a;
}

void Assign( D2D1_BITMAP_PROPERTIES1& left, D2D1BitmapProperties1% right )
{
    Assign( left.pixelFormat, right.PixelFormat );
    left.dpiX = right.DpiX;
    left.dpiY = right.DpiY;
    left.bitmapOptions = ( D2D1_BITMAP_OPTIONS )right.BitmapOptions;
    left.colorContext = Take<::ID2D1ColorContext>( right.ColorContext );
}

void Assign( D2D1_CREATION_PROPERTIES& left, D2D1CreationProperties% right )
{
    left.threadingMode = ( D2D1_THREADING_MODE )right.ThreadingMode;
    left.debugLevel = ( D2D1_DEBUG_LEVEL )right.DebugLevel;
    left.options = ( D2D1_DEVICE_CONTEXT_OPTIONS )right.Options;
}

void Assign( D2D1_MATRIX_3X2_F& left, Matrix3x2% right )
{
    left._11 = (FLOAT)right._11;
    left._12 = (FLOAT)right._12;
    left._21 = (FLOAT)right._21;
    left._22 = (FLOAT)right._22;
    left._31 = (FLOAT)right._31;
    left._32 = (FLOAT)right._32;
}

void Assign( Matrix3x2% left, D2D1_MATRIX_3X2_F& right )
{
    left._11 = right._11;
    left._12 = right._12;
    left._21 = right._21;
    left._22 = right._22;
    left._31 = right._31;
    left._32 = right._32;
}

void Assign( D2D1_RECT_F& left, SC::Engine::Runtime::Core::Numerics::Rectangle% right )
{
    left.left = (FLOAT)right.Left;
    left.top = (FLOAT)right.Top;
    left.right = (FLOAT)right.Right;
    left.bottom = (FLOAT)right.Bottom;
}

void Assign( D2D1_ROUNDED_RECT& left, D2D1RoundedRect% right )
{
    Assign( left.rect, right.Rect );
    left.radiusX = right.RadiusX;
    left.radiusY = right.RadiusY;
}

void Assign( D2D1_ELLIPSE& left, D2D1Ellipse% right )
{
    Assign( left.point, right.Point );
    left.radiusX = right.RadiusX;
    left.radiusY = right.RadiusY;
}

void Assign( D2D1_POINT_2F& left, Vector2% right )
{
    left.x = (FLOAT)right.X;
    left.y = (FLOAT)right.Y;
}

void Assign( DWRITE_GLYPH_RUN& left, DWriteGlyphRun% right )
{
    left.fontFace = Take<::IDWriteFontFace>( right.FontFace );
    left.fontEmSize = right.FontEmSize;
    left.glyphCount = right.GlyphCount;
    left.glyphIndices = new UINT16[left.glyphCount];
    if ( right.GlyphAdvances != nullptr ) left.glyphAdvances = new FLOAT[left.glyphCount];
    else left.glyphAdvances = nullptr;
    if ( right.GlyphOffsets != nullptr ) left.glyphOffsets = new DWRITE_GLYPH_OFFSET[left.glyphCount];
    else left.glyphOffsets = nullptr;
    left.isSideways = right.IsSideways;
    left.bidiLevel = right.BidiLevel;

    for ( UINT i = 0; i < left.glyphCount; ++i )
    {
        ( UINT16& )left.glyphIndices[i] = right.GlyphIndices[i];
        if ( left.glyphAdvances ) ( FLOAT& )left.glyphAdvances[i] = right.GlyphAdvances[i];
        if ( left.glyphOffsets ) Assign( ( DWRITE_GLYPH_OFFSET& )left.glyphOffsets[i], right.GlyphOffsets[i] );
    }
}

void Assign( DWRITE_GLYPH_OFFSET& left, DWriteGlyphOffset% right )
{
    left.advanceOffset = right.AdvanceOffset;
    left.ascenderOffset = right.AscenderOffset;
}

void Cleanup( DWRITE_GLYPH_RUN& value )
{
    delete[] value.glyphIndices;
    if ( value.glyphAdvances ) delete[] value.glyphAdvances;
    if ( value.glyphOffsets ) delete[] value.glyphOffsets;
}