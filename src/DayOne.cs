namespace AdventOfCode;

public class DayOne(string[] inputLines) : Day(inputLines)
{
    public override void Solve()
    {
        //Console.WriteLine(Problem1(InputLines));
        Console.WriteLine(ProblemTwo(InputLines));
    }

    static string ProblemOne(string[] inputLines)
    {
        int sum = -1;

        foreach (string line in inputLines)
        {
            char start = new();
            char end = new();

            foreach (var item in line)
            {
                if (Char.IsDigit(item))
                {
                    if (start == -1)
                    {
                        start = item;
                    }
                    end = item;
                }
            }
            string resultLine = string.Concat(start, end);
            sum += Convert.ToInt32(resultLine);
        }

        return $"{sum}";
    }

    static string ProblemTwo(string[] inputLines)
    {
        Dictionary<string, int> wordToNumber = new()
        {
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9},
            {"zero", 0}
        };

        int sum = 0;
        int index = 0;
        string currentWord = string.Empty;

        for (int k = 0; k < inputLines.Length; k++)
        {
            Dictionary<int, string> hash = [];
            List<string> words = [];

            string lineReplaced = "-";
            var line = inputLines[k];

            var originLine = line;

            while (!string.IsNullOrWhiteSpace(lineReplaced))
            {
                lineReplaced = line;
                int length = line.Length;

                for (int i = 0; i < length; i++)
                {
                    if (Char.IsDigit(line[i]))
                    {
                        var digit = line[i].ToString();
                        hash.Add(index, line[i].ToString());
                        lineReplaced = lineReplaced.Replace(line[i].ToString(), string.Empty);
                        index++;
                    }
                    else
                    {
                        currentWord += line[i];

                        if (wordToNumber.TryGetValue(currentWord.ToLower(), out int number))
                        {

                            hash.Add(index, number.ToString());
                            words.Add(number.ToString());
                            if (originLine.IndexOf(currentWord) < originLine.IndexOf(hash[0]) && !words.Contains(hash[0]))
                            {
                                InsertNumberAtFirtPosition(hash, 0, number.ToString());
                                index++;
                            }

                            lineReplaced = lineReplaced.Replace(currentWord, string.Empty);
                            currentWord = string.Empty;
                            index++;
                        }
                    }
                }
                if (line.Length != 0)
                    line = line.Remove(0, 1);

                currentWord = string.Empty;
            }

            string resultLine = string.Concat(hash[0], hash[index - 1]);
            Console.WriteLine($"Line:{inputLines[k]} - Sum:{resultLine}");
            sum += Convert.ToInt32(resultLine);
            index = 0;
        }
        return $"{sum}";
    }

    static void InsertNumberAtFirtPosition(Dictionary<int, string> hash, int key, string value)
    {
        List<KeyValuePair<int, string>> tempList = [new KeyValuePair<int, string>(key, value), .. hash];
        hash.Clear();
        for (int i = 0; i < tempList.Count(); i++)
            hash.Add(i, tempList[i].Value);
    }
}

