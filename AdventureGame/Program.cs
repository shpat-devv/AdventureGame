using System;
using System.Net.Http;

namespace AdventureGame
{
    internal static class Program 
    {
        private static readonly bool LoggedIn = false;
        static async Task Main()
        {
            while (true)
            {
                if (!LoggedIn)
                {
                    Console.WriteLine("Login Or Register (L/R)");
                    string? input = Console.ReadLine();

                    if (input is not null && input.Trim() is "l" or "L" or "r" or "R")
                    {
                        Console.WriteLine("Please enter your username:");
                        string username = Console.ReadLine();
                        Console.WriteLine("Please enter your password:");
                        string password = Console.ReadLine();
                        
                        if (username is not null && password is not null)
                            await Client.LoginOrRegister(input, username, password);
                    }
                    else
                        Console.WriteLine("Invalid input. Please enter 'L' or 'R'.");
                }
                
                Console.WriteLine("Welcome to the Adventure Game!");
                Console.ReadKey();
            }
        }
    }
}