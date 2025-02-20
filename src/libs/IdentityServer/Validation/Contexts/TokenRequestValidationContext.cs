


using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;

namespace IdentityServer8.Validation;

/// <summary>
/// Class describing the token endpoint request validation context
/// </summary>
public class TokenRequestValidationContext
{
    /// <summary>
    /// The request form parameters
    /// </summary>
    public NameValueCollection RequestParameters { get; set; }

    /// <summary>
    /// The validation result of client authentication
    /// </summary>
    public ClientSecretValidationResult ClientValidationResult { get; set; }

    /// <summary>
    /// The client certificate used on the mTLS connection.
    /// </summary>
    public X509Certificate2 ClientCertificate { get; set; }

    /// <summary>
    /// The header value containing the DPoP proof token presented on the request
    /// </summary>
    public string DPoPProofToken { get; set; }
}
