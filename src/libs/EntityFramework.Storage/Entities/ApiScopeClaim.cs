


#pragma warning disable 1591

namespace IdentityServer8.EntityFramework.Entities;

public class ApiScopeClaim : UserClaim
{
    public int ScopeId { get; set; }
    public ApiScope Scope { get; set; }
}
