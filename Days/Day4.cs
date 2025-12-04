namespace AOC25.Days;

public class Day4
{
    private List<List<char>> map = new();

    public void Solve()
    {
        ParseInput();
        int rollsMovable = 0;
        for (int y = 0; y < map.Count; y++)
        {
            for (int x = 0; x < map[y].Count; x++)
            {
                char c = map[y][x];
                if (c == '.')
                    continue;
                
                if (GetRollMovable(x, y))
                    rollsMovable++;
            }
        }
        Console.WriteLine($"Part 1: {rollsMovable}");
        SolvePartTwo();
    }

    private void SolvePartTwo()
    {
        // Let the unholy nesting begin
        int rollsMovable;
        int rollsMoved = 0;
        do
        {
            rollsMovable = 0;
            for (int y = 0; y < map.Count; y++)
            {
                for (int x = 0; x < map[y].Count; x++)
                {
                    char c = map[y][x];
                    if (c == '.')
                        continue;

                    if (GetRollMovable(x, y))
                    {
                        rollsMovable++;
                        map[y][x] = '.';
                        rollsMoved++;
                    }
                }
            }
        } while (rollsMovable > 0);
        
        
        Console.WriteLine($"Part 2: {rollsMoved}");
    }

    private bool GetRollMovable(int x, int y)
    {
        int adjacentRolls = 0;
        adjacentRolls += PositionIsRoll(x - 1, y - 1) ? 1 : 0; // TL
        adjacentRolls += PositionIsRoll(x, y - 1) ? 1 : 0; // TC
        adjacentRolls += PositionIsRoll(x + 1, y - 1) ? 1 : 0; // TR
        adjacentRolls += PositionIsRoll(x + 1, y) ? 1 : 0; // CR
        adjacentRolls += PositionIsRoll(x + 1, y + 1) ? 1 : 0; // BR
        adjacentRolls += PositionIsRoll(x, y + 1) ? 1 : 0; // BC
        adjacentRolls += PositionIsRoll(x - 1, y + 1) ? 1 : 0; // BL
        adjacentRolls += PositionIsRoll(x - 1, y) ? 1 : 0; // CL

        if (adjacentRolls < 4)
            return true;
        return false;
    }
    
    private char GetChar(int posX, int posY)
    {
        if (posY < 0 || posY >= map.Count)
            return '0';
        if (posX < 0 || posX >= map[posY].Count)
            return '0';
        
        return map[posY][posX];
    }

    private bool PositionIsRoll(int posX, int posY)
    {
        if (GetChar(posX, posY) == '@')
            return true;
        return false;
    }
    
    private void ParseInput()
    {
        var input = FileUtils.GetInputText(4);
        var mapRaw = input.Split("\r\n");
        
        // Convert map from array to list for pt. 2
        for (int y = 0; y < mapRaw.Length; y++)
        {
            List<char> row = new();
            for (int x = 0; x < mapRaw[y].Length; x++)
            {
                row.Add(mapRaw[y][x]);
            }

            map.Add(row);
        }
    }
}