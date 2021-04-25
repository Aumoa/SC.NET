// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;
using System.Collections.Generic;

using SC.Engine.Runtime.Core.Numerics;

using static SC.Engine.Runtime.GameCore.Diagnostics.LoggingSystem;
using static SC.Engine.Runtime.GameCore.Diagnostics.LogVerbosity;

namespace SC.Engine.Runtime.GameCore
{
    /// <summary>
    /// 트랜스폼을 가지는 컴포넌트를 표현합니다.
    /// </summary>
    public class SSceneComponent : SActorComponent
    {
        struct SceneAttachment
        {
            public SSceneComponent AttachParent;
            public string SocketName;

            public void Clear()
            {
                AttachParent = null;
                SocketName = null;
            }

            public Transform GetAttachmentTransform(EComponentTransformSpace space = EComponentTransformSpace.World)
            {
                if (AttachParent is null)
                {
                    return Transform.Identity;
                }

                if (SocketName is null)
                {
                    if (space == EComponentTransformSpace.World)
                    {
                        return AttachParent.ComponentTransform;
                    }
                    else
                    {
                        return AttachParent.RelativeTransform;
                    }
                }
                else
                {
                    return AttachParent.GetSocketTransform(SocketName, space);
                }
            }
        }

        Transform _transform = Transform.Identity;
        Transform _worldTransform = Transform.Identity;
        Transform _localToWorld = Transform.Identity;
        EComponentMobility _mobility = EComponentMobility.Static;
        EComponentDirtyFlags _dirtyMask = EComponentDirtyFlags.None;

        SceneAttachment _componentAttachment;
        List<SSceneComponent> _childComponents = new();

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SSceneComponent()
        {

        }

        /// <summary>
        /// 자식 컴포넌트의 트랜스폼을 업데이트합니다.
        /// </summary>
        public virtual void UpdateChildTransforms()
        {
            foreach (SSceneComponent child in _childComponents)
            {
                child.UpdateComponentToWorld();
            }
        }

        /// <summary>
        /// 컴포넌트가 월드에서 표현되기 위한 트랜스폼을 계산합니다.
        /// </summary>
        public virtual void UpdateComponentToWorld()
        {
            // 부착된 부모 컴포넌트가 없으면 언제나 단위 트랜스폼입니다.
            if (GetAttachParent() is null)
            {
                _localToWorld = Transform.Identity;
                return;
            }

            if (GetAttachSocketName() is null)
            {
                _localToWorld = GetAttachParent().GetSocketTransform(GetAttachSocketName());
            }
            else
            {
                _localToWorld = GetAttachParent().ComponentTransform;
            }

            // 변경된 LocalToWorld 트랜스폼을 사용하여 월드 트랜스폼을 업데이트합니다.
            UpdateWorldTransform();
        }

        /// <summary>
        /// 특정 소켓의 트랜스폼을 가져옵니다.
        /// </summary>
        /// <param name="socketName"> 소켓 이름을 전달합니다. </param>
        /// <param name="space"> 트랜스폼 공간을 전달합니다. </param>
        /// <returns> 소켓의 트랜스폼이 반환됩니다. </returns>
        public virtual Transform GetSocketTransform(string socketName, EComponentTransformSpace space = EComponentTransformSpace.World)
        {
            Log(Error, "SceneComponent", $"대상 컴포넌트에서 {socketName} 소켓을 찾을 수 없습니다.");
            return Transform.Identity;
        }

        /// <summary>
        /// 컴포넌트를 델타만큼 이동하고, 지정한 회전값으로 변경합니다.
        /// </summary>
        /// <param name="inMoveDelta"> 이동량을 전달합니다. </param>
        /// <param name="inNewRotation"> 변경할 회전값을 전달합니다. </param>
        /// <param name="inSpace"> 컴포넌트 트랜스폼 공간을 전달합니다. </param>
        /// <returns> 이동 결과가 반환됩니다. </returns>
        public virtual bool MoveComponent(Vector3 inMoveDelta, Quaternion inNewRotation, EComponentTransformSpace inSpace = EComponentTransformSpace.World)
        {
            Quaternion oldRotation = inSpace == EComponentTransformSpace.World ? ComponentRotation : Rotation;
            if (inMoveDelta.NearlyEquals(Vector3.Zero, 0.001f) && oldRotation.NearlyEquals(inNewRotation, 0.001f))
            {
                // inMoveDelta 및 inNewRotation으로 변경한 결과가 이전 트랜스폼과 매우 유사합니다.
                // 이동을 스킵하고, 이동하지 않았다고 표시하는 값을 반환합니다.
                return false;
            }

            Vector3 relativeLocation;
            Quaternion relativeRotation;

            if (inSpace == EComponentTransformSpace.World && GetAttachParent() is not null)
            {
                // 트랜스폼 단위는 오직 로컬 공간에서 계산됩니다.
                // 따라서 월드 공간 좌표를 로컬 공간 좌표로 변경한 후 적용합니다.
                Vector3 newLocation = ComponentLocation + inMoveDelta;
                Quaternion newRotation = inNewRotation;

                var worldTransform = new Transform(newLocation, ComponentScale, newRotation);
                var relativeTransform = worldTransform.GetRelativeTransform(_componentAttachment.GetAttachmentTransform());

                relativeLocation = relativeTransform.Translation;
                relativeRotation = relativeTransform.Rotation;
            }
            else
            {
                relativeLocation = Location + inMoveDelta;
                relativeRotation = inNewRotation;
            }

            _transform.Translation = relativeLocation;
            _transform.Rotation = relativeRotation;
            UpdateWorldTransform();

            return true;
        }

        /// <summary>
        /// 대상 컴포넌트 또는 소켓에 부착합니다.
        /// </summary>
        /// <param name="attachTo"> 대상 컴포넌트를 전달합니다. </param>
        /// <param name="socketName"> 소켓 이름을 전달합니다. </param>
        public void AttachToComponent(SSceneComponent attachTo, string socketName = null)
        {
            if (attachTo is null)
            {
                throw new ArgumentNullException(nameof(attachTo));
            }

            if (GetAttachParent() == attachTo && GetAttachSocketName() == socketName)
            {
                // 컴포넌트가 이미 대상 컴포넌트 및 소켓에 부착되어 있습니다.
                return;
            }

            if (GetAttachParent() is not null)
            {
                DetachFromComponent();
            }

            attachTo._childComponents.Add(this);
            _componentAttachment.AttachParent = attachTo;
            _componentAttachment.SocketName = socketName;

            UpdateComponentToWorld();
        }

        /// <summary>
        /// 현재 부착된 컴포넌트에서 분리합니다.
        /// </summary>
        public void DetachFromComponent()
        {
            if (GetAttachParent() is null)
            {
                // 이 컴포넌트는 어디에도 부착되어 있지 않습니다.
                return;
            }

            int indexOf = GetAttachParent()._childComponents.IndexOf(this);
            if (indexOf == -1)
            {
                Log(Error, "SceneComponent", "컴포넌트를 대상 컴포넌트의 하위 목록에서 찾을 수 없습니다.");
                return;
            }
            else
            {
                GetAttachParent()._childComponents.RemoveAt(indexOf);
            }

            _componentAttachment.Clear();
            UpdateComponentToWorld();
        }

        /// <summary>
        /// 컴포넌트의 더티 상태를 설정합니다.
        /// </summary>
        /// <param name="inFlags"> 더티 플래그를 전달합니다. </param>
        public void SetMarkDirty(EComponentDirtyFlags inFlags)
        {
            _dirtyMask |= inFlags;
        }

        /// <summary>
        /// 컴포넌트의 더티 상태가 한 개라도 활성화되어 있는지 검사합니다.
        /// </summary>
        /// <param name="inFlags"> 검사할 더티 플래그를 전달합니다. </param>
        /// <returns> 검사 결과가 반환됩니다. </returns>
        public bool HasAnyDirtyMark(EComponentDirtyFlags inFlags)
        {
            return (_dirtyMask & inFlags) != 0;
        }

        /// <summary>
        /// 더티 상태를 해결합니다.
        /// </summary>
        public virtual void ResolveDirtyState()
        {
            _dirtyMask = EComponentDirtyFlags.None;
        }

        /// <summary>
        /// 부착 대상 컴포넌트를 가져옵니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        public SSceneComponent GetAttachParent()
        {
            return _componentAttachment.AttachParent;
        }

        /// <summary>
        /// 부착 대상 컴포넌트의 소켓 이름을 가져옵니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        public string GetAttachSocketName()
        {
            return _componentAttachment.SocketName;
        }

        /// <summary>
        /// 하위 컴포넌트 목록을 가져옵니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        public IReadOnlyList<SSceneComponent> GetChildComponents()
        {
            return _childComponents;
        }

        /// <summary>
        /// 이 컴포넌트의 상대 트랜스폼을 설정하거나 가져옵니다.
        /// </summary>
        public Transform RelativeTransform
        {
            get => _transform;
            set
            {
                if (_transform != value)
                {
                    _transform = value;
                    UpdateWorldTransform();
                }
            }
        }

        /// <summary>
        /// 이 컴포넌트의 월드 공간 트랜스폼을 가져옵니다.
        /// </summary>
        public Transform ComponentTransform
        {
            get => _worldTransform;
        }

        /// <summary>
        /// 이 컴포넌트의 상대 위치를 설정하거나 가져옵니다.
        /// </summary>
        public Vector3 Location
        {
            get => _transform.Translation;
            set
            {
                if (_transform.Translation != value)
                {
                    _transform.Translation = value;
                    UpdateWorldTransform();
                }
            }
        }

        /// <summary>
        /// 이 컴포넌트의 상대 비례를 설정하거나 가져옵니다.
        /// </summary>
        public Vector3 Scale
        {
            get => _transform.Scale;
            set
            {
                if (_transform.Scale != value)
                {
                    _transform.Scale = value;
                    UpdateWorldTransform();
                }
            }
        }

        /// <summary>
        /// 이 컴포넌트의 상대 회전을 설정하거나 가져옵니다.
        /// </summary>
        public Quaternion Rotation
        {
            get => _transform.Rotation;
            set
            {
                if (_transform.Rotation != value)
                {
                    _transform.Rotation = value;
                    UpdateWorldTransform();
                }
            }
        }

        void UpdateWorldTransform()
        {
            if (ComponentHasBegunPlay && _mobility != EComponentMobility.Movable)
            {
                Log(Error, "SceneComponent", "컴포넌트가 이동 가능하지 않은데 월드 트랜스폼이 변경되려합니다.");
                return;
            }

            if (GetAttachParent() is not null)
            {
                _worldTransform = Transform.Multiply(_transform, _localToWorld);
            }
            else
            {
                _worldTransform = _transform;
            }

            SetMarkDirty(EComponentDirtyFlags.TransformUpdated);
            UpdateChildTransforms();
        }

        /// <summary>
        /// 컴포넌트의 월드 공간 위치를 가져옵니다.
        /// </summary>
        public Vector3 ComponentLocation => _worldTransform.Translation;

        /// <summary>
        /// 컴포넌트의 월드 공간 비례를 가져옵니다.
        /// </summary>
        public Vector3 ComponentScale => _worldTransform.Scale;

        /// <summary>
        /// 컴포넌트의 월드 공간 회전을 가져옵니다.
        /// </summary>
        public Quaternion ComponentRotation => _worldTransform.Rotation;

        /// <summary>
        /// 컴포넌트의 모빌리티를 설정하거나 가져옵니다.
        /// </summary>
        public EComponentMobility Mobility
        {
            get => _mobility;
            set
            {
                if (ComponentHasBegunPlay)
                {
                    Log(Error, "SceneComponent", "모빌리티는 게임플레이가 시작된 후 변경할 수 없습니다.");
                    return;
                }

                _mobility = value;
            }
        }
    }
}
