// Copyright 2020-2021 Aumoa.lib. All right reserved.

#include "pch.h"
#include "HandleBase.h"

using namespace System;

using namespace SC::ThirdParty::Win32Runtime;

HandleBase::HandleBase() : Super()
	, handle(nullptr)
	, bDisposed(false)
{
	
}

HandleBase::~HandleBase()
{
	NativeDispose(true);
	GC::SuppressFinalize(this);
}

HandleBase::!HandleBase()
{
	NativeDispose(false);
}

void HandleBase::Close()
{
	CloseHandle((HANDLE)handle);
}

IntPtr HandleBase::Handle::get()
{
	return IntPtr(handle);
}

void HandleBase::Handle::set(IntPtr value)
{
	handle = value.ToPointer();
}

void HandleBase::NativeDispose(bool bDisposing)
{
	if (bDisposing)
	{
		// 관리되는 멤버를 제거합니다.
	}

	// 관리되지 않는 멤버를 제거합니다.
	if (!bDisposed)
	{
		Close();
		bDisposed = true;
	}
}