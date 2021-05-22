// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.ThirdParty.DirectX;

namespace SC.Engine.Runtime.RenderCore
{
    /// <summary>
    /// GPU 리소스를 표현합니다.
    /// </summary>
    public class RHIResource : RHIDeviceResource
    {
        internal ID3D12Resource _resource;

        internal RHIResource(RHIDeviceBundle deviceBundle, ID3D12Resource resource) : base(deviceBundle)
        {
            _resource = resource;
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            _resource?.Dispose();
            base.Dispose();
        }
    }
}
