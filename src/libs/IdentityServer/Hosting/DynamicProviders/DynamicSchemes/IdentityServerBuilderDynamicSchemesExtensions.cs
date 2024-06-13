


#nullable enable

using IdentityServer8.Hosting.DynamicProviders;
using IdentityServer8.Models;
using System.Collections.Generic;

namespace Microsoft.Extensions.DependencyInjection;
/// <summary>
/// Add extension methods for configuring generic dynamic providers.
/// </summary>
public static class IdentityServerBuilderDynamicSchemesExtensions
{
    /// <summary>
    /// Adds the in memory identity provider store.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <param name="providers"></param>
    /// <returns></returns>
    public static IIdentityServerBuilder AddInMemoryIdentityProviders(
        this IIdentityServerBuilder builder, IEnumerable<IdentityProvider> providers)
    {
        builder.Services.AddSingleton(providers);
        builder.AddIdentityProviderStore<InMemoryIdentityProviderStore>();

        return builder;
    }
}
