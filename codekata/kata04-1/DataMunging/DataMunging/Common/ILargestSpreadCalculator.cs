using DataMunging.DatFile;

namespace DataMunging.Common
{
    public interface ILargestSpreadCalculator<T> where T : IDatData
    {
        T GetLargestSpread();
    }
}