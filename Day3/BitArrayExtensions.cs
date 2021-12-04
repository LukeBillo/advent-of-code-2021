using System.Collections;

namespace Day3;

public static class BitArrayExtensions
{
    public static int ToInt(this BitArray bitArray)
    {
        if (bitArray.Length > 32)
        {
            throw new ArgumentException("Can't cast bit array greater than 32 bits to int", nameof(bitArray));
        }

        Console.WriteLine(bitArray.ToReadableString());

        var value = 0;
        
        for (var i = 0; i < bitArray.Length; i++)
        {
            if (bitArray[bitArray.Length - i - 1])
            {
                value += Convert.ToInt32(Math.Pow(2, i));
            }
        }

        return value;
    }

    public static string ToReadableString(this BitArray bitArray)
    {
        var stringified = "";

        foreach (bool bit in bitArray)
        {
            stringified += bit ? '1' : '0';        
        }

        return stringified;
    }
}