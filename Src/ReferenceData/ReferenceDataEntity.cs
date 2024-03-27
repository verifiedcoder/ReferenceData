using System.ComponentModel.DataAnnotations;

namespace ReferenceData;

/// <summary>
///     <para>Provides properties applicable to all reference data entities.</para>
///     <para>Implements <see cref="Entity" />.</para>
/// </summary>
/// <seealso cref="Entity" />
public abstract class ReferenceDataEntity : Entity
{
    /// <summary>
    ///     Gets or sets the reference data description.
    /// </summary>
    /// <value>The description.</value>
    [Required]
    public string Description { get; init; } = string.Empty;
}
