


#nullable enable

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using IdentityServer8.Models;

namespace IdentityServer8.Validation;

/// <summary>
/// Parser for finding the best secret in an Enumerable List
/// </summary>
public interface ISecretsListParser
{
    /// <summary>
    /// Tries to find the best secret on the context that can be used for authentication
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>
    /// A parsed secret
    /// </returns>
    Task<ParsedSecret?> ParseAsync(HttpContext context);

    /// <summary>
    /// Gets all available authentication methods.
    /// </summary>
    /// <returns></returns>
    IEnumerable<string> GetAvailableAuthenticationMethods();
}
