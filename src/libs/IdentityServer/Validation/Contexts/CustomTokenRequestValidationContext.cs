


#nullable enable

namespace IdentityServer8.Validation;

/// <summary>
/// Context class for custom token request validation
/// </summary>
public class CustomTokenRequestValidationContext
{
    /// <summary>
    /// Gets or sets the result.
    /// </summary>
    /// <value>
    /// The result.
    /// </value>
    public TokenRequestValidationResult? Result { get; set; }
}
