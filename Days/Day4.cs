namespace AOC25.Days;

public class Day4
{
    private string[] map;

    public void Solve()
    {
        ParseInput();
        int rollsMovable = 0;
        for (int y = 0; y < map.Length; y++)
        {
            for (int x = 0; x < map[y].Length; x++)
            {
                char c = map[y][x];
                if (c == '.')
                    continue;

                int adjacentRolls = 0;
                // Can definitely be done easier, but this does the job
                adjacentRolls += PositionIsRoll(x - 1, y - 1) ? 1 : 0; // TL
                adjacentRolls += PositionIsRoll(x, y - 1) ? 1 : 0; // TC
                adjacentRolls += PositionIsRoll(x + 1, y - 1) ? 1 : 0; // TR
                adjacentRolls += PositionIsRoll(x + 1, y) ? 1 : 0; // CR
                adjacentRolls += PositionIsRoll(x + 1, y + 1) ? 1 : 0; // BR
                adjacentRolls += PositionIsRoll(x, y + 1) ? 1 : 0; // BC
                adjacentRolls += PositionIsRoll(x - 1, y + 1) ? 1 : 0; // BL
                adjacentRolls += PositionIsRoll(x - 1, y) ? 1 : 0; // CL
                
                if (adjacentRolls < 4)
                    rollsMovable++;
            }
        }
        Console.WriteLine($"Part 1: {rollsMovable}");
    }

    private char GetChar(int posX, int posY)
    {
        if (posY < 0 || posY >= map.Length)
            return '0';
        if (posX < 0 || posX >= map[posY].Length)
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
        map = input.Split("\r\n");
    }
}