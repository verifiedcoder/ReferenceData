using System.ComponentModel.DataAnnotations;

namespace ReferenceData;

/// <summary>
///     Base class for all data entities.
/// </summary>
public abstract class Entity
{
    /// <summary>
    ///     Gets or sets the entity identifier.
    /// </summary>
    /// <value>The identifier.</value>
    [Key]
    public int? Id { get; init; }
}
