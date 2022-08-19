using Ayo.Core;
using Microsoft.EntityFrameworkCore;

namespace Ayo.Api.Data;

public class ConversionRateRepository:IConversionRateRepository
{
    private readonly ConversionDbContext _conversionDbContext;

    public ConversionRateRepository(ConversionDbContext conversionDbContext)
    {
        _conversionDbContext = conversionDbContext ?? throw new ArgumentNullException();
    }
    public async Task<ConversionRate> GetConversionRate(string source, string target)
    {
        var rate = await _conversionDbContext.ConversionRates
            .Where(n=>n.source == source && n.target == target).SingleOrDefaultAsync();
        if (rate != null)
        {
            return new ConversionRate()
            {
                Source = rate.source,
                Target = rate.target,
                Value = rate.value
            };
        }
        return null;
    }
}