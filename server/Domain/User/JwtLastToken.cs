// ReSharper disable PropertyCanBeMadeInitOnly.Global
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace server.Domain.User;

public class JwtLastToken
{
    public long Id { get; set; }

    // The exception 'The [DeleteBehavior] attribute may only be specified on the dependent side of the relationship. 
    public long UserId { get; set; }

    public DateTime ExpiryDateTime { get; set; }

    // ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
    public string Token { get; set; }
}
