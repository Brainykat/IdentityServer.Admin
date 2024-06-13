


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using IdentityServer8.Configuration.Configuration;

namespace IdentityServer8.Configuration;

/// <summary>
/// Extension methods for adding IdentityServer configuration endpoints.
/// </summary>
public static class ConfigurationEndpointExtensions
{
    internal static bool _licenseChecked;

    /// <summary>
    /// Maps the dynamic client registration endpoint.
    /// </summary>
    public static IEndpointConventionBuilder MapDynamicClientRegistration(this IEndpointRouteBuilder endpoints, string path = "/connect/dcr")
    {
        endpoints.CheckLicense();

        return endpoints.MapPost(path, (DynamicClientRegistrationEndpoint endpoint, HttpContext context) => endpoint.Process(context));
    }

    internal static void CheckLicense(this IEndpointRouteBuilder endpoints)
    {
        if (_licenseChecked == false)
        {
            var loggerFactory = endpoints.ServiceProvider.GetRequiredService<ILoggerFactory>();
            var options = endpoints.ServiceProvider.GetRequiredService<IOptions<IdentityServerConfigurationOptions>>().Value;
        }

        _licenseChecked = true;
    }
}
