


using System.Threading.Tasks;

namespace IdentityServer8.Validation;

/// <summary>
/// Interface for the token request validator
/// </summary>
public interface ITokenRequestValidator
{
    /// <summary>
    /// Validates the request.
    /// </summary>
    Task<TokenRequestValidationResult> ValidateRequestAsync(TokenRequestValidationContext context);
}