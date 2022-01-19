using Microsoft.EntityFrameworkCore;
using ReferenceData.Sample.Entities.ReferenceData;

namespace ReferenceData.Sample;

/// <summary>
///     <para>Provides a unit of work and repository wrapper over a data provider. This class cannot be inherited.</para>
///     <para>Implements <see cref="DbContext" />.</para>
/// </summary>
/// <seealso cref="DbContext" />
public class ReferenceDataContext : DbContext
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ReferenceDataContext" /> class.
    /// </summary>
    /// <param name="dbContextOptions">The database context options.</param>
    public ReferenceDataContext(DbContextOptions<ReferenceDataContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }

    /// <summary>
    ///     Gets or sets a reference data set representing available colors.
    /// </summary>
    /// <value>The available colors.</value>
    public virtual DbSet<AvailableColorEntity> AvailableColors { get; set; } = null!;

    /// <summary>
    ///     Called when [model creating].
    /// </summary>
    /// <param name="modelBuilder">The model builder.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.Entity<AvailableColorEntity>()
                       .ToTable(nameof(ReferenceData.AvailableColors))
                       .HasData(ReferenceData.AvailableColors);
}
