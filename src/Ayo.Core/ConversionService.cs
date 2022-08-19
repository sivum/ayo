namespace Ayo.Core;

public class ConversionService
{
    private readonly MetricImperialFactory _metricImperialFactory;
    private readonly IConversionRateRepository _conversionRateRepository;

    public ConversionService(MetricImperialFactory metricImperialFactory, 
                            IConversionRateRepository conversionRateRepository)
    {
        _metricImperialFactory = metricImperialFactory ?? throw new ArgumentNullException();
        _conversionRateRepository = conversionRateRepository ?? throw new ArgumentException();
    }

    public async Task<ConversionResult> Convert(string source, string target, double value)
    {
        var conversionRate = await _conversionRateRepository.GetConversionRate(source, target);
        if (conversionRate == null)
        {
            throw new InvalidOperationException();
        }
        return await new ValueTask<ConversionResult>(new ConversionResult()
        {
            Target = target,
            Value = 0d
        });
    }
}