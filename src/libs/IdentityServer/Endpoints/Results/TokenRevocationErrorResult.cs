


using IdentityServer8.Extensions;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;
using IdentityServer8.Hosting;
using System;

namespace IdentityServer8.Endpoints.Results;

/// <summary>
/// Result for revocation error
/// </summary>
/// <seealso cref="IEndpointResult" />
public class TokenRevocationErrorResult : EndpointResult<TokenRevocationErrorResult>
{
    /// <summary>
    /// Gets or sets the error.
    /// </summary>
    /// <value>
    /// The error.
    /// </value>
    public string Error { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TokenRevocationErrorResult"/> class.
    /// </summary>
    /// <param name="error">The error.</param>
    public TokenRevocationErrorResult(string error)
    {
        Error = error ?? throw new ArgumentNullException(nameof(error));
    }
}

class TokenRevocationErrorHttpWriter : IHttpResponseWriter<TokenRevocationErrorResult>
{
    public Task WriteHttpResponse(TokenRevocationErrorResult result, HttpContext context)
    {
        context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
        return context.Response.WriteJsonAsync(new { error = result.Error });
    }
}