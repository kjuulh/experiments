using System;
using DataMunging.Football;
using DataMunging.Weather;

namespace DataMunging.DatFile
{
    public static class DatFileExtractorFactory
    {
        public static IDatFileExtractor<WeatherData> CreateRecordedDateExtractor(string path) =>
            new DatFileExtractor<WeatherData>(path,
                2,
                strings => new WeatherData(strings),
                l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries));

        public static IDatFileExtractor<FootballData> CreateFootBallExtractor(string path) =>
            new DatFileExtractor<FootballData>(path, 1, strings => new FootballData(strings),
                s => s.Replace("-", string.Empty).Split(' ', StringSplitOptions.RemoveEmptyEntries));
    }
}