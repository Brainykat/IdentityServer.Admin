


using System;
using System.Threading.Tasks;
using IdentityServer8.Extensions;
using Microsoft.Extensions.Logging;
using System.Collections.Specialized;
using IdentityServer8.Models;
using IdentityServer8.Stores;
using IdentityServer8.Validation;
using IdentityServer8.Configuration;
using static IdentityServer8.IdentityServerConstants;

namespace IdentityServer8.Services;

internal class OidcReturnUrlParser : IReturnUrlParser
{
    private readonly IdentityServerOptions _options;
    private readonly IAuthorizeRequestValidator _validator;
    private readonly IUserSession _userSession;
    private readonly IServerUrls _urls;
    private readonly ILogger _logger;
    private readonly IAuthorizationParametersMessageStore _authorizationParametersMessageStore;

    public OidcReturnUrlParser(
        IdentityServerOptions options,
        IAuthorizeRequestValidator validator,
        IUserSession userSession,
        IServerUrls urls,
        ILogger<OidcReturnUrlParser> logger,
        IAuthorizationParametersMessageStore authorizationParametersMessageStore = null)
    {
        _options = options;
        _validator = validator;
        _userSession = userSession;
        _urls = urls;
        _logger = logger;
        _authorizationParametersMessageStore = authorizationParametersMessageStore;
    }

    public async Task<AuthorizationRequest> ParseAsync(string returnUrl)
    {
        using var activity = Tracing.ValidationActivitySource.StartActivity("OidcReturnUrlParser.Parse");
        
        if (IsValidReturnUrl(returnUrl))
        {
            var parameters = returnUrl.ReadQueryStringAsNameValueCollection();
            if (_authorizationParametersMessageStore != null)
            {
                var messageStoreId = parameters[Constants.AuthorizationParamsStore.MessageStoreIdParameterName];
                var entry = await _authorizationParametersMessageStore.ReadAsync(messageStoreId);
                parameters = entry?.Data.FromFullDictionary() ?? new NameValueCollection();
            }

            var user = await _userSession.GetUserAsync();
            var result = await _validator.ValidateAsync(parameters, user);
            if (!result.IsError)
            {
                _logger.LogTrace("AuthorizationRequest being returned");
                return new AuthorizationRequest(result.ValidatedRequest);
            }
        }

        _logger.LogTrace("No AuthorizationRequest being returned");
        return null;
    }

    public bool IsValidReturnUrl(string returnUrl)
    {
        using var activity = Tracing.ValidationActivitySource.StartActivity("OidcReturnUrlParser.IsValidReturnUrl");
        
        if (_options.UserInteraction.AllowOriginInReturnUrl && returnUrl.IsUri())
        {
            var host = _urls.Origin;
            if (returnUrl.StartsWith(host, StringComparison.OrdinalIgnoreCase) == true)
            {
                returnUrl = returnUrl.Substring(host.Length);
            }
        }
            
        if (returnUrl.IsLocalUrl())
        {
            {
                var index = returnUrl.IndexOf('?');
                if (index >= 0)
                {
                    returnUrl = returnUrl.Substring(0, index);
                }
            }
            {
                var index = returnUrl.IndexOf('#');
                if (index >= 0)
                {
                    returnUrl = returnUrl.Substring(0, index);
                }
            }

            if (returnUrl.EndsWith(ProtocolRoutePaths.Authorize, StringComparison.Ordinal) ||
                returnUrl.EndsWith(ProtocolRoutePaths.AuthorizeCallback, StringComparison.Ordinal))
            {
                _logger.LogTrace("returnUrl is valid");
                return true;
            }
        }

        _logger.LogTrace("returnUrl is not valid");
        return false;
    }
}
