﻿// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using Skoruba.AuditLogging.Events;
using IdentityServer.Admin.BusinessLogic.Dtos.Configuration;

namespace IdentityServer.Admin.BusinessLogic.Events.ApiResource
{
    public class ApiResourceDeletedEvent : AuditEvent
    {
        public ApiResourceDto ApiResource { get; set; }

        public ApiResourceDeletedEvent(ApiResourceDto apiResource)
        {
            ApiResource = apiResource;
        }
    }
}