﻿// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using IdentityServer8.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using IdentityServer.Admin.EntityFramework.Interfaces;

namespace IdentityServer.Admin.EntityFramework.Shared.DbContexts
{
    public class IdentityServerPersistedGrantDbContext : PersistedGrantDbContext<IdentityServerPersistedGrantDbContext>, IAdminPersistedGrantDbContext
    {
        public IdentityServerPersistedGrantDbContext(DbContextOptions<IdentityServerPersistedGrantDbContext> options)
            : base(options)
        {
        }
    }
}