// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.RenderCore.Slate.Application;
using SC.ThirdParty.WinAPI;

namespace SC.Engine.Runtime.GameFramework.Slate
{
    class SGameApplication : SApplication
    {
        CoreWindow _target;

        public SGameApplication(CoreWindow target) : base()
        {
            _target = target;
        }
    }
}
