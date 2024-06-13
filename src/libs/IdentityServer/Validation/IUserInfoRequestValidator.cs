


using System.Threading.Tasks;

namespace IdentityServer8.Validation;

/// <summary>
/// Validator for userinfo requests
/// </summary>
public interface IUserInfoRequestValidator
{
    /// <summary>
    /// Validates a userinfo request.
    /// </summary>
    /// <param name="accessToken">The access token.</param>
    /// <returns></returns>
    Task<UserInfoRequestValidationResult> ValidateRequestAsync(string accessToken);
}