using System.Text.Json.Serialization;

namespace server.DataAccess.Models;

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public Role Role { get; set; }
    public string? Bio { get; set; }

    public List<UserScheduleAttempt>? Attempts { get; set; }

    [JsonIgnore] public string? PasswordHash { get; set; }
}
