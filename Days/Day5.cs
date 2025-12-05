namespace AOC25.Days;

public class Day5
{
    private List<(ulong, ulong)> ranges = new();
    private List<ulong> ingredients = new();
    
    public void Solve()
    {
        ParseInput();
        int freshIngredients = 0;
        foreach (var ingredient in ingredients)
        {
            if (GetInRangeAbs(ingredient))
                freshIngredients++;
        }
        Console.WriteLine($"Part 1: {freshIngredients}");
        SolvePartTwo();
    }

    private void SolvePartTwo()
    {
        for (int range = 0; range < ranges.Count - 1; range++)
        {
            for (int i = 0; i < ranges.Count; i++)
            {
                if (range == i)
                    continue;
                
                if (GetInRange(range, ranges[i].Item1) || GetInRange(range, ranges[i].Item2))
                {
                    var newRange = CombineRanges(ranges[range], ranges[i]);
                    var a = ranges[range]; // Caching necessary before removal
                    var b = ranges[i];
                    ranges.Remove(a);
                    ranges.Remove(b);
                    ranges.Add(newRange);
                    range = 0; // Reset and check again
                    break;
                }
            }
        }

        ulong ingredientsTotal = 0;
        foreach (var range in ranges)
        {
            ingredientsTotal += range.Item2 - range.Item1 + 1;
        }
        Console.WriteLine($"Part 2: {ingredientsTotal}");
    }

    private bool GetInRange(int rangeIndex, ulong ingredient)
    {
        if (ingredient >= ranges[rangeIndex].Item1 && ingredient <= ranges[rangeIndex].Item2)
        {
            return true;
        }

        return false;
    }

    private (ulong, ulong) CombineRanges((ulong, ulong) range1, (ulong, ulong) range2)
    {
        ulong lowest = Math.Min(range1.Item1, range2.Item1);
        ulong highest = Math.Max(range1.Item2, range2.Item2);
        return new (lowest, highest);
    }
    
    private bool GetInRangeAbs(ulong ingredient)
    {
        foreach (var range in ranges)
        {
            if (ingredient >= range.Item1 && ingredient <= range.Item2)
            {
                return true;
            }
        }
        return false;
    }
    
    private void ParseInput()
    {
        var input = FileUtils.GetInputText(5);
        var raw = input.Split("\r\n\r\n");
        var rangesRaw = raw[0].Split("\r\n");
        var ingredientsRaw = raw[1].Split("\r\n");

        foreach (var range in rangesRaw)
        {
            var rgs = range.Split("-");
            ranges.Add((ulong.Parse(rgs[0]), ulong.Parse(rgs[1])));
        }

        foreach (var ingredient in ingredientsRaw)
        {
            ingredients.Add(ulong.Parse(ingredient));
        }
    }
}