// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.GameCore;
using SC.Engine.Runtime.GameCore.SceneRendering;

namespace SC.Engine.Runtime.GameFramework.Camera
{
    /// <summary>
    /// 게임 세계에서 카메라 구성 요소에 대한 공통 함수를 제공합니다.
    /// </summary>
    public class SCameraComponent : SSceneComponent
    {
        float _fov = 0;
        float _aspectRatio = 0;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SCameraComponent() : base()
        {
            Mobility = ComponentMobility.Movable;
        }

        /// <summary>
        /// 뷰 정보를 계산합니다.
        /// </summary>
        /// <param name="outViewInfo"> 값이 반환됩니다. </param>
        public void CalcCameraView(out MinimalViewInfo outViewInfo)
        {
            outViewInfo = new();
            outViewInfo.FOV = _fov;
            outViewInfo.AspectRatio = _aspectRatio;
            outViewInfo.Location = ComponentLocation;
            outViewInfo.Rotation = ComponentRotation;
        }
    }
}
