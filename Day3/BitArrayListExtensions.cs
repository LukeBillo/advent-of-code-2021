using System.Collections;

namespace Day3;

public static class BitArrayListExtensions
{
    public static IList<BitArray> WhereContainsMostCommonBitForPosition(this IList<BitArray> bitArrays, int bitPosition)
    {
        var mostCommonBit = bitArrays.GetMostCommonBitForPosition(bitPosition);
        return bitArrays.Where(bitArray => bitArray.Get(bitPosition) == mostCommonBit).ToList();
    }
    
    public static IList<BitArray> WhereContainsLeastCommonBitForPosition(this IList<BitArray> bitArrays, int bitPosition)
    {
        var leastCommonBit = bitArrays.GetLeastCommonBitForPosition(bitPosition);
        return bitArrays.Where(bitArray => bitArray.Get(bitPosition) == leastCommonBit).ToList();
    }
    
    public static bool GetMostCommonBitForPosition(this IList<BitArray> bitArrays, int bitPosition)
    {
        var numberOf1Bits = bitArrays.Count(bits => bits[bitPosition]);
        return numberOf1Bits * 2 >= bitArrays.Count;
    }
    
    public static bool GetLeastCommonBitForPosition(this IList<BitArray> bitArrays, int bitPosition)
    {
        var numberOf0Bits = bitArrays.Count(bits => !bits[bitPosition]);
        return !(numberOf0Bits * 2 <= bitArrays.Count);
    }
}