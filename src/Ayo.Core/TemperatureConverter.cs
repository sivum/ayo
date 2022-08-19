namespace Ayo.Core;

public class TemperatureConverter:IMetricImperialConverter
{
    private const double K = 32.0;
    public double Convert(string source, string target, double value,double multiplier)
    {
        var operation = (source, target) switch
        {
            ("c", "f") => ConvertCelciusToFahrenheit(value,multiplier),
            ("f", "c") => ConvertFahrenheitToCelcius(value,multiplier),
            _ => throw new InvalidOperationException()
        };
        return operation;
    }

    private double ConvertFahrenheitToCelcius(double value,double multiplier)
    {
        return (value - K)/ multiplier;
    }

    private double ConvertCelciusToFahrenheit(double value,double multiplier)
    {
        return multiplier * value + K;
    }
}