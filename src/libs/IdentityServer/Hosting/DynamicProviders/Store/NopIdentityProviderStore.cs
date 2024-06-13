


using IdentityServer8.Models;
using IdentityServer8.Stores;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer8.Hosting.DynamicProviders;

class NopIdentityProviderStore : IIdentityProviderStore
{
    public Task<IEnumerable<IdentityProviderName>> GetAllSchemeNamesAsync()
    {
        return Task.FromResult(Enumerable.Empty<IdentityProviderName>());
    }

    public Task<IdentityProvider> GetBySchemeAsync(string scheme)
    {
        return Task.FromResult<IdentityProvider>(null);
    }
}
