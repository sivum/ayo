using FluentAssertions;

namespace Ayo.Core.Tests;

public class TemperatureConversionTests
{
    [Theory()]
    [InlineData("c","f", 1.0, 33.8)]
    [InlineData("f","c", 1.0,-17.22222222222222)]
    [InlineData("f","c", 74,23.333333333333332)]
    public void GivenSourceAndTargetConvert(string source, string target,
        double value, double expected)

    {
        var sut = new TemparatureConverter();
        var multiplier = 1.8;
        var result = sut.Convert(source, target, value,multiplier);
        result.Should().Be(expected);
    }
    
}