namespace AOC25.Days;

public class Day2
{
    private List<(ulong, ulong)> sequences = new();
    
    public void Solve()
    {
        ParseInput();
        ulong sum = 0;
        foreach (var sequence in sequences)
        {
            for (ulong i = sequence.Item1; i <= sequence.Item2; i++)
            {
                int digits = i.ToString().Length;
                if (digits % 2 != 0)
                    continue;

                if (CheckSymmetry(i, digits / 2))
                {
                    sum += i;
                }
            }
        }
        
        Console.WriteLine($"Part 1: {sum}");
        SolvePartTwo();
    }

    private void SolvePartTwo()
    {
        ulong sum = 0;
        foreach (var sequence in sequences)
        {
            for (ulong i = sequence.Item1; i <= sequence.Item2; i++)
            {
                if (CheckRecurringSequence(i))
                {
                    sum += i;
                }
            }
        }
        
        Console.WriteLine($"Part 2: {sum}");
    }
    
    private bool CheckSymmetry(ulong number, int digitsToCheck)
    {
        string numString = number.ToString();
        string a = numString.Substring(0, digitsToCheck);
        string b = numString.Substring(digitsToCheck);
        if (a == b)
            return true;
        
        return false;
    }

    private bool CheckRecurringSequence(ulong number)
    {
        string numString = number.ToString();
        for (int digitsToCheck = 1; digitsToCheck <= numString.Length / 2; digitsToCheck++) // Check all sequence lengths
        {
            string checkSequence = numString.Substring(0, digitsToCheck);
            bool asymmetryFound = false;
            for (int digit = 0; digit < numString.Length; digit += digitsToCheck) // Check sequence (first i should always succeed)
            {
                if (digit + digitsToCheck > numString.Length) // Cancel if check sequence position exceeds num length
                {
                    asymmetryFound = true;
                    break;
                }
                
                string inspectedSequence = numString.Substring(digit, digitsToCheck);
                if (checkSequence != inspectedSequence)
                {
                    asymmetryFound = true;
                    break;
                }
            }

            if (!asymmetryFound)
            {
                return true;
            }
        }
        return false;
    }
    
    private void ParseInput()
    {
        var input = FileUtils.GetInputText(2);
        var sequencesRaw = input.Split(',');
        foreach (var sequence in sequencesRaw)
        {
            var seqFormatted = sequence.Split('-');
            ulong numFirst = ulong.Parse(seqFormatted[0]);
            ulong numLast = ulong.Parse(seqFormatted[1]);
            sequences.Add((numFirst, numLast));
        }
    }
}