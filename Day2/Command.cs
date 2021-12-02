namespace Day2;

public record Command
{
    public Direction Direction { get; private init; }
    public int Amount { get; private init; }

    public static Command FromString(string command)
    {
        var splitCommand = command.Split(' ');

        if (splitCommand.Length != 2)
        {
            throw new InvalidDataException("Provided command was not in the format '<direction> <amount>'");
        }
        
        var direction = Enum.Parse<Direction>(splitCommand[0], true);
        var amount = int.Parse(splitCommand[1]);

        return new Command
        {
            Direction = direction,
            Amount = amount
        };
    }
}