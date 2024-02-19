using System.ComponentModel.DataAnnotations;
using server.Models;

namespace server.DTO;

public class UpdateRequest
{
    private string? _confirmPassword;

    // treat empty string as null for password fields to 
    // make them optional in front end apps
    private string? _password;
    public string? Title { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    [EnumDataType(typeof(Role))] public string? Role { get; set; }

    [EmailAddress] public string? Email { get; set; }

    [MinLength(6)]
    public string? Password
    {
        get => _password;
        set => _password = ReplaceEmptyWithNull(value);
    }

    [Compare("Password")]
    public string? ConfirmPassword
    {
        get => _confirmPassword;
        set => _confirmPassword = ReplaceEmptyWithNull(value);
    }

    // helpers

    private string? ReplaceEmptyWithNull(string? value)
    {
        // replace empty string with null to make field optional
        return string.IsNullOrEmpty(value) ? null : value;
    }
}