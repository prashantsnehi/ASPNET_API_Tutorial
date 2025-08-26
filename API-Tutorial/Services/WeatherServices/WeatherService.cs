namespace API_Tutorial.Services.WeatherServices;

public class WeatherService : IWeatherService
{
    private readonly string[] Summaries;

    public WeatherService()
    {
        Summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecast()
    {
        var weatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();

        return await Task.FromResult(weatherForecast);
    }
}