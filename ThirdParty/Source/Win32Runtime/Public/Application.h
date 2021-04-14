// Copyright 2020-2021 Aumoa.lib. All right reserved.

#pragma once

#include "IPlatformHandle.h"

namespace SC::ThirdParty::Win32Runtime
{
	/// <summary>
	/// 애플리케이션을 정의합니다.
	/// </summary>
	public ref class Application : public IPlatformHandle
	{
	public:
		using Super = System::Object;

	private:
		bool _disposed;
		void* _handle;

	public:
		/// <summary>
		/// 개체를 초기화합니다.
		/// </summary>
		Application();
		~Application();

		/// <inheritdoc/>
		virtual void Close();

		/// <inheritdoc/>
		virtual System::IntPtr GetHandle();

	private:
		void CheckDisposed();
	};
}