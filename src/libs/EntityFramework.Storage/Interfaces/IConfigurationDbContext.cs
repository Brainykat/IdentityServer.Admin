


#nullable enable

using System;
using IdentityServer8.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer8.EntityFramework.Interfaces;

/// <summary>
/// Abstraction for the configuration context.
/// </summary>
/// <seealso cref="System.IDisposable" />
public interface IConfigurationDbContext : IDisposable
{
    /// <summary>
    /// Gets or sets the clients.
    /// </summary>
    /// <value>
    /// The clients.
    /// </value>
    DbSet<Client> Clients { get; set; }
        
    /// <summary>
    /// Gets or sets the clients' CORS origins.
    /// </summary>
    /// <value>
    /// The clients CORS origins.
    /// </value>
    DbSet<ClientCorsOrigin> ClientCorsOrigins { get; set; }

    /// <summary>
    /// Gets or sets the identity resources.
    /// </summary>
    /// <value>
    /// The identity resources.
    /// </value>
    DbSet<IdentityResource> IdentityResources { get; set; }

    /// <summary>
    /// Gets or sets the API resources.
    /// </summary>
    /// <value>
    /// The API resources.
    /// </value>
    DbSet<ApiResource> ApiResources { get; set; }

    /// <summary>
    /// Gets or sets the scopes.
    /// </summary>
    /// <value>
    /// The identity resources.
    /// </value>
    DbSet<ApiScope> ApiScopes { get; set; }

    /// <summary>
    /// Gets or sets the identity providers.
    /// </summary>
    /// <value>
    /// The identity providers.
    /// </value>
    DbSet<IdentityProvider> IdentityProviders { get; set; }
}
