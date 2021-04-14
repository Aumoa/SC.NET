// Copyright 2020-2021 Aumoa.lib. All right reserved.

#pragma once

#include "IPlatformHandle.h"

namespace SC::ThirdParty::Win32Runtime
{
	/// <summary>
	/// Windows 환경에서 사용하는 핸들 시스템의 기본 함수를 제공합니다.
	/// </summary>
	public ref class HandleBase abstract : public IPlatformHandle
	{
	public:
		using Super = System::Object;

	private:
		void* _handle;
		bool _disposed;

	public:
		/// <summary>
		/// 새 개체를 초기화합니다.
		/// </summary>
		HandleBase();
		~HandleBase();

		/// <inheritdoc/>
		virtual void Close();

		/// <inheritdoc/>
		virtual System::IntPtr GetHandle();

	protected:
		/// <summary>
		/// 네이티브 핸들의 포인터를 설정합니다.
		/// </summary>
		/// <param name="value"> 값을 전달합니다. </param>
		void SetHandle(System::IntPtr value);

	private:
		void CheckDisposed();
	};
}