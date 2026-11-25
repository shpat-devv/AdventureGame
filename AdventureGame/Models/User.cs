using System.ComponentModel.DataAnnotations;

namespace AdventureGame.Models;

public class User(string? username, string? password)
{
    [StringLength(20, MinimumLength = 1)]
    public string? Username { get; set; } = username;

    [StringLength(50, MinimumLength = 8)]
    public string? Password { get; set; } = password;
}