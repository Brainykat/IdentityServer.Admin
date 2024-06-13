


#nullable enable

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdentityServer8.EntityFramework.Entities;

namespace IdentityServer8.EntityFramework;

/// <summary>
/// Interface to model notifications from the TokenCleanup feature.
/// </summary>
public interface IOperationalStoreNotification
{
    /// <summary>
    /// Notification for persisted grants being removed.
    /// </summary>
    /// <param name="persistedGrants"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task PersistedGrantsRemovedAsync(IEnumerable<PersistedGrant> persistedGrants, CancellationToken cancellationToken = default);

    /// <summary>
    /// Notification for device codes being removed.
    /// </summary>
    /// <param name="deviceCodes"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeviceCodesRemovedAsync(IEnumerable<DeviceFlowCodes> deviceCodes, CancellationToken cancellationToken = default);
}
