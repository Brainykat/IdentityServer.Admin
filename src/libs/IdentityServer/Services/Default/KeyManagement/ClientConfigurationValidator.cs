


using IdentityServer8.Configuration;
using IdentityServer8.Validation;
using System.Threading.Tasks;

namespace IdentityServer8.Services.KeyManagement;

/// <summary>
/// Client configuration validator that ensures access token lifetimes are compatible with the key management options.
/// </summary>
public class ClientConfigurationValidator : DefaultClientConfigurationValidator
{
    private readonly KeyManagementOptions _keyManagerOptions;

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="isOptions"></param>
    /// <param name="keyManagerOptions"></param>
    public ClientConfigurationValidator(IdentityServerOptions isOptions, KeyManagementOptions keyManagerOptions = null)
        : base(isOptions)
    {
        _keyManagerOptions = keyManagerOptions;
    }

    /// <inheritdoc/>
    protected override async Task ValidateLifetimesAsync(ClientConfigurationValidationContext context)
    {
        await base.ValidateLifetimesAsync(context);
            
        if (context.IsValid)
        {
            if (_keyManagerOptions == null) throw new System.Exception("KeyManagerOptions not configured.");

            var keyMaxAge = (int)_keyManagerOptions.KeyRetirementAge.TotalSeconds;
            var accessTokenAge = context.Client.AccessTokenLifetime;
            if (keyMaxAge < accessTokenAge)
            {
                context.SetError("AccessTokenLifetime is greater than the IdentityServer signing key KeyRetirement value.");
            }
        }
    }
}
