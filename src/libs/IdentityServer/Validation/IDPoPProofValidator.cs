


#nullable enable

using System.Threading.Tasks;

namespace IdentityServer8.Validation;

/// <summary>
/// Validator for handling DPoP proofs.
/// </summary>
public interface IDPoPProofValidator
{
    /// <summary>
    /// Validates the DPoP proof.
    /// </summary>
    Task<DPoPProofValidatonResult> ValidateAsync(DPoPProofValidatonContext context);
}
