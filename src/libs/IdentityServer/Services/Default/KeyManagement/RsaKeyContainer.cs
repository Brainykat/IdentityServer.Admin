


using System;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer8.Services.KeyManagement;

/// <summary>
/// Container class for RsaSecurityKey.
/// </summary>
public class RsaKeyContainer : KeyContainer
{
    /// <summary>
    /// Constructor for RsaKeyContainer.
    /// </summary>
    public RsaKeyContainer() : base()
    {
    }

    /// <summary>
    /// Constructor for RsaKeyContainer.
    /// </summary>
    public RsaKeyContainer(RsaSecurityKey key, string algorithm, DateTime created)
        : base(key.KeyId, algorithm, created)
    {
        if (key.Rsa != null)
        {
            Parameters = key.Rsa.ExportParameters(includePrivateParameters: true);
        }
        else
        {
            Parameters = key.Parameters;
        }
    }

    /// <summary>
    /// The RSAParameters.
    /// </summary>
    public RSAParameters Parameters { get; set; }

    /// <inheritdoc/>
    public override AsymmetricSecurityKey ToSecurityKey()
    {
        return new RsaSecurityKey(Parameters)
        {
            KeyId = Id
        };
    }
}