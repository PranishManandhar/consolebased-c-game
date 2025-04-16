using System;
using System.Collections.Generic;

namespace weatherInfo
{
    public enum Weather
    {
        Raining, Sunny, Cloudy, Windy
    }

    struct WeatherInfoRange
    {
        public float maxTemperature;
        public float minTemperature;
        public string Precipitation;
        public float maxWindSpeed;
        public float minWindSpeed;

        public WeatherInfoRange(float minTemp, float maxTemp, float minWind, float maxWind, string precipitation)
        {
            minTemperature = minTemp;
            maxTemperature = maxTemp;
            minWindSpeed = minWind;
            maxWindSpeed = maxWind;
            Precipitation = precipitation;
        }
    }

    public static class WeatherSystem
    {
        static readonly Random random = new Random();
        static readonly Dictionary<Weather, WeatherInfoRange> weatherranges = new Dictionary<Weather, WeatherInfoRange>()
        {
            { Weather.Sunny, new WeatherInfoRange(25f, 50f, 5f, 50f, "None") },
            { Weather.Raining, new WeatherInfoRange(15f, 25f, 10f, 25f, "Rain") },
            { Weather.Cloudy, new WeatherInfoRange(20f, 30f, 5f, 15f, "None") },
            { Weather.Windy, new WeatherInfoRange(10f, 20f, 20f, 50f, "Dust") }
        };

        public static (Weather, float, float,string) GenerateWeather()
        {
            Weather weather = (Weather)random.Next(0, 4);
            WeatherInfoRange info = weatherranges[weather];

            float temp = random.Next((int)info.minTemperature, (int)info.maxTemperature + 1);
            float windspeed = random.Next((int)info.minWindSpeed, (int)info.maxWindSpeed + 1);

            return (weather, temp, windspeed,info.Precipitation);
        }
    }
}
