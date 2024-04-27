using System.ComponentModel.DataAnnotations.Schema;

namespace server.DataAccess.Models;

public class JwtLastToken
{
    public long Id { get; set; }

    [ForeignKey("UserId")] public long UserId { get; set; }

    public DateTime ExpiryDateTime { get; set; }
    public string Token { get; set; }
}
