namespace API_Tutorial.Services.WeatherServices
{
	public interface IWeatherService
    {
		Task<IEnumerable<WeatherForecast>> GetWeatherForecast();
	}
}

