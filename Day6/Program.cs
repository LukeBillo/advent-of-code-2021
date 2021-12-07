var startingLanternFishAges = File.ReadAllLines("lanternfish-ages.txt")
    .Single()
    .Split(',')
    .Select(int.Parse)
    .GroupBy(age => age)
    .ToDictionary(grouping => grouping.Key, grouping => grouping.Count());

const int daysOfSimulation = 256;
const int daysUntilAgeResets = 8;

var lanternFishAges = new Dictionary<int, long>
{
    { 0, startingLanternFishAges.GetValueOrDefault(0) },
    { 1, startingLanternFishAges.GetValueOrDefault(1) },
    { 2, startingLanternFishAges.GetValueOrDefault(2) },
    { 3, startingLanternFishAges.GetValueOrDefault(3) },
    { 4, startingLanternFishAges.GetValueOrDefault(4) },
    { 5, startingLanternFishAges.GetValueOrDefault(5) },
    { 6, startingLanternFishAges.GetValueOrDefault(6) },
    { 7, startingLanternFishAges.GetValueOrDefault(7) },
    { 8, startingLanternFishAges.GetValueOrDefault(8) }
};

for (var i = 0; i < daysOfSimulation; i++)
{
    var lanternFishGoingToSix = lanternFishAges[0] + lanternFishAges[7];
    var numberOfNewLanternFish = lanternFishAges[0];

    for (var age = 0; age < daysUntilAgeResets; age++)
    {
        lanternFishAges[age] = lanternFishAges[age + 1];
    }

    lanternFishAges[6] = lanternFishGoingToSix;
    lanternFishAges[8] = numberOfNewLanternFish;
}

Console.WriteLine($"After {daysOfSimulation} days, there are {lanternFishAges.Select(kvp => kvp.Value).Sum()} lantern fish");