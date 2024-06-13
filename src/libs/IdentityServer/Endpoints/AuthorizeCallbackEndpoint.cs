


using System.Net;
using System.Threading.Tasks;
using IdentityServer8.Configuration;
using IdentityServer8.Endpoints.Results;
using IdentityServer8.Hosting;
using IdentityServer8.ResponseHandling;
using IdentityServer8.Services;
using IdentityServer8.Stores;
using IdentityServer8.Validation;
using IdentityServer8.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace IdentityServer8.Endpoints;

internal class AuthorizeCallbackEndpoint : AuthorizeEndpointBase
{
    public AuthorizeCallbackEndpoint(
        IEventService events,
        ILogger<AuthorizeCallbackEndpoint> logger,
        IdentityServerOptions options,
        IAuthorizeRequestValidator validator,
        IAuthorizeInteractionResponseGenerator interactionGenerator,
        IAuthorizeResponseGenerator authorizeResponseGenerator,
        IUserSession userSession,
        IConsentMessageStore consentResponseStore,
        IAuthorizationParametersMessageStore authorizationParametersMessageStore = null)
        : base(events, logger, options, validator, interactionGenerator, authorizeResponseGenerator, userSession, consentResponseStore, authorizationParametersMessageStore)
    {
    }

    public override async Task<IEndpointResult> ProcessAsync(HttpContext context)
    {
        using var activity = Tracing.BasicActivitySource.StartActivity(IdentityServerConstants.EndpointNames.Authorize + "CallbackEndpoint");
        
        if (!HttpMethods.IsGet(context.Request.Method))
        {
            Logger.LogWarning("Invalid HTTP method for authorize endpoint.");
            return new StatusCodeResult(HttpStatusCode.MethodNotAllowed);
        }

        Logger.LogDebug("Start authorize callback request");

        var parameters = context.Request.Query.AsNameValueCollection();
        var user = await UserSession.GetUserAsync();

        var result = await ProcessAuthorizeRequestAsync(parameters, user, true);

        Logger.LogTrace("End Authorize Request. Result type: {0}", result?.GetType().ToString() ?? "-none-");

        return result;
    }
}
