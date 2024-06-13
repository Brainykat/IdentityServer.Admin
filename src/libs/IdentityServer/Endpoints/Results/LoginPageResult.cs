


using IdentityServer8.Configuration;
using IdentityServer8.Validation;

namespace IdentityServer8.Endpoints.Results;

/// <summary>
/// Result for login page
/// </summary>
public class LoginPageResult : AuthorizeInteractionPageResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LoginPageResult"/> class.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="options"></param>
    /// <exception cref="System.ArgumentNullException">request</exception>
    public LoginPageResult(ValidatedAuthorizeRequest request, IdentityServerOptions options) 
        : base(request, options.UserInteraction.LoginUrl, options.UserInteraction.LoginReturnUrlParameter)
    {
    }
}