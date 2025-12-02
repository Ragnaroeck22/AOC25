namespace AOC25;

public class FileUtils
{
    public static string GetInputText(int day)
    {
        string path = $"C:\\Users\\Maximilian.Roeck\\RiderProjects\\AOC25\\AOC25\\Input\\Day{day}.txt";
        return File.ReadAllText(path);
    }
}