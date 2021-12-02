const string submarineDepthsReport = "submarine-depths.txt";

var depths = File.ReadAllLines(submarineDepthsReport)
    .Select(int.Parse)
    .ToList();

var depthIncreases = 0;
var previousDepthSum = int.MaxValue;

for (var i = 0; i < depths.Count; i++)
{
    var sumOfDepths = depths.Skip(i).Take(3).Sum();
    if (sumOfDepths > previousDepthSum)
    {
        depthIncreases += 1;
    }
    
    previousDepthSum = sumOfDepths;
}

Console.WriteLine($"Depth increases: {depthIncreases}, number of recorded depths: {depths.Count}");