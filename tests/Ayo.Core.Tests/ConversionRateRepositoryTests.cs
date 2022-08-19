using FluentAssertions;

namespace Ayo.Core.Tests;

public class ConversionRateRepositoryTests
{
    [Fact]
    public async Task GivenSourceAndTargetGetConversionRateFromRepository()
    {
        var source = "c";
        var target = "f";
        var conversionRateRepository = new ConversionRateRepositoryStub();
        conversionRateRepository.GetAllConversionRatesMock = GenerateMockConversionRates;
        var conversionRate = await conversionRateRepository.GetConversionRate(source,target);
        conversionRate.Value.Should().Be(4.5);
    }

    private List<ConversionRate> GenerateMockConversionRates()
    {
        var conversionRates = new List<ConversionRate>();
        conversionRates.Add(new ConversionRate(){ Source = "c",Target = "f",Value = 4.5});
        return conversionRates;
    }
}