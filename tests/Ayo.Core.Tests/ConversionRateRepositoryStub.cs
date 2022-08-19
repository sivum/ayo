namespace Ayo.Core.Tests;

public class ConversionRateRepositoryStub:IConversionRateRepository
{
    public Func<List<ConversionRate>> GetAllConversionRatesMock { get; set; } = null!;

    public async Task<ConversionRate> GetConversionRate(string source, string target)
    {
        var conversionRates = GetAllConversionRatesMock();
        var conversionRate =
            conversionRates.Single(n => n.Source == source && n.Target == target);
        return await new ValueTask<ConversionRate>(conversionRate);
    }
}