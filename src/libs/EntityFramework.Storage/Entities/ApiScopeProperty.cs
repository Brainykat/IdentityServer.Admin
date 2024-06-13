


#pragma warning disable 1591

namespace IdentityServer8.EntityFramework.Entities;

public class ApiScopeProperty : Property
{
    public int ScopeId { get; set; }
    public ApiScope Scope { get; set; }
}