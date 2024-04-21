using System.ComponentModel.DataAnnotations;
using server.Models;

namespace server.DTO;

public class CreateUserRequest
{
    [Required] public string? Title { get; set; }

    [Required] public string? Username { get; set; }
    [Required] public string? Bio { get; set; }

    [Required]
    [EnumDataType(typeof(Role))]
    public string? Role { get; set; }

    [Required] [EmailAddress] public string? Email { get; set; }

    [Required] [MinLength(6)] public string? Password { get; set; }

    [Required] [Compare("Password")] public string? ConfirmPassword { get; set; }
}
