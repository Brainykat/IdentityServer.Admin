


using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer8.Configuration;


/// <summary>
/// Extension methods for adding the entity framework based client configuration
/// store implementation to DI.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the in memory client configuration store to DI. 
    /// </summary>
    /// <remark>
    /// This is for testing and demos only.
    /// </remark>
    public static IServiceCollection AddInMemoryClientConfigurationStore(this IdentityServerConfigurationBuilder builder)
    {
        return builder.Services.AddTransient<IClientConfigurationStore, InMemoryClientConfigurationStore>();
    }
}
