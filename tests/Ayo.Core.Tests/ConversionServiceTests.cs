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
        var target = "in";
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
        var target = "in";
        var value = 1d;
        // ReSharper disable once UnusedVariable
        var conversionResult  = await sut.Convert(source, target, value);
    }
    
    [Fact]
    public async Task GivenConversionServiceAcceptSourceTargetAndValueAndReturnConversionResultWithTheTarget()
    {
        var metricImperialFactory = new MetricImperialFactory();
        var conversionRateRepository = SetupConversionRateRepositoryStub();
        var sut = new ConversionService(metricImperialFactory,conversionRateRepository);
        var source = "mm";
        var target = "in";
        var value = 1d;
        var conversionResult  = await sut.Convert(source, target, value);
        conversionResult.Target.Should().Be("in");
    }
    
     [Fact]
     public async  Task GivenConversionServiceWithUnsupportedSourceOrTargetReturnInvalidOperationException()
     {
         var metricImperialFactory = new MetricImperialFactory();
         var conversionRateRepository = SetupConversionRateRepositoryStub();
         var sut = new ConversionService(metricImperialFactory,conversionRateRepository);
         var source = "xy";
         var target = "in";
         var value = 1d;
        await  Assert.ThrowsAsync<InvalidOperationException>(() => sut.Convert(source, target, value));
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
        conversionRates.Add(new ConversionRate(){ Source = "c",Target = "f",Value = 1.8});
        conversionRates.Add(new ConversionRate(){ Source = "f",Target = "c",Value = 1.8});
        conversionRates.Add(new ConversionRate(){ Source = "mm",Target = "in",Value = 0.0394});
        conversionRates.Add(new ConversionRate(){ Source = "in",Target = "mm",Value = 25.40});
        conversionRates.Add(new ConversionRate(){ Source = "in",Target = "cm",Value = 2.54});
        conversionRates.Add(new ConversionRate(){ Source = "ft",Target = "m",Value = 0.3048});
        conversionRates.Add(new ConversionRate(){ Source = "m",Target = "ft",Value = 3.2809});
        conversionRates.Add(new ConversionRate(){ Source = "km",Target = "mi",Value = 0.6214});
        conversionRates.Add(new ConversionRate(){ Source = "mi",Target = "km",Value = 3.2809});
        return conversionRates;
    }
}