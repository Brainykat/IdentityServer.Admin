


using IdentityServer8.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using IdentityServer8.Events;
using IdentityServer8.Services;
using IdentityServer8.Validation;

namespace IdentityServer8.Stores;

/// <summary>
/// Client store decorator for running runtime configuration validation checks
/// </summary>
public class ValidatingClientStore<T> : IClientStore
    where T : IClientStore
{
    private readonly IClientStore _inner;
    private readonly IClientConfigurationValidator _validator;
    private readonly IEventService _events;
    private readonly ILogger<ValidatingClientStore<T>> _logger;
    private readonly string _validatorType;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidatingClientStore{T}" /> class.
    /// </summary>
    /// <param name="inner">The inner.</param>
    /// <param name="validator">The validator.</param>
    /// <param name="events">The events.</param>
    /// <param name="logger">The logger.</param>
    public ValidatingClientStore(T inner, IClientConfigurationValidator validator, IEventService events, ILogger<ValidatingClientStore<T>> logger)
    {
        _inner = inner;
        _validator = validator;
        _events = events;
        _logger = logger;

        _validatorType = validator.GetType().FullName;
    }

    /// <summary>
    /// Finds a client by id (and runs the validation logic)
    /// </summary>
    /// <param name="clientId">The client id</param>
    /// <returns>
    /// The client or an InvalidOperationException
    /// </returns>
    public async Task<Client> FindClientByIdAsync(string clientId)
    {
        using var activity = Tracing.StoreActivitySource.StartActivity("ValidatingClientStore.FindClientById");
        
        var client = await _inner.FindClientByIdAsync(clientId);

        if (client != null)
        {
            _logger.LogTrace("Calling into client configuration validator: {validatorType}", _validatorType);

            var context = new ClientConfigurationValidationContext(client);
            await _validator.ValidateAsync(context);

            if (context.IsValid)
            {
                _logger.LogDebug("client configuration validation for client {clientId} succeeded.", client.ClientId);
                Telemetry.Metrics.ClientValidation(clientId);
                return client;
            }

            _logger.LogError("Invalid client configuration for client {clientId}: {errorMessage}", client.ClientId, context.ErrorMessage);
            Telemetry.Metrics.ClientValidationFailure(clientId, context.ErrorMessage);
            await _events.RaiseAsync(new InvalidClientConfigurationEvent(client, context.ErrorMessage));
                    
            return null;
        }

        Telemetry.Metrics.ClientValidationFailure(clientId, "Client not found");

        return null;
    }
}