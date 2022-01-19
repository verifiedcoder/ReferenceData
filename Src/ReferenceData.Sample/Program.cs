using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReferenceData.Sample;
using ReferenceData.Sample.Entities.ReferenceData;
using ReferenceData.Sample.Enums;
using ReferenceData.Sample.Extensions;

var sp = new ServiceCollection().AddDbContext<ReferenceDataContext>(options => options.UseInMemoryDatabase("ReferenceDataSample"))
                                .BuildServiceProvider();

// Use strongly typed enums in your DTOs and models when working with reference data, while maintaining descriptive entries in your database.
using (var context = sp.GetRequiredService<ReferenceDataContext>())
{
    // Create the database, which will fire off the seeding of reference data from the source enum.
    Console.WriteLine($"Database Created?: '{context.Database.EnsureCreated()}'{Environment.NewLine}");
    Console.WriteLine($"Seeded Reference Data:{Environment.NewLine}");

    context.AvailableColors
           .ToList()
           .ForEach(c => Console.WriteLine($"ID: '{c.Id}', Description: '{c.Description}'."));

    // Read the entities from the database and illustrate how they can be converted to enums for use as strongly typed property values.
    Console.WriteLine($"{Environment.NewLine}Convert from Reference Data Entity to Enum:{Environment.NewLine}");

    context.AvailableColors
           .ToList()
           .Select(ReferenceDataConverter.ConvertReferenceDataEntityToEnum<AvailableColor, AvailableColorEntity>)
           .ToList()
           .ForEach(c => Console.WriteLine($"Value: '{c.GetValue()}', Property: '{c}', Description: '{c.GetDescription()}'."));

    // Illustrate how enums can be converted to their entity representations.
    Console.WriteLine($"{Environment.NewLine}Convert from Enum to Reference Data Entity:{Environment.NewLine}");

    // Full circle.
    context.AvailableColors
           .ToList()
           .Select(ReferenceDataConverter.ConvertReferenceDataEntityToEnum<AvailableColor, AvailableColorEntity>)
           .ToList()
           .Select(ReferenceDataConverter.ConvertEnumToReferenceDataEntity<AvailableColor, AvailableColorEntity>)
           .ToList()
           .ForEach(c => Console.WriteLine($"ID: '{c.Id}', Description: '{c.Description}'."));
}

Console.ReadLine();

Environment.Exit(0);
