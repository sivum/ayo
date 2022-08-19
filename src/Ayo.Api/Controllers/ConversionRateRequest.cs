namespace Ayo.Api.Controllers;

public class ConversionRateRequest
{
    public string Source { get; set; }
    public string Target { get; set; }
    public double Value { get; set; }
}