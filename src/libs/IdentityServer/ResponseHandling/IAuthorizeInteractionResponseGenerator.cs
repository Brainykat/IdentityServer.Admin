


#nullable enable

using System.Threading.Tasks;
using IdentityServer8.Models;
using IdentityServer8.Validation;

namespace IdentityServer8.ResponseHandling;

/// <summary>
/// Interface for determining if user must login or consent when making requests to the authorization endpoint.
/// </summary>
public interface IAuthorizeInteractionResponseGenerator
{
    /// <summary>
    /// Processes the interaction logic.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="consent">The consent.</param>
    /// <returns></returns>
    Task<InteractionResponse> ProcessInteractionAsync(ValidatedAuthorizeRequest request, ConsentResponse? consent = null);
}
