


namespace IdentityServer8.Models;

/// <summary>
/// Models the type of proof of possession
/// </summary>
public enum ProofType
{
    /// <summary>
    /// None
    /// </summary>
    None,
    /// <summary>
    /// Client certificate
    /// </summary>
    ClientCertificate,
    /// <summary>
    /// DPoP
    /// </summary>
    DPoP
}
