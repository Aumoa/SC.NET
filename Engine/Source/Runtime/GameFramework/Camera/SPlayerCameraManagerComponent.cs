// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.GameFramework.Components;
using SC.Engine.Runtime.GameFramework.Controllers;
using SC.Engine.Runtime.GameFramework.Diagnostics;
using SC.Engine.Runtime.GameFramework.Pawns;
using SC.Engine.Runtime.RenderCore;

using static SC.Engine.Runtime.GameFramework.Diagnostics.LogVerbosity;

namespace SC.Engine.Runtime.GameFramework.Camera
{
    /// <summary>
    /// 로컬 플레이어의 카메라를 관리하는 컴포넌트입니다.
    /// </summary>
    public class SPlayerCameraManagerComponent : SActorComponent
    {
        const float DefaultFOV = 0.25f * 3.14f;

        bool _printNoCameraWarning = true;
        SCameraComponent _pawnCamera;
        Transform _lastUpdatedTransform;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SPlayerCameraManagerComponent()
        {

        }

        /// <summary>
        /// 뷰 정보를 계산합니다.
        /// </summary>
        /// <param name="outViewInfo"> 값이 반환됩니다. </param>
        public void CalcCameraView(out MinimalViewInfo outViewInfo)
        {
            if (_pawnCamera is not null)
            {
                _printNoCameraWarning = true;
                _pawnCamera.CalcCameraView(out outViewInfo);

                if (outViewInfo.AspectRatio == 0.0f)
                {
                    RHIGameViewport vp = SGameEngine.GetEngine().GetGameViewport();
                    outViewInfo.AspectRatio = vp.ResolutionX / (float)vp.ResolutionY;
                }

                _lastUpdatedTransform = _pawnCamera.ComponentTransform;
            }
            else
            {
                APlayerController playerController = GetOwner<APlayerController>();
                if (playerController is null)
                {
                    this.Log(Error, $"{nameof(SPlayerCameraManagerComponent)} component must be attached to {nameof(APlayerController)} instance. Abort.");
                    outViewInfo = new();
                    return;
                }

                Transform updateTransform;
                APawn pawn = playerController.GetPawn();

                if (pawn is null)
                {
                    PrintNoCameraWarning("There is no camera component, and not possessed to pawn. Use last updated transform.");
                    updateTransform = _lastUpdatedTransform;
                }
                else
                {
                    PrintNoCameraWarning("Camera component is not setted. Use possessed pawn's transform.");
                    updateTransform = pawn.GetActorTransform();
                }

                RHIGameViewport vp = SGameEngine.GetEngine().GetGameViewport();
                outViewInfo = new();
                outViewInfo.FOV = DefaultFOV;
                outViewInfo.AspectRatio = vp.ResolutionX / (float)vp.ResolutionY;
                outViewInfo.Location = updateTransform.Translation;
                outViewInfo.Rotation = updateTransform.Rotation;

                _lastUpdatedTransform = updateTransform;
            }
        }

        /// <summary>
        /// 카메라 컴포넌트를 업데이트합니다.
        /// </summary>
        public void UpdateCameraComponent()
        {
            _pawnCamera = null;

            APlayerController playerController = GetOwner<APlayerController>();
            if (playerController is null)
            {
                this.Log(Error, $"The owner of this component is not a {nameof(APlayerController)}. Abort.");
                return;
            }

            APawn pawn = playerController.GetPawn();
            if (pawn is null)
            {
                this.Log(Error, $"The owner instance that type of {nameof(APlayerController)} is not possessed to any pawn. Abort.");
                return;
            }

            SCameraComponent camera = pawn.GetComponent<SCameraComponent>();
            if (camera is null)
            {
                this.Log(Error, "The possessed pawn have not camera component. Use default transform value.");
                return;
            }

            _pawnCamera = camera;
        }

        void PrintNoCameraWarning(string message)
        {
            if (_printNoCameraWarning)
            {
                this.Log(Warning, message);
                _printNoCameraWarning = false;
            }
        }
    }
}
