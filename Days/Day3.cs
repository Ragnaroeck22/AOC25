namespace AOC25.Days;

public class Day3
{
    private List<List<ulong>> banks = new();
    
    public void Solve()
    {
        ParseInput();

        ulong joltage = 0;
        foreach (var bank in banks)
        {
            int highestIndex = 0;
            for (int i = 0; i < bank.Count - 1; i++) // Never take last index as highest!
            {
                if (bank[i] > bank[highestIndex])
                {
                    highestIndex = i;
                }
            }

            int secondHighestIndex = highestIndex + 1;
            for (int i = secondHighestIndex; i < bank.Count; i++)
            {
                if (bank[i] > bank[secondHighestIndex])
                {
                    secondHighestIndex = i;
                }
            }

            string fused = bank[highestIndex].ToString() + bank[secondHighestIndex].ToString();
            joltage += ulong.Parse(fused);
        }
        Console.WriteLine($"Part 1: {joltage}");
        SolvePartTwo();
    }

    private void SolvePartTwo()
    {
        ulong joltage = 0;
        for (int bank = 0; bank < banks.Count; bank++)
        {
            List<int> indices = new();
            for (int batteriesLeft = 12; batteriesLeft > 0; batteriesLeft--)
            {
                int lastIndex = -1;
                if (indices.Count > 0)
                {
                    lastIndex = indices[^1];
                }
                
                indices.Add(FindHighestIndex(bank, lastIndex + 1, batteriesLeft));
            }

            string fused = "";
            foreach (var index in indices)
            {
                fused += banks[bank][index];
            }
            //Console.WriteLine($"Fused {fused}");
            joltage += ulong.Parse(fused);
        }
        Console.WriteLine($"Part 2: {joltage}");
    }

    private int FindHighestIndex(int bank, int startIndex, int batteriesLeft)
    {
        int highestIndex = startIndex;
        for (int i = startIndex; i < banks[bank].Count - (batteriesLeft - 1); i++)
        {
            if (banks[bank][i] > banks[bank][highestIndex])
            {
                highestIndex = i;
            }
        }
        return highestIndex;
    }
    
    private void ParseInput()
    {
        var input = FileUtils.GetInputText(3);
        var lines = input.Split("\r\n");
        foreach (var line in lines)
        {
            List<ulong> bank = new();
            foreach (var character in line)
            {
                bank.Add(ulong.Parse(character.ToString()));
            }
            banks.Add(bank);
        }
    }
}