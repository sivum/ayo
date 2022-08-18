namespace Ayo.Core;

public class TemparatureConverter
{
    public double Convert(string source, string target, double value)
    {
        var operation = (source, target) switch
        {
            ("c", "f") => ConvertCelciusToFahrenheit(value),
            ("f", "c") => ConvertFahrenheitToCelcius(value),
            _ => throw new InvalidOperationException()
        };
        return operation;
    }

    private double ConvertFahrenheitToCelcius(double value)
    {
        return (value - 32.0)/1.8;

    }

    private double ConvertCelciusToFahrenheit(double value)
    {
        return 1.8 * value + 32.0;
    }
}