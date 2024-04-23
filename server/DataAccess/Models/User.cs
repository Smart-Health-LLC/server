using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace server.DataAccess.Models;

public class User
{
    public int Id { get; set; }

    [MaxLength(100)] public string? Username { get; set; }

    [MaxLength(100)] public string? Email { get; set; }

    public Role Role { get; set; }

    [MaxLength(1000)] public string? Bio { get; set; }

    [ForeignKey("UserScheduleAttemptId")] public virtual List<UserScheduleAttempt>? Attempts { get; set; }

    [JsonIgnore] public string? PasswordHash { get; set; }
}
