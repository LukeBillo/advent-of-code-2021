using System.Collections;

namespace Day3;

public static class CO2ScrubberRating
{
    public static int Get(IList<BitArray> bitArrays, int bitPosition = 0)
    {
        var bitArraysWithLeastCommonBit = bitArrays.WhereContainsLeastCommonBitForPosition(bitPosition);
        return bitArraysWithLeastCommonBit.Count == 1
            ? bitArraysWithLeastCommonBit.First().ToInt()
            : Get(bitArraysWithLeastCommonBit, bitPosition + 1);
    }
}