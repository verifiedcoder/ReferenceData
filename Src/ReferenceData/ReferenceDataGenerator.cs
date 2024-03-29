namespace ReferenceData;

/// <summary>
///     Provides a concise and consistent method of generating static reference data.
/// </summary>
public static class ReferenceDataGenerator
{
    /// <summary>
    ///     Extracts reference data from a specified Enum to a target typed reference data entity.
    /// </summary>
    /// <typeparam name="TEnum">The Enum.</typeparam>
    /// <typeparam name="TReferenceDataEntity">The type of the reference data entity.</typeparam>
    /// <returns>A collection of concrete reference data instances matching the specified Enum.</returns>
    public static IEnumerable<TReferenceDataEntity> GetReferenceDataFor<TEnum, TReferenceDataEntity>()
        where TReferenceDataEntity : ReferenceDataEntity, new()
        where TEnum : Enum
        => from TEnum enumValue in Enum.GetValues(typeof(TEnum))
           select new TReferenceDataEntity
           {
               Id = enumValue.GetValue(),
               Description = enumValue.GetDescription()
           };
}
