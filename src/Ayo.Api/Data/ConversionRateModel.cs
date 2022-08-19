namespace Ayo.Api.Data;

public class ConversionRateModel
{
    
    public long id { get; set; }
    public string source { get; set; }
    public string target { get; set; }
    public  double value { get; set; }
}