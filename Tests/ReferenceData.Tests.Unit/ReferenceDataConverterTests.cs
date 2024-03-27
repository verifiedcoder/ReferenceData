using FluentAssertions;
using Xunit;

namespace ReferenceData.Tests.Unit;

public class ReferenceDataConverterTests
{
    [Fact]
    public void ConvertEnumToReferenceDataEntity_ReturnsCorrectEntity()
    {
        // Act
        var entity = ReferenceDataConverter.ConvertEnumToReferenceDataEntity<AvailableColor, AvailableColorEntity>(AvailableColor.ColdWhite);

        // Assert
        entity.Id.Should().Be(1);
        entity.Description.Should().Be("Cold White");
    }

    [Fact]
    public void ConvertReferenceDataEntityToEnum_ReturnsCorrectEnumValue()
    {
        // Arrange
        var entity = new AvailableColorEntity { Id = 1, Description = "Cold White" };

        // Act
        var enumValue = ReferenceDataConverter.ConvertReferenceDataEntityToEnum<AvailableColorEntity, AvailableColor>(entity);

        // Assert
        enumValue.Should().Be(AvailableColor.ColdWhite);
    }
}
