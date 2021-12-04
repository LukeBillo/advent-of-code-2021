using System.Collections;

namespace Day3;

public static class OxygenGeneratorRating
{
    public static int Get(IList<BitArray> bitArrays, int bitPosition = 0)
    {
        var bitArraysWithMostCommonBit = bitArrays.WhereContainsMostCommonBitForPosition(bitPosition);
        return bitArraysWithMostCommonBit.Count == 1
            ? bitArraysWithMostCommonBit.First().ToInt()
            : Get(bitArraysWithMostCommonBit, bitPosition + 1);
    }
}