using ReferenceData.Sample.Entities.ReferenceData;
using ReferenceData.Sample.Extensions;

namespace ReferenceData.Sample;

/// <summary>
///     Helper methods to convert between reference data and their Enum counterparts.
/// </summary>
public static class ReferenceDataConverter
{
    /// <summary>
    ///     Converts a source enum to its relevant reference data entity.
    /// </summary>
    /// <typeparam name="TEnum">The type 'TEnum' of the reference enum.</typeparam>
    /// <typeparam name="TEntity">The type 'TEntity' of the reference data entity.</typeparam>
    /// <param name="source">The source enum.</param>
    /// <returns>An instance of <see cref="ReferenceDataEntity" /> as the target reference data entity.</returns>
    public static TEntity ConvertEnumToReferenceDataEntity<TEnum, TEntity>(TEnum source)
        where TEnum : Enum
        where TEntity : ReferenceDataEntity, new()
    {
        try
        {
            var id = source.GetValue();

            return new TEntity
            {
                Id = id,
                Description = source.GetDescription()
            };
        }
        catch (ArgumentException)
        {
            return new TEntity
            {
                Id = 0,
                Description = "NONE"
            };
        }
    }

    /// <summary>
    ///     Converts a source reference data entity to its relevant enum.
    /// </summary>
    /// <remarks>While very unlikely, null <em>could</em> be returned from this method.</remarks>
    /// <typeparam name="TEnum">The type 'TEnum' of the reference enum.</typeparam>
    /// <typeparam name="TEntity">The type 'TEntity' of the reference data entity.</typeparam>
    /// <param name="source">The source entity.</param>
    /// <returns>'TEnum' as the target reference data enum.</returns>
    public static TEnum ConvertReferenceDataEntityToEnum<TEntity, TEnum>(TEntity source)
        where TEnum : Enum
        where TEntity : ReferenceDataEntity, new()
    {
        try
        {
            return EnumExtensions.GetEnumValueFromDescription<TEnum>(source.Description);
        }
        // Normally, log a warning.
        catch (ArgumentException)
        {
            return (TEnum)Activator.CreateInstance(typeof(TEnum))!;
        }
    }
}