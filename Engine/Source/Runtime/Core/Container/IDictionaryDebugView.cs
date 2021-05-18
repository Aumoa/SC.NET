// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SC.Engine.Runtime.Core.Container
{
    /// <summary>
    /// 사전 컬렉션의 기본 디버그 항목을 표시합니다.
    /// </summary>
    /// <typeparam name="TKey"> 키 형식을 전달합니다. </typeparam>
    /// <typeparam name="TValue"> 값 형식을 전달합니다. </typeparam>
    public sealed class IDictionaryDebugView<TKey, TValue> where TKey : notnull
    {
        private readonly IDictionary<TKey, TValue> _dict;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="dictionary"> 대상 컬렉션을 전달합니다. </param>
        public IDictionaryDebugView(IDictionary<TKey, TValue> dictionary)
        {
            _dict = dictionary ?? throw new ArgumentNullException(nameof(dictionary));
        }

        /// <summary>
        /// 아이템 목록을 가져옵니다.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public KeyValuePair<TKey, TValue>[] Items
        {
            get
            {
                var items = new KeyValuePair<TKey, TValue>[_dict.Count];
                _dict.CopyTo(items, 0);
                return items;
            }
        }
    }
}
