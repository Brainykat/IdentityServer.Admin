


#pragma warning disable 1591

using System;

namespace IdentityServer8.EntityFramework.Entities;

public class PersistedGrant
{
    public long Id { get; set; }
    public string Key { get; set; }
    public string Type { get; set; }
    public string SubjectId { get; set; }
    public string SessionId { get; set; }
    public string ClientId { get; set; }
    public string Description { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime? Expiration { get; set; }
    public DateTime? ConsumedTime { get; set; }
    public string Data { get; set; }
}