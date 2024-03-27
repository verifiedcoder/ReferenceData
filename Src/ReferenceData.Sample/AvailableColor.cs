using System.ComponentModel;

namespace ReferenceData.Sample;

/// <summary>
///     Note that enums must have descriptions for all properties or conversion will fail, returning an enum description of
///     '0'. This is by design to highlight the failure.
/// </summary>
/// <remarks>
///     The values should be treated as immutable, i.e., if ColdWhite is 1, it should never, ever, be changed to any
///     other value.
/// </remarks>
public enum AvailableColor
{
    [Description("Cold White")]
    ColdWhite = 1,

    [Description("Emerald Green")]
    EmeraldGreen = 2,

    [Description("Racing Red")]
    RacingRed = 3,

    [Description("Royal Blue")]
    RoyalBlue = 4
}
