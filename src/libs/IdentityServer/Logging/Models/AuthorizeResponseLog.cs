


using IdentityServer8.ResponseHandling;
using IdentityServer8.Extensions;

namespace IdentityServer8.Logging.Models;

internal class AuthorizeResponseLog
{
    public string SubjectId { get; set; }
    public string ClientId { get; set; }
    public string RedirectUri { get; set; }
    public string State { get; set; }

    public string Scope { get; set; }
    public string Error { get; set; }
    public string ErrorDescription { get; set; }


    public AuthorizeResponseLog(AuthorizeResponse response)
    {
        ClientId = response.Request?.Client?.ClientId;
        SubjectId = response.Request?.Subject?.GetSubjectId();
        RedirectUri = response.RedirectUri;
        State = response.State;
        Scope = response.Scope;
        Error = response.Error;
        ErrorDescription = response.ErrorDescription;
    }

    public override string ToString()
    {
        return LogSerializer.Serialize(this);
    }
}