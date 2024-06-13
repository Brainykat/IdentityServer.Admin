


using System.Threading.Tasks;

namespace IdentityServer8.Validation;

/// <summary>
/// Default implementation of the CIBA validator extensibility point. This
/// validator deliberately does nothing.
/// </summary>
public class DefaultCustomBackchannelAuthenticationValidator : ICustomBackchannelAuthenticationValidator
{
    /// <inheritdoc/>
    public Task ValidateAsync(CustomBackchannelAuthenticationRequestValidationContext customValidationContext)
    {
        return Task.CompletedTask;
    }
}