


#pragma warning disable 1591

namespace IdentityServer8.EntityFramework.Entities;

public abstract class Property
{
    public int Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}