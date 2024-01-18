﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using SimpleIdServer.IdServer.Domains;
using SimpleIdServer.IdServer.DTOs;
using System.Text.Json.Serialization;

namespace SimpleIdServer.IdServer.Api.Provisioning
{
    public class AddIdentityProvisioningMapperRequest
    {
        [JsonPropertyName(IdentityProvisioningMappingRuleNames.MapperType)]
        public MappingRuleTypes MappingRule { get; set; }
        [JsonPropertyName(IdentityProvisioningMappingRuleNames.From)]
        public string From { get; set; } = null!;
        [JsonPropertyName(IdentityProvisioningMappingRuleNames.TargetUserAttribute)]
        public string? TargetUserAttribute { get; set; } = null;
        [JsonPropertyName(IdentityProvisioningMappingRuleNames.TargetUserProperty)]
        public string? TargetUserProperty { get; set; } = null;
        [JsonPropertyName(IdentityProvisioningMappingRuleNames.HasMultipleAttribute)]
        public bool HasMultipleAttribute { get; set; }
        [JsonPropertyName(IdentityProvisioningMappingRuleNames.Usage)]
        public IdentityProvisioningMappingUsage Usage { get; set; } = IdentityProvisioningMappingUsage.USER;
    }
}
