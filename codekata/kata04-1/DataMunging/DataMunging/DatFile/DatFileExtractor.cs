using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataMunging.DatFile
{
    public interface IDatFileExtractor<T> where T : IDatData
    {
        Task<IEnumerable<T>> GetData();
    }

    public class DatFileExtractor<T> : IDatFileExtractor<T> where T : IDatData
    {
        public string Path { get; }
        public int Skip { get; }
        public Func<string[], T> FormatData { get; }
        public Func<string, string[]> SplitAlgorithm { get; }

        public DatFileExtractor(string path, int skip, Func<string[], T> formatData,
            Func<string, string[]> splitAlgorithm)
        {
            Path = path;
            Skip = skip;
            FormatData = formatData;
            SplitAlgorithm = splitAlgorithm;
        }

        public async Task<IEnumerable<T>> GetData()
        {
            if (!File.Exists(Path))
                return Enumerable.Empty<T>();
            var lines = await File.ReadAllLinesAsync(Path);

            if (!lines.Any())
                return Enumerable.Empty<T>();

            return lines
                .Skip(Skip)
                .Select(SplitAlgorithm)
                .Where(s => s.Length != 0)
                .Select(FormatData);
        }
    }
}