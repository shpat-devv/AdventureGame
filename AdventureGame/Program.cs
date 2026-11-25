using AdventureGame.Models;

namespace AdventureGame
{
    internal static class Program 
    {
        private static bool _loggedIn = false;
        private static readonly Client Client = new Client();
        private static User _user;

        private static async Task Main()
        {
            while (true)
            {
                if (!_loggedIn) 
                    await InitializeLogin();

                Console.WriteLine("Welcome to the Adventure Game!");
                Console.ReadKey();
            }
        }
        
        private static void DisplayOptions() 
        {
            Console.WriteLine("1. Confirm Identity");
            Console.WriteLine("2. Start Game");
            Console.WriteLine("3. Exit");
            
            
        }
        
        private static async Task InitializeLogin() 
        {
            while (true)
            {
                _user = GetUserCreds();

                if (string.IsNullOrEmpty(_user.Username) || string.IsNullOrEmpty(_user.Password))
                {
                    Console.WriteLine("Username and password cannot be empty. Please try again.");
                    continue;
                }
                
                Console.WriteLine("Login Or Register (L/R)");
                char input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                
                if (input is 'l' or 'L')
                {
                    if (await Client.Login(_user))
                    {
                        _loggedIn = true;
                        break;
                    }
                }
            
                else if (input is 'r' or 'R')
                {
                    await Client.Register(_user);
                }
            
                else
                    Console.WriteLine("Invalid input. Please enter 'L' or 'R'.");
            }
        }
        
        private static User GetUserCreds() 
        {
            Console.WriteLine("What is your username?");
            var username = Console.ReadLine();
            Console.WriteLine("What is your password?");
            var password = Console.ReadLine();
            
            return new User(username, password);
        }
    }
}