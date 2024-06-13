


namespace IdentityServer8.Configuration.Configuration;

/// <summary>
/// Top level options for IdentityServer.Configuration.
/// </summary>
public class IdentityServerConfigurationOptions
{
    /// <summary>
    /// Gets or Sets the license key. Typically, this is the same license key as
    /// used by IdentityServer.
    /// </summary>
    public string? LicenseKey { get; set; }

    /// <summary>
    /// Options for Dynamic Client Registration
    /// </summary>
    public DynamicClientRegistrationOptions DynamicClientRegistration { get; set; } = new DynamicClientRegistrationOptions();
}
