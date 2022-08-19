using FluentAssertions;
namespace Ayo.Core.Tests;

public class ConversionServiceTests
{
    [Fact]
    public void GivenConversionServiceAcceptMetricImperialFactoryAndConversionRateRepositoryInConstructor()
    {
        var metricImperialFactory = new MetricImperialFactory();
        var conversionRateRepository = new ConversionRateRepositoryStub();
        var sut = new ConversionService(metricImperialFactory,conversionRateRepository);
    }
    
    [Fact]
    public async Task  GivenConversionServiceAcceptSourceTargetAndValue()
    {
        var metricImperialFactory = new MetricImperialFactory();
        var conversionRateRepository = new ConversionRateRepositoryStub();
        var sut = new ConversionService(metricImperialFactory,conversionRateRepository);
        var source = "mm";
        var target = "l";
        var value = 1d;
        _ = await sut.Convert(source, target, value);
    }
    
    [Fact]
    public async Task  GivenConversionServiceAcceptSourceTargetAndValueAndReturnConversionResult()
    {
        var metricImperialFactory = new MetricImperialFactory();
        var conversionRateRepository = new ConversionRateRepositoryStub();
        var sut = new ConversionService(metricImperialFactory,conversionRateRepository);
        var source = "mm";
        var target = "l";
        var value = 1d;
        var conversionResult  = await sut.Convert(source, target, value);
    }
    
    [Fact]
    public async Task  GivenConversionServiceAcceptSourceTargetAndValueAndReturnConversionResultWithTheTarget()
    {
        var metricImperialFactory = new MetricImperialFactory();
        var conversionRateRepository = new ConversionRateRepositoryStub();
        var sut = new ConversionService(metricImperialFactory,conversionRateRepository);
        var source = "mm";
        var target = "l";
        var value = 1d;
        var conversionResult  = await sut.Convert(source, target, value);
        conversionResult.Target.Should().Be("l");
    }
    
    
}