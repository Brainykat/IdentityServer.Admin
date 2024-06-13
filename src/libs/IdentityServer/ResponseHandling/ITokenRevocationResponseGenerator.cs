


using System.Threading.Tasks;
using IdentityServer8.Validation;

namespace IdentityServer8.ResponseHandling;

/// <summary>
/// Interface for the userinfo response generator
/// </summary>
public interface ITokenRevocationResponseGenerator
{
    /// <summary>
    /// Creates the revocation endpoint response and processes the revocation request.
    /// </summary>
    /// <param name="validationResult">The userinfo request validation result.</param>
    /// <returns></returns>
    Task<TokenRevocationResponse> ProcessAsync(TokenRevocationRequestValidationResult validationResult);
}