static string Problem1()
{
    string[] lines = ReadFile("input.txt");

    int sum = -1;

    foreach (string line in lines)
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

static string Problem2()
{
    string[] lines = ReadFile("input2.txt");

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

    for (int k = 0; k < lines.Length; k++)
    {
        Dictionary<int, string> hash = [];
        List<string> words = [];

        string lineReplaced = "-";
        var line = lines[k];

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
        Console.WriteLine($"Line:{lines[k]} - Sum:{resultLine}");
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


static string[] ReadFile(string fileName)
{
    try
    {
        string[] lines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), fileName));
        return lines;
    }
    catch (IOException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        return [];
    }
}

//Console.WriteLine("Problem 1: " + Problem1());
Console.WriteLine("Problem 2: " + Problem2());