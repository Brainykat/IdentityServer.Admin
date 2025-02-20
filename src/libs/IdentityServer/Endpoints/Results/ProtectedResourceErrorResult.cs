


using System.Threading.Tasks;
using IdentityServer8.Hosting;
using IdentityServer8.Extensions;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using IdentityModel;

namespace IdentityServer8.Endpoints.Results;

/// <summary>
/// Models result of a protected resource
/// </summary>
public class ProtectedResourceErrorResult : EndpointResult<ProtectedResourceErrorResult>
{
    /// <summary>
    /// The error
    /// </summary>
    public string Error { get; }
    /// <summary>
    /// The error description
    /// </summary>
    public string ErrorDescription { get; }

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="error"></param>
    /// <param name="errorDescription"></param>
    public ProtectedResourceErrorResult(string error, string errorDescription = null)
    {
        Error = error;
        ErrorDescription = errorDescription;
    }
}

internal class ProtectedResourceErrorHttpWriter : IHttpResponseWriter<ProtectedResourceErrorResult>
{
    public Task WriteHttpResponse(ProtectedResourceErrorResult result, HttpContext context)
    {
        context.Response.StatusCode = 401;
        context.Response.SetNoCache();

        var error = result.Error;
        var errorDescription = result.ErrorDescription;

        if (Constants.ProtectedResourceErrorStatusCodes.ContainsKey(error))
        {
            context.Response.StatusCode = Constants.ProtectedResourceErrorStatusCodes[error];
        }

        if (error == OidcConstants.ProtectedResourceErrors.ExpiredToken)
        {
            error = OidcConstants.ProtectedResourceErrors.InvalidToken;
            errorDescription = "The access token expired";
        }

        var errorString = string.Format($"error=\"{error}\"");
        if (errorDescription.IsMissing())
        {
            context.Response.Headers.Append(HeaderNames.WWWAuthenticate, new StringValues(new[] { "Bearer realm=\"IdentityServer\"", errorString }).ToString());
        }
        else
        {
            var errorDescriptionString = string.Format($"error_description=\"{errorDescription}\"");
            context.Response.Headers.Append(HeaderNames.WWWAuthenticate, new StringValues(new[] { "Bearer realm=\"IdentityServer\"", errorString, errorDescriptionString }).ToString());
        }

        return Task.CompletedTask;
    }
}