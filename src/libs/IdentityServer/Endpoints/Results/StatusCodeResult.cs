


using System.Threading.Tasks;
using System.Net;
using IdentityServer8.Hosting;
using Microsoft.AspNetCore.Http;

namespace IdentityServer8.Endpoints.Results;

/// <summary>
/// Result for a raw HTTP status code
/// </summary>
/// <seealso cref="IEndpointResult" />
public class StatusCodeResult : EndpointResult<StatusCodeResult>
{
    /// <summary>
    /// Gets the status code.
    /// </summary>
    /// <value>
    /// The status code.
    /// </value>
    public int StatusCode { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="StatusCodeResult"/> class.
    /// </summary>
    /// <param name="statusCode">The status code.</param>
    public StatusCodeResult(HttpStatusCode statusCode)
    {
        StatusCode = (int)statusCode;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StatusCodeResult"/> class.
    /// </summary>
    /// <param name="statusCode">The status code.</param>
    public StatusCodeResult(int statusCode)
    {
        StatusCode = statusCode;
    }
}

class StatusCodeHttpWriter : IHttpResponseWriter<StatusCodeResult>
{
    public Task WriteHttpResponse(StatusCodeResult result, HttpContext context)
    {
        context.Response.StatusCode = result.StatusCode;

        return Task.CompletedTask;
    }
}