using System.ComponentModel;
using System.Reflection;

namespace ReferenceData.Sample.Extensions;

/// <summary>
///     Provides extensions to <see cref="Enum" /> to access values and descriptions.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    ///     Gets the enumeration value.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <returns>System.Int32.</returns>
    public static int GetValue(this Enum source)
        => (int)Convert.ChangeType(source, source.GetTypeCode());

    /// <summary>
    ///     Gets the enumeration description.
    /// </summary>
    /// <remarks>The description is sourced from a [Description(&quot;&quot;)] attribute decorating the Enum value.</remarks>
    /// <param name="source">The source Enum.</param>
    /// <returns>The Enum value description or the string representation of the value if no description attribute is found.</returns>
    public static string GetDescription(this Enum source)
    {
        var enumMember = source.GetType().GetMember(source.ToString()).FirstOrDefault();

        var descriptionAttribute = enumMember == null
            ? default
            : enumMember.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;

        return descriptionAttribute == default
            ? source.ToString()
            : descriptionAttribute.Description;
    }

    /// <summary>
    ///     Retrieves an enum item from a specified string by matching the string to the DescriptionAttribute elements assigned
    ///     to each enum item.
    /// </summary>
    /// <typeparam name="TEnum">The enum type that should be returned.</typeparam>
    /// <param name="description">The description that should be searched.</param>
    /// <param name="ignoreCase">Whether string comparison of descriptions should be case-sensitive or not.</param>
    /// <returns>The matched enum item</returns>
    /// <exception cref="ArgumentException">Thrown if no enum item could be found with the corresponding description</exception>
    public static TEnum GetEnumValueFromDescription<TEnum>(string description, bool ignoreCase = false)
        where TEnum : Enum
    {
        foreach (var item in typeof(TEnum).GetFields())
        {
            if (Attribute.GetCustomAttribute(item, typeof(DescriptionAttribute)) is DescriptionAttribute attribute &&
                string.Equals(attribute.Description, description, ignoreCase
                                  ? StringComparison.OrdinalIgnoreCase
                                  : StringComparison.Ordinal))
            {
                return (TEnum)item.GetValue(default)!;
            }
        }

        throw new ArgumentException($"Enum item with description '{description}' could not be found", nameof(description));
    }
}
