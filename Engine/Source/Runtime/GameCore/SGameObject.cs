// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.GameCore
{
    /// <summary>
    /// 모든 게임 오브젝트의 베이스 클래스입니다.
    /// </summary>
    public abstract class SGameObject
    {
        SWorld _worldPrivate;
        EGameObjectFlags _flags = EGameObjectFlags.None;
        string _name;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SGameObject()
        {
            _name = GetType().Name;
        }

        /// <summary>
        /// 개체를 소유하는 게임 세계를 설정합니다.
        /// </summary>
        /// <param name="inWorld"> 개체를 전달합니다. </param>
        public void SetWorld(SWorld inWorld)
        {
            _worldPrivate = inWorld;
        }

        /// <summary>
        /// 개체를 소유하는 게임 세계를 가져옵니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        public virtual SWorld GetWorld()
        {
            return _worldPrivate;
        }

        /// <summary>
        /// 오브젝트에 지정한 플래그 중 하나라도 활성화되어 있는지 검사합니다.
        /// </summary>
        /// <param name="flags"> 플래그를 전달합니다. </param>
        /// <returns> 활성되어 있는지 나타내는 값이 반환됩니다. </returns>
        public virtual bool HasAnyFlags(EGameObjectFlags flags)
        {
            return (_flags & flags) != 0;
        }

        /// <summary>
        /// 오브젝트의 이름을 가져옵니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        public string GetName()
        {
            return _name;
        }

        /// <summary>
        /// 오브젝트의 이름을 설정합니다.
        /// </summary>
        /// <param name="value"> 값을 전달합니다. </param>
        public void SetName(string value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            _name = value;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Name: {GetName()}, {base.ToString()}";
        }
    }
}
