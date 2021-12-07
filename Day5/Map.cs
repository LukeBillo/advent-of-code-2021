namespace Day5;

public class Map
{
    private readonly IList<IList<VisitableCoordinate>> _map;

    public Map(Coordinate end)
    {
        var (endX, endY) = end;
        _map = new List<IList<VisitableCoordinate>>();

        for (var y = 0; y <= endY; y++)
        {
            var row = new List<VisitableCoordinate>();

            for (var x = 0; x <= endX; x++)
            {
                var coordinate = new Coordinate(x, y);
                row.Add(new VisitableCoordinate(coordinate, 0));
            }

            _map.Add(row);
        }
    }

    public void VisitCoordinatesForLineSegment(LineSegment lineSegment)
    {
        var currentCoordinate = lineSegment.Start;

        while (currentCoordinate != lineSegment.End)
        {
            VisitCoordinate(currentCoordinate);

            var nextX = GetNextPosition(currentCoordinate.X, lineSegment.End.X);
            var nextY = GetNextPosition(currentCoordinate.Y, lineSegment.End.Y);
            currentCoordinate = new Coordinate(nextX, nextY);
        }

        VisitCoordinate(currentCoordinate);
    }

    private static int GetNextPosition(int currentPosition, int endPosition)
    {
        if (currentPosition == endPosition)
        {
            return currentPosition;
        }

        return currentPosition > endPosition ? currentPosition - 1 : currentPosition + 1;
    }

    private void VisitCoordinate(Coordinate coordinate)
    {
        var (x, y) = coordinate;
        var visitedCoordinate = _map[y][x];
        _map[y][x] = visitedCoordinate with { TimesVisited = visitedCoordinate.TimesVisited + 1 };
    }

    public IList<VisitableCoordinate> GetCoordinatesVisitedMoreThanOrEqualTo(int numberOfVisits)
    {
        return _map
            .SelectMany(xRow => xRow.Where(coordinate => coordinate.TimesVisited >= numberOfVisits))
            .ToList();
    }

    public void DisplayInConsole()
    {
        foreach (var xRow in _map)
        {
            Console.WriteLine();
            foreach (var (_, timesVisited) in xRow)
            {
                var output = timesVisited is 0 ? "." : timesVisited.ToString();
                Console.Write(output);
            }
        }
    }
}