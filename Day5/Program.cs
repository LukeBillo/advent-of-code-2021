using Day5;

var ventLines = File.ReadAllLines("hydrothermal-vent-lines.txt")
    .Select(line => new LineSegment(line))
    .ToList();

var allCoordinates = ventLines.Select(line => line.Start).ToList();
allCoordinates.AddRange(ventLines.Select(line => line.End));

var highestX = allCoordinates.Max(coordinate => coordinate.X);
var highestY = allCoordinates.Max(coordinate => coordinate.Y);

var map = new Map(new Coordinate(highestX, highestY));

foreach (var ventLine in ventLines)
{
    map.VisitCoordinatesForLineSegment(ventLine);
}

var coordinatesWithMoreThan2Lines = map.GetCoordinatesVisitedMoreThanOrEqualTo(2);
Console.WriteLine($"There are {coordinatesWithMoreThan2Lines.Count} coordinates where 2 or more lines overlap");