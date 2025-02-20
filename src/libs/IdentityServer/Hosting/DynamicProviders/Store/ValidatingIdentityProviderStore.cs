


using IdentityServer8.Events;
using IdentityServer8.Models;
using IdentityServer8.Services;
using IdentityServer8.Stores;
using IdentityServer8.Validation;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer8.Hosting.DynamicProviders;

/// <summary>
/// Validating decorator for IIdentityProviderStore
/// </summary>
/// <typeparam name="T"></typeparam>
public class ValidatingIdentityProviderStore<T> : IIdentityProviderStore
    where T : IIdentityProviderStore
{
    private readonly IIdentityProviderStore _inner;
    private readonly IIdentityProviderConfigurationValidator _validator;
    private readonly IEventService _events;
    private readonly ILogger<ValidatingIdentityProviderStore<T>> _logger;
    private readonly string _validatorType;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidatingIdentityProviderStore{T}" /> class.
    /// </summary>
    public ValidatingIdentityProviderStore(T inner, IIdentityProviderConfigurationValidator validator, IEventService events, ILogger<ValidatingIdentityProviderStore<T>> logger)
    {
        _inner = inner;
        _validator = validator;
        _events = events;
        _logger = logger;

        _validatorType = validator.GetType().FullName;
    }

    /// <inheritdoc/>
    public Task<IEnumerable<IdentityProviderName>> GetAllSchemeNamesAsync()
    {
        return _inner.GetAllSchemeNamesAsync();
    }

    /// <inheritdoc/>
    public async Task<IdentityProvider> GetBySchemeAsync(string scheme)
    {
        var idp = await _inner.GetBySchemeAsync(scheme);

        if (idp != null)
        {
            _logger.LogTrace("Calling into identity provider configuration validator: {validatorType}", _validatorType);

            var context = new IdentityProviderConfigurationValidationContext(idp);
            await _validator.ValidateAsync(context);

            if (context.IsValid)
            {
                _logger.LogDebug("IdentityProvider validation for scheme {scheme} succeeded.", scheme);
                Telemetry.Metrics.DynamicIdentityProviderValidation(scheme);
                return idp;
            }

            _logger.LogError("Invalid IdentityProvider configuration for scheme {scheme}: {errorMessage}", scheme, context.ErrorMessage);
            Telemetry.Metrics.DynamicIdentityProviderValidationFailure(scheme, context.ErrorMessage);
            await _events.RaiseAsync(new InvalidIdentityProviderConfiguration(idp, context.ErrorMessage));

            return null;
        }

        Telemetry.Metrics.DynamicIdentityProviderValidationFailure(scheme, "Scheme not found");

        return null;
    }
}
