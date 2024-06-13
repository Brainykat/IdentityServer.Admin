﻿


#pragma warning disable 1591

namespace IdentityServer8.EntityFramework.Entities;

public class ClientGrantType
{
    public int Id { get; set; }
    public string GrantType { get; set; }

    public int ClientId { get; set; }
    public Client Client { get; set; }
}