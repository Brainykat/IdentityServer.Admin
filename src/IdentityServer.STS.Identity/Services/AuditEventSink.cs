// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System.Threading.Tasks;
using IdentityServer8.Events;
using IdentityServer8.Services;
using Microsoft.Extensions.Logging;

namespace IdentityServer.STS.Identity.Services
{
    public class AuditEventSink : DefaultEventSink
    {
        public AuditEventSink(ILogger<DefaultEventService> logger) : base(logger)
        {
        }

        public override Task PersistAsync(Event evt)
        {
            return base.PersistAsync(evt);
        }
    }
}