﻿// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using IdentityServer.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace IdentityServer.Admin.BusinessLogic.Identity.Dtos.Identity.Base
{
    public class BaseUserClaimDto<TUserId> : IBaseUserClaimDto
    {
        public int ClaimId { get; set; }

        public TUserId UserId { get; set; }

        object IBaseUserClaimDto.UserId => UserId;
    }
}