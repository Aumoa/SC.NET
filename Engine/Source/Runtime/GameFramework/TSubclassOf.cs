// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.GameCore;

namespace SC.Engine.Runtime.GameFramework
{
    /// <summary>
    /// 특정 클래스 및 해당 클래스로 변환을 지원하는 하위 클래스에 대한 타입을 표현합니다.
    /// </summary>
    /// <typeparam name="T"> 클래스를 전달합니다. </typeparam>
    public struct TSubclassOf<T> where T : SGameObject
    {
        Type _class;

        /// <summary>
        /// 서브클래스 인스턴스를 가져옵니다.
        /// </summary>
        /// <typeparam name="TSub"> 서브클래스 형식을 가져옵니다. </typeparam>
        /// <returns> 값이 반환됩니다. </returns>
        public static TSubclassOf<T> Get<TSub>() where TSub : T
        {
            TSubclassOf<T> subc = new();
            subc._class = typeof(TSub);
            return subc;
        }

        /// <summary>
        /// 서브클래스 인스턴스를 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public static TSubclassOf<T> Get()
        {
            TSubclassOf<T> subc = new();
            subc._class = typeof(T);
            return subc;
        }

        /// <summary>
        /// 개체를 생성합니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        public T Instantiate()
        {
            return Activator.CreateInstance(_class) as T;
        }

        /// <summary>
        /// 타입 인스턴스를 가져옵니다.
        /// </summary>
        public Type Class => _class;

        /// <summary>
        /// 서브클래스 형식을 대입합니다.
        /// </summary>
        /// <typeparam name="TSub"> 서브클래스 형식을 전달합니다. </typeparam>
        public void Assign<TSub>() where TSub : T
        {
            this = Get<TSub>();
        }
    }
}
