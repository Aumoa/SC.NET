// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.Core.Numerics;
using SC.Engine.Runtime.RenderCore;
using SC.Engine.Runtime.RenderCore.Slate.Application;
using SC.ThirdParty.WinAPI;

namespace SC.Engine.Runtime.GameFramework.Slate
{
    class SGameApplication : SApplication
    {
        CoreWindow _target;

        public SGameApplication(CoreWindow target, RHIDeviceBundle deviceBundle) : base(deviceBundle)
        {
            _target = target;
        }

        public override Vector2 GetDesiredSize()
        {
            System.Drawing.Size sz = _target.GetClientSize();
            return new Vector2(sz.Width, sz.Height);
        }
    }
}
