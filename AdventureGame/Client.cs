using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using AdventureGame.Models;

namespace AdventureGame;

public class Client
{
    private static readonly HttpClient HttpClient = new HttpClient();
    private const string Url = "https://127.0.0.1:7270/";
    private static string UserToken = "";

    public static async Task Register(User user)
    {
        try
        {
            var jsonBody = JsonSerializer.Serialize(user);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var responseBody = await HttpClient.PostAsync(Url + $"api/user/register/", content);
            
            Console.WriteLine(responseBody);
                
        }
        catch
        {
            Console.WriteLine("An error occurred while processing your request.");
        }
    }

    public static async Task<bool> Login(User user)
    {
        try
        {
            var jsonBody = JsonSerializer.Serialize(user);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var responseBody = await HttpClient.PostAsync(Url + $"api/user/login/", content);

            Console.WriteLine();
            Console.WriteLine(responseBody.StatusCode);
            
            if (responseBody.IsSuccessStatusCode)
            {
                UserToken = await responseBody.Content.ReadAsStringAsync();
                Console.WriteLine(UserToken);
                return true;
            }
        }
        catch
        {
            Console.WriteLine("An error occurred while processing your request.");
            return false;
        }
        
        return false;
    }

    public static async Task ConfirmIdentity()
    {
        try
        {

            
            using var request = new HttpRequestMessage(HttpMethod.Get, Url + "api/user/login/");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", UserToken);
            var responseBody = await HttpClient.SendAsync(request);
            ;
            
            if (responseBody.IsSuccessStatusCode)
            {
                Console.WriteLine("Identity confirmed.");
            }
        }
        catch
        {
            Console.WriteLine("An error occurred while processing your request.");
        }
    }
}