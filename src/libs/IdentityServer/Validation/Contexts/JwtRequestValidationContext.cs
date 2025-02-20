


#nullable enable

using IdentityServer8.Models;

namespace IdentityServer8.Validation;

/// <summary>
/// Context for validating a JWT sent as a request parameter.
/// </summary>
public class JwtRequestValidationContext
{
    /// <summary>
    /// The Client for which the validation is being performed.
    /// </summary>
    public Client Client { get; set; } = default!;

    /// <summary>
    /// The JWT request object string.
    /// </summary>
    public string JwtTokenString { get; set; } = default!;

    /// <summary>
    /// Specifies whether the JWT typ and content-type for JWT secured authorization requests is checked according to IETF spec.
    /// This might break older OIDC conformant request objects.
    /// </summary>
    public bool? StrictJarValidation { get; set; }

    /// <summary>
    /// Indicates if the JTI claim is expected in the result.
    /// </summary>
    public bool IncludeJti { get; internal set; }
}
