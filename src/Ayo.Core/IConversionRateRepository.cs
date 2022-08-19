namespace Ayo.Core;

public interface IConversionRateRepository
{
    Task<ConversionRate> GetConversionRate(string source, string target);
}