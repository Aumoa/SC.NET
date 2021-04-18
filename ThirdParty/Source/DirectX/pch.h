// Copyright 2020-2021 Aumoa.lib. All right reserved.

#pragma once

#include <Windows.h>
#include <dxgi1_6.h>
#include <d3d12.h>
#include <msclr/marshal.h>
#include <msclr/marshal_cppstd.h>
#include <string>

#include "TComPtr.h"

#define HR(exp) if (auto hr = (exp); FAILED(hr)) { throw gcnew System::Runtime::InteropServices::COMException(#exp, (int)hr); }
#define RELEASE(exp) if (exp != nullptr) { exp->Release(); exp = nullptr; }