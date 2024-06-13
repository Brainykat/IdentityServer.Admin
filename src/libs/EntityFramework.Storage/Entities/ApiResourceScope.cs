


#pragma warning disable 1591

namespace IdentityServer8.EntityFramework.Entities;

public class ApiResourceScope
{
    public int Id { get; set; }
    public string Scope { get; set; }

    public int ApiResourceId { get; set; }
    public ApiResource ApiResource { get; set; }
}
