


using IdentityServer8.Configuration;
using IdentityServer8.Hosting;

namespace IdentityServer8.Extensions;

internal static class EndpointOptionsExtensions
{
    public static bool IsEndpointEnabled(this EndpointsOptions options, Endpoint endpoint)
    {
        return endpoint?.Name switch
        {
            IdentityServerConstants.EndpointNames.Authorize => options.EnableAuthorizeEndpoint,
            IdentityServerConstants.EndpointNames.CheckSession => options.EnableCheckSessionEndpoint,
            IdentityServerConstants.EndpointNames.DeviceAuthorization => options.EnableDeviceAuthorizationEndpoint,
            IdentityServerConstants.EndpointNames.Discovery => options.EnableDiscoveryEndpoint,
            IdentityServerConstants.EndpointNames.EndSession => options.EnableEndSessionEndpoint,
            IdentityServerConstants.EndpointNames.Introspection => options.EnableIntrospectionEndpoint,
            IdentityServerConstants.EndpointNames.Revocation => options.EnableTokenRevocationEndpoint,
            IdentityServerConstants.EndpointNames.Token => options.EnableTokenEndpoint,
            IdentityServerConstants.EndpointNames.UserInfo => options.EnableUserInfoEndpoint,
            IdentityServerConstants.EndpointNames.PushedAuthorization => options.EnablePushedAuthorizationEndpoint,
            _ => true
        };
    }
}