


using IdentityServer8.Models;
using System;
using System.Collections.Concurrent;

namespace IdentityServer8.Hosting.DynamicProviders;
// this is designed as a per-request cache is to ensure that a scheme loaded from the cache is still available later in the
// request and made available anywhere else during this request (in case the static cache times out across 
// 2 calls within the same request)
// also, we need a non-async version that can be used from within the non-async Configure API in IConfigureNamedOptions<>

/// <summary>
/// Cache for DynamicAuthenticationScheme.
/// </summary>
public class DynamicAuthenticationSchemeCache
{
    private readonly ConcurrentDictionary<string, DynamicAuthenticationScheme> _cache = new();

    /// <summary>
    /// Adds the scheme.
    /// </summary>
    public void Add(string name, DynamicAuthenticationScheme item)
    {
        name = name ?? String.Empty;
        _cache.TryAdd(name, item);
    }

    /// <summary>
    /// Gets the scheme.
    /// </summary>
    public DynamicAuthenticationScheme Get(string name)
    {
        name = name ?? String.Empty;
        _cache.TryGetValue(name, out var item);
        return item;
    }

    /// <summary>
    /// Returns the downcast IdentityProvider.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <returns></returns>
    public T GetIdentityProvider<T>(string name)
        where T : IdentityProvider
    {
        return Get(name)?.IdentityProvider as T;
    }
}
