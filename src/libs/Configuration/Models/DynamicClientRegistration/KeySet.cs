


namespace IdentityServer8.Configuration.Models.DynamicClientRegistration;

/// <summary>
/// Represents a JSON Web Key Set.
/// </summary>
/// <remark>
/// The keys themselves are represented as objects without additional structure,
/// rather than more complex types, such as 
/// <seealso cref="IdentityModel.Jwk.JsonWebKey" />, because we don't want
/// serializing and deserializing to and from such types to introduce additional
/// properties to the keys.
/// </remark>
public record KeySet(IEnumerable<object> Keys);
