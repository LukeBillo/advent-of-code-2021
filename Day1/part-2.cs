// See https://aka.ms/new-console-template for more information

const string submarineDepthsReport = "submarine-depths.txt";

var depths = File.ReadAllLines(submarineDepthsReport)
    .Select(int.Parse)
    .ToList();

var depthIncreases = 0;
var previousDepthSum = int.MaxValue;
var threeMeasurements = new List<int>();

for (var i = 0; i < depths.Count; i++)
{
    var depth = depths[i];
    
    if (threeMeasurements.Count < 3)
    {
        threeMeasurements.Add(depth);
    }
    else
    {
        threeMeasurements[i % 3] = depth;
    }

    if (threeMeasurements.Count != 3)
    {
        continue;
    }

    var sumOfDepths = threeMeasurements.Sum();
    if (sumOfDepths > previousDepthSum)
    {
        depthIncreases += 1;
    }
    
    previousDepthSum = sumOfDepths;
}

Console.WriteLine($"Depth increases: {depthIncreases}, number of recorded depths: {depths.Count}");