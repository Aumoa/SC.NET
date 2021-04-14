// Copyright 2020-2021 Aumoa.lib. All right reserved.

#include "pch.h"
#include "HandleBase.h"

using namespace System;

using namespace SC::ThirdParty::Win32Runtime;

HandleBase::HandleBase() : Super()
{
	
}

HandleBase::~HandleBase()
{
	if (_disposed)
	{
		Close();
		_disposed = true;
	}
}

void HandleBase::Close()
{
	CheckDisposed();

	if (_handle != nullptr)
	{
		CloseHandle((HANDLE)_handle);
		_handle = nullptr;
	}
}

IntPtr HandleBase::GetHandle()
{
	CheckDisposed();
	return IntPtr(_handle);
}

void HandleBase::SetHandle(IntPtr value)
{
	CheckDisposed();
	_handle = value.ToPointer();
}

void HandleBase::CheckDisposed()
{
	if (_disposed)
	{
		throw gcnew AccessViolationException("개체가 이미 종료되었습니다.");
	}
}