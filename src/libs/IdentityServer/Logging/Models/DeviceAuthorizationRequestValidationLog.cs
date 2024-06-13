


using System.Collections.Generic;
using IdentityServer8.Validation;
using IdentityModel;
using IdentityServer8.Extensions;

namespace IdentityServer8.Logging;

internal class DeviceAuthorizationRequestValidationLog
{
    public string ClientId { get; set; }
    public string ClientName { get; set; }
    public string Scopes { get; set; }

    public Dictionary<string, string> Raw { get; set; }

    private static readonly string[] SensitiveValuesFilter = {
        OidcConstants.TokenRequest.ClientSecret,
        OidcConstants.TokenRequest.ClientAssertion
    };

    public DeviceAuthorizationRequestValidationLog(ValidatedDeviceAuthorizationRequest request)
    {
        Raw = request.Raw.ToScrubbedDictionary(SensitiveValuesFilter);

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