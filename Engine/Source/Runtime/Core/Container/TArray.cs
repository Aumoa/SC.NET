// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace SC.Engine.Runtime.Core.Container
{
    /// <summary>
    /// 연속된 공간을 가지는 가변 데이터 컨테이너를 표현합니다.
    /// </summary>
    /// <typeparam name="T"> 데이터 유형을 전달합니다. </typeparam>
    [Serializable]
    [DebuggerTypeProxy(typeof(IReadOnlyCollectionDebugView<>))]
    [DebuggerDisplay("Count = {Count}")]
    public partial class TArray<T> : IList<T>, IReadOnlyList<T>, ICloneable
    {
        static T[] EmptyArray = new T[0];
        const int CapacityUnit = 16;

        T[] _items;
        int _count;
        int _revision;

        /// <summary>
        /// 이 데이터와 일치하는지 여부를 검사하는 함수의 대리자입니다.
        /// </summary>
        /// <param name="inValue"> 데이터가 전달됩니다. </param>
        public delegate bool PredicateDelegate(T inValue);

        /// <summary>
        /// 두 데이터를 비교한 값을 반환하는 함수의 대리자입니다.
        /// </summary>
        /// <param name="left"> 첫 번째 데이터가 전달됩니다. </param>
        /// <param name="right"> 두 번째 데이터가 전달됩니다. </param>
        public delegate int CompareDelegate(T left, T right);

        /// <summary>
        /// <see cref="TArray{T}"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        public TArray()
        {
            _items = EmptyArray;
        }

        /// <summary>
        /// <see cref="TArray{T}"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="inItems"> 초기 아이템 목록을 전달합니다. </param>
        public TArray(params T[] inItems)
        {
            if (inItems?.Length > 0)
            {
                Count = inItems.Length;
                inItems.CopyTo(_items, 0);
            }
        }

        /// <summary>
        /// <see cref="TArray{T}"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="reservedCapacity"> 예약 공간을 전달합니다. </param>
        public TArray(int reservedCapacity)
        {
            if (reservedCapacity < 0)
            {
                throw new ArgumentException($"reserve 매개변수의 값({reservedCapacity})이 0 이하입니다.");
            }

            if (reservedCapacity == 0)
            {
                _items = EmptyArray;
            }
            else
            {
                Capacity = reservedCapacity;
            }
        }

        /// <summary>
        /// <see cref="TArray{T}"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="inCollection"> 초기 값을 채울 컬렉션을 전달합니다. </param>
        public TArray(IEnumerable<T> inCollection)
        {
            CheckNull(inCollection);

            using (var enumerator = inCollection.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Add(enumerator.Current);
                }
            }
        }

        /// <summary>
        /// <see cref="TArray{T}"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="inCollection"> 초기 값을 채울 컬렉션을 전달합니다. </param>
        public TArray(ICollection<T> inCollection)
        {
            CheckNull(inCollection);

            if (inCollection.Count == 0)
            {
                _items = EmptyArray;
            }
            else
            {
                Count = inCollection.Count;
                inCollection.CopyTo(_items, 0);
            }
        }

        /// <inheritdoc/>
        public virtual IEnumerator<T> GetEnumerator()
        {
            return new VectorEnumerator(this, _revision, 0, _count);
        }

        /// <inheritdoc/>
        public virtual void Add(T item)
        {
            EnsureCapacity(_count + 1, false);
            _items[_count++] = item;
            ++_revision;
        }

        /// <inheritdoc/>
        public virtual void Clear()
        {
            Clear(true);
        }

        /// <inheritdoc/>
        public virtual bool Contains(T item)
        {
            for (int i = 0; i < _count; ++i)
            {
                if (_items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc/>
        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            CopyTo(arrayIndex, array, 0, _count - arrayIndex);
        }

        /// <inheritdoc/>
        public virtual bool Remove(T item) => Remove(item, true);

        /// <inheritdoc/>
        public virtual int IndexOf(T item) => Array.IndexOf(_items, item);

        /// <inheritdoc/>
        public virtual void Insert(Index index, T item) => Insert(IndexToInt(index), item);

        /// <summary>
        /// 컬렉션에 값을 위치에 추가합니다. 기존 위치 이후의 값을 뒤로 밀어냅니다.
        /// </summary>
        /// <param name="index"> 값을 추가할 위치를 전달합니다. </param>
        /// <param name="item"> 값을 전달합니다. </param>
        public void Insert(int index, T item)
        {
            CheckIndex(index);

            EnsureCapacity(_count + 1, false);

            // Container has items that need move to back.
            if (index < _count)
            {
                Array.Copy(_items, index, _items, index + 1, _count - index);
            }

            _items[index] = item;
            ++_count;
            ++_revision;
        }

        /// <inheritdoc/>
        public virtual void RemoveAt(int index)
        {
            RemoveAt(index, true);
        }

        /// <inheritdoc/>
        public virtual void RemoveAt(Index index)
        {
            RemoveAt(index, true);
        }

        /// <inheritdoc/>
        public virtual object Clone()
        {
            var clone = new TArray<T>(Count);
            _items.CopyTo(clone._items, 0);
            clone._count = _count;

            return clone;
        }

        /// <summary>
        /// 컨테이너에 기본값을 가진 데이터를 컨테이너의 마지막에 추가합니다.
        /// </summary>
        public void AddDefault()
        {
            Add(default);
        }

        /// <summary>
        /// 대상 배열로 컨테이너의 모든 데이터를 복사합니다.
        /// </summary>
        /// <param name="array"> 복사 위치를 전달합니다. </param>
        public void CopyTo(T[] array)
        {
            CopyTo(0, array, 0, _count);
        }

        /// <summary>
        /// 대상 배열로 컨테이너의 일부 데이터를 복사합니다.
        /// </summary>
        /// <param name="fromIndex"> 현재 컨테이너의 복사 시작 위치를 전달합니다. </param>
        /// <param name="array"></param>
        /// <param name="toIndex"></param>
        /// <param name="count"></param>
        public void CopyTo(int fromIndex, T[] array, int toIndex, int count)
        {
            CheckIndex(fromIndex);

            Array.Copy(_items, fromIndex, array, toIndex, count);
        }

        /// <summary>
        /// 지정한 위치부터 시작하여 대상 배열에 데이터를 복사합니다.
        /// </summary>
        /// <param name="array"> 대상 배열을 전달합니다. </param>
        /// <param name="arrayIndex"> 시작 위치를 전달합니다. </param>
        public void CopyTo(TArray<T> array, int arrayIndex = 0)
        {
            CheckIndex(arrayIndex);

            _items.CopyTo(array._items, arrayIndex);
        }

        /// <summary>
        /// 컨테이너에서 전달된 매개변수와 일치하는 데이터 하나를 제거합니다.
        /// </summary>
        /// <param name="item"> 제거할 데이터를 전달합니다. </param>
        /// <param name="bAllowShrink"> 이 컨테이너의 예약 공간이 축소되는 것을 허용합니다. </param>
        /// <returns> 컨테이너에서 데이터 제거를 성공하였을 경우 <see langword="true"/>가 반환됩니다. </returns>
        public bool Remove(T item, bool bAllowShrink)
        {
            int index = IndexOf(item);
            if (index < 0)
            {
                return false;
            }

            RemoveAt(index, bAllowShrink);
            return true;
        }

        /// <summary>
        /// 컨테이너에서 해당 인덱스에 있는 데이터를 제거합니다.
        /// </summary>
        /// <param name="index"> 인덱스를 전달합니다. </param>
        /// <param name="bAllowShrink"> 이 컨테이너의 예약 공간이 축소되는 것을 허용합니다. </param>
        public void RemoveAt(int index, bool bAllowShrink) => RemoveAt(new Index(index), bAllowShrink);

        /// <summary>
        /// 컨테이너에서 해당 인덱스에 있는 데이터를 제거합니다.
        /// </summary>
        /// <param name="index"> 인덱스를 전달합니다. </param>
        /// <param name="bAllowShrink"> 이 컨테이너의 예약 공간이 축소되는 것을 허용합니다. </param>
        public void RemoveAt(Index index, bool bAllowShrink)
        {
            int i = IndexToInt(index);
            CheckIndex(i);

            --_count;

            // Container has items that need move to front.
            if (i < _count)
            {
                Array.Copy(_items, i + 1, _items, i, _count - i);
            }

            _items[_count] = default;
            ++_revision;

            if (bAllowShrink)
            {
                EnsureCapacity(_count, false);
            }
        }

        /// <summary>
        /// 컨테이너에 데이터 목록을 추가합니다.
        /// </summary>
        /// <param name="append"> 데이터 목록을 전달합니다. </param>
        public void Append(IEnumerable<T> append)
        {
            InsertRange(_count, append);
        }

        /// <summary>
        /// 컨테이너에서 해당 인덱스부터 특정 개수만큼 데이터를 제거합니다.
        /// </summary>
        /// <param name="index"> 인덱스를 전달합니다. </param>
        /// <param name="count"> 제거할 데이터 개수를 전달합니다. </param>
        /// <param name="bAllowShrink"> 이 컨테이너의 예약 공간이 축소되는 것을 허용합니다. </param>
        public void RemoveAt(int index, int count, bool bAllowShrink = true)
        {
            if (count <= 0)
            {
                throw new IndexOutOfRangeException($"{nameof(count)} 매개변수의 값이 0보다 작거나 같습니다.");
            }

            CheckIndex(index);
            CheckIndex(index + count - 1);

            _count -= count;

            // Container has items that need move to front.
            if (count < _count)
            {
                Array.Copy(_items, index + count, _items, index, _count - index);
            }

            Array.Clear(_items, _count, count);

            _items[count] = default;
            ++_revision;

            if (bAllowShrink)
            {
                EnsureCapacity(count, false);
            }
        }

        /// <summary>
        /// 컨테이너에서 모든 데이터를 제거합니다.
        /// </summary>
        /// <param name="bAllowShrink"> 이 컨테이너의 예약 공간이 축소되는 것을 허용합니다. </param>
        public void Clear(bool bAllowShrink)
        {
            if (bAllowShrink)
            {
                _items = EmptyArray;
            }

            _count = 0;
            ++_revision;
        }

        /// <summary>
        /// 이 컨테이너가 가진 데이터의 실제 개수를 설정합니다. 데이터 개수가 현재 개수보다 많아질 경우, 늘어난 공간은 기본값으로 채워집니다.
        /// </summary>
        /// <param name="value"> 새로운 데이터 개수를 전달합니다. </param>
        /// <param name="bAllowShrink"> 이 컨테이너의 예약 공간이 축소되는 것을 허용합니다. </param>
        public void SetCount(int value, bool bAllowShrink)
        {
            if (value < _count)
            {
                int last = _count;
                _count = value;

                if (bAllowShrink)
                {
                    EnsureCapacity(_count, true);
                }
                else
                {
                    Array.Clear(_items, _count, last - _count);
                }

                ++_revision;
            }
            else if (value > _count)
            {
                _count = value;
                EnsureCapacity(_count, true);
                ++_revision;
            }
        }

        /// <summary>
        /// 이 컨테이너가 소유한 데이터의 일부를 참조하는 읽기 전용 리스트를 가져옵니다.
        /// </summary>
        /// <param name="startIndex"> 참조를 시작할 위치를 전달합니다. </param>
        /// <param name="length"> 참조 개수를 전달합니다. </param>
        /// <returns> 읽기 전용 리스트 개체가 반환됩니다. </returns>
        public IReadOnlyList<T> GetSubarrayView(int startIndex, int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException($"length 매개변수가 {length}입니다.");
            }

            CheckIndex(startIndex);
            CheckIndex(startIndex + length - 1);

            return new SubarrayView(this, startIndex, length);
        }

        /// <summary>
        /// 기존 컨테이너에 해당 데이터가 존재하지 않을 경우 새 데이터를 배열의 마지막에 추가합니다.
        /// </summary>
        /// <param name="item"> 추가할 데이터를 전달합니다. </param>
        /// <returns> 데이터 추가에 성공했을 경우 <see langword="true"/>를 반환합니다. </returns>
        public bool AddUnique(T item)
        {
            if (!Contains(item))
            {
                Add(item);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 기존 컨테이너에 해당 데이터가 존재하지 않을 경우 새 데이터를 지정한 위치에 추가합니다.
        /// </summary>
        /// <param name="index"> 데이터가 추가될 위치를 전달합니다. </param>
        /// <param name="item"> 추가할 데이터를 전달합니다. </param>
        /// <returns> 데이터 추가에 성공했을 경우 <see langword="true"/>를 반환합니다. </returns>
        public bool InsertUnique(int index, T item)
        {
            if (!Contains(item))
            {
                Insert(index, item);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 이 컨테이너에 있는 모든 데이터를 정렬합니다.
        /// </summary>
        /// <param name="pred"> 정렬을 위한 순서 비교 함수를 전달합니다. </param>
        public void Sort(CompareDelegate pred = null)
        {
            Sort(pred is not null ? new LocalComparer(pred) : null);
        }

        /// <summary>
        /// 이 컨테이너에 있는 모든 데이터를 정렬합니다.
        /// </summary>
        /// <param name="comparer"> 정렬을 위한 순서 비교 개체를 전달합니다. </param>
        public void Sort(IComparer<T> comparer)
        {
            Array.Sort(_items, 0, _count, comparer);
            ++_revision;
        }

        /// <summary>
        /// 데이터 일치 여부를 서술하는 함수를 제공해 컨테이너에 데이터가 있는지 여부를 검사합니다.
        /// </summary>
        /// <param name="pred"> 데이터 술부를 전달합니다. </param>
        /// <returns> 일치하는 데이터가 있을 경우 <see langword="true"/>를 반환합니다. </returns>
        public bool ContainsByPredicate(PredicateDelegate pred)
        {
            int indexOf = IndexOfByPredicate(pred);
            if (indexOf != -1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 데이터 일치 여부를 서술하는 함수를 제공해 컨테이너서 가장 처음 발견된 일치하는 데이터의 인덱스를 가져옵니다.
        /// </summary>
        /// <param name="pred"> 데이터 술부를 전달합니다. </param>
        /// <returns> 일치하는 개체가 있을 경우 해당 개체의 인덱스를, 없을 경우 <c>-1</c>을 반환합니다. </returns>
        public int IndexOfByPredicate(PredicateDelegate pred)
        {
            if (pred == null)
            {
                throw new ArgumentNullException($"매개변수 {nameof(pred)}가 null입니다.");
            }

            for (int i = 0; i < _count; ++i)
            {
                if (pred(_items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 해당 데이터와 일치하는 모든 데이터를 반환합니다.
        /// </summary>
        /// <param name="value"> 데이터를 전달합니다. </param>
        /// <returns> 일치하는 모든 데이터의 복사된 배열이 반환됩니다. 일치하는 값이 없을 경우 <see langword="null"/>이 반환됩니다. </returns>
        public TArray<T> FindAll(T value)
        {
            int length = 0;

            for (int i = 0; i < _count; ++i)
            {
                if (_items[i].Equals(value))
                {
                    length += 1;
                }
            }

            if (length == 0)
            {
                return null;
            }
            else
            {
                var vector = new TArray<T>(length);
                for (int i = 0; i < length; ++i)
                {
                    vector._items[i] = value;
                }
                vector._count = length;

                return vector;
            }
        }

        /// <summary>
        /// 데이터 일치 여부를 서술하는 함수를 제공해 일치하는 모든 데이터를 반환합니다.
        /// </summary>
        /// <param name="pred"> 데이터 술부를 전달합니다. </param>
        /// <returns> 일치하는 모든 데이터의 복사된 배열이 반환됩니다. 일치하는 값이 없을 경우 <see langword="null"/>이 반환됩니다. </returns>
        public TArray<T> FindAllByPredicate(PredicateDelegate pred)
        {
            if (pred == null)
            {
                throw new ArgumentNullException($"매개변수 {nameof(pred)}가 null입니다.");
            }

            var result = new TArray<T>();

            for (int i = 0; i < _count; ++i)
            {
                if (pred(_items[i]))
                {
                    result.Add(_items[i]);
                }
            }

            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        /// <summary>
        /// 전달된 인덱스가 이 컨테이너에서 올바른 배열 인덱스인지 검사합니다.
        /// </summary>
        /// <param name="index"> 인덱스를 전달합니다. </param>
        /// <returns> 올바를 경우 <see langword="true"/>가 반환됩니다. </returns>
        public bool IsValidIndex(int index)
        {
            if (index < 0 || index >= _count)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 컨테이너 내의 두 데이터의 위치를 교환합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 데이터의 위치를 전달합니다. </param>
        /// <param name="right"> 두 번째 데이터의 위치를 전달합니다. </param>
        public void Swap(int left, int right)
        {
            CheckIndex(left);
            CheckIndex(right);

            T temp = _items[left];
            _items[left] = _items[right];
            _items[right] = temp;
        }

        /// <summary>
        /// 컨테이너 내의 두 데이터의 위치를 교환합니다.
        /// </summary>
        /// <param name="left"> 첫 번째 데이터의 위치를 전달합니다. </param>
        /// <param name="right"> 두 번째 데이터의 위치를 전달합니다. </param>
        public void Swap(Index left, Index right)
        {
            int l = IndexToInt(left);
            int r = IndexToInt(right);

            CheckIndex(l);
            CheckIndex(r);

            T temp = _items[l];
            _items[l] = _items[r];
            _items[r] = temp;
        }

        /// <summary>
        /// 컨테이너의 지정한 위치에 컬렉션 데이터를 모두 삽입합니다.
        /// </summary>
        /// <param name="index"> 삽입 위치를 전달합니다. </param>
        /// <param name="collection"> 데이터 컬렉션을 전달합니다. </param>
        public void InsertRange(int index, IEnumerable<T> collection)
        {
            CheckNull(collection);
            CheckIndex(index);

            using (var enumerator = collection.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Insert(index++, enumerator.Current);
                }
            }
        }

        /// <summary>
        /// 컨테이너의 지정한 위치에 컬렉션 데이터를 모두 삽입합니다.
        /// </summary>
        /// <param name="index"> 삽입 위치를 전달합니다. </param>
        /// <param name="collection"> 데이터 컬렉션을 전달합니다. </param>
        public void InsertRange(int index, ICollection<T> collection)
        {
            CheckNull(collection);
            CheckIndex(index);

            int count = collection.Count;
            Slack = count;
            if (index < this._count)
            {
                Array.Copy(_items, index, _items, index + count, this._count - index);
            }

            if (this == collection)
            {
                Array.Copy(_items, 0, _items, index, index);
                Array.Copy(_items, index + count, _items, index * 2, this._count - index);
            }
            else
            {
                collection.CopyTo(_items, index);
            }

            _count += count;
            ++_revision;
        }

		/// <summary>
		/// 이 컨테이너가 가진 데이터의 실제 개수를 설정하거나 가져옵니다. 데이터 개수가 현재 개수보다 많아질 경우, 늘어난 공간은 기본값으로 채워집니다.
		/// </summary>
		public virtual int Count
		{
            get => _count;
            set => SetCount(value, true);
		}

		/// <inheritdoc/>
		public virtual bool IsReadOnly
		{
            get => false;
		}

		/// <summary>
		/// 이 컨테이너에 남아있는 여유 공간을 설정하거나 가져옵니다.
		/// </summary>
		public int Slack
		{

            get => _items.Length - _count;
            set => Capacity = _count + value;
		}

		/// <summary>
		/// 이 컨테이너의 여유 공간을 설정하거나 가져옵니다. 여유 공간은 <see cref="Count"/>보다 작아지지 않습니다.
		/// </summary>
		public int Capacity
		{
            get => _items.Length;
            set
            {
                if (value < _count)
                {
                    value = _count;
                }

                if (_items is null || _items.Length != value)
                {
                    var tempArray = new T[value];
                    _items?.CopyTo(tempArray, 0);
                    _items = tempArray;
                }
            }
		}

        T IList<T>.this[int index]
        {
            get
            {
                CheckIndex(index);
                return _items[index];
            }
            set
            {
                CheckIndex(index);
                _items[index] = value;
            }
        }

        /// <summary>
        /// 이 컨테이너에 보관된 값의 참조를 인덱스 값으로 가져옵니다.
        /// </summary>
        public ref T this[int index]
		{
            get
            {
                CheckIndex(index);
                return ref _items[index];
            }
        }

        /// <summary>
        /// 이 컨테이너에 보관된 값의 참조를 인덱스 값으로 가져옵니다.
        /// </summary>
        public ref T this[Index index]
        {
            get
            {
                int i = IndexToInt(index);
                return ref this[i];
            }
        }

        bool EnsureCapacity(int minimumCount, bool bExplicit)
        {
            if (minimumCount < _items.Length)
            {
                return false;
            }

            if (bExplicit)
            {
                Capacity = minimumCount;
            }
            else
            {
                int nextCapacity = _items.Length + CapacityUnit;
                Capacity = nextCapacity;
            }

            return true;
        }

        void CheckIndex(int index)
        {
            if (index >= _count)
            {
                throw new IndexOutOfRangeException($"인덱스({index})가 범위를 벗어났습니다.");
            }
        }

        void CheckNull(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException($"매개변수가 null입니다.");
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        T IReadOnlyList<T>.this[int index] => this[index];

        class LocalComparer : IComparer<T>
        {
            CompareDelegate myPred;

            public LocalComparer(CompareDelegate pred)
            {
                myPred = pred;
            }

            public virtual int Compare(T x, T y)
            {
                return myPred(x, y);
            }
        }

        class SubarrayView : IReadOnlyList<T>
        {
            TArray<T> origin;
            int revision;

            int startIndex;
            int length;

            public SubarrayView(TArray<T> inOrigin, int inStartIndex, int inLength)
            {
                origin = inOrigin;
                revision = inOrigin._revision;

                startIndex = inStartIndex;
                length = inLength;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return new VectorEnumerator(origin, revision, startIndex, length);
            }

            public int Count
            {
                get => length;
            }

            public T this[int index]
            {
                get
                {
                    CheckIndex(index);
                    return origin[startIndex + index];
                }
            }

            void CheckIndex(int index)
            {
                if (index < 0 || index >= length)
                {
                    throw new IndexOutOfRangeException($"인덱스({index}는 잘못된 값입니다.");
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        class VectorEnumerator : IEnumerator<T>
        {
            TArray<T> origin;
            int revision;
            T current;
            int myIndex;

            int startIndex;
            int length;

            public VectorEnumerator(TArray<T> InOrigin, int InRevision, int InStartIndex, int InLength)
            {
                origin = InOrigin;
                revision = InRevision;

                startIndex = InStartIndex;
                length = InLength;
            }

            public virtual void Dispose()
            {

            }

            public virtual bool MoveNext()
            {
                VersionCheck();

                bool bValid = IsValidIndex(Index);

                if (bValid)
                {
                    current = origin[Index];
                }
                else
                {
                    current = default;
                }

                ++myIndex;
                return bValid;
            }

            public virtual void Reset()
            {
                VersionCheck();

                myIndex = 0;
                current = default;
            }

            public virtual T Current
            {
                get => current;
            }

            void VersionCheck()
            {
                if (origin._revision != revision)
                {
                    throw new InvalidOperationException("열거하는 동안 컨테이너 내용이 변경되었습니다.");
                }
            }

            bool IsValidIndex(int index)
            {
                if (index >= length)
                {
                    return false;
                }

                return true;
            }

            int Index
            {
                get => startIndex + myIndex;
            }

            object IEnumerator.Current => Current;
        }

        /// <summary>
        /// 값을 최상위에 추가합니다.
        /// </summary>
        /// <param name="value"> 값을 전달합니다. </param>
        public void Push(T value)
        {
            Insert(_count, value);
        }

        /// <summary>
        /// 최상위 값을 가져오고 컨테이너에서 제거합니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public T Pop()
        {
            if (_count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            int indexOf = _count - 1;
            T value = _items[indexOf];
            RemoveAt(indexOf);
            return value;
        }

        /// <summary>
        /// 최상위 값의 참조를 가져옵니다.
        /// </summary>
        /// <returns> 값의 참조가 반환됩니다. </returns>
        public ref T Peek()
        {
            if (_count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            return ref _items[^1];
        }

        int IndexToInt(Index index)
        {
            if (index.IsFromEnd)
            {
                return _count - index.Value;
            }
            else
            {
                return index.Value;
            }
        }
    }
}