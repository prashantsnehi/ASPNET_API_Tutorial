using Microsoft.AspNetCore.Mvc;
using API_Tutorial.Filters;
using API_Tutorial.Services.WeatherServices;

namespace API_Tutorial.Controllers;

[ApiController]
[Route("[controller]")]
[TypeFilter(typeof(ResponseHeaderFilter), Arguments = new object[] { "X-Server-Info", "Prashant", 1 })]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherService _weatherService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
    {
        _logger = logger;
        _weatherService = weatherService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [TypeFilter(typeof(ResponseHeaderFilter), Arguments = new object[] { "X-Location-Info", "India", 0 }, Order = 0)]
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation("Reached WeatherForecast Controller on Method Get");
        var weatherForecast = await _weatherService.GetWeatherForecast();

        return await Task.FromResult(Ok(weatherForecast));
    }
}

