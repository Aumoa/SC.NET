// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System.Collections.Generic;

using SC.Engine.Runtime.Core.Container;
using SC.Engine.Runtime.Core.Numerics;

namespace SC.Engine.Runtime.GameCore
{
    /// <summary>
    /// 게임 세계에 작용하는 액터 개체를 표현합니다.
    /// </summary>
    public class AActor : SGameObject, ITickFunctionObject
    {
        /// <summary>
        /// 액터에 대한 틱 함수를 제공합니다.
        /// </summary>
        public class ActorTickFunction : TickFunction
        {
            AActor _target;

            /// <summary>
            /// 개체를 초기화합니다.
            /// </summary>
            /// <param name="target"> 틱 대상을 전달합니다. </param>
            public ActorTickFunction(AActor target)
            {
                _target = target;
            }

            /// <inheritdoc/>
            public override void ExecuteTick(double deltaTime)
            {
                if (_target.ActorHasBegunPlay && _target.TickEnabled)
                {
                    _target.TickActor(deltaTime);
                }

                base.ExecuteTick(deltaTime);
            }
        }

        ActorTickFunction _primaryActorTick;

        SSceneComponent _rootComponent;
        TSet<SActorComponent> _ownedComponents = new();

        /// <summary>
        /// 컴포넌트가 추가되거나 제거될 때 호출되는 이벤트의 대리자입니다.
        /// </summary>
        /// <param name="component"> 추가되는 컴포넌트가 전달됩니다. </param>
        public delegate void ComponentModifyDelegate(SActorComponent component);

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public AActor()
        {
            _primaryActorTick = new ActorTickFunction(this);
            TickEnabled = true;
        }

        /// <summary>
        /// 컴포넌트가 추가될 때 호출되는 이벤트입니다.
        /// </summary>
        public event ComponentModifyDelegate ComponentAdded;

        /// <summary>
        /// 컴포넌트가 제거될 때 호출되는 이벤트입니다.
        /// </summary>
        public event ComponentModifyDelegate ComponentRemoved;

        /// <inheritdoc/>
        public virtual bool TickEnabled { get; set; }

        /// <inheritdoc/>
        public virtual TickFunction GetTickFunction()
        {
            return _primaryActorTick;
        }

        /// <inheritdoc/>
        public virtual void AddPrerequisiteObject(ITickFunctionObject obj)
        {
            PrimaryActorTick.AddPrerequisite(obj);
        }

        /// <inheritdoc/>
        public virtual void RemovePrerequisiteObject(ITickFunctionObject obj)
        {
            PrimaryActorTick.RemovePrerequisite(obj);
        }

        /// <summary>
        /// 액터 틱 함수에 대한 정의를 설정합니다.
        /// </summary>
        public ActorTickFunction PrimaryActorTick => _primaryActorTick;

        /// <summary>
        /// 액터의 <see cref="BeginPlay"/>가 호출되었는지 나타내는 값을 가져옵니다.
        /// </summary>
        public bool ActorHasBegunPlay { get; private set; }

        /// <summary>
        /// 액터가 게임 세계에서 활동을 시작할 때 호출됩니다.
        /// </summary>
        public virtual void BeginPlay()
        {
            ActorHasBegunPlay = true;

            foreach (SActorComponent component in _ownedComponents)
            {
                if (component.ComponentHasBegunPlay)
                {
                    component.SetOwnerPrivate(this);
                    component.BeginPlay();
                }
            }
        }

        /// <summary>
        /// 액터가 게임 세계에서 활동을 종료할 때 호출됩니다.
        /// </summary>
        public virtual void EndPlay()
        {
            foreach (SActorComponent component in _ownedComponents)
            {
                if (component.ComponentHasBegunPlay)
                {
                    component.EndPlay();
                    component.SetOwnerPrivate(null);
                }
            }

            ActorHasBegunPlay = false;
        }

        /// <summary>
        /// 액터의 틱이 활성화되어 틱이 실행될 때 호출됩니다.
        /// </summary>
        /// <param name="deltaTime"> 이전 프레임으로부터 흐른 시간이 전달됩니다. </param>
        public virtual void TickActor(double deltaTime)
        {
        }

        /// <summary>
        /// 액터가 소유한 루트 컴포넌트의 트랜스폼을 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다.</returns>
        public Transform GetActorTransform() => _rootComponent.ComponentTransform;

        /// <summary>
        /// 액터가 소유한 루트 컴포넌트의 트랜스폼을 설정합니다.
        /// </summary>
        /// <param name="value"> 값을 전달합니다. </param>
        public void SetActorTransform(Transform value)
        {
            Transform relative;
            if (_rootComponent.GetAttachParent() is not null)
            {
                relative = value.GetRelativeTransform(GetAttachParent().GetSocketTransform(GetAttachSocketName()));
            }
            else
            {
                relative = value;
            }

            _rootComponent.RelativeTransform = relative;
        }

        /// <summary>
        /// 이 액터의 루트 컴포넌트가 부착된 컴포넌트를 가져옵니다.
        /// </summary>
        /// <returns> 컴포넌트가 반환됩니다. </returns>
        public SSceneComponent GetAttachParent() => _rootComponent.GetAttachParent();

        /// <summary>
        /// 이 액터의 루트 컴포넌트가 부착된 컴포넌트의 소켓 이름을 가져옵니다.
        /// </summary>
        /// <returns> 이름이 반환됩니다. </returns>
        public string GetAttachSocketName() => _rootComponent.GetAttachSocketName();

        /// <summary>
        /// 액터의 위치를 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public Vector3 GetActorLocation() => _rootComponent.ComponentLocation;

        /// <summary>
        /// 액터의 위치를 설정합니다.
        /// </summary>
        /// <param name="value"> 값을 전달합니다. </param>
        public void SetActorLocation(Vector3 value)
        {
            Vector3 delta = value - GetActorLocation();
            _rootComponent.MoveComponent(delta, GetActorRotation());
        }

        /// <summary>
        /// 액터의 회전을 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public Quaternion GetActorRotation() => _rootComponent.ComponentRotation;

        /// <summary>
        /// 액터의 회전을 설정합니다.
        /// </summary>
        /// <param name="value"> 값을 전달합니다. </param>
        public void SetActorRotation(Quaternion value) => _rootComponent.MoveComponent(Vector3.Zero, value);

        /// <summary>
        /// 액터의 모빌리티를 가져옵니다.
        /// </summary>
        /// <returns> 값이 반환됩니다. </returns>
        public ComponentMobility GetMobility() => _rootComponent.Mobility;

        /// <summary>
        /// 액터의 모빌리티를 설정합니다.
        /// </summary>
        /// <param name="value"> 값을 전달합니다. </param>
        public void SetMobility(ComponentMobility value) => _rootComponent.Mobility = value;

        /// <summary>
        /// 액터가 소유한 루트 컴포넌트를 가져옵니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        public SSceneComponent GetRootComponent() => _rootComponent;

        /// <summary>
        /// 액터의 루트 컴포넌트를 설정합니다.
        /// </summary>
        /// <param name="value"> 개체를 전달합니다. </param>
        public void SetRootComponent(SSceneComponent value)
        {
            if (ActorHasBegunPlay)
            {
                if (_rootComponent is not null)
                {
                    foreach (SSceneComponent component in _rootComponent.GetChildComponents())
                    {
                        component.AttachToComponent(value);
                    }
                }
            }

            _rootComponent = value;
        }

        /// <summary>
        /// 이 액터가 소유하는 컴포넌트를 추가합니다.
        /// </summary>
        /// <param name="ownedComponent"> 컴포넌트를 전달합니다. </param>
        public SActorComponent AddOwnedComponent(SActorComponent ownedComponent)
        {
            if (_ownedComponents.Contains(ownedComponent))
            {
                return null;
            }

            _ownedComponents.Add(ownedComponent);
            ComponentAdded?.Invoke(ownedComponent);

            if (ActorHasBegunPlay)
            {
                ownedComponent.BeginPlay();
            }

            return ownedComponent;
        }

        /// <summary>
        /// 이 액터가 소유하는 컴포넌트를 추가합니다.
        /// </summary>
        /// <param name="ownedComponent"> 컴포넌트를 전달합니다. </param>
        public T AddOwnedComponent<T>(T ownedComponent) where T : SActorComponent
        {
            return AddOwnedComponent(ownedComponent) as T;
        }

        /// <summary>
        /// 이 액터가 소유하는 컴포넌트를 제거합니다.
        /// </summary>
        /// <param name="ownedComponent"> 컴포넌트를 전달합니다. </param>
        public void RemoveOwnedComponent(SActorComponent ownedComponent)
        {
            if (ownedComponent.ComponentHasBegunPlay)
            {
                ownedComponent.EndPlay();
            }

            ComponentRemoved?.Invoke(ownedComponent);
            _ownedComponents.Remove(ownedComponent);
        }

        /// <summary>
        /// 액터가 소유한 컴포넌트 목록을 가져옵니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        public IReadOnlySet<SActorComponent> GetActorComponents()
        {
            return _ownedComponents;
        }

        /// <summary>
        /// 소유한 컴포넌트 중에서 형식으로 변환 가능한 컴포넌트를 가져옵니다.
        /// </summary>
        /// <typeparam name="T"> 형식을 전달합니다. </typeparam>
        /// <returns> 컴포넌트 개체가 반환됩니다. </returns>
        public T GetComponent<T>() where T : SActorComponent
        {
            // 액터 컴포넌트 목록에서 대상을 찾습니다.
            foreach (SActorComponent actorComponent in _ownedComponents)
            {
                if (actorComponent is T inst)
                {
                    return inst;
                }
            }

            // 재귀적 씬 컴포넌트에서 대상을 찾습니다.
            TArray<SSceneComponent> currRoot = new();
            currRoot.Push(GetRootComponent());

            while (currRoot.Count != 0)
            {
                SSceneComponent curr = currRoot.Pop();
                if (curr is T inst)
                {
                    return inst;
                }

                // 지원하지 않는 형식일 경우 자식 컴포넌트를 등록합니다.
                foreach (SSceneComponent child in curr.GetChildComponents())
                {
                    currRoot.Push(child);
                }
            }

            return null;
        }

        internal void BroadcastComponentAdd(SSceneComponent caller)
        {
            TArray<SSceneComponent> roots = new();
            roots.Push(caller);

            while (roots.Count != 0)
            {
                SSceneComponent let = roots.Pop();
                foreach (SSceneComponent child in let.GetChildComponents())
                {
                    roots.Push(child);
                }
                ComponentAdded?.Invoke(let);
            }
        }

        internal void BroadcastComponentRemove(SSceneComponent caller)
        {
            TArray<SSceneComponent> roots = new();
            roots.Push(caller);

            while (roots.Count != 0)
            {
                SSceneComponent let = roots.Pop();
                foreach (SSceneComponent child in let.GetChildComponents())
                {
                    roots.Push(child);
                }
                ComponentRemoved?.Invoke(let);
            }
        }
    }
}
