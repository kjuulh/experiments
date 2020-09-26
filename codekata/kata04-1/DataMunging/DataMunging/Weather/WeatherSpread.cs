using System;
using System.Collections.Generic;
using System.Linq;
using DataMunging.Common;

namespace DataMunging.Weather
{
    public class WeatherSpread : ILargestSpreadCalculator<WeatherData>
    {
        private readonly Func<WeatherData, decimal> _getSpread;
        public IEnumerable<WeatherData> Days { get; }

        public WeatherSpread(Func<WeatherData, decimal> getSpread, IEnumerable<WeatherData> days)
        {
            _getSpread = getSpread;
            Days = days;
        }

        public WeatherData GetLargestSpread() => Days.OrderBy(_getSpread).Last();
    }
}