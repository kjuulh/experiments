using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataMunging
{
    public interface IRecordedDate
    {
        public string Day { get; }
        public decimal MaxTemperature { get; }
        public decimal MinTemperature { get; }
    }

    public class RecordedDate : IRecordedDate
    {
        public string Day { get; }
        public decimal MaxTemperature { get; }
        public decimal MinTemperature { get; }

        public RecordedDate(IReadOnlyList<string> rawString) : this(rawString[0], rawString[1], rawString[2])
        {
        }

        public RecordedDate(string day, string maxTemperature, string minTemperature)
        {
            Day = day;
            MaxTemperature = decimal.Parse(maxTemperature.Replace("*", string.Empty));
            MinTemperature = decimal.Parse(minTemperature.Replace("*", string.Empty));
        }
    }

    public interface IRecordedDays
    {
        IRecordedDate GetLargestSpread();
    }

    public class RecordedDays : IRecordedDays
    {
        private readonly Func<IRecordedDate, decimal> _getSpread;
        public IEnumerable<IRecordedDate> Days { get; }

        public RecordedDays(Func<IRecordedDate, decimal> getSpread, IEnumerable<IRecordedDate> days)
        {
            _getSpread = getSpread;
            Days = days;
        }

        public IRecordedDate GetLargestSpread() => Days.OrderBy(_getSpread).Last();
    }

    public static class RecordedDaysFactory
    {
        public static IRecordedDays Create(IEnumerable<IRecordedDate> days) =>
            new RecordedDays(d => d.MaxTemperature - d.MinTemperature, days);
    }

    public interface IDatFileExtractor
    {
        Task<IEnumerable<IRecordedDate>> GetData();
    }

    public class DatFileExtractor : IDatFileExtractor
    {
        public string Path { get; }
        public int Skip { get; }
        public Func<string[], IRecordedDate> FormatData { get; }
        public Func<string, string[]> SplitAlgorithm { get; }

        public DatFileExtractor(string path, int skip, Func<string[], IRecordedDate> formatData,
            Func<string, string[]> splitAlgorithm)
        {
            Path = path;
            Skip = skip;
            FormatData = formatData;
            SplitAlgorithm = splitAlgorithm;
        }

        public async Task<IEnumerable<IRecordedDate>> GetData()
        {
            var lines = await File.ReadAllLinesAsync(Path);
            return lines
                .Skip(Skip)
                .Select(SplitAlgorithm)
                .Select(FormatData);
        }
    }

    public static class DatFileExtractorFactory
    {
        public static IDatFileExtractor Create(string path) =>
            new DatFileExtractor(path,
                2,
                strings => new RecordedDate(strings),
                l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries));
    }

    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            var dataFromFile = await DatFileExtractorFactory
                .Create("data/weather.dat")
                .GetData();
            var largestSpread = RecordedDaysFactory
                .Create(dataFromFile)
                .GetLargestSpread();

            Console.WriteLine("Get largest spread");
            Console.WriteLine(largestSpread.Day);
        }
    }
}