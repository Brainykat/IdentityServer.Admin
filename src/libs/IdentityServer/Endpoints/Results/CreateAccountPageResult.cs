


using IdentityServer8.Configuration;
using IdentityServer8.Validation;

namespace IdentityServer8.Endpoints.Results;

/// <summary>
/// Result for create account page
/// </summary>
public class CreateAccountPageResult : AuthorizeInteractionPageResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateAccountPageResult"/> class.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="options"></param>
    /// <exception cref="System.ArgumentNullException">request</exception>
    public CreateAccountPageResult(ValidatedAuthorizeRequest request, IdentityServerOptions options) 
        : base(request, options.UserInteraction.CreateAccountUrl, options.UserInteraction.CreateAccountReturnUrlParameter)
    {
    }
}