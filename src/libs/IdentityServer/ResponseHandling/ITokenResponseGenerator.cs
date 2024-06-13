


#nullable enable

using System.Threading.Tasks;
using IdentityServer8.Validation;

namespace IdentityServer8.ResponseHandling;

/// <summary>
/// Interface the token response generator
/// </summary>
public interface ITokenResponseGenerator
{
    /// <summary>
    /// Processes the response.
    /// </summary>
    /// <param name="validationResult">The validation result.</param>
    /// <returns></returns>
    Task<TokenResponse> ProcessAsync(TokenRequestValidationResult validationResult);
}
