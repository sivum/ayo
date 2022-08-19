namespace Ayo.Core;

public class LengthAreaVolumeConverter:IMetricImperialConverter
{
    public double Convert(string source, string target, double value, double multiplier)
    {
        var operation = ExecuteValidOperations(source, target, value, multiplier);
        return operation;
    }

    private double ExecuteValidOperations(string source, string target, double value, double multiplier)
    {
        var operation = (source, target) switch
        {
            ("mm", "in") => LengthAreaVolumeMultiplier(value, multiplier),
            ("in", "mm") => LengthAreaVolumeMultiplier(value, multiplier),
            ("in", "cm") => LengthAreaVolumeMultiplier(value, multiplier),
            ("cm", "in") => LengthAreaVolumeMultiplier(value, multiplier),
            ("ft", "m") =>  LengthAreaVolumeMultiplier(value, multiplier),
            ("m", "ft") =>  LengthAreaVolumeMultiplier(value, multiplier),
            ("km", "mi") => LengthAreaVolumeMultiplier(value, multiplier),
            ("mi", "km") => LengthAreaVolumeMultiplier(value, multiplier),
            _ => throw new InvalidOperationException()
        };
        return operation;
    }

    private double LengthAreaVolumeMultiplier(double value, double multiplier)
    {
        return value * multiplier;
    }
}