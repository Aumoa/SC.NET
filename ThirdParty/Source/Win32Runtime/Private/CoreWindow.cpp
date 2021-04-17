// Copyright 2020-2021 Aumoa.lib. All right reserved.

#include "pch.h"
#include "CoreWindow.h"

#include "Application.h"

using namespace System;
using namespace System::ComponentModel;
using namespace SC::ThirdParty::Win32Runtime;

CoreWindow::CoreWindow(Application^ app, String^ title) : Super()
{
	if (_globalItem != nullptr)
	{
		throw gcnew AccessViolationException("CoreWindow 개체가 중복되었습니다.");
	}

	_globalItem = this;
	_app = app;
	_handle = CreateCoreWindow();
	Title = title;
}

CoreWindow::~CoreWindow()
{
	if (!_disposed)
	{
		_disposed = true;
	}
}

void CoreWindow::Close()
{
	CheckDisposed();
}

IntPtr CoreWindow::GetHandle()
{
	CheckDisposed();
	return IntPtr(_handle);
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	switch (uMsg)
	{
	case WM_DESTROY:
		CoreWindow::_globalItem->BroadcastDestroy();
		break;
	}

	return DefWindowProcW(hWnd, uMsg, wParam, lParam);
}

void CoreWindow::BroadcastDestroy()
{
	CheckDisposed();
	Destroy();
	PostQuitMessage(0);
}

void* CoreWindow::CreateCoreWindow()
{
	static constexpr const wchar_t* ClassName = L"SC.ThirdParty.Win32Runtime.CoreWindow";

	WNDCLASSEXW wcex = { };
	wcex.cbSize = sizeof(wcex);
	wcex.lpfnWndProc = WndProc;
	wcex.hInstance = (HINSTANCE)_app->GetHandle().ToPointer();
	wcex.lpszClassName = ClassName;
	if (RegisterClassExW(&wcex) == 0)
	{
		throw gcnew Win32Exception((int)GetLastError());
	}

	HWND hWnd = CreateWindowExW(0, ClassName, L"", WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, nullptr, nullptr, wcex.hInstance, nullptr);
	if (hWnd == nullptr)
	{
		throw gcnew Win32Exception((int)GetLastError());
	}

	return hWnd;
}

void CoreWindow::CheckDisposed()
{
	if (_disposed)
	{
		throw gcnew AccessViolationException("개체가 이미 종료되었습니다.");
	}
}