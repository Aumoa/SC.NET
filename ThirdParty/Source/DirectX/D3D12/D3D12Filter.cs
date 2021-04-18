// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// D3D12 샘플링 필터를 표현합니다.
    /// </summary>
    public enum D3D12Filter
    {
        /// <summary>
        /// 
        /// </summary>
        MIN_MAG_MIP_POINT  = 0,

        /// <summary>
        /// 
        /// </summary>
        MIN_MAG_POINT_MIP_LINEAR   = 0x1,

        /// <summary>
        /// 
        /// </summary>
        MIN_POINT_MAG_LINEAR_MIP_POINT = 0x4,

        /// <summary>
        /// 
        /// </summary>
        MIN_POINT_MAG_MIP_LINEAR   = 0x5,

        /// <summary>
        /// 
        /// </summary>
        MIN_LINEAR_MAG_MIP_POINT   = 0x10,

        /// <summary>
        /// 
        /// </summary>
        MIN_LINEAR_MAG_POINT_MIP_LINEAR    = 0x11,

        /// <summary>
        /// 
        /// </summary>
        MIN_MAG_LINEAR_MIP_POINT   = 0x14,

        /// <summary>
        /// 
        /// </summary>
        MIN_MAG_MIP_LINEAR = 0x15,

        /// <summary>
        /// 
        /// </summary>
        ANISOTROPIC    = 0x55,

        /// <summary>
        /// 
        /// </summary>
        COMPARISON_MIN_MAG_MIP_POINT   = 0x80,

        /// <summary>
        /// 
        /// </summary>
        COMPARISON_MIN_MAG_POINT_MIP_LINEAR    = 0x81,

        /// <summary>
        /// 
        /// </summary>
        COMPARISON_MIN_POINT_MAG_LINEAR_MIP_POINT  = 0x84,

        /// <summary>
        /// 
        /// </summary>
        COMPARISON_MIN_POINT_MAG_MIP_LINEAR    = 0x85,

        /// <summary>
        /// 
        /// </summary>
        COMPARISON_MIN_LINEAR_MAG_MIP_POINT    = 0x90,

        /// <summary>
        /// 
        /// </summary>
        COMPARISON_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x91,

        /// <summary>
        /// 
        /// </summary>
        COMPARISON_MIN_MAG_LINEAR_MIP_POINT    = 0x94,

        /// <summary>
        /// 
        /// </summary>
        COMPARISON_MIN_MAG_MIP_LINEAR  = 0x95,

        /// <summary>
        /// 
        /// </summary>
        COMPARISON_ANISOTROPIC = 0xd5,

        /// <summary>
        /// 
        /// </summary>
        MINIMUM_MIN_MAG_MIP_POINT  = 0x100,

        /// <summary>
        /// 
        /// </summary>
        MINIMUM_MIN_MAG_POINT_MIP_LINEAR   = 0x101,

        /// <summary>
        /// 
        /// </summary>
        MINIMUM_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x104,

        /// <summary>
        /// 
        /// </summary>
        MINIMUM_MIN_POINT_MAG_MIP_LINEAR   = 0x105,

        /// <summary>
        /// 
        /// </summary>
        MINIMUM_MIN_LINEAR_MAG_MIP_POINT   = 0x110,

        /// <summary>
        /// 
        /// </summary>
        MINIMUM_MIN_LINEAR_MAG_POINT_MIP_LINEAR    = 0x111,

        /// <summary>
        /// 
        /// </summary>
        MINIMUM_MIN_MAG_LINEAR_MIP_POINT   = 0x114,

        /// <summary>
        /// 
        /// </summary>
        MINIMUM_MIN_MAG_MIP_LINEAR = 0x115,

        /// <summary>
        /// 
        /// </summary>
        MINIMUM_ANISOTROPIC    = 0x155,

        /// <summary>
        /// 
        /// </summary>
        MAXIMUM_MIN_MAG_MIP_POINT  = 0x180,

        /// <summary>
        /// 
        /// </summary>
        MAXIMUM_MIN_MAG_POINT_MIP_LINEAR   = 0x181,

        /// <summary>
        /// 
        /// </summary>
        MAXIMUM_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x184,

        /// <summary>
        /// 
        /// </summary>
        MAXIMUM_MIN_POINT_MAG_MIP_LINEAR   = 0x185,

        /// <summary>
        /// 
        /// </summary>
        MAXIMUM_MIN_LINEAR_MAG_MIP_POINT   = 0x190,

        /// <summary>
        /// 
        /// </summary>
        MAXIMUM_MIN_LINEAR_MAG_POINT_MIP_LINEAR    = 0x191,

        /// <summary>
        /// 
        /// </summary>
        MAXIMUM_MIN_MAG_LINEAR_MIP_POINT   = 0x194,

        /// <summary>
        /// 
        /// </summary>
        MAXIMUM_MIN_MAG_MIP_LINEAR = 0x195,

        /// <summary>
        /// 
        /// </summary>
        MAXIMUM_ANISOTROPIC    = 0x1d5
    }
}
