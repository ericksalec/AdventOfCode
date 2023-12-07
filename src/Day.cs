namespace AdventOfCode;
public abstract class Day
{
    protected string[] InputLines;

    public Day(string[] inputLines)
    {
        InputLines = inputLines;
    }

    public abstract void Solve();

    public virtual void PrintResult(string result)
    {
        Console.WriteLine(result);
    }
}
