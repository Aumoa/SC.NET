// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.GameFramework.Camera;
using SC.Engine.Runtime.GameFramework.Components;
using SC.Engine.Runtime.GameFramework.Pawns;
using SC.ThirdParty.WinAPI;

namespace SC.Engine.Runtime.GameFramework.Controllers
{
    /// <summary>
    /// 로컬 플레이어 제어를 제공합니다.
    /// </summary>
    public class APlayerController : AController
    {
        SPlayerCameraManagerComponent _cameraMgr;
        SInputComponent _inputComp;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public APlayerController()
        {
            SetRootComponent(new SSceneComponent());
            _cameraMgr = AddOwnedComponent(new SPlayerCameraManagerComponent());
            _inputComp = AddOwnedComponent(new SInputComponent());

            _inputComp.KeyPressed += KeyPressed;
            _inputComp.LeftButtonPressed += MouseButtonPressed;
        }

        void MouseButtonPressed()
        {
            if (IsCursorLocked && IsAutoUnlockMouseCursor)
            {
                MouseTracker.GetInstance().SetMode(MouseTracker.PositionMode.Relative);
            }
        }

        void KeyPressed(SInputComponent.Key key)
        {
            if (IsCursorLocked && IsAutoUnlockMouseCursor)
            {
                if (key == SInputComponent.Key.Escape)
                {
                    MouseTracker.GetInstance().SetMode(MouseTracker.PositionMode.Relative);
                }
            }
        }

        /// <inheritdoc/>
        protected override void OnPossess(APawn inPawn)
        {
            base.OnPossess(inPawn);
            GetPawn().ComponentAdded += APlayerController_ComponentAdded;
        }

        /// <inheritdoc/>
        protected override void OnUnPossess()
        {
            GetPawn().ComponentAdded -= APlayerController_ComponentAdded;
            base.OnUnPossess();
        }

        /// <summary>
        /// 마우스 커서 잠금을 자동을 해제합니다.
        /// </summary>
        public bool IsAutoUnlockMouseCursor { get; set; }

        /// <summary>
        /// 커서가 잠금 상태인지 나타내는 값을 설정하거나 가져옵니다.
        /// </summary>
        public bool IsCursorLocked
        {
            get => MouseTracker.GetInstance().IsVisible;
            set => MouseTracker.GetInstance().IsVisible = value;
        }

        void APlayerController_ComponentAdded(SActorComponent component)
        {
            _cameraMgr.UpdateCameraComponent();
        }
    }
}
