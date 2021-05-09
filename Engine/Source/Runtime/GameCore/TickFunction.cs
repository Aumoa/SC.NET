// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Container;

namespace SC.Engine.Runtime.GameCore
{
    /// <summary>
    /// 틱 함수를 제공합니다.
    /// </summary>
    public class TickFunction
    {
        /// <summary>
        /// 이 틱 함수 제공자가 틱을 사용할 수 있습니다.
        /// </summary>
        public bool CanEverTick;

        /// <summary>
        /// 이 프레임에서 틱이 완료되었습니다.
        /// </summary>
        public bool CompleteTickThisFrame;

        /// <summary>
        /// 실제 틱 그룹이 결정되어야 합니다.
        /// </summary>
        public bool NeedActualGroup;

        /// <summary>
        /// 틱 그룹을 나타냅니다.
        /// </summary>
        public ETickingGroup TickGroup = ETickingGroup.PrePhysics;

        /// <summary>
        /// 실제 틱 그룹을 나타냅니다.
        /// </summary>
        public ETickingGroup ActualTickGroup;

        /// <summary>
        /// 틱 주기를 나타냅니다.
        /// </summary>
        public double TickInterval;

        TArray<ITickFunctionObject> _prerequisites = new();
        bool _needUpdateGroup = false;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public TickFunction()
        {

        }

        /// <summary>
        /// 틱을 준비합니다.
        /// </summary>
        public virtual void ReadyTick()
        {
            CompleteTickThisFrame = false;
            NeedActualGroup = false;
            ActualTickGroup = TickGroup;

            ComputeTickGroupDependency();
        }

        /// <summary>
        /// 틱을 실행합니다.
        /// </summary>
        /// <param name="deltaTime"> 이전 프레임에서 경과한 시간을 전달합니다. </param>
        public virtual void ExecuteTick(double deltaTime)
        {
            CompleteTickThisFrame = true;

            foreach (ITickFunctionObject item in _prerequisites)
            {
                TickFunction function = item.GetTickFunction();
                if (!function.CompleteTickThisFrame)
                {
                    function.ExecuteTick(deltaTime);
                }
            }
        }

        /// <summary>
        /// 의존 관계를 추가합니다.
        /// </summary>
        /// <param name="tickableObject"> 틱 가능 오브젝트를 전달합니다. </param>
        public void AddPrerequisite(ITickFunctionObject tickableObject)
        {
            _prerequisites.Add(tickableObject);
            _needUpdateGroup = true;
        }

        /// <summary>
        /// 의존 관계를 제거합니다.
        /// </summary>
        /// <param name="tickableObject"> 틱 가능 오브젝트를 전달합니다. </param>
        public void RemovePrerequisite(ITickFunctionObject tickableObject)
        {
            _needUpdateGroup = _prerequisites.Remove(tickableObject);
        }

        bool NeedUpdateTickGroup
        {
            get
            {
                if (_needUpdateGroup)
                {
                    return true;
                }
                else
                {
                    foreach (ITickFunctionObject tick in _prerequisites)
                    {
                        TickFunction tf = tick.GetTickFunction();
                        if (tf.NeedUpdateTickGroup)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        void ComputeTickGroupDependency()
        {
            if (!NeedUpdateTickGroup)
            {
                return;
            }

            // 의존 관계의 틱 그룹을 우선 계산합니다.
            for (int i = 0; i < _prerequisites.Count;)
            {
                ITickFunctionObject obj = _prerequisites[i];
                if (obj is SGameObject gobj && gobj.HasAnyFlags(EGameObjectFlags.PendingKill))
                {
                    _prerequisites.RemoveAt(i);
                    continue;
                }

                TickFunction tf = obj.GetTickFunction();
                tf.ComputeTickGroupDependency();

                ++i;
            }

            // 틱 우선 순위를 결정합니다.
            foreach (ITickFunctionObject tick in _prerequisites)
            {
                TickFunction tf = tick.GetTickFunction();
                if (Compare(TickGroup, tf.TickGroup) < 0)
                {
                    ActualTickGroup = tf.TickGroup;
                    NeedActualGroup = true;
                }
            }

            _needUpdateGroup = true;
        }

        int Compare(ETickingGroup lh, ETickingGroup rh)
        {
            return Math.Clamp((int)lh - (int)rh, -1, 1);
        }
    }
}
