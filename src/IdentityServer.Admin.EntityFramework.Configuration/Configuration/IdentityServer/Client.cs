﻿// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System.Collections.Generic;
using IdentityServer.Admin.EntityFramework.Configuration.Configuration.Identity;

namespace IdentityServer.Admin.EntityFramework.Configuration.Configuration.IdentityServer
{
    public class Client : global::IdentityServer8.Models.Client
    {
        public List<Claim> ClientClaims { get; set; } = new List<Claim>();
    }
}
