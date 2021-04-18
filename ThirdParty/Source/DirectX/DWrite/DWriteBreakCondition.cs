// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.ThirdParty.DirectX
{
    /// <summary>
    /// DWrite Condition at the edges of inline object or text used to determine line-breaking behaviour.
    /// </summary>
    public enum DWriteBreakCondition
	{
		/// <summary>
		/// Whether a break is allowed is determined by the condition of the neighboring text span or inline object.
		/// </summary>
		Neutral,

		/// <summary>
		/// A break is allowed, unless overruled by the condition of the neighboring text span or inline object, either prohibited by a May Not or forced by a Must.
		/// </summary>
		CanBreak,

		/// <summary>
		/// There should be no break, unless overruled by a Must condition from the neighboring text span or inline object.
		/// </summary>
		MayNotBreak,

		/// <summary>
		/// The break must happen, regardless of the condition of the adjacent text span or inline object.
		/// </summary>
		MustBreak
	}
}
