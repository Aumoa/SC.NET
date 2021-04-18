// Copyright 2020-2021 Aumoa.lib. All right reserved.

namespace SC.Engine.Runtime.GameFramework
{
    /// <summary>
    /// 모든 게임 오브젝트의 베이스 클래스입니다.
    /// </summary>
    public abstract class GameObject
    {
        World _worldPrivate;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public GameObject()
        {

        }

        /// <summary>
        /// 개체를 소유하는 게임 세계를 설정합니다.
        /// </summary>
        /// <param name="inWorld"> 개체를 전달합니다. </param>
        public void SetWorld(World inWorld)
        {
            _worldPrivate = inWorld;
        }

        /// <summary>
        /// 개체를 소유하는 게임 세계를 가져옵니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        public virtual World GetWorld()
        {
            return _worldPrivate;
        }
    }
}
