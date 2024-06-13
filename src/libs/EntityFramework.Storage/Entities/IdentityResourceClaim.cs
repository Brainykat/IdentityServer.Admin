


#pragma warning disable 1591

namespace IdentityServer8.EntityFramework.Entities;

public class IdentityResourceClaim : UserClaim
{
    public int IdentityResourceId { get; set; }
    public IdentityResource IdentityResource { get; set; }
}