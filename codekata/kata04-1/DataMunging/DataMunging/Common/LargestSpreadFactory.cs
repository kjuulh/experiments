using System;
using System.Collections.Generic;
using DataMunging.Football;
using DataMunging.Weather;

namespace DataMunging.Common
{
    public static class LargestSpreadFactory
    {
        public static ILargestSpreadCalculator<FootballData> Create(IEnumerable<FootballData> results) =>
            new FootballSpread(results, f => Math.Abs(f.For - f.Against));

        public static ILargestSpreadCalculator<WeatherData> Create(IEnumerable<WeatherData> results) =>
            new WeatherSpread(f => Math.Abs(f.MaxTemperature - f.MinTemperature), results);
    }
}