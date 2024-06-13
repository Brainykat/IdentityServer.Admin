


#nullable enable

using System.Threading.Tasks;
using IdentityServer8.Models;

namespace IdentityServer8.Services;

/// <summary>
/// The backchannel authentication throttling service.
/// </summary>
public interface IBackchannelAuthenticationThrottlingService
{
    /// <summary>
    /// Decides if the requesting client and request needs to slow down.
    /// </summary>
    Task<bool> ShouldSlowDown(string requestId, BackChannelAuthenticationRequest details);
}
