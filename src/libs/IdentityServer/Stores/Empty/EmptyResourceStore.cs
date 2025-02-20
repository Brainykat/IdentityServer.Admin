


using IdentityServer8.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer8.Stores.Empty;

internal class EmptyResourceStore : IResourceStore
{
    public Task<IEnumerable<ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
    {
        return Task.FromResult(Enumerable.Empty<ApiResource>());
    }

    public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
    {
        return Task.FromResult(Enumerable.Empty<ApiResource>());
    }

    public Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
    {
        return Task.FromResult(Enumerable.Empty<ApiScope>());
    }

    public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
    {
        return Task.FromResult(Enumerable.Empty<IdentityResource>());
    }

    public Task<Resources> GetAllResourcesAsync()
    {
        return Task.FromResult(new Resources() { OfflineAccess = true });
    }
}

