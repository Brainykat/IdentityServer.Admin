


using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using IdentityServer8.Services;

#pragma warning disable 1591

namespace IdentityServer8.Hosting;

public class BaseUrlMiddleware
{
    private readonly RequestDelegate _next;

    public BaseUrlMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        context.RequestServices.GetRequiredService<IServerUrls>().BasePath = context.Request.PathBase.Value;

        await _next(context);
    }
}