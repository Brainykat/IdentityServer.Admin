


#nullable enable

namespace IdentityServer8.Configuration;

/// <summary>
/// Configures client initiated backchannel authentication
/// </summary>
public class CibaOptions
{
    /// <summary>
    /// Gets or sets the default lifetime of the request in seconds.
    /// </summary>
    public int DefaultLifetime { get; set; } = 300;

    /// <summary>
    /// Gets or sets the polling interval in seconds.
    /// </summary>
    public int DefaultPollingInterval { get; set; } = 5;
}
