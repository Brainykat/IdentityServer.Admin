


using IdentityServer8.Validation;
using IdentityServer8.Extensions;

#pragma warning disable 1591

namespace IdentityServer8.ResponseHandling;

public class AuthorizeResponse
{
    public ValidatedAuthorizeRequest Request { get; set; }
    public string RedirectUri => Request?.RedirectUri;
    public string State => Request?.State;
    public string Scope => Request?.ValidatedResources?.RawScopeValues.ToSpaceSeparatedString();

    public string IdentityToken { get; set; }
    public string AccessToken { get; set; }
    public int AccessTokenLifetime { get; set; }
    public string Code { get; set; }
    public string SessionState { get; set; }
    public string Issuer { get; set; }

    public string Error { get; set; }
    public string ErrorDescription { get; set; }
    public bool IsError => Error.IsPresent();
}