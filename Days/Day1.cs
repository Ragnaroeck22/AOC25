namespace AOC25.Days;

public class Day1
{
    private List<int> operations = new();
    
    public void Solve()
    {
        ParseInput();
        // Not perfect, but whatever
        int dialValue = 50;
        int clicks = 0;
        for (int i = 0; i < operations.Count; i++)
        {
            dialValue += operations[i];
            int hundredVal = dialValue / 100; // We need the truncating effect of int
            dialValue -= hundredVal * 100; // Works with negative numbers as well (but why?)
            
            if (dialValue == 0)
            {
                clicks++;
            }
        }
        Console.WriteLine($"Part one: {clicks}");
        SolvePartTwo();
    }

    private void SolvePartTwoAlt()
    {
        // I can't be bothered debugging this...
        int dialValue = 50;
        int clicks = 0;
        for (int i = 0; i < operations.Count; i++)
        {
            int oldDialValue = dialValue; // debug
            int operation = operations[i]; // debug
            dialValue += operations[i];
            
            int hundredVal = dialValue / 100;
            int clicksThisIteration = Math.Abs(hundredVal);
            if (dialValue < 0 && dialValue % 100 != 0)
            {
                hundredVal--;
            }

            dialValue -= hundredVal * 100;
            
            if (dialValue is < 0 or > 99)
            {
                Console.WriteLine("Correction failed");
            }
            
            clicks += Math.Abs(clicksThisIteration);
            
            if (dialValue == 0) // The && hundredVal should correct for landing on 0 exactly (it doesn't)
            {
                clicks++;
            }
        }
        Console.WriteLine(dialValue);
        Console.WriteLine($"Part two: {clicks}");
    }
    
    private void SolvePartTwo()
    {
        int dialValue = 50;
        int clicks = 0;
        for (int i = 0; i < operations.Count; i++)
        {
            int val = 1;
            if (operations[i] < 0)
            {
                val = -1;
            }
            
            // WTF is going on? Use ultra-brute force for now
            for (int j = 0; j < Math.Abs(operations[i]); j++)
            {
                dialValue += val;
                if (dialValue < 0)
                {
                    dialValue += 100;
                }

                if (dialValue > 99)
                {
                    dialValue -= 100;
                }
                if (dialValue == 0)
                {
                    clicks++;
                }
            }
        }
        
        Console.WriteLine($"Part two: {clicks}");
    }
    
    private void ParseInput()
    {
        var input = FileUtils.GetInputText(1);
        var lines = input.Split("\r\n");
        foreach (var line in lines)
        {
            char op = line[0];
            int denominator = int.Parse(line.Substring(1));
            if (op == 'R')
            {
                operations.Add(denominator);
            }
            else
            {
                operations.Add(denominator * -1);
            }
        }
    }
}