


#nullable enable

using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer8.Models;

namespace IdentityServer8.Services;

/// <summary>
/// Interface for the key material service
/// </summary>
public interface IKeyMaterialService
{
    /// <summary>
    /// Gets all validation keys.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<SecurityKeyInfo>> GetValidationKeysAsync();

    /// <summary>
    /// Gets the signing credentials.
    /// </summary>
    /// <param name="allowedAlgorithms">Collection of algorithms used to filter the server supported algorithms. 
    /// A value of null or empty indicates that the server default should be returned.</param>
    /// <returns></returns>
    Task<SigningCredentials> GetSigningCredentialsAsync(IEnumerable<string>? allowedAlgorithms = null);

    /// <summary>
    /// Gets all signing credentials.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<SigningCredentials>> GetAllSigningCredentialsAsync();
}
