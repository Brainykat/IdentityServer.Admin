


#pragma warning disable 1591

namespace IdentityServer8.EntityFramework.Entities;

public class ClientCorsOrigin
{
    public int Id { get; set; }
    public string Origin { get; set; }

    public int ClientId { get; set; }
    public Client Client { get; set; }
}