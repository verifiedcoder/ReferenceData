using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReferenceData;
using ReferenceData.Sample;

var sp = new ServiceCollection().AddDbContext<ReferenceDataContext>(options => options.UseInMemoryDatabase("ReferenceDataSample"))
                                .BuildServiceProvider();

// Use strongly typed enums in your DTOs and models when working with reference data, while maintaining descriptive entries in your database or UI.
using (var context = sp.GetRequiredService<ReferenceDataContext>())
{
    // Create the database, which will fire off the seeding of reference data from the source enum.
    Console.WriteLine($"Database Created?: '{context.Database.EnsureCreated()}'{Environment.NewLine}");
    Console.WriteLine($"Seeded Reference Data:{Environment.NewLine}");

    // Read the entities from the database and show how they can be converted to enums.
    context.AvailableColors
           .ToList()
           .ForEach(c => Console.WriteLine($"ID: '{c.Id}', Description: '{c.Description}'."));

    // Show how enums can be converted to their entity representations.
    Console.WriteLine($"{Environment.NewLine}Convert from Reference Data Entity to Enum:{Environment.NewLine}");

    context.AvailableColors
           .ToList()
           .Select(ReferenceDataConverter.ConvertReferenceDataEntityToEnum<AvailableColorEntity, AvailableColor>)
           .ToList()
           .ForEach(c => Console.WriteLine($"Value: '{c.GetValue()}', Name: '{c}', Description: '{c.GetDescription()}'."));

    // Full circle.
    Console.WriteLine($"{Environment.NewLine}Convert from Reference Data Entity to Enum and back again:{Environment.NewLine}");

    context.AvailableColors
           .ToList()
           .Select(ReferenceDataConverter.ConvertReferenceDataEntityToEnum<AvailableColorEntity, AvailableColor>)
           .Select(ReferenceDataConverter.ConvertEnumToReferenceDataEntity<AvailableColor, AvailableColorEntity>)
           .ToList()
           .ForEach(c => Console.WriteLine($"ID: '{c.Id}', Description: '{c.Description}'."));
}

Console.ReadLine();

Environment.Exit(0);
