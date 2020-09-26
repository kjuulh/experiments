using System;
using System.Threading.Tasks;
using DataMunging.Common;
using DataMunging.DatFile;

namespace DataMunging
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            await GetWeatherSpread();
            await GetFootballSpread();
        }

        private static async Task GetFootballSpread()
        {
            var footballDataFromFile = await DatFileExtractorFactory
                .CreateFootBallExtractor(
                    "/home/hermansen/git/kjuulh/experiments/codekata/kata04-1/DataMunging/DataMunging/data/football.dat")
                .GetData();
            var footballLargestSpread = LargestSpreadFactory
                .Create(footballDataFromFile)
                .GetLargestSpread();

            Console.WriteLine("Get largest football spread");
            Console.WriteLine(footballLargestSpread.Team);
        }

        private static async Task GetWeatherSpread()
        {
            var dataFromFile = await DatFileExtractorFactory
                .CreateRecordedDateExtractor(
                    "/home/hermansen/git/kjuulh/experiments/codekata/kata04-1/DataMunging/DataMunging/data/weather.dat")
                .GetData();
            var largestSpread = LargestSpreadFactory
                .Create(dataFromFile)
                .GetLargestSpread();

            Console.WriteLine("Get largest weather spread");
            Console.WriteLine(largestSpread.Day);
        }
    }
}