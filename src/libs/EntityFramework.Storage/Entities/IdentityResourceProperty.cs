


#pragma warning disable 1591

namespace IdentityServer8.EntityFramework.Entities;

public class IdentityResourceProperty : Property
{
    public int IdentityResourceId { get; set; }
    public IdentityResource IdentityResource { get; set; }
}