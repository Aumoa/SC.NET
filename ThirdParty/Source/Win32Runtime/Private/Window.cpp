// Copyright 2020-2021 Aumoa.lib. All right reserved.

#include "pch.h"
#include "Window.h"

using namespace System;
using namespace SC::ThirdParty::Win32Runtime;
using namespace std;
using namespace msclr::interop;

#define GET_HANDLE() ((HWND)GetHandle().ToPointer())

Window::Window() : Super()
{

}

String^ Window::Title::get()
{
	auto hWnd = GET_HANDLE();

	wstring buffer;
	int length = GetWindowTextW(hWnd, nullptr, 0);

	buffer.resize(length + 1);
	GetWindowTextW(hWnd, buffer.data(), length);

	return gcnew String(buffer.c_str());
}

void Window::Title::set(String^ value)
{
	auto hWnd = (HWND)GetHandle().ToPointer();
	wstring value_c = marshal_as<wstring>(value);

	SetWindowTextW(hWnd, value_c.c_str());
}

bool Window::IsVisible::get()
{
	return IsWindowVisible(GET_HANDLE());
}

void Window::IsVisible::set(bool value)
{
	HWND hWnd = GET_HANDLE();
	ShowWindow(hWnd, value ? SW_SHOW : SW_HIDE);
}