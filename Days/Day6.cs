using System.Text.RegularExpressions;

namespace AOC25.Days;

public class Day6
{
    private List<char> operators = new();
    private List<List<long>> numbers = new();
    
    public void Solve()
    {
        ParseInput();

        long sum = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            char op = operators[i];
            long solution = numbers[i][0];
            for (int j = 1; j < numbers[i].Count; j++)
            {
                //Console.Write($"{solution} {op} {numbers[i][j]} = ");
                switch (op)
                {
                    case '+':
                        solution += numbers[i][j];
                        break;
                    case '*':
                        solution *= numbers[i][j];
                        break;
                }
                //Console.Write(solution + "\n");
            }
            sum += solution;
        }
        Console.WriteLine($"Part 1: {sum}");
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
        
        //Console.WriteLine($"Width: {numbers.Count}");
        
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