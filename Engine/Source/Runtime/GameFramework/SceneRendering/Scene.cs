// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.Engine.Runtime.Core.Container;
using SC.Engine.Runtime.GameFramework.Camera;
using SC.Engine.Runtime.GameFramework.Components;
using SC.Engine.Runtime.GameFramework.Controllers;

namespace SC.Engine.Runtime.GameFramework.SceneRendering
{
    /// <summary>
    /// 렌더링 대상 월드의 <see cref="SPrimitiveComponent"/> 집합입니다.
    /// </summary>
    public class Scene
    {
        SWorld _world;

        TArray<SPrimitiveComponent> _primitiveComponents = new();
        TArray<PrimitiveSceneProxy> _primitiveSceneProxies = new();

        SceneVisibility _localPlayerVisibility;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        /// <param name="world"></param>
        public Scene(SWorld world)
        {
            _world = world;
            _localPlayerVisibility = new SceneVisibility(this);
        }

        /// <summary>
        /// 이 씬의 소유 월드를 가져옵니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        public SWorld GetWorld()
        {
            return _world;
        }

        internal void Update()
        {
            foreach (PrimitiveSceneProxy proxy in _primitiveSceneProxies)
            {
                proxy.Update();

                if (proxy.Mobility == ComponentMobility.Movable)
                {
                    proxy.UpdateMovable();
                }
            }
        }

        internal void InitViews()
        {
            APlayerController localPlayer = _world.GetLocalPlayer();
            SPlayerCameraManager cameraManager = localPlayer.CameraManager;

            // Get local player's view info.
            cameraManager.CalcCameraView(out MinimalViewInfo viewInfo);
            viewInfo.Apply();

            // Update visibilities.
            _localPlayerVisibility.UpdateView(viewInfo);
        }

        internal void AddPrimitive(SPrimitiveComponent primitiveComponent)
        {
            _primitiveComponents.Add(primitiveComponent);
            _primitiveSceneProxies.Add(primitiveComponent.CreateSceneProxy());
        }

        internal ReadOnlySpan<PrimitiveSceneProxy> GetPrimitives()
        {
            return _primitiveSceneProxies.AsReadOnlySpan();
        }
    }
}
