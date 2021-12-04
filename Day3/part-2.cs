using System.Collections;
using Day3;

const string diagnosticReportFile = "diagnostic-report.txt";

var boolArrayList = File.ReadAllLines(diagnosticReportFile)
    .Select(line => line.Select(bit => bit == '1').ToArray())
    .ToList();

var bitArrays = boolArrayList.Select(boolArray => new BitArray(boolArray)).ToList();
    
var oxygenGeneratorRating = OxygenGeneratorRating.Get(bitArrays);
var co2ScrubberRating = CO2ScrubberRating.Get(bitArrays);

Console.WriteLine($"O2 Generator Rating: {oxygenGeneratorRating}");
Console.WriteLine($"CO2 Scrubber Rating: {co2ScrubberRating}");

var lifeSupportRating = oxygenGeneratorRating * co2ScrubberRating;
Console.WriteLine($"Life support rating: {lifeSupportRating}");