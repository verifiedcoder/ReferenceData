using ReferenceData.Sample.Entities.ReferenceData;
using ReferenceData.Sample.Enums;

namespace ReferenceData.Sample;

public static class ReferenceData
{
    /// <summary>
    ///     Gets strongly typed reference data of the specified enumeration.
    /// </summary>
    /// <remarks>The method name should reflect the intended destination table name for this set of reference data.</remarks>
    public static IEnumerable<AvailableColorEntity> AvailableColors => ReferenceDataGenerator.GetReferenceDataFor<AvailableColor, AvailableColorEntity>();
}
