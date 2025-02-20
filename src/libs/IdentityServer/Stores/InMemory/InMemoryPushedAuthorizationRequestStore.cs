


#nullable enable

using IdentityServer8.Models;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace IdentityServer8.Stores;

/// <summary>
/// In-memory implementation of the pushed authorization request store
/// </summary>
public class InMemoryPushedAuthorizationRequestStore : IPushedAuthorizationRequestStore
{
    private readonly ConcurrentDictionary<string, PushedAuthorizationRequest> _repository = new ConcurrentDictionary<string, PushedAuthorizationRequest>();

    /// <inheritdoc/>
    public Task StoreAsync(PushedAuthorizationRequest pushedAuthorizationRequest)
    {
        using var activity = Tracing.StoreActivitySource.StartActivity("InMemoryPushedAuthorizationRequestStore.Store");
        
        _repository[pushedAuthorizationRequest.ReferenceValueHash] = pushedAuthorizationRequest;

        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public Task<PushedAuthorizationRequest?> GetByHashAsync(string referenceValueHash)
    {
        using var activity = Tracing.StoreActivitySource.StartActivity("InMemoryPushedAuthorizationRequestStore.Get");
        _repository.TryGetValue(referenceValueHash, out var request);

        return Task.FromResult(request);
    }

    /// <inheritdoc/>
    public Task ConsumeByHashAsync(string referenceValueHash)
    {
        using var activity = Tracing.StoreActivitySource.StartActivity("InMemoryPushedAuthorizationRequestStore.Remove");
        _repository.TryRemove(referenceValueHash, out _);
        return Task.CompletedTask;
    }
}