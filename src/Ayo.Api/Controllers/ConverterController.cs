using Ayo.Core;
using Microsoft.AspNetCore.Mvc;

namespace Ayo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ConverterController : ControllerBase
{
    private readonly ConversionService _conversionService;
    private readonly ILogger<ConverterController> _logger;

    public ConverterController(ConversionService conversionService,ILogger<ConverterController> logger)
    {
        _conversionService = conversionService ?? throw new ArgumentNullException();
        _logger = logger;
    }

    [HttpPost(Name = "Convert")]
    public Task<ConversionResult> ConvertMetricImperial(ConversionRateRequest request)
    {
        return _conversionService.Convert(request.Source, request.Target, request.Value);
    }
}