using System;
using System.Collections.Generic;

namespace Project_1._0.Models
{
    public class WeatherData
    {
        public double TempC { get; set; }
        public double TempF { get; set; }
        public string ConditionText { get; set; }
        public string ConditionIcon { get; set; }
        public int Humidity { get; set; }
        public double WindKph { get; set; }
        public string WindDir { get; set; }
        public double UvIndex { get; set; }
        public int Aqi { get; set; }

        public WeatherData()
        {
            ConditionText = string.Empty;
            ConditionIcon = string.Empty;
            WindDir = string.Empty;
        }
    }

    public class ForecastDay
    {
        public string Date { get; set; }
        public double MaxTempC { get; set; }
        public double MinTempC { get; set; }
        public double MaxTempF { get; set; }
        public double MinTempF { get; set; }
        public string ConditionText { get; set; }
        public string ConditionIcon { get; set; }
        public int ChanceOfRain { get; set; }
        public List<HourlyForecast> Hourly { get; set; }

        public ForecastDay()
        {
            Date = string.Empty;
            ConditionText = string.Empty;
            ConditionIcon = string.Empty;
            Hourly = new List<HourlyForecast>();
        }
    }

    public class HourlyForecast
    {
        public DateTime Time { get; set; }
        public double TempC { get; set; }
        public double TempF { get; set; }
        public string ConditionIcon { get; set; }
        public int ChanceOfRain { get; set; }

        public HourlyForecast()
        {
            ConditionIcon = string.Empty;
        }
    }

    public class WeatherForecast
    {
        public string City { get; set; }
        public List<ForecastDay> ForecastDays { get; set; }

        public WeatherForecast()
        {
            City = string.Empty;
            ForecastDays = new List<ForecastDay>();
        }
    }
}
