namespace Ayo.Core;

public class MetricImperialFactory
{
    public IMetricImperialConverter GetConverter(string source, string target)
    {
        IMetricImperialConverter converter = (source, target) switch
        {
            ("c", "f") => new TemperatureConverter(),
            ("f", "c") => new TemperatureConverter(),
            _ => new LengthAreaVolumeConverter()
        };
        return converter;
    }
}