


using System.Collections.Generic;
using System.Linq;
using IdentityServer8.Validation;
using IdentityServer8.Extensions;

namespace IdentityServer8.Logging.Models;

internal class BackchannelAuthenticationRequestValidationLog
{
    public string ClientId { get; set; }
    public string ClientName { get; set; }
    public string Scopes { get; set; }

    public IEnumerable<string> AuthenticationContextReferenceClasses { get; set; }
    public string Tenant { get; set; }
    public string IdP { get; set; }

    public Dictionary<string, string> Raw { get; set; }

    public BackchannelAuthenticationRequestValidationLog(ValidatedBackchannelAuthenticationRequest request, IEnumerable<string> sensitiveValuesFilter)
    {
        Raw = request.Raw.ToScrubbedDictionary(sensitiveValuesFilter.ToArray());

        if (request.Client != null)
        {
            ClientId = request.Client.ClientId;
            ClientName = request.Client.ClientName;
        }

        if (request.RequestedScopes != null)
        {
            Scopes = request.RequestedScopes.ToSpaceSeparatedString();
        }
    }

    public override string ToString()
    {
        return LogSerializer.Serialize(this);
    }
}