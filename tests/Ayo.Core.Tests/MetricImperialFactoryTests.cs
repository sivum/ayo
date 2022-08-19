using FluentAssertions;

namespace Ayo.Core.Tests;

public class MetricImperialFactoryTests
{
    [Fact()]
    public void GivenSourceAndTargetReturnMetricImperialConverter()
    {
        var source = "cm";
        var target = "in";
        var sut = new MetricImperialFactory();
        var result = sut.GetConverter(source, target);
        result.Should().BeAssignableTo<IMetricImperialConverter>();
    }
    
    [Fact()]
    public void GivenSourceAsInchesAndTargetAsMetricReturnLengthAreaVolumeConverter()
    {
        var source = "cm";
        var target = "in";
        var sut = new MetricImperialFactory();
        var result = sut.GetConverter(source, target);
        result.Should().BeOfType<LengthAreaVolumeConverter>();
    }
    
    [Fact()]
    public void GivenSourceAsCelciusAndTargetAsFarehnheitReturnTemperatureConverter()
    {
        var source = "c";
        var target = "f";
        var sut = new MetricImperialFactory();
        var result = sut.GetConverter(source, target);
        result.Should().BeOfType<TemperatureConverter>();
    }
}