using FluentAssertions;
namespace Ayo.Core.Tests;

public class ConversionServiceTests
{
    [Fact]
    public void GivenConversionServiceAcceptMetricImperialFactoryAndConversionRateRepositoryInConstructor()
    {
        var metricImperialFactory = new MetricImperialFactory();
        var conversionRateRepository = SetupConversionRateRepositoryStub();
        // ReSharper disable once UnusedVariable
        var sut = new ConversionService(metricImperialFactory,conversionRateRepository);
    }
    
    [Fact]
    public async Task  GivenConversionServiceAcceptSourceTargetAndValue()
    {
        var metricImperialFactory = new MetricImperialFactory();
        var conversionRateRepository = SetupConversionRateRepositoryStub();
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
        var conversionRateRepository = SetupConversionRateRepositoryStub();
        var sut = new ConversionService(metricImperialFactory,conversionRateRepository);
        var source = "mm";
        var target = "l";
        var value = 1d;
        // ReSharper disable once UnusedVariable
        var conversionResult  = await sut.Convert(source, target, value);
    }
    
    [Fact]
    public async Task  GivenConversionServiceAcceptSourceTargetAndValueAndReturnConversionResultWithTheTarget()
    {
        var metricImperialFactory = new MetricImperialFactory();
        var conversionRateRepository = SetupConversionRateRepositoryStub();
        var sut = new ConversionService(metricImperialFactory,conversionRateRepository);
        var source = "mm";
        var target = "l";
        var value = 1d;
        var conversionResult  = await sut.Convert(source, target, value);
        conversionResult.Target.Should().Be("l");
    }

    private ConversionRateRepositoryStub SetupConversionRateRepositoryStub()
    {
       var conversionRateRepository =  new ConversionRateRepositoryStub();
       conversionRateRepository.GetAllConversionRatesMock = GenerateMockConversionRates;
       return conversionRateRepository;
    }
    
    private List<ConversionRate> GenerateMockConversionRates()
    {
        var conversionRates = new List<ConversionRate>();
        conversionRates.Add(new ConversionRate(){ Source = "c",Target = "f",Value = 4.5});
        return conversionRates;
    }
}