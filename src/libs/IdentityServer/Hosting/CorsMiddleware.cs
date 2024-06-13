


using IdentityServer8.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

#pragma warning disable 1591

namespace IdentityServer8.Hosting;

public static class CorsMiddlewareExtensions
{
    public static void ConfigureCors(this IApplicationBuilder app)
    {
        var options = app.ApplicationServices.GetRequiredService<IdentityServerOptions>();
        app.UseCors(options.Cors.CorsPolicyName);
    }
}