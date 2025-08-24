using API_Tutorial.Infrastructure;
using API_Tutorial.Services.AuthService;
using API_Tutorial.Services.WeatherServices;
using Microsoft.EntityFrameworkCore;

namespace API_Tutorial.Extensions;

public static class ServicesExtension
{
	public static IServiceCollection ServiceConfiguration(this IServiceCollection service, IConfiguration config)
	{
        service.AddDbContext<APIDbContext>(options =>
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlite(connectionString);
        });

        service.AddScoped<IAuthService, AuthService>();
        service.AddScoped<IWeatherService, WeatherService>();
		return service;
	}
}

