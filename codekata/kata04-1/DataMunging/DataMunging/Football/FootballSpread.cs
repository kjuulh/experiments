using System;
using System.Collections.Generic;
using System.Linq;
using DataMunging.Common;

namespace DataMunging.Football
{
    public class FootballSpread : ILargestSpreadCalculator<FootballData>
    {
        private readonly Func<FootballData, int> _getSpread;
        public IEnumerable<FootballData> Results { get; }

        public FootballSpread(IEnumerable<FootballData> results, Func<FootballData, int> getSpread)
        {
            _getSpread = getSpread;
            Results = results;
        }

        public FootballData GetLargestSpread() => Results.OrderBy(_getSpread).Last();
    }
}