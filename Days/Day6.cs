using System.Text.RegularExpressions;

namespace AOC25.Days;

public class Day6
{
    private List<char> operators = new();
    private List<List<long>> numbers = new();
    
    public void Solve()
    {
        //ParseInput();
        ParseInputPartTwo();
        
        long sum = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            char op = operators[i];
            long solution = numbers[i][0];
            for (int j = 1; j < numbers[i].Count; j++)
            {
                switch (op)
                {
                    case '+':
                        solution += numbers[i][j];
                        break;
                    case '*':
                        solution *= numbers[i][j];
                        break;
                }
            }
            sum += solution;
        }
        Console.WriteLine($"Solution: {sum}");
    }

    private void ParseInputPartTwo()
    {
        // I hate this
        // This only works with the actual input, not the example
        // I'm too lazy to do it dynamically
        var input = FileUtils.GetInputText(6);
        
        var lines = input.Split("\r\n");
        for (int startIndex = 0; startIndex + 1 < lines[0].Length;)
        {
            List<long> nums = new();
            
            // Fuck you, AoC. I defy everything you stand for.
            var l0 = Regex.Matches(lines[0].Substring(startIndex), @"[\d]+");
            var l1 = Regex.Matches(lines[1].Substring(startIndex), @"[\d]+");
            var l2 = Regex.Matches(lines[2].Substring(startIndex), @"[\d]+");
            var l3 = Regex.Matches(lines[3].Substring(startIndex), @"[\d]+");
            int maxLength = Math.Max(l0[0].Length, l1[0].Length);
            maxLength = Math.Max(maxLength, l2[0].Length);
            maxLength = Math.Max(maxLength, l3[0].Length);
            
            for (int x = 0; x < maxLength; x++)
            {
                int idx = startIndex + x;
                string parseString = $"{lines[0][idx]}{lines[1][idx]}{lines[2][idx]}{lines[3][idx]}";
                nums.Add(long.Parse(parseString));
            }
            numbers.Add(nums);
            startIndex += maxLength + 1;
        }
        
        var matchesOperators = Regex.Matches(input, @"[+*]+");
        for (int i = 0; i < matchesOperators.Count; i++)
        {
            operators.Add(matchesOperators[i].Value[0]);
        }
    }
    
    private void ParseInput()
    {
        var input = FileUtils.GetInputText(6);
        var matchesDigits = Regex.Matches(input, @"[\d]+");
        var matchesOperators = Regex.Matches(input, @"[+*]+");
        
        // Initialize width
        var cut = input.Split("\r\n");
        int width = Regex.Matches(cut[0], @"[\d]+").Count;
        for (int i = 0; i < width; i++)
        {
            numbers.Add(new ());
        }
        
        for (int i = 0; i < matchesDigits.Count; i++)
        {
            numbers[i % numbers.Count].Add(long.Parse(matchesDigits[i].Value));
        }

        for (int i = 0; i < matchesOperators.Count; i++)
        {
            operators.Add(matchesOperators[i].Value[0]);
        }
    }
}