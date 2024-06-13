


using System.Collections.Specialized;
using System.Threading.Tasks;
using IdentityServer8.Models;

namespace IdentityServer8.Validation;

/// <summary>
/// Interface for the token revocation request validator
/// </summary>
public interface ITokenRevocationRequestValidator
{
    /// <summary>
    /// Validates the request.
    /// </summary>
    /// <param name="parameters">The parameters.</param>
    /// <param name="client">The client.</param>
    /// <returns></returns>
    Task<TokenRevocationRequestValidationResult> ValidateRequestAsync(NameValueCollection parameters, Client client);
}