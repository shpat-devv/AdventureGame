namespace AdventureGame;

public class Helper
{
    private readonly Dictionary<int, string> _options = new Dictionary<int, string>()
    {
        { 1, "Confirm Identity" },
        { 2, "Start Game" },
        { 3, "Quit"},
    };
    
    public void PrintItems()
    {
        foreach (var item in _options)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}