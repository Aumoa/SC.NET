// Copyright 2020-2021 Aumoa.lib. All right reserved.

#pragma once

#undef _MANAGED

#include <Windows.h>
#include <wincodec.h>
#include <msclr/marshal.h>
#include <msclr/marshal_cppstd.h>
#include <wrl/client.h>

using Microsoft::WRL::ComPtr;

#define HR(x) if (HRESULT hr = (x); FAILED(hr)) { throw gcnew System::Runtime::InteropServices::COMException(#x, (int)hr); }
#define SafeRelease(x) if ((x) != nullptr) { (x)->Release(); (x) = nullptr; }