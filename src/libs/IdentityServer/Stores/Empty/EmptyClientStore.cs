


using IdentityServer8.Models;
using System.Threading.Tasks;

namespace IdentityServer8.Stores.Empty;

internal class EmptyClientStore : IClientStore
{
    public Task<Client> FindClientByIdAsync(string clientId)
    {
        return Task.FromResult<Client>(null);
    }
}

