using FluentAssertions;
using Xunit;

namespace ReferenceData.Tests.Unit;

public class EnumExtensionsTests
{
    [Fact]
    public void GetValue_ReturnsCorrectValue()
    {
        // Assert
        AvailableColor.ColdWhite.GetValue().Should().Be(1);
        AvailableColor.EmeraldGreen.GetValue().Should().Be(2);
        AvailableColor.RacingRed.GetValue().Should().Be(3);
        AvailableColor.RoyalBlue.GetValue().Should().Be(4);
    }

    [Fact]
    public void GetDescription_ReturnsCorrectDescription()
    {
        // Assert
        AvailableColor.ColdWhite.GetDescription().Should().Be("Cold White");
        AvailableColor.EmeraldGreen.GetDescription().Should().Be("Emerald Green");
        AvailableColor.RacingRed.GetDescription().Should().Be("Racing Red");
        AvailableColor.RoyalBlue.GetDescription().Should().Be("Royal Blue");
    }

    [Fact]
    public void TryGetEnumValueFromDescription_ReturnsCorrectEnumValue()
    {
        // Act
        var valueFound = EnumExtensions.TryGetEnumValueFromDescription("Cold White", out AvailableColor result);

        // Assert
        valueFound.Should().BeTrue();
        result.Should().Be(AvailableColor.ColdWhite);
    }

    [Fact]
    public void TryGetEnumValueFromDescription_ReturnsFalseForInvalidDescription()
    {
        // Act
        var valueFound = EnumExtensions.TryGetEnumValueFromDescription("Invalid Description", out AvailableColor result);

        // Assert
        valueFound.Should().BeFalse();
        result.Should().Be(default);
    }
}
