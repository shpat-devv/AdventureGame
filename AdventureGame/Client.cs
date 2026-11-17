using System.Net.Http;

namespace AdventureGame;

public class Client
{
    static readonly HttpClient HttpClient = new HttpClient();
    static readonly string Url = "https://127.0.0.1:7270/";

    public static async Task LoginOrRegister(string input, string username, string password)
    {
        try
        {
            string responseBody = await HttpClient.GetStringAsync(Url + "api/characters/");
            Console.WriteLine(responseBody);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex}");
        }
    }
}