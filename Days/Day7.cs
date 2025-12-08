namespace AOC25.Days;

public class Day7
{
    private List<List<char>> map = new();
    //private int startX = 0;
    public void Solve()
    {
        ParseInput();

        int splits = 0;
        for (int y = 1; y < map.Count; y++)
        {
            for (int x = 0; x < map[y].Count; x++)
            {
                char c = map[y][x];
                char topChar = map[y - 1][x];
                if (topChar != '|' && topChar != 'S')
                    continue;

                if (c == '^')
                {
                    splits++;
                    SetChar('|', x - 1, y);
                    SetChar('|', x + 1, y);
                }
                else if (topChar == '|' || topChar == 'S') // Condition should be unnecessary, but I'll keep it just in case
                {
                    SetChar('|', x, y);
                }
            }
        }
        Console.WriteLine($"Part 1: {splits}");
    }

    private void SetChar(char c, int x, int y)
    {
        if (y < 0 || y >= map.Count)
            return;

        if (x < 0 || x >= map[y].Count)
            return;

        if (map[y][x] != '.')
            return;
        
        map[y][x] = c;
    }
    
    private void ParseInput()
    {
        var input = FileUtils.GetInputText(7);
        var lines = input.Split("\r\n");
        foreach (var line in lines)
        {
            List<char> cLine = new();
            for (int i = 0; i < line.Length; i++)
            {
                cLine.Add(line[i]);
                /*
                if (line[i] == 'S') 
                    startX = i;
                */
            }
            map.Add(cLine);
        }
    }
}