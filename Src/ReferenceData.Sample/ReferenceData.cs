namespace ReferenceData.Sample;

public static class ReferenceData
{
    /// <summary>
    ///     Gets strongly typed reference data for the specified enumeration.
    /// </summary>
    /// <remarks>The property name should reflect the intended destination table name for this set of reference data.</remarks>
    public static IEnumerable<AvailableColorEntity> AvailableColors => ReferenceDataGenerator.GetReferenceDataFor<AvailableColor, AvailableColorEntity>();
}
