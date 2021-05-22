// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;
using SC.Engine.Runtime.GameCore;

namespace SC.Engine.Runtime.GameFramework.Camera
{
    /// <summary>
    /// 카메라를 촬영 개체와 일정 간격을 유지하면서 따라다닐 수 있게 보조하는 기능을 제공합니다.
    /// </summary>
    public class SSpringArmComponent : SSceneComponent
    {
        /// <summary>
        /// 스프링 암이 사용하는 소켓 이름을 가져옵니다.
        /// </summary>
        public const string SocketName = "SpringArmSocket";

        Vector3 _socketRelativeLocation;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SSpringArmComponent()
        {
            PrimaryComponentTick.CanEverTick = true;
            PrimaryComponentTick.TickGroup = ETickingGroup.PostPhysics;
        }

        /// <inheritdoc/>
        public override void TickComponent(double deltaTime)
        {
            base.TickComponent(deltaTime);
            UpdateSpringArmTransform(deltaTime);
        }

        void UpdateSpringArmTransform(double deltaTime)
        {
            _socketRelativeLocation = new Vector3(-TargetArmLength, 0, 0);
            _socketRelativeLocation += TargetOffset;
            _socketRelativeLocation += SocketOffset;

            UpdateChildTransforms();
        }

        /// <inheritdoc/>
        public override Transform GetSocketTransform(string socketName, ComponentTransformSpace space = ComponentTransformSpace.World)
        {
            if (socketName != SocketName)
            {
                return base.GetSocketTransform(socketName, space);
            }

            Transform relativeTransform = Transform.Identity;
            relativeTransform.Translation = _socketRelativeLocation;

            switch (space)
            {
                case ComponentTransformSpace.World:
                    return Transform.Multiply(ComponentTransform, relativeTransform);
            }

            return relativeTransform;
        }

        /// <summary>
        /// 충돌이 발생하지 않았을 때 스프링 암이 유지되는 길이를 설정하거나 가져옵니다.
        /// </summary>
        public float TargetArmLength { get; set; } = 1.0f;

        /// <summary>
        /// 스프링 암의 종료 위치에서의 오프셋을 설정하거나 가져옵니다.
        /// </summary>
        /// <remarks>
        /// 스프링 암의 종료 위치는 실질적으로 카메라의 위치를 나타내므로 카메라의 상대적 위치를 사용하여 이를 조정할 수도 있지만, 충돌 검사의 정확한 판정을 위해 이 값을 사용해 변경하세요.
        /// </remarks>
        public Vector3 SocketOffset { get; set; }

        /// <summary>
        /// 월드 공간을 기준으로 하는 타겟의 오프셋을 설정하거나 가져옵니다.
        /// </summary>
        public Vector3 TargetOffset { get; set; }
    }
}
