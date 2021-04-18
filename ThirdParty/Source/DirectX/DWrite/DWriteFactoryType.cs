// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// <para> DWrite Specifies the type of DirectWrite factory object. </para>
    /// <para> DirectWrite factory contains internal state such as font loader registration and cached font data. </para>
    /// <para> In most cases it is recommended to use the shared factory object, because it allows multiple components that use DirectWrite to share internal DirectWrite state and reduce memory usage. </para>
    /// <para> However, there are cases when it is desirable to reduce the impact of a component, such as a plug-in from an untrusted source, on the rest of the process by sandboxing and isolating it from the rest of the process components. </para>
    /// <para> In such cases, it is recommended to use an isolated factory for the sandboxed component. </para>
    /// </summary>
    public enum DWriteFactoryType
	{
		/// <summary>
		/// <para> Shared factory allow for re-use of cached font data across multiple in process components. </para>
		/// <para> Such factories also take advantage of cross process font caching components for better performance. </para>
		/// </summary>
		Shared,

		/// <summary>
		/// Objects created from the isolated factory do not interact with internal DirectWrite state from other components.
		/// </summary>
		Isolated,
	}
}
