// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.GameFramework.Ticking;

namespace SC.Engine.Runtime.GameFramework.Components
{
    /// <summary>
    /// 액터 역할을 수행하는 컴포넌트를 표현합니다.
    /// </summary>
    public class SActorComponent : SGameObject, ITickFunctionObject
    {
        /// <summary>
        /// 컴포넌트에 대한 틱 함수를 제공합니다.
        /// </summary>
        public class ComponentTickFunction : TickFunction
        {
            SActorComponent _target;

            /// <summary>
            /// 개체를 초기화합니다.
            /// </summary>
            /// <param name="target"> 틱 대상을 전달합니다. </param>
            public ComponentTickFunction(SActorComponent target)
            {
                _target = target;
            }

            /// <inheritdoc/>
            public override void ExecuteTick(double deltaTime)
            {
                if (_target.ComponentHasBegunPlay && _target.TickEnabled)
                {
                    _target.TickComponent(deltaTime);
                }

                base.ExecuteTick(deltaTime);
            }
        }

        ComponentTickFunction _primaryComponentTick;
        AActor _owner;
        bool _registered;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SActorComponent()
        {
            TickEnabled = true;
            _primaryComponentTick = new ComponentTickFunction(this);
        }

        internal void SetOwnerPrivate(AActor value)
        {
            _owner = value;
        }

        /// <inheritdoc/>
        public virtual TickFunction GetTickFunction()
        {
            return _primaryComponentTick;
        }

        /// <inheritdoc/>
        public virtual void AddPrerequisiteObject(ITickFunctionObject obj)
        {
            PrimaryComponentTick.AddPrerequisite(obj);
        }

        /// <inheritdoc/>
        public virtual void RemovePrerequisiteObject(ITickFunctionObject obj)
        {
            PrimaryComponentTick.RemovePrerequisite(obj);
        }

        /// <summary>
        /// 액터 컴포넌트를 소유한 액터가 게임 세계에서 활동을 시작할 때 호출됩니다.
        /// </summary>
        public virtual void BeginPlay()
        {
            if (_owner is not null)
            {
                SetWorld(_owner.GetWorld());
                ComponentHasBegunPlay = true;
            }
        }

        /// <summary>
        /// 액터 컴포넌트를 소유한 액터가 게임 세계에서 활동을 종료할 때 호출됩니다.
        /// </summary>
        public virtual void EndPlay()
        {
            if (ComponentHasBegunPlay)
            {
                SetWorld(null);
                ComponentHasBegunPlay = false;
            }
        }

        /// <summary>
        /// 액터의 틱이 활성화되어 틱이 실행될 때 호출됩니다.
        /// </summary>
        /// <param name="deltaTime"> 이전 프레임으로부터 흐른 시간이 전달됩니다. </param>
        public virtual void TickComponent(double deltaTime)
        {

        }

        /// <summary>
        /// 컴포넌트를 게임 세계에 등록합니다.
        /// </summary>
        public void RegisterComponent()
        {
            RegisterComponentWithWorld(GetWorld());
        }

        /// <summary>
        /// 컴포넌트를 게임 세계에 등록합니다.
        /// </summary>
        /// <param name="world"> 게임 세계 개체를 전달합니다. </param>
        public void RegisterComponentWithWorld(SWorld world)
        {
            if (world is null)
            {
                throw new ArgumentNullException(nameof(world), "World parameter cannot be null.");
            }

            if (_registered)
            {
                // 이미 등록된 컴포넌트입니다.
                return;
            }

            world.RegisterComponent(this);
            _registered = true;
        }

        /// <summary>
        /// 이 컴포넌트를 소유한 액터를 가져옵니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        public AActor GetOwner()
        {
            return _owner;
        }

        /// <summary>
        /// 이 컴포넌트를 소유한 액터를 가져옵니다.
        /// </summary>
        /// <typeparam name="T"> 액터 형식의 파생 클래스를 전달합니다. </typeparam>
        /// <returns> 개체가 반환됩니다. </returns>
        public T GetOwner<T>() where T : AActor
        {
            return GetOwner() as T;
        }

        /// <summary>
        /// 컴포넌트 틱 함수에 대한 정의를 설정합니다.
        /// </summary>
        public ComponentTickFunction PrimaryComponentTick => _primaryComponentTick;

        /// <inheritdoc/>
        public virtual bool TickEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// 액터 컴포넌트의 <see cref="BeginPlay"/>가 호출되었는지 나타내는 값을 가져옵니다.
        /// </summary>
        public bool ComponentHasBegunPlay { get; private set; }

        /// <summary>
        /// 컴포넌트가 등록되었는지 나타내는 값을 가져옵니다.
        /// </summary>
        public bool IsRegistered { get; }
    }
}
