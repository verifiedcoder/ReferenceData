using System.ComponentModel;
using System.Reflection;

namespace ReferenceData;

/// <summary>
///     Provides extensions to <see cref="Enum" /> to access values and descriptions.
/// </summary>
public static class EnumExtensions
{
    private static readonly Dictionary<Enum, string> DescriptionCache = new();

    /// <summary>
    ///     Converts the enumeration value to its underlying integral type.
    /// </summary>
    /// <param name="source">The source enumeration value.</param>
    /// <returns>The underlying integral value of the enumeration.</returns>
    public static int GetValue(this Enum source) => (int)Convert.ChangeType(source, source.GetTypeCode());

    /// <summary>
    ///     Gets the description of the enumeration value from the DescriptionAttribute, if present.
    /// </summary>
    /// <param name="source">The source enumeration value.</param>
    /// <returns>
    ///     The description of the enumeration value, or the string representation of the value if no description
    ///     attribute is found.
    /// </returns>
    public static string GetDescription(this Enum source)
    {
        if (DescriptionCache.TryGetValue(source, out var description))
        {
            return description;
        }

        var enumMember = source.GetType().GetMember(source.ToString()).FirstOrDefault();

        var descriptionAttribute = enumMember?.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;

        description = descriptionAttribute?.Description ?? source.ToString();

        DescriptionCache[source] = description;

        return description;
    }

    /// <summary>
    ///     Tries to retrieve an enum item from a specified string by matching the string to the DescriptionAttribute elements
    ///     assigned to each enum item.
    /// </summary>
    /// <typeparam name="TEnum">The enum type that should be returned.</typeparam>
    /// <param name="description">The description that should be searched.</param>
    /// <param name="result">
    ///     When this method returns, contains the enum item that was found, or the default value of TEnum if
    ///     no match was found.
    /// </param>
    /// <param name="ignoreCase">Whether string comparison of descriptions should be case-sensitive or not.</param>
    /// <returns>true if a matching enum item was found; otherwise, false.</returns>
    public static bool TryGetEnumValueFromDescription<TEnum>(string description, out TEnum? result, bool ignoreCase = false)
        where TEnum : Enum
    {
        foreach (var item in typeof(TEnum).GetFields())
        {
            if (Attribute.GetCustomAttribute(item, typeof(DescriptionAttribute)) is DescriptionAttribute attribute &&
                string.Equals(attribute.Description, description, ignoreCase
                                  ? StringComparison.OrdinalIgnoreCase
                                  : StringComparison.Ordinal))
            {
                result = (TEnum)item.GetValue(default)!;

                return true;
            }
        }

        result = default;

        return false;
    }
}
