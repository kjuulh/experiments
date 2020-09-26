using System.Collections.Generic;
using DataMunging.DatFile;

namespace DataMunging.Weather
{
    public class WeatherData : IDatData
    {
        public string Day { get; }
        public decimal MaxTemperature { get; }
        public decimal MinTemperature { get; }

        public WeatherData(IReadOnlyList<string> rawString) : this(rawString[0], rawString[1], rawString[2])
        {
        }

        public WeatherData(string day, string maxTemperature, string minTemperature)
        {
            Day = day;
            MaxTemperature = decimal.Parse(maxTemperature.Replace("*", string.Empty));
            MinTemperature = decimal.Parse(minTemperature.Replace("*", string.Empty));
        }
    }
}