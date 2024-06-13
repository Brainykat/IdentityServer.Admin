


#nullable enable

using System.Threading.Tasks;
using IdentityServer8.Models;

namespace IdentityServer8.Services;

/// <summary>
/// The device flow throttling service.
/// </summary>
public interface IDeviceFlowThrottlingService
{
    /// <summary>
    /// Decides if the requesting client and device code needs to slow down.
    /// </summary>
    /// <param name="deviceCode">The device code.</param>
    /// <param name="details">The device code details.</param>
    /// <returns></returns>
    Task<bool> ShouldSlowDown(string deviceCode, DeviceCode details);
}
