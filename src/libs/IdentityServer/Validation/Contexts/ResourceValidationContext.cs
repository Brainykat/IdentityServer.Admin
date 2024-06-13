


using IdentityServer8.Models;

namespace IdentityServer8.Validation;

/// <summary>
/// Class describing the resource validation context
/// </summary>
public class ResourceValidationContext
{
    /// <summary>
    /// Gets or sets the result.
    /// </summary>
    /// <value>
    /// The result.
    /// </value>
    public GrantValidationResult Result { get; set; } = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
}