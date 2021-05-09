// Copyright 2020-2021 Aumoa.lib. All right reserved.

using System;

using SC.ThirdParty.DirectX;
using SC.ThirdParty.WindowsCodecs;

namespace SC.Engine.Runtime.RenderCore
{
    /// <summary>
    /// 텍스처 2D를 표현합니다.
    /// </summary>
    public class RHITexture2D : RHIDeviceResource
    {
        internal ID3D12Resource _resource;

        internal RHITexture2D(RHIDeviceBundle deviceBundle) : base(deviceBundle)
        {
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            _resource?.Release();

            base.Dispose();
        }

        internal static RHITexture2D LoadFromImage(RHIDeviceBundle deviceBundle, Image image)
        {
            // 텍스처 리소스를 생성합니다.
            ID3D12Device device = deviceBundle.GetDevice();

            ImagePixelFormat pixelFormat = image.PixelFormat;
            DXGIFormat dxgiFormat = PixelFormatToDXGIFormat(pixelFormat);

            ID3D12Resource textureResource = deviceBundle.CreateTexture2D(image.Width, image.Height, dxgiFormat, initialState: D3D12ResourceStates.CopyDest);
            ID3D12Resource uploadHeap = deviceBundle.CreateUploadHeap(textureResource, out var footprint);

            IntPtr ptr = uploadHeap.Map();
            image.CopyPixels((int)footprint.Footprint.RowPitch, ptr);
            uploadHeap.Unmap();

            D3D12TextureCopyLocation dst = new();
            D3D12TextureCopyLocation src = new();

            dst.Type = D3D12TextureCopyType.SubresourceIndex;
            dst.pResource = textureResource;
            dst.SubresourceIndex = 0;

            src.Type = D3D12TextureCopyType.PlacedFootprint;
            src.pResource = uploadHeap;
            src.PlacedFootprint = footprint;

            var dc = new RHIDeferredContext(deviceBundle, false);
            dc.BeginDraw();
            ID3D12GraphicsCommandList commandList = dc.GetCommandList();
            commandList.CopyTextureRegion(dst, 0, 0, 0, src, null);
            commandList.ResourceBarrier(D3D12ResourceBarrier.TransitionBarrier(textureResource, D3D12ResourceStates.CopyDest, D3D12ResourceStates.PixelShaderResource));
            dc.EndDraw();

            var queue = deviceBundle.GetPrimaryQueue();
            queue.ExecuteCommandLists(dc);
            queue.AddPendingReference(dc);
            queue.AddPendingReference(uploadHeap);

            RHITexture2D instance = new(deviceBundle);
            instance._resource = textureResource;
            return instance;
        }

        static DXGIFormat PixelFormatToDXGIFormat(ImagePixelFormat pixelFormat)
        {
            return pixelFormat switch
            {
                ImagePixelFormat.R8G8B8A8_UNORM => DXGIFormat.R8G8B8A8_UNORM,
                _ => throw new FormatException("지원하지 않는 이미지 형식입니다.")
            };
        }
    }
}
