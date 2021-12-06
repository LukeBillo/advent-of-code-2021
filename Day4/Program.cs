using Day4;

const string bingoInputFile = "bingo-input.txt";

var bingoFileLines = File.ReadAllLines(bingoInputFile).ToList();
var drawnBingoNumbers = bingoFileLines.First();

var bingoBoards = new List<BingoBoard>();
var bingoBoardLines = new List<string>();

foreach (var line in bingoFileLines.Skip(1))
{
    if (line == string.Empty)
    {
        if (bingoBoardLines.Any())
        {
            bingoBoards.Add(new BingoBoard(bingoBoardLines));
            bingoBoardLines = new List<string>();
        }
        
        continue;
    }
    
    bingoBoardLines.Add(line);
}

if (bingoBoardLines.Any())
{
    bingoBoards.Add(new BingoBoard(bingoBoardLines));
}

var winningBoards = new List<(BingoBoard board, int winningScore)>();

foreach (var drawnNumber in drawnBingoNumbers.Split(',').Select(int.Parse))
{
    foreach (var bingoBoard in bingoBoards.Where(board => !board.IsWinner))
    {
        bingoBoard.MarkNumberAsDrawn(drawnNumber);

        if (bingoBoard.IsWinner)
        {
            var winningScore = bingoBoard.GetWinningScore(drawnNumber);
            winningBoards.Add((bingoBoard, winningScore));
        }
    }
}

var lastWinningBoard = winningBoards.Last();
Console.WriteLine($"The winning score is: {lastWinningBoard.winningScore}");