namespace Day4;

public class BingoNumber
{
    public BingoNumber(int number)
    {
        Number = number;
        HasBeenDrawn = false;
    }
    
    public bool HasBeenDrawn { get; set; }
    public int Number { get; set; }
}