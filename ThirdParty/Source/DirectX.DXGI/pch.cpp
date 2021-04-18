// Copyright 2020 Aumoa.lib. All right reserved.

using namespace SC::Engine::Runtime::Core::Numerics;
using namespace SC::ThirdParty::DirectX;
using namespace SC::ThirdParty::WinAPI;

using namespace System;

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
    array<System::Byte>^ guidData = guid.ToByteArray();
    pin_ptr<System::Byte> data = &( guidData[0] );

    return *( _GUID* )data;
}

SC::Engine::Runtime::Core::Numerics::Rectangle ToRectangle( const RECT& rect )
{
    SC::Engine::Runtime::Core::Numerics::Rectangle left;
    left.Left = (float)rect.left;
    left.Top = (float)rect.top;
    left.Right = (float)rect.right;
    left.Bottom = (float)rect.bottom;
    return left;
}

void Assign( DXGIRational% left, const DXGI_RATIONAL& right )
{
    left.Denominator = right.Denominator;
    left.Numerator = right.Numerator;
}

void Assign( DXGI_RATIONAL& left, DXGIRational% right )
{
    left.Denominator = right.Denominator;
    left.Numerator = right.Numerator;
}

void Assign( DXGIModeDesc% left, const DXGI_MODE_DESC& right )
{
    left.Width = right.Width;
    left.Height = right.Height;
    Assign( left.RefreshRate, right.RefreshRate );
    left.Format = ( DXGIFormat )right.Format;
    left.ScanlineOrdering = ( DXGIModeScanlineOrder )right.ScanlineOrdering;
    left.Scaling = ( DXGIModeScaling )right.Scaling;
}

void Assign( DXGI_MODE_DESC& left, DXGIModeDesc% right )
{
    left.Width = right.Width;
    left.Height = right.Height;
    Assign( left.RefreshRate, right.RefreshRate );
    left.Format = ( DXGI_FORMAT )right.Format;
    left.ScanlineOrdering = ( DXGI_MODE_SCANLINE_ORDER )right.ScanlineOrdering;
    left.Scaling = ( DXGI_MODE_SCALING )right.Scaling;
}

void Assign( DXGIGammaControlCapabilities% left, const DXGI_GAMMA_CONTROL_CAPABILITIES& right )
{
    left.ScaleAndOffsetSupported = right.ScaleAndOffsetSupported;
    left.MaxConvertedValue = right.MaxConvertedValue;
    left.MinConvertedValue = right.MinConvertedValue;
    left.NumGammaControlPoints = right.NumGammaControlPoints;

    for ( int i = 0; i < 1025; ++i )
    {
        left.ControlPointPositions[i] = right.ControlPointPositions[i];
    }
}

void Assign( DXGI_GAMMA_CONTROL_CAPABILITIES& left, DXGIGammaControlCapabilities% right )
{
    left.ScaleAndOffsetSupported = right.ScaleAndOffsetSupported;
    left.MaxConvertedValue = right.MaxConvertedValue;
    left.MinConvertedValue = right.MinConvertedValue;
    left.NumGammaControlPoints = right.NumGammaControlPoints;

    for ( int i = 0; i < 1025; ++i )
    {
        left.ControlPointPositions[i] = right.ControlPointPositions[i];
    }
}

void Assign( DXGI_GAMMA_CONTROL& left, DXGIGammaControl% right )
{
    Assign( left.Scale, right.Scale );
    Assign( left.Offset, right.Offset );
}

void Assign( DXGIGammaControl% left, DXGI_GAMMA_CONTROL& right )
{
    Assign( left.Scale, right.Scale );
    Assign( left.Offset, right.Offset );
}

void Assign( DXGI_RGB& left, DXGIRGB% right )
{
    left.Red = right.R;
    left.Green = right.G;
    left.Blue = right.B;
}

void Assign( DXGIRGB% left, DXGI_RGB& right )
{
    left.R = right.Red;
    left.G = right.Green;
    left.B = right.Blue;
}

void Assign( DXGI_FRAME_STATISTICS& left, DXGIFrameStatistics% right )
{
    left.PresentCount = right.PresentCount;
    left.PresentRefreshCount = right.PresentRefreshCount;
    left.SyncRefreshCount = right.SyncRefreshCount;
    left.SyncQPCTime.QuadPart = right.SyncQPCTime;
    left.SyncGPUTime.QuadPart = right.SyncGPUTime;
}

void Assign( DXGIFrameStatistics% left, DXGI_FRAME_STATISTICS& right )
{
    left.PresentCount = right.PresentCount;
    left.PresentRefreshCount = right.PresentRefreshCount;
    left.SyncRefreshCount = right.SyncRefreshCount;
    left.SyncQPCTime = right.SyncQPCTime.QuadPart;
    left.SyncGPUTime = right.SyncGPUTime.QuadPart;
}

void Assign( DXGI_ADAPTER_DESC& left, DXGIAdapterDesc% right )
{
    std::wstring description;
    Assign( description, right.Description );
    
    memcpy( left.Description, description.c_str(), sizeof( wchar_t ) * description.length() );
    left.VendorId = right.VendorId;
    left.DeviceId = right.DeviceId;
    left.SubSysId = right.SubSysId;
    left.Revision = right.Revision;
    left.DedicatedVideoMemory = ( SIZE_T )right.DedicatedVideoMemory;
    left.DedicatedSystemMemory = ( SIZE_T )right.DedicatedSystemMemory;
    left.SharedSystemMemory = ( SIZE_T )right.SharedSystemMemory;
    Assign( left.AdapterLuid, right.AdapterLuid );
}

void Assign( DXGIAdapterDesc% left, DXGI_ADAPTER_DESC& right )
{
    Assign( left.Description, right.Description );
    left.VendorId = right.VendorId;
    left.DeviceId = right.DeviceId;
    left.SubSysId = right.SubSysId;
    left.Revision = right.Revision;
    left.DedicatedVideoMemory = right.DedicatedVideoMemory;
    left.DedicatedSystemMemory = right.DedicatedSystemMemory;
    left.SharedSystemMemory = right.SharedSystemMemory;
    Assign( left.AdapterLuid, right.AdapterLuid );
}

void Assign( DXGI_ADAPTER_DESC1& left, DXGIAdapterDesc1% right )
{
    std::wstring description;
    Assign( description, right.Description );

    memcpy( left.Description, description.c_str(), sizeof( wchar_t ) * description.length() );
    left.VendorId = right.VendorId;
    left.DeviceId = right.DeviceId;
    left.SubSysId = right.SubSysId;
    left.Revision = right.Revision;
    left.DedicatedVideoMemory = ( SIZE_T )right.DedicatedVideoMemory;
    left.DedicatedSystemMemory = ( SIZE_T )right.DedicatedSystemMemory;
    left.SharedSystemMemory = ( SIZE_T )right.SharedSystemMemory;
    left.Flags = ( int )right.Flags;
    Assign( left.AdapterLuid, right.AdapterLuid );
}

void Assign( DXGIAdapterDesc1% left, DXGI_ADAPTER_DESC1& right )
{
    Assign( left.Description, right.Description );
    left.VendorId = right.VendorId;
    left.DeviceId = right.DeviceId;
    left.SubSysId = right.SubSysId;
    left.Revision = right.Revision;
    left.DedicatedVideoMemory = right.DedicatedVideoMemory;
    left.DedicatedSystemMemory = right.DedicatedSystemMemory;
    left.SharedSystemMemory = right.SharedSystemMemory;
    left.Flags = ( DXGIAdapterFlags )right.Flags;
    Assign( left.AdapterLuid, right.AdapterLuid );
}

void Assign( std::wstring& left, String^ right )
{
    msclr::interop::marshal_context context;
    auto lpText = context.marshal_as<const wchar_t*>( right );
    left = lpText;
}

void Assign( String^% left, const std::wstring& right )
{
    left = gcnew String( right.c_str() );
}

void Assign( Luid% left, LUID& right )
{
    left.LowPart = right.LowPart;
    left.HighPart = right.HighPart;
}

void Assign( LUID& left, Luid% right )
{
    left.LowPart = right.LowPart;
    left.HighPart = right.HighPart;
}

void Assign( DXGISurfaceDesc% left, DXGI_SURFACE_DESC& right )
{
    left.Width = right.Width;
    left.Height = right.Height;
    left.Format = ( DXGIFormat )right.Format;
    Assign( left.SampleDesc, right.SampleDesc );
}

void Assign( DXGI_SURFACE_DESC& left, DXGISurfaceDesc% right )
{
    left.Width = right.Width;
    left.Height = right.Height;
    left.Format = ( DXGI_FORMAT )right.Format;
    Assign( left.SampleDesc, right.SampleDesc );
}

void Assign( DXGI_SAMPLE_DESC& left, DXGISampleDesc% right )
{
    left.Count = right.Count;
    left.Quality = right.Quality;
}

void Assign( DXGISampleDesc% left, DXGI_SAMPLE_DESC& right )
{
    left.Count = right.Count;
    left.Quality = right.Quality;
}

void Assign( DXGI_SWAP_CHAIN_DESC& left, DXGISwapChainDesc% right )
{
    Assign( left.BufferDesc, right.BufferDesc );
    Assign( left.SampleDesc, right.SampleDesc );
    left.BufferUsage = ( DXGI_USAGE )right.BufferUsage;
    left.BufferCount = right.BufferCount;
    left.OutputWindow = ( HWND )right.OutputWindow->GetHandle().ToPointer();
    left.Windowed = right.Windowed;
    left.SwapEffect = ( DXGI_SWAP_EFFECT )right.SwapEffect;
    left.Flags = ( UINT )right.Flags;
}

void Assign( DXGISwapChainDesc% left, DXGI_SWAP_CHAIN_DESC& right )
{
    Assign( left.BufferDesc, right.BufferDesc );
    Assign( left.SampleDesc, right.SampleDesc );
    left.BufferUsage = ( DXGIUsage )right.BufferUsage;
    left.BufferCount = right.BufferCount;
    left.OutputWindow = gcnew GeneralHandle( IntPtr( right.OutputWindow ) );
    left.Windowed = right.Windowed;
    left.SwapEffect = ( DXGISwapEffect )right.SwapEffect;
    left.Flags = ( DXGISwapChainFlag )right.Flags;
}

void Assign( DXGI_SWAP_CHAIN_DESC1& left, DXGISwapChainDesc1% right )
{
    left.Width = right.Width;
    left.Height = right.Height;
    left.Format = ( DXGI_FORMAT )right.Format;
    left.Stereo = right.Stereo;
    Assign( left.SampleDesc, right.SampleDesc );
    left.BufferUsage = ( DXGI_USAGE )right.BufferUsage;
    left.BufferCount = right.BufferCount;
    left.Scaling = ( DXGI_SCALING )right.Scaling;
    left.SwapEffect = ( DXGI_SWAP_EFFECT )right.SwapEffect;
    left.AlphaMode = ( DXGI_ALPHA_MODE )right.AlphaMode;
    left.Flags = ( UINT )right.Flags;
}

void Assign( DXGISwapChainDesc1% left, DXGI_SWAP_CHAIN_DESC1& right )
{
    left.Width = right.Width;
    left.Height = right.Height;
    left.Format = ( DXGIFormat )right.Format;
    left.Stereo = right.Stereo;
    Assign( left.SampleDesc, right.SampleDesc );
    left.BufferUsage = ( DXGIUsage )right.BufferUsage;
    left.BufferCount = right.BufferCount;
    left.Scaling = ( DXGIScaling )right.Scaling;
    left.SwapEffect = ( DXGISwapEffect )right.SwapEffect;
    left.AlphaMode = ( DXGIAlphaMode )right.AlphaMode;
    left.Flags = ( DXGISwapChainFlag )right.Flags;
}

void Assign( DXGI_SWAP_CHAIN_FULLSCREEN_DESC& left, DXGISwapChainFullscreenDesc% right )
{
    Assign( left.RefreshRate, right.RefreshRate );
    left.ScanlineOrdering = ( DXGI_MODE_SCANLINE_ORDER )right.ScanlineOrdering;
    left.Scaling = ( DXGI_MODE_SCALING )right.Scaling;
    left.Windowed = right.Windowed;
}

void Assign( DXGISwapChainFullscreenDesc% left, DXGI_SWAP_CHAIN_FULLSCREEN_DESC& right )
{
    Assign( left.RefreshRate, right.RefreshRate );
    left.ScanlineOrdering = ( DXGIModeScanlineOrder )right.ScanlineOrdering;
    left.Scaling = ( DXGIModeScaling )right.Scaling;
    left.Windowed = right.Windowed;
}

void Assign( DXGI_PRESENT_PARAMETERS& left, DXGIPresentParameters% right )
{
    if ( right.DirtyRects != nullptr )
    {
        left.DirtyRectsCount = right.DirtyRects->Count;
        left.pDirtyRects = new RECT[left.DirtyRectsCount];

        for ( int i = 0; i < ( int )left.DirtyRectsCount; ++i )
        {
            Assign( left.pDirtyRects[i], right.DirtyRects[i] );
        }
    }
    else
    {
        left.DirtyRectsCount = 0;
        left.pDirtyRects = nullptr;
    }

    if ( right.ScrollRect.HasValue )
    {
        left.pScrollRect = new RECT();
        Assign( *left.pScrollRect, right.ScrollRect.Value );
    }
    else
    {
        left.pScrollRect = nullptr;
    }

    if ( right.ScrollOffset.HasValue )
    {
        left.pScrollOffset = new POINT();
        Assign( *left.pScrollOffset, right.ScrollOffset.Value );
    }
    else
    {
        left.pScrollOffset = nullptr;
    }
}

void Assign( DXGIPresentParameters% left, DXGI_PRESENT_PARAMETERS& right )
{
    if ( right.DirtyRectsCount != 0 )
    {
        cli::array<SC::Engine::Runtime::Core::Numerics::Rectangle>^ arr = gcnew cli::array<SC::Engine::Runtime::Core::Numerics::Rectangle>( right.DirtyRectsCount );
        left.DirtyRects = ( System::Collections::Generic::IList<SC::Engine::Runtime::Core::Numerics::Rectangle>^ )arr;

        for ( int i = 0; i < ( int )right.DirtyRectsCount; ++i )
        {
            Assign( left.DirtyRects[i], right.pDirtyRects[i] );
        }
    }

    if ( right.pScrollRect )
    {
        SC::Engine::Runtime::Core::Numerics::Rectangle r;
        Assign( r, *right.pScrollRect );
        left.ScrollRect = r;
    }

    if ( right.pScrollOffset )
    {
        Vector2 r;
        Assign( r, *right.pScrollOffset );
        left.ScrollOffset = r;
    }
}

void Assign( RECT& left, SC::Engine::Runtime::Core::Numerics::Rectangle% right )
{
    left.left = (LONG)right.Left;
    left.top = (LONG)right.Top;
    left.right = (LONG)right.Right;
    left.bottom = (LONG)right.Bottom;
}

void Assign( SC::Engine::Runtime::Core::Numerics::Rectangle% left, RECT& right )
{
    left.Left = (float)right.left;
    left.Top = (float)right.top;
    left.Right = (float)right.right;
    left.Height = (float)right.bottom;
}

void Assign( POINT& left, Vector2% right )
{
    left.x = (LONG)right.X;
    left.y = (LONG)right.Y;
}

void Assign( Vector2% left, POINT& right )
{
    left.X = (float)right.x;
    left.Y = (float)right.y;
}

void Assign( DXGI_RGBA& left, DXGIRGBA% right )
{
    left.r = right.R;
    left.g = right.G;
    left.b = right.B;
    left.a = right.A;
}

void Assign( DXGIRGBA% left, DXGI_RGBA& right )
{
    left.R = right.r;
    left.G = right.g;
    left.B = right.b;
    left.A = right.a;
}

void Assign( DXGI_MATRIX_3X2_F& left, Matrix3x2% right )
{
    left._11 = (FLOAT)right._11;
    left._12 = (FLOAT)right._12;

    left._21 = (FLOAT)right._21;
    left._22 = (FLOAT)right._22;

    left._31 = (FLOAT)right._31;
    left._32 = (FLOAT)right._32;
}

void Assign( Matrix3x2% left, DXGI_MATRIX_3X2_F& right )
{
    left._11 = right._11;
    left._12 = right._12;

    left._21 = right._21;
    left._22 = right._22;

    left._31 = right._31;
    left._32 = right._32;
}