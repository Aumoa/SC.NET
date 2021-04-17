// Copyright 2020-2021 Aumoa.lib. All right reserved.

#include "pch.h"
#include "Application.h"

#include "CoreWindow.h"

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

void Application::Run(CoreWindow^ dialog)
{
	Initialize();

	// 창이 보이지 않는 상태라면 보이게 합니다.
	if (!dialog->IsVisible)
	{
		dialog->IsVisible = true;
	}

	MSG msg = { };
	while (true)
	{
		if (PeekMessageW(&msg, nullptr, 0, 0, PM_REMOVE))
		{
			if (msg.message == WM_QUIT)
			{
				break;
			}
			else
			{
				TranslateMessage(&msg);
				DispatchMessageW(&msg);
			}
		}
		else
		{
			Idle();
		}
	}

	Shutdown();
}

void Application::CheckDisposed()
{
	if (_disposed)
	{
		throw gcnew AccessViolationException("개체가 이미 종료되었습니다.");
	}
}