﻿// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using Skoruba.AuditLogging.Events;
using IdentityServer.Admin.BusinessLogic.Dtos.Grant;
using IdentityServer.Admin.BusinessLogic.Dtos.Key;

namespace IdentityServer.Admin.BusinessLogic.Events.Key
{
    public class KeyDeletedEvent : AuditEvent
    {
        public KeyDto Key { get; set; }

        public KeyDeletedEvent(KeyDto key)
        {
            Key = key;
        }
    }
}