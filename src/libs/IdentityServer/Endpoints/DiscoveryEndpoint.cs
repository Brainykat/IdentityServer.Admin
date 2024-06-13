


using System.Net;
using System.Threading.Tasks;
using IdentityServer8.Configuration;
using IdentityServer8.Endpoints.Results;
using IdentityServer8.Hosting;
using IdentityServer8.ResponseHandling;
using IdentityServer8.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace IdentityServer8.Endpoints;

internal class DiscoveryEndpoint : IEndpointHandler
{
    private readonly ILogger _logger;

    private readonly IdentityServerOptions _options;
    private readonly IIssuerNameService _issuerNameService;
    private readonly IServerUrls _urls;
    private readonly IDiscoveryResponseGenerator _responseGenerator;

    public DiscoveryEndpoint(
        IdentityServerOptions options,
        IIssuerNameService issuerNameService,
        IDiscoveryResponseGenerator responseGenerator,
        IServerUrls urls,
        ILogger<DiscoveryEndpoint> logger)
    {
        _logger = logger;
        _options = options;
        _issuerNameService = issuerNameService;
        _urls = urls;
        _responseGenerator = responseGenerator;
    }

    public async Task<IEndpointResult> ProcessAsync(HttpContext context)
    {
        using var activity = Tracing.BasicActivitySource.StartActivity(IdentityServerConstants.EndpointNames.Discovery + "Endpoint");
        
        _logger.LogTrace("Processing discovery request.");

        // validate HTTP
        if (!HttpMethods.IsGet(context.Request.Method))
        {
            _logger.LogWarning("Discovery endpoint only supports GET requests");
            return new StatusCodeResult(HttpStatusCode.MethodNotAllowed);
        }

        _logger.LogDebug("Start discovery request");

        if (!_options.Endpoints.EnableDiscoveryEndpoint)
        {
            _logger.LogInformation("Discovery endpoint disabled. 404.");
            return new StatusCodeResult(HttpStatusCode.NotFound);
        }

        var baseUrl = _urls.BaseUrl;
        var issuerUri = await _issuerNameService.GetCurrentAsync();

        // generate response
        _logger.LogTrace("Calling into discovery response generator: {type}", _responseGenerator.GetType().FullName);
        var response = await _responseGenerator.CreateDiscoveryDocumentAsync(baseUrl, issuerUri);

        return new DiscoveryDocumentResult(response, _options.Discovery.ResponseCacheInterval);
    }
}
