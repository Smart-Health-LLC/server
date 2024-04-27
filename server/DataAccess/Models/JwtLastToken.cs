using System.ComponentModel.DataAnnotations.Schema;

namespace server.DataAccess.Models;

public class JwtLastToken
{
    public int Id { get; set; }

    [ForeignKey("UserId")] public int UserId { get; set; }

    public DateTime ExpiryDateTime { get; set; }
    public string Token { get; set; }
}
