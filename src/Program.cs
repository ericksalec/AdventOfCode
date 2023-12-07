using AdventOfCode;

class Program
{
    static void Main()
    {
        string[] inputLines = ReadInputFromFile("input2.txt");

        Day dayToRun = new DayOne(inputLines);

        RunDay(inputLines, dayToRun);

        Console.ReadLine(); 
    }

    static string[] ReadInputFromFile(string filePath)
    {
        return File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), filePath));
    }

    public static void RunDay(string[] inputLines, Day day)
    {
        day.Solve();
    }
}