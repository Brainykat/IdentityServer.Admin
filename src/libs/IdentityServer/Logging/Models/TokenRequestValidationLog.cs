


using System.Collections.Generic;
using System.Linq;
using IdentityServer8.Validation;
using IdentityServer8.Extensions;
using System;
using IdentityModel;

namespace IdentityServer8.Logging.Models;

internal class TokenRequestValidationLog
{
    public string ClientId { get; set; }
    public string ClientName { get; set; }
    public string GrantType { get; set; }
    public string Scopes { get; set; }

    public string AuthorizationCode { get; set; }
    public string RefreshToken { get; set; }

    public string UserName { get; set; }
    public IEnumerable<string> AuthenticationContextReferenceClasses { get; set; }
    public string Tenant { get; set; }
    public string IdP { get; set; }

    public Dictionary<string, string> Raw { get; set; }

    public TokenRequestValidationLog(ValidatedTokenRequest request, IEnumerable<string> sensitiveValuesFilter)
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

        GrantType = request.GrantType;
        AuthorizationCode = request.AuthorizationCodeHandle.Obfuscate();
        RefreshToken = request.RefreshTokenHandle.Obfuscate();
        
        if (!sensitiveValuesFilter.Contains(OidcConstants.TokenRequest.UserName, StringComparer.OrdinalIgnoreCase))
        {
            UserName = request.UserName;
        }
        else if (request.UserName.IsPresent())
        {
            UserName = "***REDACTED***";
        }
    }

    public override string ToString()
    {
        return LogSerializer.Serialize(this);
    }
}