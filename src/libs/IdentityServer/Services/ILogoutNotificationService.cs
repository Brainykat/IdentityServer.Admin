


#nullable enable

using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer8.Models;

namespace IdentityServer8.Services;

/// <summary>
/// Provides features for OIDC signout notifications.
/// </summary>
public interface ILogoutNotificationService
{
    /// <summary>
    /// Builds the URLs needed for front-channel logout notification.
    /// </summary>
    /// <param name="context">The context for the logout notification.</param>
    Task<IEnumerable<string>> GetFrontChannelLogoutNotificationsUrlsAsync(LogoutNotificationContext context);

    /// <summary>
    /// Builds the http back-channel logout request data for the collection of clients.
    /// </summary>
    /// <param name="context">The context for the logout notification.</param>
    Task<IEnumerable<BackChannelLogoutRequest>> GetBackChannelLogoutNotificationsAsync(LogoutNotificationContext context);
}

/// <summary>
/// Information necessary to make a back-channel logout request to a client.
/// </summary>
public class BackChannelLogoutRequest
{
    /// <summary>
    /// Gets or sets the client identifier.
    /// </summary>
    public string ClientId { get; set; } = default!;

    /// <summary>
    /// Gets the subject identifier.
    /// </summary>
    public string? SubjectId { get; set; }

    /// <summary>
    /// Gets or sets the session identifier.
    /// </summary>
    public string? SessionId { get; set; }

    /// <summary>
    /// Gets or sets the back channel logout URI.
    /// </summary>
    public string LogoutUri { get; set; } = default!;

    /// <summary>
    /// Gets a value indicating whether the session identifier is required.
    /// </summary>
    public bool SessionIdRequired { get; set; }

    /// <summary>
    /// The issuer for the back-channel logout
    /// </summary>
    public string? Issuer { get; set; }

    /// <summary>
    /// Indicates why the user's session ended.
    /// </summary>
    public LogoutNotificationReason? LogoutReason { get; set; }
}
