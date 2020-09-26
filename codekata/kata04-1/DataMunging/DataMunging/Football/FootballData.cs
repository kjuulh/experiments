using System.Collections.Generic;
using DataMunging.DatFile;

namespace DataMunging.Football
{
    public class FootballData : IDatData
    {
        public FootballData(IReadOnlyList<string> rawString) : this(rawString[1],
            int.Parse(rawString[6]),
            int.Parse(rawString[7]))
        {
        }

        public FootballData(string team, int @for, int against)
        {
            Team = team;
            For = @for;
            Against = against;
        }

        public string Team { get; }
        public int For { get; }
        public int Against { get; }
    }
}