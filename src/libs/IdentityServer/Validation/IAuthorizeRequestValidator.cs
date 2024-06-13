


using System.Collections.Specialized;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer8.Validation;

/// <summary>
///  Authorize endpoint request validator.
/// </summary>
public interface IAuthorizeRequestValidator
{
    /// <summary>
    ///  Validates authorize request parameters.
    /// </summary>
    /// <param name="parameters"></param>
    /// <param name="subject"></param>
    /// <param name="authorizeRequestType"></param>
    /// <returns></returns>
    Task<AuthorizeRequestValidationResult> ValidateAsync(NameValueCollection parameters, ClaimsPrincipal subject = null, AuthorizeRequestType authorizeRequestType = AuthorizeRequestType.Authorize);
}