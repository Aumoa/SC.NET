// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

using SC.Engine.Runtime.Core.Mathematics;

namespace SC.Engine.Runtime.Core.Container
{
    /// <summary>
    /// 중복 불가능한 키로 이루어진 컨테이너입니다.
    /// </summary>
    /// <typeparam name="T"> 키의 형식을 전달합니다. </typeparam>
    [Serializable]
    [DebuggerTypeProxy(typeof(IReadOnlyCollectionDebugView<>))]
    [DebuggerDisplay("Count = {Count}")]
    public class TSet<T> : ISet<T>, IReadOnlySet<T>, ICollection<T>, ICloneable, ISerializable
    {
        int[] _buckets;
        Entry[] _entries;
        int _count;
        int _version;
        int _freeList;
        int _freeCount;
        IEqualityComparer<T> _comparer;

        /// <summary>
        /// <see cref="TSet{T}"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="capacity"> 미리 할당된 용량을 설정합니다. </param>
        /// <param name="comparer"> 개체를 정렬할 때 사용할 비교 개체를 전달합니다. </param>
        public TSet(int capacity = 0, IEqualityComparer<T> comparer = null)
        {
            ThrowIfCapacityOutOfRange(capacity);

            if (capacity > 0)
            {
                Initialize(capacity);
            }

            _comparer = comparer ?? EqualityComparer<T>.Default;
        }

        /// <summary>
        /// <see cref="TSet{T}"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="set"> 복사할 원본 컨테이너를 전달합니다. </param>
        /// <param name="comparer"> 개체를 정렬할 때 사용할 비교 개체를 전달합니다. </param>
        public TSet(ISet<T> set, IEqualityComparer<T> comparer = null) :
            this(set is not null ? set.Count : 0, comparer)
        {
            ThrowIfArgumentNull(set);

            foreach (T value in set)
            {
                Add(value);
            }
        }

        /// <summary>
        /// 이 개체가 사용하는 비교기를 가져옵니다.
        /// </summary>
        public virtual IEqualityComparer<T> Comparer => _comparer;

        /// <summary>
        /// 컨테이너에 보관된 아이템의 개수를 가져옵니다.
        /// </summary>
        public virtual int Count => _count - _freeCount;

        /// <summary>
        /// 컨테이너에 새로운 값을 추가합니다.
        /// </summary>
        /// <param name="value"> 값을 전달합니다. </param>
        public virtual bool Add(T value) => Insert(value, true);

        /// <summary>
        /// 컨테이너에서 지정한 값의 참조를 가져옵니다.
        /// </summary>
        /// <param name="value"> 값을 전달합니다. </param>
        /// <returns> 키와 쌍을 이루는 값의 참조가 반환됩니다. </returns>
        public ref T this[T value]
        {
            get
            {
                int i = FindEntry(value);
                if (i >= 0)
                {
                    return ref _entries[i].Value;
                }

                ThrowKeyNotFoundException();
                return ref _entries[0].Value;
            }
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
        /// 이 컨테이너에 지정한 값이 존재하는지 검사합니다.
        /// </summary>
        /// <param name="value"> 키를 전달합니다. </param>
        /// <returns> 존재할 경우 <see langword="true"/>가 반환됩니다. </returns>
        public virtual bool Contains(T value)
        {
            return FindEntry(value) >= 0;
        }

        /// <summary>
        /// 컨테이너의 열거자를 가져옵니다.
        /// </summary>
        /// <returns> 열거자가 반환됩니다. </returns>
        public virtual Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        /// <inheritdoc/>
        public virtual bool Remove(T value)
        {
            ThrowIfArgumentNull(value);

            if (_buckets is not null)
            {
                int hashCode = _comparer.GetHashCode(value) & 0x7FFFFFFF;
                int bucket = hashCode % _buckets.Length;
                int last = -1;
                for (int i = _buckets[bucket]; i >= 0; last = i, i = _entries[i].Next)
                {
                    if (_entries[i].HashCode == hashCode && _comparer.Equals(_entries[i].Value, value))
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
        /// 지정한 값을 찾습니다. 값을 찾지 못했을 경우 예외 대신 <see langword="false"/>를 반환합니다.
        /// </summary>
        /// <param name="key"> 찾을 값을 전달합니다. </param>
        /// <param name="value"> 실제 저장된 값을 받을 변수의 참조를 전달합니다. </param>
        /// <returns> 값을 찾았을 경우 <see langword="true"/>가 반환됩니다. </returns>
        public bool TryGetValue(T key, out T value)
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
            return new TSet<T>(this, Comparer);
        }

        int FindEntry(T key)
        {
            ThrowIfArgumentNull(key);

            if (_buckets is not null)
            {
                int hashCode = _comparer.GetHashCode(key) & 0x7FFFFFFF;
                for (int i = _buckets[hashCode % _buckets.Length]; i >= 0; i = _entries[i].Next)
                {
                    if (_entries[i].HashCode == hashCode && _comparer.Equals(_entries[i].Value, key))
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

        bool Insert(T value, bool add)
        {
            ThrowIfArgumentNull(value);

            if (_buckets == null)
            {
                Initialize(0);
            }

            int hashCode = _comparer.GetHashCode(value) & 0x7FFFFFFF;
            int targetBucket = hashCode % _buckets.Length;

            for (int i = _buckets[targetBucket]; i >= 0; i = _entries[i].Next)
            {
                if (_entries[i].HashCode == hashCode && _comparer.Equals(_entries[i].Value, value))
                {
                    if (add)
                    {
                        return false;
                    }
                    _entries[i].Value = value;
                    _version++;
                    return true;
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
            _entries[index].Value = value;
            _buckets[targetBucket] = index;
            _version++;

            return true;
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
                        newEntries[i].HashCode = (_comparer.GetHashCode(newEntries[i].Value) & 0x7FFFFFFF);
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

        void ICollection<T>.CopyTo(T[] array, int index)
        {
            ThrowIfArgumentNull(array);
            ThrowIfIndexOutOfRange(index, array.Length);

            if (array.Length - index < Count)
            {
                throw new OutOfMemoryException("복사 위치의 공간이 충분하지 않습니다.");
            }

            int count = _count;
            Entry[] entries = _entries;
            for (int i = 0; i < count; i++)
            {
                if (entries[i].HashCode >= 0)
                {
                    array[index++] = entries[i].Value;
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

        static void ThrowIfArgumentNull<T2>(T2 argument)
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

        void ICollection<T>.Add(T value)
        {
            Add(value);
        }

        bool ICollection<T>.Contains(T value)
        {
            int i = FindEntry(value);
            if (i >= 0 && EqualityComparer<T>.Default.Equals(_entries[i].Value, value))
            {
                return true;
            }
            return false;
        }

        bool ICollection<T>.Remove(T value)
        {
            int i = FindEntry(value);
            if (i >= 0 && EqualityComparer<T>.Default.Equals(_entries[i].Value, value))
            {
                Remove(value);
                return true;
            }
            return false;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        bool ICollection<T>.IsReadOnly => false;

        /// <summary>
        /// <see cref="TMap{TKey, TValue}"/> 컨테이너 데이터를 순회하는 열거자 클래스입니다.
        /// </summary>
        public struct Enumerator : IEnumerator<T>
        {
            TSet<T> dictionary;
            int version;
            int index;
            T current;

            internal const int DictEntry = 1;
            internal const int KeyValuePair = 2;

            internal Enumerator(TSet<T> dictionary)
            {
                this.dictionary = dictionary;
                version = dictionary._version;
                index = 0;
                current = default;
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
                        current = dictionary._entries[index].Value;
                        index++;
                        return true;
                    }
                    index++;
                }

                index = dictionary._count + 1;
                current = default;
                return false;
            }

            /// <inheritdoc/>
            public T Current => current;

            /// <inheritdoc/>
            public void Dispose()
            {
            }

            object IEnumerator.Current => current;

            void IEnumerator.Reset()
            {
                dictionary.ThrowIfVersionNotValidRemoted(version);

                index = 0;
                current = default;
            }
        }

        struct Entry
        {
            public int HashCode;
            public int Next;
            public T Value;
        }

        /// <inheritdoc/>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info is null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue("Version", _version);
            info.AddValue("Comparer", Comparer, typeof(IEqualityComparer<T>));
            info.AddValue("HashSize", _buckets is null ? 0 : _buckets.Length);

            if (_buckets is not null)
            {
                var array = new T[Count];
                CopyTo(array, 0);
                info.AddValue("KeyValuePair", array, typeof(T[]));
            }
        }

        void CopyTo(T[] array, int index)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if ((uint)index > (uint)array.Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (array.Length - index < Count)
            {
                throw new ArgumentException("Too small");
            }

            int count = _count;
            Entry[] entries = _entries;
            for (int i = 0; i < count; ++i)
            {
                if (entries[i].Next >= -1)
                {
                    array[index++] = entries[i].Value;
                }
            }
        }

        /// <inheritdoc/>
        public virtual void ExceptWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            // This is already the empty set; return.
            if (Count == 0)
            {
                return;
            }

            // Special case if other is this; a set minus itself is the empty set.
            if (other == this)
            {
                Clear();
                return;
            }

            // Remove every element in other from this.
            foreach (T element in other)
            {
                Remove(element);
            }
        }

        /// <inheritdoc/>
        public virtual void IntersectWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            // Intersection of anything with empty set is empty set, so return if count is 0.
            // Same if the set intersecting with itself is the same set.
            if (Count == 0 || other == this)
            {
                return;
            }

            // If other is known to be empty, intersection is empty set; remove all elements, and we're done.
            if (other is ICollection<T> otherAsCollection)
            {
                if (otherAsCollection.Count == 0)
                {
                    Clear();
                    return;
                }

                // Faster if other is a hashset using same equality comparer; so check
                // that other is a hashset using the same equality comparer.
                if (other is TSet<T> otherAsSet && EqualityComparersAreEqual(this, otherAsSet))
                {
                    IntersectWithHashSetWithSameComparer(otherAsSet);
                    return;
                }
            }

            IntersectWithEnumerable(other);
        }

        static bool EqualityComparersAreEqual(TSet<T> set1, TSet<T> set2) => set1.Comparer.Equals(set2.Comparer);

        /// <summary>
        /// If other is a hashset that uses same equality comparer, intersect is much faster
        /// because we can use other's Contains
        /// </summary>
        private void IntersectWithHashSetWithSameComparer(TSet<T> other)
        {
            Entry[] entries = _entries;
            for (int i = 0; i < _count; i++)
            {
                ref Entry entry = ref entries![i];
                if (entry.Next >= -1)
                {
                    T item = entry.Value;
                    if (!other.Contains(item))
                    {
                        Remove(item);
                    }
                }
            }
        }

        const int StackAllocThreshold = 100;

        ref struct BitHelper
        {
            private const int IntSize = sizeof(int) * 8;
            private readonly Span<int> _span;

            internal BitHelper(Span<int> span, bool clear)
            {
                if (clear)
                {
                    span.Clear();
                }
                _span = span;
            }

            internal void MarkBit(int bitPosition)
            {
                int bitArrayIndex = bitPosition / IntSize;
                if ((uint)bitArrayIndex < (uint)_span.Length)
                {
                    _span[bitArrayIndex] |= (1 << (bitPosition % IntSize));
                }
            }

            internal bool IsMarked(int bitPosition)
            {
                int bitArrayIndex = bitPosition / IntSize;
                return
                    (uint)bitArrayIndex < (uint)_span.Length &&
                    (_span[bitArrayIndex] & (1 << (bitPosition % IntSize))) != 0;
            }

            /// <summary>How many ints must be allocated to represent n bits. Returns (n+31)/32, but avoids overflow.</summary>
            internal static int ToIntArrayLength(int n) => n > 0 ? ((n - 1) / IntSize + 1) : 0;
        }

        /// <summary>
        /// Iterate over other. If contained in this, mark an element in bit array corresponding to
        /// its position in _slots. If anything is unmarked (in bit array), remove it.
        ///
        /// This attempts to allocate on the stack, if below StackAllocThreshold.
        /// </summary>
        private unsafe void IntersectWithEnumerable(IEnumerable<T> other)
        {
            if (_buckets is null)
            {
                throw new NullReferenceException($"{nameof(_buckets)} shouldn't be null; callers should check first.");
            }

            // Keep track of current last index; don't want to move past the end of our bit array
            // (could happen if another thread is modifying the collection).
            int originalCount = _count;
            int intArrayLength = BitHelper.ToIntArrayLength(originalCount);

            Span<int> span = stackalloc int[StackAllocThreshold];
            BitHelper bitHelper = intArrayLength <= StackAllocThreshold ?
                new BitHelper(span.Slice(0, intArrayLength), clear: true) :
                new BitHelper(new int[intArrayLength], clear: false);

            // Mark if contains: find index of in slots array and mark corresponding element in bit array.
            foreach (T item in other)
            {
                int index = FindEntry(item);
                if (index >= 0)
                {
                    bitHelper.MarkBit(index);
                }
            }

            // If anything unmarked, remove it. Perf can be optimized here if BitHelper had a
            // FindFirstUnmarked method.
            for (int i = 0; i < originalCount; i++)
            {
                ref Entry entry = ref _entries![i];
                if (entry.Next >= -1 && !bitHelper.IsMarked(i))
                {
                    Remove(entry.Value);
                }
            }
        }

        /// <inheritdoc/>
        public virtual bool IsProperSubsetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            // No set is a proper subset of itself.
            if (other == this)
            {
                return false;
            }

            if (other is ICollection<T> otherAsCollection)
            {
                // No set is a proper subset of an empty set.
                if (otherAsCollection.Count == 0)
                {
                    return false;
                }

                // The empty set is a proper subset of anything but the empty set.
                if (Count == 0)
                {
                    return otherAsCollection.Count > 0;
                }

                // Faster if other is a hashset (and we're using same equality comparer).
                if (other is TSet<T> otherAsSet && EqualityComparersAreEqual(this, otherAsSet))
                {
                    if (Count >= otherAsSet.Count)
                    {
                        return false;
                    }

                    // This has strictly less than number of items in other, so the following
                    // check suffices for proper subset.
                    return IsSubsetOfHashSetWithSameComparer(otherAsSet);
                }
            }

            (int uniqueCount, int unfoundCount) = CheckUniqueAndUnfoundElements(other, returnIfUnfound: false);
            return uniqueCount == Count && unfoundCount > 0;
        }

        /// <summary>
        /// Implementation Notes:
        /// If other is a hashset and is using same equality comparer, then checking subset is
        /// faster. Simply check that each element in this is in other.
        ///
        /// Note: if other doesn't use same equality comparer, then Contains check is invalid,
        /// which is why callers must take are of this.
        ///
        /// If callers are concerned about whether this is a proper subset, they take care of that.
        /// </summary>
        internal bool IsSubsetOfHashSetWithSameComparer(TSet<T> other)
        {
            foreach (T item in this)
            {
                if (!other.Contains(item))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines counts that can be used to determine equality, subset, and superset. This
        /// is only used when other is an IEnumerable and not a HashSet. If other is a HashSet
        /// these properties can be checked faster without use of marking because we can assume
        /// other has no duplicates.
        ///
        /// The following count checks are performed by callers:
        /// 1. Equals: checks if unfoundCount = 0 and uniqueFoundCount = _count; i.e. everything
        /// in other is in this and everything in this is in other
        /// 2. Subset: checks if unfoundCount >= 0 and uniqueFoundCount = _count; i.e. other may
        /// have elements not in this and everything in this is in other
        /// 3. Proper subset: checks if unfoundCount > 0 and uniqueFoundCount = _count; i.e
        /// other must have at least one element not in this and everything in this is in other
        /// 4. Proper superset: checks if unfound count = 0 and uniqueFoundCount strictly less
        /// than _count; i.e. everything in other was in this and this had at least one element
        /// not contained in other.
        ///
        /// An earlier implementation used delegates to perform these checks rather than returning
        /// an ElementCount struct; however this was changed due to the perf overhead of delegates.
        /// </summary>
        /// <param name="other"></param>
        /// <param name="returnIfUnfound">Allows us to finish faster for equals and proper superset
        /// because unfoundCount must be 0.</param>
        private unsafe (int UniqueCount, int UnfoundCount) CheckUniqueAndUnfoundElements(IEnumerable<T> other, bool returnIfUnfound)
        {
            // Need special case in case this has no elements.
            if (_count == 0)
            {
                int numElementsInOther = 0;
                foreach (T item in other)
                {
                    numElementsInOther++;
                    break; // break right away, all we want to know is whether other has 0 or 1 elements
                }

                return (UniqueCount: 0, UnfoundCount: numElementsInOther);
            }

            Debug.Assert((_buckets != null) && (_count > 0), "_buckets was null but count greater than 0");

            int originalCount = _count;
            int intArrayLength = BitHelper.ToIntArrayLength(originalCount);

            Span<int> span = stackalloc int[StackAllocThreshold];
            BitHelper bitHelper = intArrayLength <= StackAllocThreshold ?
                new BitHelper(span.Slice(0, intArrayLength), clear: true) :
                new BitHelper(new int[intArrayLength], clear: false);

            int unfoundCount = 0; // count of items in other not found in this
            int uniqueFoundCount = 0; // count of unique items in other found in this

            foreach (T item in other)
            {
                int index = FindEntry(item);
                if (index >= 0)
                {
                    if (!bitHelper.IsMarked(index))
                    {
                        // Item hasn't been seen yet.
                        bitHelper.MarkBit(index);
                        uniqueFoundCount++;
                    }
                }
                else
                {
                    unfoundCount++;
                    if (returnIfUnfound)
                    {
                        break;
                    }
                }
            }

            return (uniqueFoundCount, unfoundCount);
        }

        /// <inheritdoc/>
        public virtual bool IsProperSupersetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            // The empty set isn't a proper superset of any set, and a set is never a strict superset of itself.
            if (Count == 0 || other == this)
            {
                return false;
            }

            if (other is ICollection<T> otherAsCollection)
            {
                // If other is the empty set then this is a superset.
                if (otherAsCollection.Count == 0)
                {
                    // Note that this has at least one element, based on above check.
                    return true;
                }

                // Faster if other is a hashset with the same equality comparer
                if (other is TSet<T> otherAsSet && EqualityComparersAreEqual(this, otherAsSet))
                {
                    if (otherAsSet.Count >= Count)
                    {
                        return false;
                    }

                    // Now perform element check.
                    return ContainsAllElements(otherAsSet);
                }
            }

            // Couldn't fall out in the above cases; do it the long way
            (int uniqueCount, int unfoundCount) = CheckUniqueAndUnfoundElements(other, returnIfUnfound: true);
            return uniqueCount < Count && unfoundCount == 0;
        }

        /// <summary>
        /// Checks if this contains of other's elements. Iterates over other's elements and
        /// returns false as soon as it finds an element in other that's not in this.
        /// Used by SupersetOf, ProperSupersetOf, and SetEquals.
        /// </summary>
        private bool ContainsAllElements(IEnumerable<T> other)
        {
            foreach (T element in other)
            {
                if (!Contains(element))
                {
                    return false;
                }
            }

            return true;
        }

        /// <inheritdoc/>
        public virtual bool IsSubsetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            // The empty set is a subset of any set, and a set is a subset of itself.
            // Set is always a subset of itself
            if (Count == 0 || other == this)
            {
                return true;
            }

            // Faster if other has unique elements according to this equality comparer; so check
            // that other is a hashset using the same equality comparer.
            if (other is TSet<T> otherAsSet && EqualityComparersAreEqual(this, otherAsSet))
            {
                // if this has more elements then it can't be a subset
                if (Count > otherAsSet.Count)
                {
                    return false;
                }

                // already checked that we're using same equality comparer. simply check that
                // each element in this is contained in other.
                return IsSubsetOfHashSetWithSameComparer(otherAsSet);
            }

            (int uniqueCount, int unfoundCount) = CheckUniqueAndUnfoundElements(other, returnIfUnfound: false);
            return uniqueCount == Count && unfoundCount >= 0;
        }

        /// <inheritdoc/>
        public virtual bool IsSupersetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            // A set is always a superset of itself.
            if (other == this)
            {
                return true;
            }

            // Try to fall out early based on counts.
            if (other is ICollection<T> otherAsCollection)
            {
                // If other is the empty set then this is a superset.
                if (otherAsCollection.Count == 0)
                {
                    return true;
                }

                // Try to compare based on counts alone if other is a hashset with same equality comparer.
                if (other is TSet<T> otherAsSet &&
                    EqualityComparersAreEqual(this, otherAsSet) &&
                    otherAsSet.Count > Count)
                {
                    return false;
                }
            }

            return ContainsAllElements(other);
        }

        /// <inheritdoc/>
        public virtual bool Overlaps(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            if (Count == 0)
            {
                return false;
            }

            // Set overlaps itself
            if (other == this)
            {
                return true;
            }

            foreach (T element in other)
            {
                if (Contains(element))
                {
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc/>
        public virtual bool SetEquals(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            // A set is equal to itself.
            if (other == this)
            {
                return true;
            }

            // Faster if other is a hashset and we're using same equality comparer.
            if (other is TSet<T> otherAsSet && EqualityComparersAreEqual(this, otherAsSet))
            {
                // Attempt to return early: since both contain unique elements, if they have
                // different counts, then they can't be equal.
                if (Count != otherAsSet.Count)
                {
                    return false;
                }

                // Already confirmed that the sets have the same number of distinct elements, so if
                // one is a superset of the other then they must be equal.
                return ContainsAllElements(otherAsSet);
            }
            else
            {
                // If this count is 0 but other contains at least one element, they can't be equal.
                if (Count == 0 &&
                    other is ICollection<T> otherAsCollection &&
                    otherAsCollection.Count > 0)
                {
                    return false;
                }

                (int uniqueCount, int unfoundCount) = CheckUniqueAndUnfoundElements(other, returnIfUnfound: true);
                return uniqueCount == Count && unfoundCount == 0;
            }
        }

        /// <summary>
        /// <see cref="TSet{T}"/> 인스턴스에서 요청과 일치하는 모든 값을 제거합니다.
        /// </summary>
        /// <param name="match"> 요청을 전달합니다. </param>
        /// <returns> 제거된 값의 개수가 반환됩니다. </returns>
        public int RemoveWhere(Predicate<T> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            Entry[] entries = _entries;
            int numRemoved = 0;
            for (int i = 0; i < _count; i++)
            {
                ref Entry entry = ref entries![i];
                if (entry.Next >= -1)
                {
                    // Cache value in case delegate removes it
                    T value = entry.Value;
                    if (match(value))
                    {
                        // Check again that remove actually removed it.
                        if (Remove(value))
                        {
                            numRemoved++;
                        }
                    }
                }
            }

            return numRemoved;
        }

        /// <inheritdoc/>
        public virtual void SymmetricExceptWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            // If set is empty, then symmetric difference is other.
            if (Count == 0)
            {
                UnionWith(other);
                return;
            }

            // Special-case this; the symmetric difference of a set with itself is the empty set.
            if (other == this)
            {
                Clear();
                return;
            }

            // If other is a HashSet, it has unique elements according to its equality comparer,
            // but if they're using different equality comparers, then assumption of uniqueness
            // will fail. So first check if other is a hashset using the same equality comparer;
            // symmetric except is a lot faster and avoids bit array allocations if we can assume
            // uniqueness.
            if (other is TSet<T> otherAsSet && EqualityComparersAreEqual(this, otherAsSet))
            {
                SymmetricExceptWithUniqueHashSet(otherAsSet);
            }
            else
            {
                SymmetricExceptWithEnumerable(other);
            }
        }

        /// <summary>
        /// if other is a set, we can assume it doesn't have duplicate elements, so use this
        /// technique: if can't remove, then it wasn't present in this set, so add.
        ///
        /// As with other methods, callers take care of ensuring that other is a hashset using the
        /// same equality comparer.
        /// </summary>
        /// <param name="other"></param>
        private void SymmetricExceptWithUniqueHashSet(TSet<T> other)
        {
            foreach (T item in other)
            {
                if (!Remove(item))
                {
                    AddIfNotPresent(item, out _);
                }
            }
        }

        /// <summary>
        /// Implementation notes:
        ///
        /// Used for symmetric except when other isn't a HashSet. This is more tedious because
        /// other may contain duplicates. HashSet technique could fail in these situations:
        /// 1. Other has a duplicate that's not in this: HashSet technique would add then
        /// remove it.
        /// 2. Other has a duplicate that's in this: HashSet technique would remove then add it
        /// back.
        /// In general, its presence would be toggled each time it appears in other.
        ///
        /// This technique uses bit marking to indicate whether to add/remove the item. If already
        /// present in collection, it will get marked for deletion. If added from other, it will
        /// get marked as something not to remove.
        ///
        /// </summary>
        /// <param name="other"></param>
        private unsafe void SymmetricExceptWithEnumerable(IEnumerable<T> other)
        {
            int originalCount = _count;
            int intArrayLength = BitHelper.ToIntArrayLength(originalCount);

            Span<int> itemsToRemoveSpan = stackalloc int[StackAllocThreshold / 2];
            BitHelper itemsToRemove = intArrayLength <= StackAllocThreshold / 2 ?
                new BitHelper(itemsToRemoveSpan.Slice(0, intArrayLength), clear: true) :
                new BitHelper(new int[intArrayLength], clear: false);

            Span<int> itemsAddedFromOtherSpan = stackalloc int[StackAllocThreshold / 2];
            BitHelper itemsAddedFromOther = intArrayLength <= StackAllocThreshold / 2 ?
                new BitHelper(itemsAddedFromOtherSpan.Slice(0, intArrayLength), clear: true) :
                new BitHelper(new int[intArrayLength], clear: false);

            foreach (T item in other)
            {
                int location;
                if (AddIfNotPresent(item, out location))
                {
                    // wasn't already present in collection; flag it as something not to remove
                    // *NOTE* if location is out of range, we should ignore. BitHelper will
                    // detect that it's out of bounds and not try to mark it. But it's
                    // expected that location could be out of bounds because adding the item
                    // will increase _lastIndex as soon as all the free spots are filled.
                    itemsAddedFromOther.MarkBit(location);
                }
                else
                {
                    // already there...if not added from other, mark for remove.
                    // *NOTE* Even though BitHelper will check that location is in range, we want
                    // to check here. There's no point in checking items beyond originalCount
                    // because they could not have been in the original collection
                    if (location < originalCount && !itemsAddedFromOther.IsMarked(location))
                    {
                        itemsToRemove.MarkBit(location);
                    }
                }
            }

            // if anything marked, remove it
            for (int i = 0; i < originalCount; i++)
            {
                if (itemsToRemove.IsMarked(i))
                {
                    Remove(_entries![i].Value);
                }
            }
        }

        /// <summary>Gets a reference to the specified hashcode's bucket, containing an index into <see cref="_entries"/>.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ref int GetBucketRef(int hashCode)
        {
            int[] buckets = _buckets!;
            return ref buckets[(uint)hashCode % (uint)buckets.Length];
        }

        private const int StartOfFreeList = -3;
        private const uint HashCollisionThreshold = 100;

        /// <summary>Adds the specified element to the set if it's not already contained.</summary>
        /// <param name="value">The element to add to the set.</param>
        /// <param name="location">The index into <see cref="_entries"/> of the element.</param>
        /// <returns>true if the element is added to the <see cref="HashSet{T}"/> object; false if the element is already present.</returns>
        private bool AddIfNotPresent(T value, out int location)
        {
            if (_buckets == null)
            {
                Initialize(0);
            }
            Debug.Assert(_buckets != null);

            Entry[] entries = _entries;
            Debug.Assert(entries != null, "expected entries to be non-null");

            IEqualityComparer<T> comparer = _comparer;
            int hashCode;

            uint collisionCount = 0;
            ref int bucket = ref Unsafe.NullRef<int>();

            if (comparer == null)
            {
                hashCode = value != null ? value.GetHashCode() : 0;
                bucket = ref GetBucketRef(hashCode);
                int i = bucket - 1; // Value in _buckets is 1-based
                if (typeof(T).IsValueType)
                {
                    // ValueType: Devirtualize with EqualityComparer<TValue>.Default intrinsic
                    while (i >= 0)
                    {
                        ref Entry entry = ref entries[i];
                        if (entry.HashCode == hashCode && EqualityComparer<T>.Default.Equals(entry.Value, value))
                        {
                            location = i;
                            return false;
                        }
                        i = entry.Next;

                        collisionCount++;
                        if (collisionCount > (uint)entries.Length)
                        {
                            // The chain of entries forms a loop, which means a concurrent update has happened.
                            throw new NotSupportedException();
                        }
                    }
                }
                else
                {
                    // Object type: Shared Generic, EqualityComparer<TValue>.Default won't devirtualize (https://github.com/dotnet/runtime/issues/10050),
                    // so cache in a local rather than get EqualityComparer per loop iteration.
                    EqualityComparer<T> defaultComparer = EqualityComparer<T>.Default;
                    while (i >= 0)
                    {
                        ref Entry entry = ref entries[i];
                        if (entry.HashCode == hashCode && defaultComparer.Equals(entry.Value, value))
                        {
                            location = i;
                            return false;
                        }
                        i = entry.Next;

                        collisionCount++;
                        if (collisionCount > (uint)entries.Length)
                        {
                            // The chain of entries forms a loop, which means a concurrent update has happened.
                            throw new NotSupportedException();
                        }
                    }
                }
            }
            else
            {
                hashCode = value != null ? comparer.GetHashCode(value) : 0;
                bucket = ref GetBucketRef(hashCode);
                int i = bucket - 1; // Value in _buckets is 1-based
                while (i >= 0)
                {
                    ref Entry entry = ref entries[i];
                    if (entry.HashCode == hashCode && comparer.Equals(entry.Value, value))
                    {
                        location = i;
                        return false;
                    }
                    i = entry.Next;

                    collisionCount++;
                    if (collisionCount > (uint)entries.Length)
                    {
                        // The chain of entries forms a loop, which means a concurrent update has happened.
                        throw new NotSupportedException();
                    }
                }
            }

            int index;
            if (_freeCount > 0)
            {
                index = _freeList;
                _freeCount--;
                Debug.Assert((StartOfFreeList - entries![_freeList].Next) >= -1, "shouldn't overflow because `next` cannot underflow");
                _freeList = StartOfFreeList - entries[_freeList].Next;
            }
            else
            {
                int count = _count;
                if (count == entries.Length)
                {
                    Resize();
                    bucket = ref GetBucketRef(hashCode);
                }
                index = count;
                _count = count + 1;
                entries = _entries;
            }

            {
                ref Entry entry = ref entries![index];
                entry.HashCode = hashCode;
                entry.Next = bucket - 1; // Value in _buckets is 1-based
                entry.Value = value;
                bucket = index + 1;
                _version++;
                location = index;
            }

            return true;
        }

        /// <inheritdoc/>
        public virtual void UnionWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            foreach (T item in other)
            {
                AddIfNotPresent(item, out _);
            }
        }
    }
}
