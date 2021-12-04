/*
using System.Collections;
using Day3;

const string diagnosticReportFile = "diagnostic-report.txt";
const int bitsPerArray = 12;

var bitArrays = File.ReadAllLines(diagnosticReportFile)
    .Select(line => new BitArray(line.Select(bit => bit == '1').ToArray()))
    .ToList();

var mostCommonBits = new BitArray(bitsPerArray);
var leastCommonBits = new BitArray(bitsPerArray);

for (var i = 0; i < bitsPerArray; i++)
{
    var mostCommonBit = bitArrays.Select(bits => bits[i])
        .GroupBy(bit => bit)
        .OrderByDescending(bit => bit.Count())
        .First()
        .Key;

    mostCommonBits.Set(i, mostCommonBit);
    leastCommonBits.Set(i, !mostCommonBit);
}

var gammaRate = mostCommonBits.ToInt();
var epsilonRate = leastCommonBits.ToInt();

var powerConsumption = gammaRate * epsilonRate;

Console.WriteLine($"Gamma rate: {gammaRate}");
Console.WriteLine($"Epsilon Rate: {epsilonRate}");
Console.WriteLine($"Power consumption: {powerConsumption}");
*/