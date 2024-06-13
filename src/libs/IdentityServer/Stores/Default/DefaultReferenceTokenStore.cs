


using System.Threading.Tasks;
using IdentityServer8.Services;
using IdentityServer8.Models;
using IdentityServer8.Stores.Serialization;
using Microsoft.Extensions.Logging;

namespace IdentityServer8.Stores;

/// <summary>
/// Default reference token store.
/// </summary>
public class DefaultReferenceTokenStore : DefaultGrantStore<Token>, IReferenceTokenStore
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DefaultReferenceTokenStore"/> class.
    /// </summary>
    /// <param name="store">The store.</param>
    /// <param name="serializer">The serializer.</param>
    /// <param name="handleGenerationService">The handle generation service.</param>
    /// <param name="logger">The logger.</param>
    public DefaultReferenceTokenStore(
        IPersistedGrantStore store, 
        IPersistentGrantSerializer serializer,
        IHandleGenerationService handleGenerationService,
        ILogger<DefaultReferenceTokenStore> logger) 
        : base(IdentityServerConstants.PersistedGrantTypes.ReferenceToken, store, serializer, handleGenerationService, logger)
    {
    }

    /// <inheritdoc/>
    public Task<string> StoreReferenceTokenAsync(Token token)
    {
        using var activity = Tracing.StoreActivitySource.StartActivity("DefaultReferenceTokenStore.StoreReferenceToken");
        
        return CreateItemAsync(token, token.ClientId, token.SubjectId, token.SessionId, token.Description, token.CreationTime, token.Lifetime);
    }

    /// <inheritdoc/>
    public Task<Token> GetReferenceTokenAsync(string handle)
    {
        using var activity = Tracing.StoreActivitySource.StartActivity("DefaultReferenceTokenStore.GetReferenceToken");
        
        return GetItemAsync(handle);
    }

    /// <inheritdoc/>
    public Task RemoveReferenceTokenAsync(string handle)
    {
        using var activity = Tracing.StoreActivitySource.StartActivity("DefaultReferenceTokenStore.RemoveReferenceToken");
        
        return RemoveItemAsync(handle);
    }

    /// <inheritdoc/>
    public Task RemoveReferenceTokensAsync(string subjectId, string clientId, string sessionId = null)
    {
        using var activity = Tracing.StoreActivitySource.StartActivity("DefaultReferenceTokenStore.RemoveReferenceTokens");
        
        return RemoveAllAsync(subjectId, clientId, sessionId);
    }
}