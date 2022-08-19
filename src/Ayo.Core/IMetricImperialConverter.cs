namespace Ayo.Core;

public interface IMetricImperialConverter
{
    double Convert(string source, string target, double value, double multiplier);
}