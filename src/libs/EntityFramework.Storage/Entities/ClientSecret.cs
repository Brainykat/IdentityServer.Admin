


#pragma warning disable 1591

namespace IdentityServer8.EntityFramework.Entities;

public class ClientSecret : Secret
{
    public int ClientId { get; set; }
    public Client Client { get; set; }
}