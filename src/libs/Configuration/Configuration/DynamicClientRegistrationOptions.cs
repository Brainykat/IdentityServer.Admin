


namespace IdentityServer8.Configuration.Configuration;

/// <summary>
/// Options for dynamic client registration.
/// </summary>
public class DynamicClientRegistrationOptions
{
    /// <summary>
    /// Gets or sets the lifetime of secrets generated for clients. If unset,
    /// generated secrets will have no expiration. Defaults to null (secrets
    /// never expire).
    /// </summary>
    public TimeSpan? SecretLifetime { get; set; }
}
