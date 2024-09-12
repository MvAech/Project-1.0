using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_1._0.Services;
using Project_1._0.Models;

namespace Project_1._0.Pages.News
{
    // IndexModel serves as the page model for the News page, handling data retrieval and passing it to the view
    public class IndexModel : PageModel
    {
        private readonly WeatherService _weatherService;

        // Initialize properties to avoid null references
        public WeatherData CurrentWeather { get; private set; } = new WeatherData();
        public WeatherForecast WeatherForecast { get; private set; } = new WeatherForecast();

        // Constructor to initialize WeatherService
        public IndexModel(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        // OnGetAsync method to fetch current weather and forecast data when the page is loaded
        public async Task OnGetAsync()
        {
            // Fetch current weather for Los Angeles
            CurrentWeather = await _weatherService.GetCurrentWeatherAsync("Los Angeles") ?? new WeatherData();

            // Fetch 3-day weather forecast for Los Angeles
            WeatherForecast = await _weatherService.GetWeatherForecastAsync("Los Angeles", 3) ?? new WeatherForecast();
        }
    }
}
