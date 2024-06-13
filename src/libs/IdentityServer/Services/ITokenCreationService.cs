


#nullable enable

using IdentityServer8.Models;
using System.Threading.Tasks;

namespace IdentityServer8.Services;

/// <summary>
/// Logic for creating security tokens
/// </summary>
public interface ITokenCreationService
{
    /// <summary>
    /// Creates a token.
    /// </summary>
    /// <param name="token">The token description.</param>
    /// <returns>A protected and serialized security token</returns>
    Task<string> CreateTokenAsync(Token token);
}
