using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using AdventureGame.Models;

namespace AdventureGame;

public class Client
{
    static readonly HttpClient HttpClient = new HttpClient();
    static readonly string Url = "https://127.0.0.1:7270/";

    public static async Task LoginOrRegister(string input, User user)
    {
        try
        {
            var jsonBody = JsonSerializer.Serialize(user);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var responseBody = await HttpClient.PostAsync(Url + $"api/user/{input}/", content);
            Console.WriteLine(responseBody);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex}");
        }
    }
}