using Project_1._0.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Project_1._0.Services
{
    public class WeatherService
    {
        private HttpClient _httpClient;
        private const string BaseUrl = "http://api.weatherapi.com/v1";
        private const string ApiKey = "cd3a20dd98ba472ea8105844240808";

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherData?> GetCurrentWeatherAsync(string city)
        {
            try
            {
                var url = $"{BaseUrl}/current.json?key={ApiKey}&q={city}&aqi=yes";
                var responseString = await _httpClient.GetStringAsync(url);
                dynamic weatherJson = JsonConvert.DeserializeObject(responseString) ?? throw new InvalidOperationException("Failed to deserialize the JSON response.");

                if (weatherJson.current == null)
                {
                    throw new InvalidOperationException("Invalid weather data received from the API.");
                }

                return new WeatherData
                {
                    TempC = (double)weatherJson.current.temp_c,
                    TempF = (double)weatherJson.current.temp_f,
                    ConditionText = (string)weatherJson.current.condition.text,
                    ConditionIcon = "https:" + (string)weatherJson.current.condition.icon,
                    Humidity = (int)weatherJson.current.humidity,
                    WindKph = (double)weatherJson.current.wind_kph,
                    WindDir = (string)weatherJson.current.wind_dir,
                    UvIndex = (double)weatherJson.current.uv,
                    Aqi = (int)weatherJson.current.air_quality.pm2_5
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching weather data: {ex.Message}");
                return null;
            }
        }

        public async Task<WeatherForecast?> GetWeatherForecastAsync(string city, int days)
        {
            try
            {
                var url = $"{BaseUrl}/forecast.json?key={ApiKey}&q={city}&days={days}&aqi=no&alerts=no";
                var responseString = await _httpClient.GetStringAsync(url);
                dynamic forecastJson = JsonConvert.DeserializeObject(responseString) ?? throw new InvalidOperationException("Failed to deserialize the JSON response.");

                if (forecastJson.forecast == null)
                {
                    throw new InvalidOperationException("Invalid weather data received from the API.");
                }

                var weatherForecast = new WeatherForecast
                {
                    City = city,
                    ForecastDays = new List<ForecastDay>()
                };

                foreach (var day in forecastJson.forecast.forecastday)
                {
                    var forecastDay = new ForecastDay
                    {
                        Date = (string)day.date,
                        MaxTempC = (double)day.day.maxtemp_c,
                        MinTempC = (double)day.day.mintemp_c,
                        MaxTempF = (double)day.day.maxtemp_f,
                        MinTempF = (double)day.day.mintemp_f,
                        ConditionText = (string)day.day.condition.text,
                        ConditionIcon = "https:" + (string)day.day.condition.icon,
                        ChanceOfRain = (int)day.day.daily_chance_of_rain,
                        Hourly = new List<HourlyForecast>()
                    };

                    foreach (var hour in day.hour)
                    {
                        var hourlyForecast = new HourlyForecast
                        {
                            Time = DateTimeOffset.FromUnixTimeSeconds((long)hour.time_epoch).DateTime, // Convert time_epoch to DateTime
                            TempC = (double)hour.temp_c,
                            TempF = (double)hour.temp_f,
                            ConditionIcon = "https:" + (string)hour.condition.icon,
                            ChanceOfRain = (int)hour.chance_of_rain
                        };
                        forecastDay.Hourly.Add(hourlyForecast);
                    }

                    weatherForecast.ForecastDays.Add(forecastDay);
                }

                return weatherForecast;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching weather forecast data: {ex.Message}");
                return null;
            }
        }
    }
}
