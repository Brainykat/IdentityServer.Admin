


using System.Threading.Tasks;

namespace IdentityServer8.Validation;

/// <summary>
/// Interface for the introspection request validator
/// </summary>
public interface IIntrospectionRequestValidator
{
    /// <summary>
    /// Validates the request.
    /// </summary>
    Task<IntrospectionRequestValidationResult> ValidateAsync(IntrospectionRequestValidationContext context);
}

