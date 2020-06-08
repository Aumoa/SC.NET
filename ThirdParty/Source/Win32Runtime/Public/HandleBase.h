// Copyright 2020-2021 Aumoa.lib. All right reserved.

#pragma once

namespace SC::ThirdParty::Win32Runtime
{
	/// <summary>
	/// Windows 환경에서 사용하는 핸들 시스템의 기본 함수를 제공합니다.
	/// </summary>
	public ref class HandleBase abstract : public System::Object
	{
	public:
		using Super = System::Object;

	private:
		void* handle;
		bool bDisposed;

	public:
		/// <summary>
		/// 새 개체를 초기화합니다.
		/// </summary>
		HandleBase();

		~HandleBase();
		!HandleBase();

		/// <summary>
		/// 기본 방법으로 핸들을 닫습니다.
		/// </summary>
		virtual void Close();

	public:
		/// <summary>
		/// 이 개체가 관리하는 핸들을 가져옵니다.
		/// </summary>
		property System::IntPtr Handle
		{
			System::IntPtr get();
			protected: void set(System::IntPtr value);
		}

	protected:
		/// <summary>
		/// 리소스 해제를 수행합니다.
		/// </summary>
		/// <param name="bDisposing"></param>
		virtual void NativeDispose(bool bDisposing);
	};
}