


using System;

namespace IdentityServer8;

/// <summary>
/// Abstraction for the date/time.
/// </summary>
public interface IClock
{
    /// <summary>
    /// The current UTC date/time.
    /// </summary>
    DateTimeOffset UtcNow { get; }
}
