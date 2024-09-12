using Microsoft.AspNetCore.Mvc;
using Project_1._0.Services;

namespace Project_1._0.Controllers
{
    // The NewsController handles requests to the News page and retrieves weather data
    public class NewsController : Controller
    {
        private readonly WeatherService _weatherService;

        // Constructor to inject the WeatherService
        public NewsController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        // Index action to retrieve and display weather data on the News page
        public async Task<IActionResult> Index()
        {
            // Fetch the current weather for Los Angeles
            var weatherData = await _weatherService.GetCurrentWeatherAsync("Los Angeles");
            return View(weatherData);
        }
    }
}
