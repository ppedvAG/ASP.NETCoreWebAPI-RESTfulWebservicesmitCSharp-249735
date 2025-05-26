using Microsoft.AspNetCore.Mvc;

namespace HelloLogging.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get(string city, int days)
        {
            var result = Enumerable.Range(1, days).Select(index => new WeatherForecast
            {
                City = city,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            // Wichtig: Statt String-Interpolation besser Parameters explizit übergeben
            _logger.LogInformation("Weather forecast for {city} for {days} days", city, days);

            return result;
        }
    }
}
