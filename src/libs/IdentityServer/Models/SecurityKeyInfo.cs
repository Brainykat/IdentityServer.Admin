


#nullable enable

using Microsoft.IdentityModel.Tokens;

namespace IdentityServer8.Models;

/// <summary>
/// Information about a security key
/// </summary>
public class SecurityKeyInfo
{
    /// <summary>
    /// The key
    /// </summary>
    public SecurityKey Key { get; set; } = default!;

    /// <summary>
    /// The signing algorithm
    /// </summary>
    public string SigningAlgorithm { get; set; } = default!;
}
