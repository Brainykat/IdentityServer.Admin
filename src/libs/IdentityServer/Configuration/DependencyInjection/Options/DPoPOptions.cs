


#nullable enable

using System;

namespace IdentityServer8.Configuration;

/// <summary>
/// Options for DPoP
/// </summary>
public class DPoPOptions
{
    /// <summary>
    /// Duration that DPoP proof tokens are considered valid. Defaults to 1 minute.
    /// </summary>
    public TimeSpan ProofTokenValidityDuration { get; set; } = TimeSpan.FromMinutes(1);

    /// <summary>
    /// Clock skew used in validating DPoP proof token expiration using a server-senerated nonce value. Defaults to zero.
    /// </summary>
    public TimeSpan ServerClockSkew { get; set; } = TimeSpan.FromMinutes(0);
}
