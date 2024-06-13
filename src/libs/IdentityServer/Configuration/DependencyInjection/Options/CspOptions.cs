


#nullable enable

using IdentityServer8.Models;

namespace IdentityServer8.Configuration;

/// <summary>
/// Options for Content Security Policy
/// </summary>
public class CspOptions
{
    /// <summary>
    /// Gets or sets the minimum CSP level.
    /// </summary>
    public CspLevel Level { get; set; } = CspLevel.Two;

    /// <summary>
    /// Gets or sets a value indicating whether the deprecated X-Content-Security-Policy header should be added.
    /// </summary>
    public bool AddDeprecatedHeader { get; set; } = true;
}
