﻿// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using Skoruba.AuditLogging.Events;
using IdentityServer.Admin.BusinessLogic.Dtos.Configuration;

namespace IdentityServer.Admin.BusinessLogic.Events.Client
{
    public class ClientPropertyRequestedEvent : AuditEvent
    {
        public ClientPropertiesDto ClientProperties { get; set; }

        public ClientPropertyRequestedEvent(ClientPropertiesDto clientProperties)
        {
            ClientProperties = clientProperties;
        }
    }
}