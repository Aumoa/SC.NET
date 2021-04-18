// Copyright 2020-2021 Aumoa.lib. All right reserved.

#pragma once

template<class T>
class TComPtr
{
	template<class T>
	friend class TComPtr;

	T* _instance;

public:
	inline TComPtr() : _instance(nullptr)
	{

	}

	inline TComPtr(std::nullptr_t) : _instance(nullptr)
	{

	}

	inline TComPtr(T* ptr) : _instance(ptr)
	{
		SafeAddRef();
	}

	inline TComPtr(const TComPtr& ptr) : TComPtr(ptr._instance)
	{

	}

	template<class O>
	inline TComPtr(const TComPtr<O>& ptr) : TComPtr(ptr._instance)
	{

	}

	inline TComPtr(TComPtr&& ptr) noexcept : _instance(ptr._instance)
	{
		ptr._instance = nullptr;
	}

	template<class O>
	inline TComPtr(TComPtr<O>&& ptr) noexcept : _instance(ptr._instance)
	{
		ptr._instance = nullptr;
	}

	inline ~TComPtr()
	{
		SafeRelease();
	}

	inline T* Detach()
	{
		T* ptr = _instance;
		_instance = nullptr;
		return ptr;
	}

	inline void Attach(T* ptr)
	{
		SafeRelease();
		_instance = ptr;
	}

	inline void Reset(T* ptr = nullptr)
	{
		SafeRelease();
		_instance = ptr;
		SafeAddRef();
	}

	inline void Swap(TComPtr<T>& target)
	{
		T* ptr = target._instance;
		target._instance = _instance;
		_instance = ptr;
	}

	[[nodiscard]] inline T* Get() const
	{
		return _instance;
	}

	[[nodiscard]] inline T** GetAddressOf()
	{
		return &_instance;
	}

	[[nodiscard]] inline T** ReleaseAndGetAddressOf()
	{
		SafeRelease();
		return &_instance;
	}

	inline bool IsValid() const
	{
		return _instance != nullptr;
	}

	[[nodiscard]] inline T* operator ->() const
	{
		return Get();
	}

	[[nodiscard]] inline operator bool() const
	{
		return IsValid();
	}

	[[nodiscard]] inline T** operator &()
	{
		return ReleaseAndGetAddressOf();
	}

	inline TComPtr& operator =(const TComPtr& rh)
	{
		SafeRelease();
		_instance = rh.Get();
		SafeAddRef();
		return *this;
	}

	inline TComPtr& operator =(TComPtr&& rh)
	{
		SafeRelease();
		_instance = rh.Get();
		rh._instance = nullptr;
		return *this;
	}

private:
	inline void SafeAddRef()
	{
		if (_instance != nullptr)
		{
			_instance->AddRef();
		}
	}

	inline void SafeRelease()
	{
		if (_instance != nullptr)
		{
			_instance->Release();
			_instance = nullptr;
		}
	}
};