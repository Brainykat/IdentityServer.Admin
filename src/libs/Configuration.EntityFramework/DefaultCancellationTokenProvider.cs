


using IdentityServer8.Services;
using Microsoft.AspNetCore.Http;

namespace IdentityServer8.Configuration.EntityFramework;

/// <summary>
/// Provides cancellation tokens based on the incoming http request
/// </summary>
class DefaultCancellationTokenProvider : ICancellationTokenProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="httpContextAccessor"></param>
    public DefaultCancellationTokenProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// Provides access to the cancellation token from the http context
    /// </summary>
    public CancellationToken CancellationToken => _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
}
