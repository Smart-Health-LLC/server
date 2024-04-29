using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using server.Domain.UserSchedule;

// ReSharper disable PropertyCanBeMadeInitOnly.Global
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace server.Domain.User;

public class User
{
    [NotMapped] public const int UsernameMinLength = 2;

    [NotMapped] public const int UsernameMaxLength = 32;

    public long Id { get; set; }


    [MinLength(UsernameMinLength)]
    [MaxLength(UsernameMaxLength)]
    public string Username { get; set; }

    public virtual JwtLastToken JwtLastToken { get; set; }

    [MaxLength(100)] public string? Email { get; set; }

    public Role Role { get; set; } = Role.User;

    [MaxLength(1000)] public string? Bio { get; set; }

    public DateOnly SignUpDate { get; set; }

    public virtual List<UserScheduleAttempt> Attempts { get; set; }

    // ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
    [JsonIgnore] public string PasswordHash { get; set; }
}
