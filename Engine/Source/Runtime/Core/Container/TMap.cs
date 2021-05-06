// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Collections;
using System.Collections.Generic;

using SC.Engine.Runtime.Core.Mathematics;

namespace SC.Engine.Runtime.Core.Container
{
    /// <summary>
    /// 키와 값이 쌍을 이루는 컨테이너입니다.
    /// </summary>
    /// <typeparam name="TKey"> 키의 형식을 전달합니다. </typeparam>
    /// <typeparam name="TValue"> 값의 형식을 전달합니다. </typeparam>
    public class TMap<TKey, TValue> : IDictionary<TKey, TValue>, IReadOnlyDictionary<TKey, TValue>, ICloneable
    {
        int[] _buckets;
        Entry[] _entries;
        int _count;
        int _version;
        int _freeList;
        int _freeCount;
        IEqualityComparer<TKey> _comparer;
        KeyCollection _keys;
        ValueCollection _values;

        /// <summary>
        /// <see cref="TMap{TKey, TValue}"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="capacity"> 미리 할당된 용량을 설정합니다. </param>
        /// <param name="comparer"> 개체를 정렬할 때 사용할 비교 개체를 전달합니다. </param>
        public TMap(int capacity = 0, IEqualityComparer<TKey> comparer = null)
        {
            ThrowIfCapacityOutOfRange(capacity);

            if (capacity > 0)
            {
                Initialize(capacity);
            }

            this._comparer = comparer ?? EqualityComparer<TKey>.Default;
        }

        /// <summary>
        /// <see cref="TMap{TKey, TValue}"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="dictionary"> 복사할 원본 컨테이너를 전달합니다. </param>
        /// <param name="comparer"> 개체를 정렬할 때 사용할 비교 개체를 전달합니다. </param>
        public TMap(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer = null) :
            this(dictionary is not null ? dictionary.Count : 0, comparer)
        {
            ThrowIfArgumentNull(dictionary);

            foreach (KeyValuePair<TKey, TValue> pair in dictionary)
            {
                Add(pair.Key, pair.Value);
            }
        }

        /// <summary>
        /// 이 개체가 사용하는 비교기를 가져옵니다.
        /// </summary>
        public virtual IEqualityComparer<TKey> Comparer => _comparer;

        /// <summary>
        /// 컨테이너에 보관된 아이템의 개수를 가져옵니다.
        /// </summary>
        public virtual int Count => _count - _freeCount;

        /// <summary>
        /// 이 컨테이너에 보관된 모든 키에 대한 컬렉션을 가져옵니다.
        /// </summary>
        public KeyCollection Keys => _keys ??= new KeyCollection(this);

        /// <summary>
        /// 이 컨테이너에 보관된 모든 값에 대한 컬렉션을 가져옵니다.
        /// </summary>
        public ValueCollection Values => _values ??= new ValueCollection(this);

        /// <summary>
        /// 컨테이너에서 지정한 키와 쌍을 이루는 값을 찾아 참조를 가져옵니다.
        /// </summary>
        /// <param name="key"> 키를 전달합니다. </param>
        /// <returns> 키와 쌍을 이루는 값의 참조가 반환됩니다. </returns>
        public ref TValue this[TKey key]
        {
            get
            {
                int i = FindEntry(key);
                if (i >= 0)
                {
                    return ref _entries[i].Value;
                }

                ThrowKeyNotFoundException();
                return ref _entries[0].Value;
            }
        }

        /// <summary>
        /// 컨테이너에 새로운 키-값 쌍을 추가합니다.
        /// </summary>
        /// <param name="key"> 키를 전달합니다. </param>
        /// <param name="value"> 값을 전달합니다. </param>
        public virtual void Add(TKey key, TValue value)
        {
            Insert(key, value, true);
        }

        /// <summary>
        /// 컨테이너에 있는 모든 데이터를 비웁니다.
        /// </summary>
        public virtual void Clear()
        {
            if (_count > 0)
            {
                for (int i = 0; i < _buckets.Length; i++)
                {
                    _buckets[i] = -1;
                }

                Array.Clear(_entries, 0, _count);
                _freeList = -1;
                _count = 0;
                _freeCount = 0;
                _version++;
            }
        }

        /// <summary>
        /// 이 컨테이너에 지정한 키가 존재하는지 검사합니다.
        /// </summary>
        /// <param name="key"> 키를 전달합니다. </param>
        /// <returns> 존재할 경우 <see langword="true"/>가 반환됩니다. </returns>
        public virtual bool ContainsKey(TKey key)
        {
            return FindEntry(key) >= 0;
        }

        /// <summary>
        /// 이 컨테이너에 지정한 값이 존재하는지 검사합니다.
        /// </summary>
        /// <param name="value"> 값을 전달합니다. </param>
        /// <returns> 존재할 경우 <see langword="true"/>가 반환됩니다. </returns>
        /// <remarks> 일반적으로 이 함수는 전체 아이템을 순회하면서 값을 찾습니다. <see cref="TMap{TKey, TValue}"/>에 기대하는 성능이 나오지 않을 수 있습니다. </remarks>
        public virtual bool ContainsValue(TValue value)
        {
            if (value == null)
            {
                for (int i = 0; i < _count; i++)
                {
                    if (_entries[i].HashCode >= 0 && _entries[i].Value == null)
                    {
                        return true;
                    }
                }
            }
            else
            {
                EqualityComparer<TValue> c = EqualityComparer<TValue>.Default;
                for (int i = 0; i < _count; i++)
                {
                    if (_entries[i].HashCode >= 0 && c.Equals(_entries[i].Value, value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 컨테이너의 열거자를 가져옵니다.
        /// </summary>
        /// <returns> 열거자가 반환됩니다. </returns>
        public virtual Enumerator GetEnumerator()
        {
            return new Enumerator(this, Enumerator.KeyValuePair);
        }

        /// <summary>
        /// 컨테이너에서 해당 키와 쌍을 이루는 값을 키와 함께 제거합니다.
        /// </summary>
        /// <param name="key"> 키를 전달합니다. </param>
        /// <returns> 키를 찾아 값을 제거했으면 <see langword="true"/>가 반환됩니다. </returns>
        public bool Remove(TKey key)
        {
            ThrowIfArgumentNull(key);

            if (_buckets is not null)
            {
                int hashCode = _comparer.GetHashCode(key) & 0x7FFFFFFF;
                int bucket = hashCode % _buckets.Length;
                int last = -1;
                for (int i = _buckets[bucket]; i >= 0; last = i, i = _entries[i].Next)
                {
                    if (_entries[i].HashCode == hashCode && _comparer.Equals(_entries[i].Key, key))
                    {
                        if (last < 0)
                        {
                            _buckets[bucket] = _entries[i].Next;
                        }
                        else
                        {
                            _entries[last].Next = _entries[i].Next;
                        }
                        _entries[i].HashCode = -1;
                        _entries[i].Next = _freeList;
                        _entries[i].Key = default(TKey);
                        _entries[i].Value = default(TValue);
                        _freeList = i;
                        _freeCount++;
                        _version++;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 지정한 키와 쌍을 이루는 값을 찾습니다. 값을 찾지 못했을 경우 예외 대신 <see langword="false"/>를 반환합니다.
        /// </summary>
        /// <param name="key"> 키를 전달합니다. </param>
        /// <param name="value"> 값을 받을 변수의 참조를 전달합니다. </param>
        /// <returns> 값을 찾았을 경우 <see langword="true"/>가 반환됩니다. </returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            int i = FindEntry(key);
            if (i >= 0)
            {
                value = _entries[i].Value;
                return true;
            }
            value = default;
            return false;
        }

        /// <summary>
        /// 컨테이너의 모든 데이터를 복사하여 새 컨테이너 개체를 생성합니다.
        /// </summary>
        /// <returns> 생성된 개체가 반환됩니다. </returns>
        public virtual object Clone()
        {
            return new TMap<TKey, TValue>(this, Comparer);
        }

        int FindEntry(TKey key)
        {
            ThrowIfArgumentNull(key);

            if (_buckets is not null)
            {
                int hashCode = _comparer.GetHashCode(key) & 0x7FFFFFFF;
                for (int i = _buckets[hashCode % _buckets.Length]; i >= 0; i = _entries[i].Next)
                {
                    if (_entries[i].HashCode == hashCode && _comparer.Equals(_entries[i].Key, key))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        void Initialize(int capacity)
        {
            int size = MathEx.GetPrime(capacity);
            _buckets = new int[size];
            for (int i = 0; i < _buckets.Length; i++)
            {
                _buckets[i] = -1;
            }

            _entries = new Entry[size];
            _freeList = -1;
        }

        void Insert(TKey key, TValue value, bool add)
        {
            ThrowIfArgumentNull(key);

            if (_buckets == null)
            {
                Initialize(0);
            }

            int hashCode = _comparer.GetHashCode(key) & 0x7FFFFFFF;
            int targetBucket = hashCode % _buckets.Length;

            for (int i = _buckets[targetBucket]; i >= 0; i = _entries[i].Next)
            {
                if (_entries[i].HashCode == hashCode && _comparer.Equals(_entries[i].Key, key))
                {
                    if (add)
                    {
                        ThrowKeyDuplicated();
                    }
                    _entries[i].Value = value;
                    _version++;
                    return;
                }
            }

            int index;
            if (_freeCount > 0)
            {
                index = _freeList;
                _freeList = _entries[index].Next;
                _freeCount--;
            }
            else
            {
                if (_count == _entries.Length)
                {
                    Resize();
                    targetBucket = hashCode % _buckets.Length;
                }
                index = _count;
                _count++;
            }

            _entries[index].HashCode = hashCode;
            _entries[index].Next = _buckets[targetBucket];
            _entries[index].Key = key;
            _entries[index].Value = value;
            _buckets[targetBucket] = index;
            _version++;
        }

        void Resize()
        {
            Resize(MathEx.ExpandPrime(_count), false);
        }

        void Resize(int newSize, bool forceNewHashCodes)
        {
            int[] newBuckets = new int[newSize];
            for (int i = 0; i < newBuckets.Length; i++)
            {
                newBuckets[i] = -1;
            }

            var newEntries = new Entry[newSize];
            Array.Copy(_entries, 0, newEntries, 0, _count);
            if (forceNewHashCodes)
            {
                for (int i = 0; i < _count; i++)
                {
                    if (newEntries[i].HashCode != -1)
                    {
                        newEntries[i].HashCode = (_comparer.GetHashCode(newEntries[i].Key) & 0x7FFFFFFF);
                    }
                }
            }
            for (int i = 0; i < _count; i++)
            {
                if (newEntries[i].HashCode >= 0)
                {
                    int bucket = newEntries[i].HashCode % newSize;
                    newEntries[i].Next = newBuckets[bucket];
                    newBuckets[bucket] = i;
                }
            }
            _buckets = newBuckets;
            _entries = newEntries;
        }

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
        {
            ThrowIfArgumentNull(array);
            ThrowIfIndexOutOfRange(index, array.Length);

            if (array.Length - index < Count)
            {
                throw new OutOfMemoryException("복사 위치의 공간이 충분하지 않습니다.");
            }

            int count = this._count;
            Entry[] entries = this._entries;
            for (int i = 0; i < count; i++)
            {
                if (entries[i].HashCode >= 0)
                {
                    array[index++] = new KeyValuePair<TKey, TValue>(entries[i].Key, entries[i].Value);
                }
            }
        }

        static void ThrowNotSupported()
        {
            throw new NotSupportedException("지원하지 않는 연산입니다.");
        }

        void ThrowIfVersionNotValidRemoted(int remotedVersion)
        {
            if (remotedVersion != _version)
            {
                throw new InvalidOperationException("컨테이너를 참조하는 중 컨테이너 데이터가 변경되었습니다.");
            }
        }

        static void ThrowKeyDuplicated()
        {
            throw new InvalidOperationException("추가하려는 키가 이미 컨테이너에 존재합니다.");
        }

        static void ThrowIfIndexOutOfRange(int index, int length)
        {
            if (index < 0 || index > length)
            {
                throw new IndexOutOfRangeException("매개변수로 전달된 인덱스가 범위를 벗어납니다.");
            }
        }

        static void ThrowIfCapacityOutOfRange(int capacity)
        {
            if (capacity < 0)
            {
                throw new OutOfMemoryException("매개변수로 전달된 허용량 값이 올바르지 않습니다.");
            }
        }

        static void ThrowIfArgumentNull<T>(T argument)
        {
            if (argument is null)
            {
                throw new ArgumentNullException("null을 허용하지 않는 매개변수에 null이 전달되었습니다.");
            }
        }

        static void ThrowKeyNotFoundException()
        {
            throw new KeyNotFoundException("지정한 키를 찾을 수 없습니다.");
        }

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> keyValuePair)
        {
            Add(keyValuePair.Key, keyValuePair.Value);
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> keyValuePair)
        {
            int i = FindEntry(keyValuePair.Key);
            if (i >= 0 && EqualityComparer<TValue>.Default.Equals(_entries[i].Value, keyValuePair.Value))
            {
                return true;
            }
            return false;
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair)
        {
            int i = FindEntry(keyValuePair.Key);
            if (i >= 0 && EqualityComparer<TValue>.Default.Equals(_entries[i].Value, keyValuePair.Value))
            {
                Remove(keyValuePair.Key);
                return true;
            }
            return false;
        }

        TValue IDictionary<TKey, TValue>.this[TKey key]
        {
            get => this[key];
            set => this[key] = value;
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        ICollection<TKey> IDictionary<TKey, TValue>.Keys => Keys;
        IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => Keys;
        ICollection<TValue> IDictionary<TKey, TValue>.Values => Values;
        IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => Values;
        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;
        TValue IReadOnlyDictionary<TKey, TValue>.this[TKey key] => this[key];

        /// <summary>
        /// <see cref="TMap{TKey, TValue}"/> 컨테이너 데이터를 순회하는 열거자 클래스입니다.
        /// </summary>
        public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IDictionaryEnumerator
        {
            TMap<TKey, TValue> dictionary;
            int version;
            int index;
            KeyValuePair<TKey, TValue> current;
            int getEnumeratorRetType;  // What should Enumerator.Current return?

            internal const int DictEntry = 1;
            internal const int KeyValuePair = 2;

            internal Enumerator(TMap<TKey, TValue> dictionary, int getEnumeratorRetType)
            {
                this.dictionary = dictionary;
                version = dictionary._version;
                index = 0;
                this.getEnumeratorRetType = getEnumeratorRetType;
                current = new KeyValuePair<TKey, TValue>();
            }

            /// <inheritdoc/>
            public bool MoveNext()
            {
                dictionary.ThrowIfVersionNotValidRemoted(version);

                // Use unsigned comparison since we set index to dictionary.count+1 when the enumeration ends.
                // dictionary.count+1 could be negative if dictionary.count is Int32.MaxValue
                while ((uint)index < (uint)dictionary._count)
                {
                    if (dictionary._entries[index].HashCode >= 0)
                    {
                        current = new KeyValuePair<TKey, TValue>(dictionary._entries[index].Key, dictionary._entries[index].Value);
                        index++;
                        return true;
                    }
                    index++;
                }

                index = dictionary._count + 1;
                current = new KeyValuePair<TKey, TValue>();
                return false;
            }

            /// <inheritdoc/>
            public KeyValuePair<TKey, TValue> Current => current;

            /// <inheritdoc/>
            public void Dispose()
            {
            }

            object IEnumerator.Current
            {
                get
                {
#if DEBUG
                    if (index == 0 || (index == dictionary._count + 1))
                    {
                        throw new InvalidOperationException("알 수 없는 컨테이너 오류입니다.");
                    }
#endif

                    if (getEnumeratorRetType == DictEntry)
                    {
                        return new DictionaryEntry(current.Key, current.Value);
                    }
                    else
                    {
                        return new KeyValuePair<TKey, TValue>(current.Key, current.Value);
                    }
                }
            }

            void IEnumerator.Reset()
            {
                dictionary.ThrowIfVersionNotValidRemoted(version);

                index = 0;
                current = new KeyValuePair<TKey, TValue>();
            }

            DictionaryEntry IDictionaryEnumerator.Entry
            {
                get
                {
#if DEBUG
                    if (index == 0 || (index == dictionary._count + 1))
                    {
                        throw new InvalidOperationException("알 수 없는 컨테이너 오류입니다.");
                    }
#endif

                    return new DictionaryEntry(current.Key, current.Value);
                }
            }

            object IDictionaryEnumerator.Key
            {
                get
                {
#if DEBUG
                    if (index == 0 || (index == dictionary._count + 1))
                    {
                        throw new InvalidOperationException("알 수 없는 컨테이너 오류입니다.");
                    }
#endif

                    return current.Key;
                }
            }

            object IDictionaryEnumerator.Value
            {
                get
                {
#if DEBUG
                    if (index == 0 || (index == dictionary._count + 1))
                    {
                        throw new InvalidOperationException("알 수 없는 컨테이너 오류입니다.");
                    }
#endif

                    return current.Value;
                }
            }
        }

        /// <summary>
        /// <see cref="TMap{TKey, TValue}"/> 컨테이너의 키 집합을 표현합니다.
        /// </summary>
        public sealed class KeyCollection : ICollection<TKey>, IReadOnlyCollection<TKey>
        {
            TMap<TKey, TValue> dictionary;

            /// <summary>
            /// <see cref="KeyCollection"/> 클래스의 새 인스턴스를 초기화합니다.
            /// </summary>
            /// <param name="dictionary"> 원본 개체를 전달합니다. </param>
            public KeyCollection(TMap<TKey, TValue> dictionary)
            {
                ThrowIfArgumentNull(dictionary);
                this.dictionary = dictionary;
            }

            /// <inheritdoc/>
            public Enumerator GetEnumerator()
            {
                return new Enumerator(dictionary);
            }

            /// <inheritdoc/>
            public void CopyTo(TKey[] array, int index)
            {
                ThrowIfArgumentNull(array);
                ThrowIfIndexOutOfRange(index, array.Length);

                if (array.Length - index < dictionary.Count)
                {
                    throw new OutOfMemoryException("복사 위치의 공간이 충분하지 않습니다.");
                }

                int count = dictionary._count;
                Entry[] entries = dictionary._entries;
                for (int i = 0; i < count; i++)
                {
                    if (entries[i].HashCode >= 0)
                    {
                        array[index++] = entries[i].Key;
                    }
                }
            }

            /// <inheritdoc/>
            public int Count => dictionary.Count;

            bool ICollection<TKey>.IsReadOnly => true;

            bool ICollection<TKey>.Contains(TKey item)
            {
                return dictionary.ContainsKey(item);
            }

            bool ICollection<TKey>.Remove(TKey item)
            {
                ThrowNotSupported();
                return false;
            }

            void ICollection<TKey>.Add(TKey item) => ThrowNotSupported();
            void ICollection<TKey>.Clear() => ThrowNotSupported();
            IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator() => GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            /// <summary>
            /// <see cref="KeyCollection"/> 컨테이너의 열거자 클래스입니다.
            /// </summary>
            public struct Enumerator : IEnumerator<TKey>
            {
                TMap<TKey, TValue> dictionary;
                int index;
                int version;
                TKey currentKey;

                internal Enumerator(TMap<TKey, TValue> dictionary)
                {
                    this.dictionary = dictionary;
                    version = dictionary._version;
                    index = 0;
                    currentKey = default;
                }

                /// <inheritdoc/>
                public void Dispose()
                {
                }

                /// <inheritdoc/>
                public bool MoveNext()
                {
                    dictionary.ThrowIfVersionNotValidRemoted(version);

                    while ((uint)index < (uint)dictionary._count)
                    {
                        if (dictionary._entries[index].HashCode >= 0)
                        {
                            currentKey = dictionary._entries[index].Key;
                            index++;
                            return true;
                        }
                        index++;
                    }

                    index = dictionary._count + 1;
                    currentKey = default(TKey);
                    return false;
                }

                /// <inheritdoc/>
                public TKey Current => currentKey;

                object System.Collections.IEnumerator.Current => Current;

                void System.Collections.IEnumerator.Reset()
                {
                    dictionary.ThrowIfVersionNotValidRemoted(version);

                    index = 0;
                    currentKey = default;
                }
            }
        }

        /// <summary>
        /// <see cref="TMap{TKey, TValue}"/> 컨테이너의 값 집합을 표현합니다.
        /// </summary>
        public sealed class ValueCollection : ICollection<TValue>, IReadOnlyCollection<TValue>
        {
            TMap<TKey, TValue> dictionary;

            /// <summary>
            /// <see cref="ValueCollection"/> 클래스의 새 인스턴스를 초기화합니다.
            /// </summary>
            /// <param name="dictionary"> 원본 개체를 전달합니다. </param>
            public ValueCollection(TMap<TKey, TValue> dictionary)
            {
                ThrowIfArgumentNull(dictionary);
                this.dictionary = dictionary;
            }

            /// <inheritdoc/>
            public Enumerator GetEnumerator()
            {
                return new Enumerator(dictionary);
            }

            /// <inheritdoc/>
            public void CopyTo(TValue[] array, int index)
            {
                ThrowIfArgumentNull(array);
                ThrowIfIndexOutOfRange(index, array.Length);

                if (array.Length - index < dictionary.Count)
                {
                    throw new OutOfMemoryException("복사 위치의 공간이 충분하지 않습니다.");
                }

                int count = dictionary._count;
                Entry[] entries = dictionary._entries;
                for (int i = 0; i < count; i++)
                {
                    if (entries[i].HashCode >= 0)
                    {
                        array[index++] = entries[i].Value;
                    }
                }
            }

            /// <inheritdoc/>
            public int Count => dictionary.Count;

            bool ICollection<TValue>.IsReadOnly => true;

            bool ICollection<TValue>.Contains(TValue item)
            {
                return dictionary.ContainsValue(item);
            }

            bool ICollection<TValue>.Remove(TValue item)
            {
                ThrowNotSupported();
                return false;
            }

            void ICollection<TValue>.Add(TValue item) => ThrowNotSupported();
            void ICollection<TValue>.Clear() => ThrowNotSupported();
            IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            /// <summary>
            /// <see cref="ValueCollection"/> 컨테이너의 열거자 클래스입니다.
            /// </summary>
            public struct Enumerator : IEnumerator<TValue>
            {
                TMap<TKey, TValue> dictionary;
                int index;
                int version;
                TValue currentValue;

                internal Enumerator(TMap<TKey, TValue> dictionary)
                {
                    this.dictionary = dictionary;
                    version = dictionary._version;
                    index = 0;
                    currentValue = default;
                }

                /// <inheritdoc/>
                public void Dispose()
                {
                }

                /// <inheritdoc/>
                public bool MoveNext()
                {
                    dictionary.ThrowIfVersionNotValidRemoted(version);

                    while ((uint)index < (uint)dictionary._count)
                    {
                        if (dictionary._entries[index].HashCode >= 0)
                        {
                            currentValue = dictionary._entries[index].Value;
                            index++;
                            return true;
                        }
                        index++;
                    }
                    index = dictionary._count + 1;
                    currentValue = default;
                    return false;
                }

                /// <inheritdoc/>
                public TValue Current
                {
                    get
                    {
                        return currentValue;
                    }
                }

                object System.Collections.IEnumerator.Current => Current;

                void System.Collections.IEnumerator.Reset()
                {
                    dictionary.ThrowIfVersionNotValidRemoted(version);

                    index = 0;
                    currentValue = default;
                }
            }
        }
        struct Entry
        {
            public int HashCode;
            public int Next;
            public TKey Key;
            public TValue Value;
        }
    }
}