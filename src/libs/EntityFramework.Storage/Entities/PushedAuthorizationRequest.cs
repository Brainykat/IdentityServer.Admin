


#pragma warning disable 1591

using System;

namespace IdentityServer8.EntityFramework.Entities;

public class PushedAuthorizationRequest
{
    public long Id { get; set; }
    public string ReferenceValueHash { get; set; }
    public DateTime ExpiresAtUtc { get; set; }
    public string Parameters { get; set; }
}
