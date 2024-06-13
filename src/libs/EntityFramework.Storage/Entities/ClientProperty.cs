


#pragma warning disable 1591

namespace IdentityServer8.EntityFramework.Entities;

public class ClientProperty : Property
{
    public int ClientId { get; set; }
    public Client Client { get; set; }
}