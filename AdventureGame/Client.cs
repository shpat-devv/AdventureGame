using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using AdventureGame.Models;

namespace AdventureGame;

public static class Client
{
    private static readonly HttpClient UserHttpClient = new HttpClient();
    private const string Url = "https://127.0.0.1:7270/";
    private static string _userToken = "";

    public static async Task Register(User user)
    {
        try
        {
            var jsonBody = JsonSerializer.Serialize(user);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var responseBody = await UserHttpClient.PostAsync(Url + $"api/user/register/", content);

            Console.WriteLine(responseBody);

        }
        catch
        {
            Console.WriteLine("An error occurred while processing your request. \n");
        }
    }

    public static async Task<bool> Login(User user)
    {
        try
        {
            var jsonBody = JsonSerializer.Serialize(user);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var responseBody = await UserHttpClient.PostAsync(Url + $"api/user/login/", content);

            Console.WriteLine();
            Console.WriteLine(responseBody.StatusCode);

            if (responseBody.IsSuccessStatusCode)
            {
                _userToken = await responseBody.Content.ReadAsStringAsync();
                Console.WriteLine(_userToken);
                return true;
            }
        }
        catch
        {
            Console.WriteLine("An error occurred while processing your request.\n");
            return false;
        }

        return false;
    }

    public static async Task ConfirmIdentity()
    {
        try
        {


            using var request = new HttpRequestMessage(HttpMethod.Get, Url + "api/user/login/");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _userToken);
            var responseBody = await UserHttpClient.SendAsync(request);
            ;

            if (responseBody.IsSuccessStatusCode)
            {
                Console.WriteLine("Identity confirmed.\n");
            }
        }
        catch
        {
            Console.WriteLine("An error occurred while processing your request.\n");
        }
    }

    //TODO:
    public static async Task ListCharacters()
    {
        
    }

    public static async Task FindCharacter()
    {
        
    }

}