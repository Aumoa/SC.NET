// Copyright 2020-2021 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// <para> Specifies broad residency priority buckets useful for quickly establishing an application priority scheme. </para>
    /// <para> Applications can assign priority values other than the five values present in this enumeration. </para>
    /// </summary>
    public enum D3D12ResidencyPriority
    {
        /// <summary>
        /// Indicates a minimum priority.
        /// </summary>
        Minimum = 0x28000000,

        /// <summary>
        /// Indicates a low priority.
        /// </summary>
        Low = 0x50000000,

        /// <summary>
        /// Indicates a normal, medium, priority.
        /// </summary>
        Normal = 0x78000000,

        /// <summary>
        /// Indicates a high priority. Applications are discouraged from using priories greater than this. For more information see <see cref="ID3D12Device1.SetResidencyPriority"/>.
        /// </summary>
        High = unchecked((int)0xa0010000),

        /// <summary>
        /// Indicates a maximum priority. Applications are discouraged from using priorities greater than this; <see cref="Maximum"/> is not guaranteed to be available. For more information see <see cref="ID3D12Device1.SetResidencyPriority"/>
        /// </summary>
        Maximum = unchecked((int)0xc8000000)
    }
}
