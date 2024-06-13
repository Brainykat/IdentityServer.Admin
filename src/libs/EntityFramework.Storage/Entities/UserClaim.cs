


#pragma warning disable 1591

namespace IdentityServer8.EntityFramework.Entities;

public abstract class UserClaim
{
    public int Id { get; set; }
    public string Type { get; set; }
}