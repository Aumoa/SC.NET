// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.GameCore;
using SC.Engine.Runtime.GameCore.SceneRendering;
using SC.Engine.Runtime.RenderCore;

using static SC.Engine.Runtime.GameCore.Diagnostics.LoggingSystem;
using static SC.Engine.Runtime.GameCore.Diagnostics.LogVerbosity;

namespace SC.Engine.Runtime.GameFramework.Camera
{
    /// <summary>
    /// 로컬 플레이어의 카메라를 관리하는 컴포넌트입니다.
    /// </summary>
    public class SPlayerCameraManager : SActorComponent
    {
        const float DefaultFOV = 0.25f * 3.14f;

        bool _printNoCameraWarning = true;
        SCameraComponent _pawnCamera;
        Transform _lastUpdatedTransform;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public SPlayerCameraManager()
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
                    Log(Error, "Camera", "SPlayerCameraManager 컴포넌트는 반드시 APlayerController 개체에 붙어야 합니다. 작업을 중지합니다.");
                    outViewInfo = new();
                    return;
                }

                Transform updateTransform;
                APawn pawn = playerController.GetPawn();

                if (pawn is null)
                {
                    PrintNoCameraWarning("카메라 컴포넌트가 설정되지 않았고, 빙의된 폰도 없습니다. 마지막으로 업데이트된 트랜스폼을 사용합니다.");
                    updateTransform = _lastUpdatedTransform;
                }
                else
                {
                    PrintNoCameraWarning("카메라 컴포넌트가 설정되지 않았습니다. 빙의된 폰의 트랜스폼을 사용합니다.");
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
                Log(Error, "Camera", "컴포넌트 소유자가 APlayerController가 아닙니다. 작업을 중지합니다.");
                return;
            }

            APawn pawn = playerController.GetPawn();
            if (pawn is null)
            {
                Log(Error, "Camera", "소유자 APlayerController가 아무 폰에도 빙의되지 않았습니다. 작업을 중지합니다.");
                return;
            }

            SCameraComponent camera = pawn.GetComponent<SCameraComponent>();
            if (camera is null)
            {
                Log(Error, "Info", "빙의된 폰이 카메라 컴포넌트를 가지고 있지 않습니다. 기본값이 사용됩니다.");
                return;
            }

            _pawnCamera = camera;
        }

        void PrintNoCameraWarning(string message)
        {
            if (_printNoCameraWarning)
            {
                Log(Warning, "Camera", message);
                _printNoCameraWarning = false;
            }
        }
    }
}
