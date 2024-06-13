


#nullable enable

using System.Threading.Tasks;
using IdentityServer8.Models;

namespace IdentityServer8.Services;

/// <summary>
/// The service responsible for performing back-channel logout notification.
/// </summary>
public interface IBackChannelLogoutService
{
    /// <summary>
    /// Performs http back-channel logout notification.
    /// </summary>
    /// <param name="context">The context of the back channel logout notification.</param>
    Task SendLogoutNotificationsAsync(LogoutNotificationContext context);
}
