using AdventureGame.Models;

namespace AdventureGame
{
    internal static class Program 
    {
        private static bool _loggedIn;
        private static User _user;
        
        private static async Task Main()
        {
            while (true)
            {
                if (!_loggedIn) 
                    await InitializeLogin();

                Console.WriteLine("Welcome to the Adventure Game!\n");
                var userChoice = DisplayOptions();
                
                if (userChoice == -1)
                    continue;
                
                if (userChoice == 1)
                    await Client.ConfirmIdentity();
                else if (userChoice == 2)
                    await Game.Start();
                else if (userChoice == 3)
                    break;
            }
        }
        
        private static int DisplayOptions() 
        {
            Console.WriteLine("1. Confirm Identity");
            Console.WriteLine("2. Start the game");
            Console.WriteLine("3. Exit");
            
            var userInput = Console.ReadLine();
            
            if (string.IsNullOrEmpty(userInput))
                return -1;

            return int.Parse(userInput);
        }
        
        private static async Task InitializeLogin() 
        {
            while (true)
            {
                _user = GetUserCreds();

                if (string.IsNullOrEmpty(_user.Username) || string.IsNullOrEmpty(_user.Password))
                {
                    Console.WriteLine("Username and password cannot be empty. Please try again.\n");
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
                    Console.WriteLine("Invalid input. Please enter 'L' or 'R'.\n");
            }
        }
        
        private static User GetUserCreds() 
        {
            Console.WriteLine("What is your username?");
            var username = Console.ReadLine();
            Console.WriteLine("What is your password?");
            var password = Console.ReadLine();
            Console.WriteLine();
            return new User(username, password);
        }
    }
}