namespace Day5;

public class LineSegment
{
    public LineSegment(string line)
    {
        var coordinates = line.Split("->")
            .Select(coordinate => coordinate.Trim())
            .Select(coordinate =>
            {
                var coordinatePositions = coordinate.Split(',');
                var x = int.Parse(coordinatePositions[0]);
                var y = int.Parse(coordinatePositions[1]);
                
                return new Coordinate(x, y);
            })
            .ToArray();

        Start = coordinates[0];
        End = coordinates[1];
    }
    
    public Coordinate Start { get; set; }
    public Coordinate End { get; set; }
};