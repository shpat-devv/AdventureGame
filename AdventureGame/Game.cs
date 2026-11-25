namespace AdventureGame;

public static class Game
{
    
    /*
     * Welcome user
     * List options
     *
     * List
     * On list, list user characters
     *
     * Waiting
     * On wait, wait for server to give user a character
     */
    
    
    
    public static async Task Start()
    {
        Console.WriteLine("Welcome to Adventure Game!");
        
        while (true)
        {
            var userChoice = DisplayOptions();
            
            if (userChoice == 1)
                await Client.ListCharacters();
            else if (userChoice == 2)
                await Client.FindCharacter();
            else if (userChoice == 3)
                break;
            else
                Console.WriteLine("Invalid choice");
        }
    }
    
    private static int DisplayOptions()
    {
        Console.WriteLine("1. List");
        Console.WriteLine("2. Wait");
        Console.WriteLine("3. Exit");

        var userInput = Console.ReadLine();
        
        if (userInput == null)
            return -1;
        
        return int.Parse(userInput);
    }
}