


#nullable enable

using IdentityServer8.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using static IdentityServer8.IdentityServerConstants;

namespace IdentityServer8.Configuration;

/// <summary>
/// Options for CORS
/// </summary>
public class CorsOptions
{
    /// <summary>
    /// Gets or sets the name of the cors policy.
    /// </summary>
    /// <value>
    /// The name of the cors policy.
    /// </value>
    public string CorsPolicyName { get; set; } = Constants.IdentityServerName;

    /// <summary>
    /// The value to be used in the preflight `Access-Control-Max-Age` response header.
    /// </summary>
    public TimeSpan? PreflightCacheDuration { get; set; }

    /// <summary>
    /// Gets or sets the cors paths.
    /// </summary>
    /// <value>
    /// The cors paths.
    /// </value>
    public ICollection<PathString> CorsPaths { get; set; } = ProtocolRoutePaths.CorsPaths.Select(x => new PathString(x.EnsureLeadingSlash())).ToList();
}
