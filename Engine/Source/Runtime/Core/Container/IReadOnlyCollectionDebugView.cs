// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SC.Engine.Runtime.Core.Container
{
    /// <summary>
    /// 읽기 전용 컬렉션의 기본 디버그 항목을 표시합니다.
    /// </summary>
    /// <typeparam name="T"> 컬렉션의 아이템 형식을 전달합니다. </typeparam>
    public sealed class IReadOnlyCollectionDebugView<T>
    {
        private readonly IReadOnlyCollection<T> _collection;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="collection"> 대상 컬렉션을 전달합니다. </param>
        public IReadOnlyCollectionDebugView(IReadOnlyCollection<T> collection)
        {
            _collection = collection ?? throw new ArgumentNullException(nameof(collection));
        }

        /// <summary>
        /// 아이템 목록을 가져옵니다.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public T[] Items
        {
            get
            {
                var items = _collection.ToArray();
                return items;
            }
        }
    }
}
