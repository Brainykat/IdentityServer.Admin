


#nullable enable

using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace IdentityServer8.Hosting;

/// <summary>
/// Endpoint handler
/// </summary>
public interface IEndpointHandler
{
    /// <summary>
    /// Processes the request.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns></returns>
    Task<IEndpointResult?> ProcessAsync(HttpContext context);
}
