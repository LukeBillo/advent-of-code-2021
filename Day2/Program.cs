using Day2;

const string submarineCommandsFile = "submarine-commands.txt";

var submarine = new Submarine(0, 0, 0);

var commands = File.ReadAllLines(submarineCommandsFile)
    .Select(Command.FromString)
    .ToList();

foreach (var command in commands)
{
    var (depthDelta, horizontalDelta, aimDelta) = CommandToPositionDeltas(command, submarine.Aim);

    submarine = submarine with
    {
        Depth = submarine.Depth + depthDelta,
        HorizontalPosition = submarine.HorizontalPosition + horizontalDelta,
        Aim = submarine.Aim + aimDelta
    };
}

Console.WriteLine($"Submarine depth: {submarine.Depth}");
Console.WriteLine($"Submarine horizontal: {submarine.HorizontalPosition}");
Console.WriteLine($"Product of two positions ({submarine.Depth}, {submarine.HorizontalPosition}): {submarine.Depth * submarine.HorizontalPosition}");

(int depthDelta, int horizontalDelta, int aimDelta) CommandToPositionDeltas(Command command, int currentAim) => command.Direction switch
{
    Direction.Forward => (currentAim * command.Amount, command.Amount, 0),
    Direction.Down => (0, 0, command.Amount),
    Direction.Up => (0, 0, -command.Amount),
    _ => throw new ArgumentOutOfRangeException(nameof(command), "Unknown direction")
};