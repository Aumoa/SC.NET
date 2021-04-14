// Copyright 2020-2021 Aumoa.lib. All right reserved.

#include "pch.h"
#include "Application.h"

using namespace System;
using namespace SC::ThirdParty::Win32Runtime;

Application::Application() : Super()
{
	_handle = GetModuleHandleW(nullptr);
}

Application::~Application()
{
	if (!_disposed)
	{
		_disposed = true;
	}
}

void Application::Close()
{
	CheckDisposed();
}

IntPtr Application::GetHandle()
{
	return IntPtr(_handle);
}

void Application::CheckDisposed()
{
	if (_disposed)
	{
		throw gcnew AccessViolationException("개체가 이미 종료되었습니다.");
	}
}