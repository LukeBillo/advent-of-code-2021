namespace Day4;

public class BingoBoard
{
    public BingoBoard(IEnumerable<string> boardLines)
    {
        BingoRows = boardLines
            .Select(line => line.Split(' '))
            .Select(numbers => numbers
                .Where(number => number != string.Empty)
                .Select(int.Parse)
                .Select(number => new BingoNumber(number))
                .ToList())
            .ToList();
    }

    public List<List<BingoNumber>> BingoRows { get; set; }

    public void MarkNumberAsDrawn(int drawnNumber)
    {
        var bingoNumbersWithDrawnNumber = BingoRows.SelectMany(row => 
            row.Where(bingoNumber => bingoNumber.Number == drawnNumber));

        foreach (var bingoNumber in bingoNumbersWithDrawnNumber)
        {
            bingoNumber.HasBeenDrawn = true;
        }
    }

    public bool IsWinner => HasWinningRow() || HasWinningColumn();

    public int GetWinningScore(int lastNumberDrawn)
    {
        var sumOfNumbersNotDrawn = BingoRows
            .SelectMany(row => row.Where(bingoNumber => !bingoNumber.HasBeenDrawn))
            .Sum(bingoNumber => bingoNumber.Number);

        return sumOfNumbersNotDrawn * lastNumberDrawn;
    }

    private bool HasWinningRow()
    {
        return BingoRows.Any(row => row.All(number => number.HasBeenDrawn));
    }

    private bool HasWinningColumn()
    {
        return BingoRows
            .Where((_, columnIndex) => HasEntireColumnBeenDrawn(columnIndex))
            .Any();
    }

    private bool HasEntireColumnBeenDrawn(int columnIndex) => BingoRows
        .Select(row => row[columnIndex])
        .All(number => number.HasBeenDrawn);
}