


#nullable enable

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace IdentityServer8.Validation;

/// <summary>
/// Models the result of JWT request validation.
/// </summary>
public class JwtRequestValidationResult : ValidationResult
{
    /// <summary>
    /// The key/value pairs from the JWT payload of a successfully validated
    /// request, or null if a validation error occurred.
    /// </summary>
    public IEnumerable<Claim>? Payload { get; set; }
}
