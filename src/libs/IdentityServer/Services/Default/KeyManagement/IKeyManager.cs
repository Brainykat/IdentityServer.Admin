


using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer8.Services.KeyManagement;

/// <summary>
/// Interface to model loading the keys.
/// </summary>
public interface IKeyManager
{
    /// <summary>
    /// Returns the current signing keys.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<KeyContainer>> GetCurrentKeysAsync();

    /// <summary>
    /// Returns all the validation keys.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<KeyContainer>> GetAllKeysAsync();
}
